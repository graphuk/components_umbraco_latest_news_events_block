namespace Graph.Components.LatestNewsEventsBlock
{
	public static class LatestNewsEventsBlockConfig
	{
		public static string HomePageId => "1067";

		public static class NewsConfig
		{
			public const string PageAlias = "NewsPage";
			public static string Title => "title";
			public static string Description => "summary";
			public static string Date => "date";
			public static string Image => "image";
			public static string Eyebrow => "eyebrow";
		}

		public static class EventsConfig
		{
			public const string PageAlias = "EventPage";
			public static string Title => "title";
			public static string StartDate => "startDate";
			public static string EndDate => "endDate";
			public static string Eyebrow => "eyebrow";
			public static string Location => "location";
		}
	}
}
