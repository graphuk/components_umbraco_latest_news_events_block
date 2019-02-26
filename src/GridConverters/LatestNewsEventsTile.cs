using System;

namespace Graph.Components.LatestNewsEventsBlock
{
	public class LatestNewsEventsTile
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public string Link { get; set; }
		public string Eyebrow { get; set; }
		public string Location { get; set; }
		public bool IsShowDate { get; set; }
		public DateTime Date { get; set; }
		public DateTime? EndDate { get; set; }

	}
}
