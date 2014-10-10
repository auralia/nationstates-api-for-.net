//-----------------------------------------------------------------------
// <copyright file="WorldData.cs" company="Auralia">
//     Copyright (C) 2013 Auralia
// </copyright>
//-----------------------------------------------------------------------

namespace Auralia.NationStates.Api
{
    using System;

    /// <summary>
    /// Represents the data returned from a NationStates world API request.
    /// </summary>
    [Serializable]
    public class WorldData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldData"/> class.
        /// </summary>
        public WorldData()
        {
            this.NumberOfNations = null;
            this.NumberOfRegions = null;
            this.CensusName = null;
            this.CensusId = null;
            this.CensusSize = null;
            this.CensusScale = null;
            this.CensusMedian = null;
            this.FeaturedRegion = null;
            this.NewNations = null;
            this.RegionsByTag = null;
            this.Poll = null;
            this.Dispatch = null;
            this.DispatchMetadata = null;
            this.Happenings = null;
        }

        /// <summary>
        /// Gets the number of nations in the world. Corresponds to the <c>numnations</c> world API shard.
        /// </summary>
        /// <value>The number of nations in the world.</value>
        public int? NumberOfNations
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the number of regions in the world. Corresponds to the <c>numregions</c> world API shard.
        /// </summary>
        /// <value>The number of regions in the world.</value>
        public int? NumberOfRegions
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the name of the daily census. Corresponds to the <c>census</c> world API shard.
        /// </summary>
        /// <value>The name of the daily census.</value>
        public string CensusName
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the ID of the daily census. Corresponds to the <c>census</c> and <c>censusid</c> world API shards.
        /// </summary>
        /// <value>The ID of the daily census.</value>
        public int? CensusId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the size of the daily census. Corresponds to the <c>censussize</c> world API shard.
        /// </summary>
        /// <value>The size of the daily census.</value>
        public int? CensusSize
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the scale of the daily census. Corresponds to the <c>censusscale</c> world API shard.
        /// </summary>
        /// <value>The scale of the daily census.</value>
        public string CensusScale
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the median of the daily census. Corresponds to the <c>censusmedian</c> world API shard.
        /// </summary>
        /// <value>The median of the daily census.</value>
        public double? CensusMedian
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the name of the daily featured region. Corresponds to the <c>featuredregion</c> world API shard.
        /// </summary>
        /// <value>The name of the daily featured region.</value>
        public string FeaturedRegion
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the most recently created nations. Corresponds to the <c>newnations</c> world API shard.
        /// </summary>
        /// <value>The most recently created nations.</value>
        public string[] NewNations
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the regions with or without the tags specified in the request. Corresponds to the <c>regionsbytag</c> world API shard.
        /// </summary>
        /// <value>The regions with or without the tags specified in the request.</value>
        public string[] RegionsByTag
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the poll with the ID specified in the request. Corresponds to the <c>poll</c> world API shard.
        /// </summary>
        /// <value>The poll with the ID specified in the request.</value>
        public PollData Poll
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the dispatch with the ID specified in the request. Corresponds to the <c>dispatch</c> world API shard.
        /// </summary>
        /// <value>The dispatch with the ID specified in the request.</value>
        public DispatchData Dispatch
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the metadata for the dispatches specified in the request. Corresponds to the <c>dispatchlist</c> world API shard.
        /// </summary>
        /// <value>The metadata for the dispatches specified in the request.</value>
        public DispatchMetadataData[] DispatchMetadata
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the world's happenings. Corresponds to the <c>happenings</c> world API shard.
        /// </summary>
        public Happening[] Happenings
        {
            get;
            internal set;
        }

        /// <summary>
        /// Represents a poll.
        /// </summary>
        public class PollData
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PollData"/> class.
            /// </summary>
            public PollData()
            {
                this.Id = null;
                this.Title = null;
                this.Region = null;
                this.StartDate = null;
                this.EndDate = null;
                this.Author = null;
                this.Options = null;
            }

            /// <summary>
            /// Gets the poll's ID.
            /// </summary>
            /// <value>The poll's ID.</value>
            public int? Id
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the poll's title.
            /// </summary>
            /// <value>The poll's title.</value>
            public string Title
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the poll's text.
            /// </summary>
            /// <value>The poll's text.</value>
            public string Text
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the poll's region.
            /// </summary>
            /// <value>The poll's region.</value>
            public string Region
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the poll's start date.
            /// </summary>
            /// <value>The poll's start date.</value>
            public DateTime? StartDate
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the poll's end date.
            /// </summary>
            /// <value>The poll's end date.</value>
            public DateTime? EndDate
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the poll's author.
            /// </summary>
            /// <value>The poll's author.</value>
            public string Author
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the poll's options.
            /// </summary>
            /// <value>The poll's options.</value>
            public Option[] Options
            {
                get;
                internal set;
            }

            /// <summary>
            /// Represents a poll option.
            /// </summary>
            public class Option
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="Option"/> class.
                /// </summary>
                public Option()
                {
                    this.Id = null;
                    this.Text = null;
                    this.Votes = null;
                }

                /// <summary>
                /// Gets the option's ID.
                /// </summary>
                /// <value>The option's ID.</value>
                public int? Id
                {
                    get;
                    internal set;
                }

                /// <summary>
                /// Gets the option's text.
                /// </summary>
                /// <value>The option's text.</value>
                public string Text
                {
                    get;
                    internal set;
                }

                /// <summary>
                /// Gets the number of votes for the option.
                /// </summary>
                /// <value>The number of votes for the option.</value>
                public int? Votes
                {
                    get;
                    internal set;
                }
            }
        }

        /// <summary>
        /// Represents a dispatch.
        /// </summary>
        public class DispatchData
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DispatchData"/> class.
            /// </summary>
            public DispatchData()
            {
                this.Id = null;
                this.Title = null;
                this.Author = null;
                this.Category = null;
                this.Subcategory = null;
                this.DateCreated = null;
                this.DateEdited = null;
                this.NumberOfViews = null;
                this.Score = null;
                this.Text = null;
            }

            /// <summary>
            /// Gets the dispatch's ID.
            /// </summary>
            /// <value>The dispatch's ID.</value>
            public int? Id
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the dispatch's title.
            /// </summary>
            /// <value>The dispatch's title.</value>
            public string Title
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the dispatch's author.
            /// </summary>
            /// <value>The dispatch's author.</value>
            public string Author
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the dispatch's category.
            /// </summary>
            /// <value>The dispatch's category.</value>
            public string Category
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the dispatch's subcategory.
            /// </summary>
            /// <value>The dispatch's subcategory.</value>
            public string Subcategory
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the date on which the dispatch was created.
            /// </summary>
            /// <value>The date on which the dispatch was created.</value>
            public DateTime? DateCreated
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the date on which the dispatch was last edited.
            /// </summary>
            /// <value>The date on which the dispatch was last edited.</value>
            public DateTime? DateEdited
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the number of views the dispatch has received.
            /// </summary>
            /// <value>The number of views the dispatch has received.</value>
            public int? NumberOfViews
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the dispatch's score.
            /// </summary>
            /// <value>The dispatch's score.</value>
            public int? Score
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the dispatch's text.
            /// </summary>
            /// <value>The dispatch's text.</value>
            public string Text
            {
                get;
                internal set;
            }
        }

        /// <summary>
        /// Represents the metadata associated with a dispatch.
        /// </summary>
        public class DispatchMetadataData
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DispatchMetadataData"/> class.
            /// </summary>
            public DispatchMetadataData()
            {
                this.Id = null;
                this.Title = null;
                this.Author = null;
                this.Category = null;
                this.Subcategory = null;
                this.DateCreated = null;
                this.DateEdited = null;
                this.NumberOfViews = null;
                this.Score = null;
            }

            /// <summary>
            /// Gets the dispatch's ID.
            /// </summary>
            /// <value>The dispatch's ID.</value>
            public int? Id
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the dispatch's title.
            /// </summary>
            /// <value>The dispatch's title.</value>
            public string Title
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the dispatch's author.
            /// </summary>
            /// <value>The dispatch's author.</value>
            public string Author
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the dispatch's category.
            /// </summary>
            /// <value>The dispatch's category.</value>
            public string Category
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the dispatch's subcategory.
            /// </summary>
            /// <value>The dispatch's subcategory.</value>
            public string Subcategory
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the date on which the dispatch was created.
            /// </summary>
            /// <value>The date on which the dispatch was created.</value>
            public DateTime? DateCreated
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the date on which the dispatch was last edited.
            /// </summary>
            /// <value>The date on which the dispatch was last edited.</value>
            public DateTime? DateEdited
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the number of views the dispatch has received.
            /// </summary>
            /// <value>The number of views the dispatch has received.</value>
            public int? NumberOfViews
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the dispatch's score.
            /// </summary>
            /// <value>The dispatch's score.</value>
            public int? Score
            {
                get;
                internal set;
            }
        }

        /// <summary>
        /// Represents an entry in the world's happenings.
        /// </summary>
        public class Happening
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Happening"/> class.
            /// </summary>
            public Happening()
            {
                this.Id = null;
                this.Timestamp = null;
                this.Text = null;
            }

            /// <summary>
            /// Gets the entry's ID.
            /// </summary>
            /// <value>The entry's ID.</value>
            public int? Id
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the entry's timestamp.
            /// </summary>
            /// <value>The entry's timestamp.</value>
            public DateTime? Timestamp
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the entry's text.
            /// </summary>
            /// <value>The entry's text.</value>
            public string Text
            {
                get;
                internal set;
            }
        }
    }
}