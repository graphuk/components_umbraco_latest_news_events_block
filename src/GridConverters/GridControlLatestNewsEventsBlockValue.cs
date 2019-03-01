using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Values;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Graph.Components.LatestNewsEventsBlock
{
	public class GridControlLatestNewsEventsBlockValue : GridControlValueBase
	{
		public GridControlLatestNewsEventsBlockItem GridControlLatestNewsEventsBlockItem { get; protected set; }

		public GridControlLatestNewsEventsBlockValue(GridControl control, JToken obj) : base(control, obj as JObject)
		{
			GridControlLatestNewsEventsBlockItem = JsonConvert.DeserializeObject<GridControlLatestNewsEventsBlockItem>(obj.ToString());
			var homePage = new UmbracoHelper(UmbracoContext.Current).TypedContent(LatestNewsEventsBlockConfig.HomePageId);
			var closestFutureEvent = homePage
				.Descendants(LatestNewsEventsBlockConfig.EventsConfig.PageAlias)
				.ToArray()
				.Where(eventPage => eventPage.GetPropertyValue<DateTime>(LatestNewsEventsBlockConfig.EventsConfig.StartDate) >=DateTime.Today ||
									eventPage.GetPropertyValue<DateTime>(LatestNewsEventsBlockConfig.EventsConfig.EndDate) >= DateTime.Today)
				.OrderBy(eventPage => eventPage.GetPropertyValue<DateTime>(LatestNewsEventsBlockConfig.EventsConfig.StartDate))
				.FirstOrDefault();
			var newsToTakeCount = closestFutureEvent != null ? LatestNewsEventsBlockConfig.MaxCountNews - 1 : LatestNewsEventsBlockConfig.MaxCountNews;
			var newsAndEvents = homePage.Descendants(LatestNewsEventsBlockConfig.NewsConfig.PageAlias)
				.ToArray()
				.OrderByDescending(newsPage => newsPage.GetPropertyValue<DateTime>(LatestNewsEventsBlockConfig.NewsConfig.Date))
				.Take(newsToTakeCount)
				.ToList();
			if (closestFutureEvent != null)
				newsAndEvents.Add(closestFutureEvent);

			GridControlLatestNewsEventsBlockItem.Tiles = newsAndEvents.Select(MapToTile);
		}

		public static GridControlLatestNewsEventsBlockValue Parse(GridControl control, JToken obj)
		{
			return obj != null ? new GridControlLatestNewsEventsBlockValue(control, obj) : null;
		}

		private LatestNewsEventsTile MapToTile(IPublishedContent page)
		{
			switch (page.DocumentTypeAlias)
			{
				case LatestNewsEventsBlockConfig.EventsConfig.PageAlias:
					return MapEventToTile(page);
				case LatestNewsEventsBlockConfig.NewsConfig.PageAlias:
					return MapNewsToTile(page);
				default:
					return null;
			}
		}

		private LatestNewsEventsTile MapNewsToTile(IPublishedContent newsPage)
		{
			return new LatestNewsEventsTile
			{
				Title = newsPage.GetPropertyValue<string>(LatestNewsEventsBlockConfig.NewsConfig.Title),
				Description = newsPage.GetPropertyValue<string>(LatestNewsEventsBlockConfig.NewsConfig.Description),
				IsShowDate = LatestNewsEventsBlockConfig.NewsConfig.IsShowDate,
				Date = newsPage.GetPropertyValue<DateTime>(LatestNewsEventsBlockConfig.NewsConfig.Date),
				Eyebrow = LatestNewsEventsBlockConfig.IsShowEyebrow
					? LatestNewsEventsBlockConfig.IsShowDefaultEyebrow
						? LatestNewsEventsBlockConfig.NewsConfig.EyebrowDefault
						: newsPage.GetPropertyValue<string>(LatestNewsEventsBlockConfig.EventsConfig.Eyebrow)
					: "",
				Image = newsPage.GetPropertyValue<IPublishedContent>(LatestNewsEventsBlockConfig.NewsConfig.Image)?.Url,
				Link = newsPage.Url
			};
		}

		private LatestNewsEventsTile MapEventToTile(IPublishedContent evenPage)
		{
			return new LatestNewsEventsTile
			{
				Title = evenPage.GetPropertyValue<string>(LatestNewsEventsBlockConfig.EventsConfig.Title),
				Eyebrow = LatestNewsEventsBlockConfig.IsShowEyebrow
					? LatestNewsEventsBlockConfig.IsShowDefaultEyebrow
						? LatestNewsEventsBlockConfig.EventsConfig.EyebrowDefault
						: evenPage.GetPropertyValue<string>(LatestNewsEventsBlockConfig.EventsConfig.Eyebrow)
					: "",
				Image = evenPage.GetPropertyValue<IPublishedContent>(LatestNewsEventsBlockConfig.EventsConfig.Image)?.Url,
				Location = evenPage.GetPropertyValue<string>(LatestNewsEventsBlockConfig.EventsConfig.Location),
				IsShowDate = LatestNewsEventsBlockConfig.EventsConfig.IsShowDate,
				Date = evenPage.GetPropertyValue<DateTime>(LatestNewsEventsBlockConfig.EventsConfig.StartDate),
				EndDate = evenPage.GetPropertyValue<DateTime>(LatestNewsEventsBlockConfig.EventsConfig.EndDate),
				Link = evenPage.Url
			};
		}
	}
}
