namespace SearchReplaceTool.Logic
{
	public enum TextSearchState
	{
		Success,
		NotFound,
	}

	public enum TextReplaceState
	{
		Replaced,
		Skipped,
		NotFound,
	}

	public class TextSearchOutcome
	{
		public TextSearchState SearchState
		{
			get; set;
		}

		public int Position
		{
			get; set;
		}

	}

	public class TextReplaceOutcome
	{
		public TextReplaceState ReplaceState
		{
			get; set;
		}

		public string UpdatedText
		{
			get; set;
		}

		public int NextSearchIndex
		{
			get; set;
		}
	}
}
