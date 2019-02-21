using System.Collections.Generic;

namespace Graph.Components.LatestNewsEventsBlock
{
	public class GridControlLatestNewsEventsBlockItem
	{
		public string Title { get; set; }
		public IEnumerable<LatestNewsEventsTile> Tiles { get; set; }
	}
}
