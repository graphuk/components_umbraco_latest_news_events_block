using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Values;

namespace Graph.Components.LatestNewsEventsBlock
{
	public class GridControlLatestNewsEventsBlockValue : GridControlValueBase
	{
		public GridControlLatestNewsEventsBlockItem GridControlLatestNewsEventsBlockItem { get; protected set; }

		public GridControlLatestNewsEventsBlockValue(GridControl control, JToken obj) : base(control, obj as JObject)
		{
			GridControlLatestNewsEventsBlockItem = JsonConvert.DeserializeObject<GridControlLatestNewsEventsBlockItem>(obj.ToString());
		}

		public static GridControlLatestNewsEventsBlockValue Parse(GridControl control, JToken obj)
		{
			return obj != null ? new GridControlLatestNewsEventsBlockValue(control, obj) : null;
		}
	}
}
