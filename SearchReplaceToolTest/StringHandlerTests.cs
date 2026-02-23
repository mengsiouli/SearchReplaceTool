using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchReplaceTool.Logic;

namespace SearchReplaceToolTest
{
	[TestClass]
	public class StringHandlerTest
	{
		readonly StringHandler m_handler = new StringHandler();

		#region SearchText_UT

		[DataRow( "Stopstop", "op", 2, 2 )]
		[DataRow( "Stopstop", "op", 3, 6 )]
		[DataRow( "Stopstop", "St", 0, 0 )]
		[DataRow( "Stopstop", "op", 6, 6 )]

		[TestMethod]
		public void SearchText_WhenSearchingFromValidIndexAndSearched_ShouldReturnFirstOccurrenceIndex( string szDocInput, string szSearch, int nStartIndex, int nSearchPosExpected )
		{
			// act
			int nSearchedPos = m_handler.SearchText( szDocInput, szSearch, nStartIndex );

			// assert
			Assert.AreEqual( nSearchPosExpected, nSearchedPos );
		}

		[DataRow( "", "Stop", 0, -1 )]
		[DataRow( "Stopstop", "", 0, -1 )]
		[DataRow( "Stopstop", "Stop", 10, -1 )]
		[DataRow( "Stopstop", "text", 0, -1 )]
		[DataRow( "Sto", "Stop", 0, -1 )]
		[DataRow( "Stopstop", "St", -1, -1 )]
		[DataRow( "Stopstop", "op", 7, -1 )]

		[TestMethod]
		public void SearchText_WhenSearchingFromInvalidStartIndexOrNotSearched_ShouldReturnMinusOne( string szDocInput, string szSearch, int nStartIndex, int nSearchPosExpected )
		{
			// act
			int nSearchedPos = m_handler.SearchText( szDocInput, szSearch, nStartIndex );

			// assert
			Assert.AreEqual( nSearchPosExpected, nSearchedPos );
		}

		#endregion

		#region  ReplaceText_UT

		[DataRow( "Stopstop", "Stop", "is", 0, "isstop" )]
		[DataRow( "Stopstop", "", "is", 0, "isStopstop" )]
		[DataRow( "Stopstop", "p", "is", 7, "Stopstois" )]
		[DataRow( "Stopstop", "", "is", 4, "Stopisstop" )]

		[TestMethod]
		public void ReplaceText_WhenDocInputIsNotEmptyAndStartIndexInRange_ShouldReturnTextWithReplacement( string szDocInput, string szSearch, string szReplace, int nStartIndex, string szReplaceTextExpected )
		{
			// act
			string szReplacedText = m_handler.ReplaceText( szDocInput, szSearch, szReplace, nStartIndex );

			// assert
			Assert.AreEqual( szReplaceTextExpected, szReplacedText );
		}

		[DataRow( "", "st", "is", 1, "" )]
		[DataRow( "Stopstop", "st", " is ", 9, "Stopstop" )]

		[TestMethod]
		public void ReplaceText_WhenDocInputIsEmptyOrStartIndexOutOfRange_ShouldReturnOriginalText( string szDocInput, string szSearch, string szReplace, int nStartIndex, string szReplaceTextExpected )
		{
			// act
			string szReplacedText = m_handler.ReplaceText( szDocInput, szSearch, szReplace, nStartIndex );

			// assert
			Assert.AreEqual( szReplaceTextExpected, szReplacedText );
		}

		#endregion

		#region  CheckDocInputAndSearchText_UT

		[DataRow( "", "hi", false )]
		[DataRow( "hi", "", false )]
		[DataRow( "  ", "hi", false )]

		[TestMethod]
		public void CheckDocInputAndSearchText_WhenDocInputOrSearchInputIsEmpty_ShouldReturnFalse( string szDocInput, string szSearchInput, bool isExpectedResult )
		{
			// act
			bool isValid = m_handler.CheckDocInputAndSearchText( szDocInput, szSearchInput );

			// assert
			Assert.AreEqual( isExpectedResult, isValid );
		}

		[DataRow( "Hello", "hi", true )]
		[DataRow( "hi", "h", true )]

		[TestMethod]
		public void CheckDocInputAndSearchText_WhenDocInputOrSearchInputIsValid_ShouldReturnTrue( string szDocInput, string szSearchInput, bool isExpectedResult )
		{
			// act
			bool isValid = m_handler.CheckDocInputAndSearchText( szDocInput, szSearchInput );

			// assert
			Assert.AreEqual( isExpectedResult, isValid );
		}

		#endregion
	}
}
