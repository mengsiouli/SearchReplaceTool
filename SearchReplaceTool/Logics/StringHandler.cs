namespace SearchReplaceTool.Logic
{
	public class StringHandler
	{
		public int SearchText( string szDocInput, string szSearch, int nStartIndex )
		{
			if( string.IsNullOrEmpty( szSearch ) || nStartIndex < 0 || nStartIndex > szDocInput.Length ) {
				return -1;
			}

			// find the position of the search string
			int nResultPos = szDocInput.IndexOf( szSearch, nStartIndex );
			return nResultPos;
		}

		public string ReplaceText( string szDocInput, string szSearch, string szReplace, int nStartIndex )
		{
			if( string.IsNullOrEmpty( szDocInput ) || nStartIndex < 0 || nStartIndex > szDocInput.Length ) {
				return szDocInput;
			}

			// replace the search string with the replace string at the specified index
			string szBeforeDocInput = szDocInput.Substring( 0, nStartIndex );
			string szAfterDocInput = szDocInput.Substring( nStartIndex + szSearch.Length );
			return szBeforeDocInput + szReplace + szAfterDocInput;
		}

		public bool CheckDocInputAndSearchText( string szDocInput, string szSearchInput )
		{
			// if docinput or search text is empty, show error message and return false
			if( string.IsNullOrWhiteSpace( szDocInput ) || string.IsNullOrEmpty( szSearchInput ) ) {
				return false;
			}
			return true;
		}
	}
}