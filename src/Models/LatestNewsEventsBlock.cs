using UmbracoGridConfigLoader.Models;
using UmbracoGridConfigLoader.Attributes;

namespace Graph.Components.LatestNewsEventsBlock
{
	public class LatestNewsEventsBlock : IGridConfigLoader
	{
		[GridLayoutProperty(Label = "Latest News And Events Block", AllowedEditors = new []{ "latestNewsEventsBlock" }, MaxItems = 1)]
		public IGridLayout Layout { get; set; }
	}
}
