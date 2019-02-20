namespace Graph.Components.LatestNewsEventsBlock
{
	public static class LatestNewsEventsBlockConfig
	{
		public static string HomePageId => "ID_HERE";

		public static class NewsConfig
		{
			public const string PageAlias = "NewsPage";
			public const string Title = "title";
			public const string Description = "summary";
			public const string Date = "date";
			public const string Image = "image";
			public const string Eyebrow = "eyebrow";
		}

		public static class EventsConfig
		{
			public const string PageAlias = "EventPage";
			public const string Title = "title";
			public const string StartDate = "startDate";
			public const string EndDate = "endDate";
			public const string Eyebrow = "eyebrow";
			public const string Location = "location";
		}
	}
}
