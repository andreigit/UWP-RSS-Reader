﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static Common.FormattableString;

namespace RssReader.Model
{

    /// <summary>
    /// RSS Channel
    /// </summary>
    public sealed class RssChannel
    {

        /// <summary>
        /// Original Uri
        /// </summary>
        public string Uri { get; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Link
        /// </summary>
        public string Link { get; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Image
        /// </summary>
        public RssChannelImage Image { get; }

        /// <summary>
        /// Last Build Date
        /// </summary>
        public string LastBuildDate { get; }

        /// <summary>
        /// News Items
        /// </summary>
        public IReadOnlyCollection<RssChannelItem> News { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uri">Original Uri</param>
        /// <param name="title">Title</param>
        /// <param name="link">Link</param>
        /// <param name="description">Description</param>
        /// <param name="image">Image</param>
        /// <param name="lastBuildDate">LastBuildDate</param>
        /// <param name="news">News</param>
        internal RssChannel(
            string uri,
            string title,
            string link,
            string description,
            RssChannelImage image,
            string lastBuildDate,
            IEnumerable<RssChannelItem> news
        )
        {
            this.Uri = uri ?? string.Empty;
            this.Title = title ?? string.Empty;
            this.Link = link ?? string.Empty;
            this.Description = description ?? string.Empty;
            this.Image = image ?? new RssChannelImage();
            this.LastBuildDate = lastBuildDate ?? string.Empty;

            Func<IList<RssChannelItem>> copyNews = () =>
                news?.Where(newsItem => (object)newsItem != null).ToArray() ?? new RssChannelItem[0];

            this.News = new ReadOnlyCollection<RssChannelItem>(copyNews());
        }

        public string TitleWithLastBuildDate => Invariant($"{this.Title} ({this.LastBuildDate})");

        public override string ToString() => this.TitleWithLastBuildDate;

    }
}
