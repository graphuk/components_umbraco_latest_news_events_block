namespace Graph.Components.LatestNewsEventsBlock
{
	public static class LatestNewsEventsBlockConfig
	{
		public static string HomePageId => "ID_HERE";
		public const int MaxCountNews = 3;
		public const bool IsShowDefaultEyebrow = true;
		public const bool IsShowEyebrow = true;

		public static class NewsConfig
		{
			public const string PageAlias = "NewsPage";
			public const string Title = "title";
			public const string Description = "summary";
			public const bool IsShowDate = true;
			public const string Date = "date";
			public const string Image = "image";
			public const string Eyebrow = "eyebrow";
			public const string EyebrowDefault = "News";
		}

		public static class EventsConfig
		{
			public const string PageAlias = "EventPage";
			public const string Title = "title";
			public const string StartDate = "startDate";
			public const bool IsShowDate = true;
			public const string EndDate = "endDate";
			public const string Eyebrow = "eyebrow";
			public const string Image = "image";
			public const string EyebrowDefault = "Event";
			public const string Location = "location";
		}
	}
}
