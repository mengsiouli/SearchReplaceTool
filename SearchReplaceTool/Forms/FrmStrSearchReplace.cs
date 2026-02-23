using SearchReplaceTool.Logic;
using System;
using System.Windows.Forms;

namespace SearchReplaceTool
{
	public partial class FrmStrSearchReplace : Form
	{
		readonly StringHandler m_stringHandler = new StringHandler();

		public FrmStrSearchReplace()
		{
			InitializeComponent();
		}

		TextSearchOutcome SearchNextMatchText( string szDocInput, string szSearch, int nStartIndex )
		{
			// search next match text position
			int nFindPos = m_stringHandler.SearchText( szDocInput, szSearch, nStartIndex );

			if( nFindPos == -1 ) {
				return new TextSearchOutcome
				{
					SearchState = TextSearchState.NotFound,
					Position = 0
				};
			}

			return new TextSearchOutcome
			{
				SearchState = TextSearchState.Success,
				Position = nFindPos
			};
		}

		TextReplaceOutcome ExecuteReplace( string szDocInput, string szSearch, string szReplace )
		{
			int nStartIndex;
			int nSelectionLength = m_txbDocumentInput.SelectionLength;
			string szCurrentSelected = m_txbDocumentInput.SelectedText;

			// use currently start position as the current replace position
			if( nSelectionLength > 0 && szCurrentSelected.Trim().Equals( szSearch, StringComparison.OrdinalIgnoreCase ) ) {
				nStartIndex = m_txbDocumentInput.SelectionStart;
			}
			else {
				int nCurIndex = DetermineCurrentIndex();

				// if no text is selected, determine the current index and search for the next occurrence
				searchOutcome = SearchNextMatchText( szDocInput, szSearch, nCurIndex );
				if( searchOutcome.SearchState == TextSearchState.Success ) {
					SelectAndFocusSearched( searchOutcome.Position, szSearch.Length );
				}

				// if no text is searched, do nothing and record the replace outcome
				else if( searchOutcome.SearchState == TextSearchState.NotFound ) {
					replaceOutcome.ReplaceState = TextReplaceState.NotFound;
					return replaceOutcome;

				}

				// set nStartIndex after searched
				nStartIndex = searchOutcome.Position;
			}

			m_txbDocumentInput.HideSelection = false;

			// ask user whether to replace the searched text
			DialogResult replaceDialogResult = MessageBox.Show( "Replace the currently selected text?", "Confirmation", MessageBoxButtons.YesNo );

			// if Yes, replace the searched text with the replace text
			if( replaceDialogResult == DialogResult.Yes ) {
				string szReplacedContent = m_stringHandler.ReplaceText( szDocInput, szSearch, szReplace, nStartIndex );

				// record the outcome of the replacement
				replaceOutcome.ReplaceState = TextReplaceState.Replaced;
				replaceOutcome.UpdatedText = szReplacedContent;
				replaceOutcome.NextSearchIndex = nStartIndex + szReplace.Length;
			}
			else {
				// skip the current match as user declined replacement
				// record the replace outcome
				replaceOutcome.ReplaceState = TextReplaceState.Skipped;
				replaceOutcome.NextSearchIndex = nStartIndex + szSearch.Length;
			}
			return replaceOutcome;
		}

		int DetermineCurrentIndex()
		{
			// if the document input was changed and the cursor is at the end of the text,
			// start the search from the beginning
			if( m_isChangeInput && m_txbDocumentInput.SelectionStart == m_txbDocumentInput.TextLength ) {

				m_txbDocumentInput.SelectionStart = 0;
				m_txbDocumentInput.SelectionLength = 0;
			}

			int nCursorIndex = m_txbDocumentInput.SelectionStart + m_txbDocumentInput.SelectionLength;

			// always reset once
			m_isChangeInput = false;
			return nCursorIndex;
		}

		void SearchNextAfterReplace( string szDocInput, string szSearch, int nStartIndex )
		{
			// automatically search after replacement or skip
			searchOutcome = SearchNextMatchText( szDocInput, szSearch, nStartIndex );

			if( searchOutcome.SearchState == TextSearchState.Success ) {
				SelectAndFocusSearched( searchOutcome.Position, szSearch.Length );
			}

			// display an error message when the search yields no results
			else if( searchOutcome.SearchState == TextSearchState.NotFound ) {
				ShowSearchOrReplaceErrorAndResetIndex( "No matching text to replace!" );
			}
		}

		void SelectAndFocusSearched( int nStartIndex, int nSearchLength )
		{
			m_txbDocumentInput.Select( nStartIndex, nSearchLength );
			m_txbDocumentInput.Focus();
		}

		void ShowSearchOrReplaceErrorAndResetIndex( string szMessage )
		{
			MessageBox.Show( szMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error );
			m_txbDocumentInput.Select( 0, 0 );
		}

		void m_txbDocumentInput_TextChanged( object sender, EventArgs e )
		{
			m_isChangeInput = true;
		}

		void m_btnSearch_Click( object sender, EventArgs e )
		{
			string szDocInput = m_txbDocumentInput.Text;
			string szSearch = m_txbSearch.Text;

			// validate input
			if( !m_stringHandler.CheckDocInputAndSearchText( m_txbDocumentInput.Text, m_txbSearch.Text ) ) {
				MessageBox.Show( "Please enter both document content and search text.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}

			// determine the current index and search for the next occurrence
			int nCurIndex = DetermineCurrentIndex();

			searchOutcome = SearchNextMatchText( szDocInput, szSearch, nCurIndex );

			if( searchOutcome.SearchState == TextSearchState.Success ) {
				SelectAndFocusSearched( searchOutcome.Position, szSearch.Length );
			}
			else if( searchOutcome.SearchState == TextSearchState.NotFound ) {
				ShowSearchOrReplaceErrorAndResetIndex( "No matching text!" );
			}

		}

		void m_btnReplace_Click( object sender, EventArgs e )
		{
			string szDocInput = m_txbDocumentInput.Text;
			string szSearch = m_txbSearch.Text;
			string szReplace = m_txbReplace.Text;

			// valid input
			if( !m_stringHandler.CheckDocInputAndSearchText( szDocInput, szSearch ) ) {
				MessageBox.Show( "Please enter both document content and search text.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}

			replaceOutcome = ExecuteReplace( szDocInput, szSearch, szReplace );

			switch( replaceOutcome.ReplaceState ) {
				case TextReplaceState.Replaced:
					szDocInput = replaceOutcome.UpdatedText;
					m_txbDocumentInput.Text = szDocInput;
					break;

				// only move selection start
				case TextReplaceState.Skipped:
					break;

				case TextReplaceState.NotFound:
					ShowSearchOrReplaceErrorAndResetIndex( "No matching text to replace!" );
					return;
			}

			// automatically search after replacement or skip
			SearchNextAfterReplace( szDocInput, szSearch, replaceOutcome.NextSearchIndex );
		}

		TextSearchOutcome searchOutcome = new TextSearchOutcome();
		TextReplaceOutcome replaceOutcome = new TextReplaceOutcome();
		bool m_isChangeInput;
	}
}
