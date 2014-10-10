//-----------------------------------------------------------------------
// <copyright file="WorldShards.cs" company="Auralia">
//     Copyright (C) 2013 Auralia
// </copyright>
//-----------------------------------------------------------------------

namespace Auralia.NationStates.Api
{
    using System;

    /// <summary>
    /// Represents the shards included in a NationStates world API request. At least one shard must be enabled.
    /// </summary>
    public class WorldShards
    {
        /// <summary>
        /// The configuration for the <c>happenings</c> world API shard in the request.
        /// </summary>
        private HappeningsConfigurationData happeningsConfiguration;

        /// <summary>
        /// The configuration for the <c>regionsbytag</c> world API shard in the request.
        /// </summary>
        private RegionsByTagConfigurationData regionsByTagConfiguration;

        /// <summary>
        /// The configuration for the <c>dispatchlist</c> world API shard in the request.
        /// </summary>
        private DispatchListConfigurationData dispatchListConfiguration;

        /// <summary>
        /// The dispatch ID associated with the <c>dispatch</c> world API shard in the request.
        /// </summary>
        private int dispatchId;

        /// <summary>
        /// The poll ID associated with the <c>poll</c> world API shard in the request.
        /// </summary>
        private int pollId;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldShards"/> class.
        /// </summary>
        /// <param name="enableAll">A value indicating whether all shards are enabled in the request.</param>
        public WorldShards(bool enableAll)
        {
            this.NumberOfNations = enableAll;
            this.NumberOfRegions = enableAll;
            this.CensusName = enableAll;
            this.CensusId = enableAll;
            this.CensusSize = enableAll;
            this.CensusScale = enableAll;
            this.CensusMedian = enableAll;
            this.FeaturedRegion = enableAll;
            this.NewNations = enableAll;
            this.RegionsByTag = enableAll;
            this.RegionsByTagConfiguration = new RegionsByTagConfigurationData();
            this.Poll = enableAll;
            this.PollId = 1;
            this.Dispatch = enableAll;
            this.DispatchId = 1;
            this.DispatchList = enableAll;
            this.DispatchListConfiguration = new DispatchListConfigurationData();
            this.Happenings = enableAll;
            this.HappeningsConfiguration = new HappeningsConfigurationData();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>numnations</c> world API shard is enabled in the request. The <c>numnations</c> shard retrieves the number of nations in the world.
        /// </summary>
        /// <value>A value indicating whether the <c>numnations</c> world API shard is enabled in the request.</value>
        public bool NumberOfNations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>numregions</c> world API shard is enabled in the request. The <c>numregions</c> shard retrieves the number of regions in the world.
        /// </summary>
        /// <value>A value indicating whether the <c>numregions</c> world API shard is enabled in the request.</value>
        public bool NumberOfRegions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>census</c> world API shard is enabled in the request. The <c>census</c> shard retrieves the name and ID of the daily census.
        /// </summary>
        /// <value>A value indicating whether the <c>census</c> world API shard is enabled in the request.</value>
        public bool CensusName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>censusid</c> world API shard is enabled in the request. The <c>censusid</c> shard retrieves the ID of the daily census.
        /// </summary>
        /// <value>A value indicating whether the <c>censusid</c> world API shard is enabled in the request.</value>
        public bool CensusId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>censussize</c> world API shard is enabled in the request. The <c>censussize</c> shard retrieves the size of the daily census.
        /// </summary>
        /// <value>A value indicating whether the <c>censussize</c> world API shard is enabled in the request.</value>
        public bool CensusSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>censusscale</c> world API shard is enabled in the request. The <c>censusscale</c> shard retrieves the scale of the daily census.
        /// </summary>
        /// <value>A value indicating whether the <c>censusscale</c> world API shard is enabled in the request.</value>
        public bool CensusScale
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>censusmedian</c> world API shard is enabled in the request. The <c>censusmedian</c> shard retrieves the median of the daily census.
        /// </summary>
        /// <value>A value indicating whether the <c>censusmedian</c> world API shard is enabled in the request.</value>
        public bool CensusMedian
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>featuredregion</c> world API shard is enabled in the request. The <c>featuredregion</c> shard retrieves the name of the daily featured region.
        /// </summary>
        /// <value>A value indicating whether the <c>featuredregion</c> world API shard is enabled in the request.</value>
        public bool FeaturedRegion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>newnations</c> world API shard is enabled in the request. The <c>newnations</c> shard retrieves the most recently created nations.
        /// </summary>
        /// <value>A value indicating whether the <c>newnations</c> world API shard is enabled in the request.</value>
        public bool NewNations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>regionsbytag</c> world API shard is enabled in the request. The <c>regionsbytag</c> shard retrieves the regions with or without the tags specified in the request. This shard cannot be enabled if the <c>dispatch</c>, <c>poll</c>, <c>dispatchlist</c> shard or <c>happenings</c> shard is enabled.
        /// </summary>
        /// <value>A value indicating whether the <c>regionsbytag</c> world API shard is enabled in the request.</value>
        public bool RegionsByTag
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the configuration for the <c>regionsbytag</c> world API shard in the request.
        /// </summary>
        /// <value>The configuration for the <c>regionsbytag</c> world API shard in the request.</value>
        public RegionsByTagConfigurationData RegionsByTagConfiguration
        {
            get
            {
                return this.regionsByTagConfiguration;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("RegionsByTagConfiguration", "The regions by tag configuration cannot be null.");
                }
                else
                {
                    this.regionsByTagConfiguration = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>poll</c> world API shard is enabled in the request. The <c>dispatch</c> shard retrieves the poll with the ID specified in the request. This shard cannot be enabled if the <c>dispatch</c>, <c>dispatchlist</c>, <c>regionsbytag</c> shard or <c>happenings</c> shard is enabled.
        /// </summary>
        /// <value>A value indicating whether the <c>poll</c> world API shard is enabled in the request.</value>
        public bool Poll
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the poll ID associated with the <c>poll</c> world API shard in the request. The default ID is 1.
        /// </summary>
        /// <value>The poll ID associated with the <c>poll</c> world API shard in the request.</value>
        public int PollId
        {
            get
            {
                return this.pollId;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("The poll ID cannot be less than one.", "PollId");
                }
                else
                {
                    this.pollId = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>dispatch</c> world API shard is enabled in the request. The <c>dispatch</c> shard retrieves the dispatch with the ID specified in the request. This shard cannot be enabled if the <c>dispatchlist</c>, <c>poll</c>, <c>regionsbytag</c> shard or <c>happenings</c> shard is enabled.
        /// </summary>
        /// <value>A value indicating whether the <c>dispatch</c> world API shard is enabled in the request.</value>
        public bool Dispatch
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the dispatch ID associated with the <c>dispatch</c> world API shard in the request. The default ID is 1.
        /// </summary>
        /// <value>The dispatch ID associated with the <c>dispatch</c> world API shard in the request.</value>
        public int DispatchId
        {
            get
            {
                return this.dispatchId;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("The dispatch ID cannot be less than one.", "DispatchId");
                }
                else
                {
                    this.dispatchId = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>dispatchlist</c> world API shard is enabled in the request. The <c>dispatchlist</c> shard retrieves metadata for the dispatches which match the criteria specified in the request. This shard cannot be enabled if the <c>dispatch</c>, <c>poll</c>, <c>regionsbytag</c> shard or <c>happenings</c> shard is enabled.
        /// </summary>
        /// <value>A value indicating whether the <c>dispatchlist</c> world API shard is enabled in the request.</value>
        public bool DispatchList
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the configuration for the <c>dispatchlist</c> world API shard in the request.
        /// </summary>
        /// <value>The configuration for the <c>dispatchlist</c> world API shard in the request.</value>
        public DispatchListConfigurationData DispatchListConfiguration
        {
            get
            {
                return this.dispatchListConfiguration;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("DispatchListConfiguration", "The dispatch list configuration cannot be null.");
                }
                else
                {
                    this.dispatchListConfiguration = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>happenings</c> world API shard is enabled in the request. The <c>happenings</c> shard retrieves the world's happenings. This shard cannot be enabled if the <c>dispatch</c>, <c>poll</c>, <c>regionsbytag</c> shard or <c>dispatchlist</c> shard is enabled.
        /// </summary>
        /// <value>A value indicating whether the <c>happenings</c> world API shard is enabled in the request.</value>
        public bool Happenings
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the configuration for the <c>happenings</c> world API shard in the request.
        /// </summary>
        /// <value>The configuration for the <c>happenings</c> world API shard in the request.</value>
        public HappeningsConfigurationData HappeningsConfiguration
        {
            get
            {
                return this.happeningsConfiguration;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("HappeningsConfiguration", "The happenings configuration cannot be null.");
                }
                else
                {
                    this.happeningsConfiguration = value;
                }
            }
        }

        /// <summary>
        /// Represents the configuration for the <c>happenings</c> world API shard.
        /// </summary>
        public class HappeningsConfigurationData
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="HappeningsConfigurationData"/> class.
            /// </summary>
            public HappeningsConfigurationData()
            {
                this.View = null;
                this.ViewValue = null;
                this.Filter = null;
                this.Limit = null;
                this.SinceId = null;
                this.BeforeId = null;
            }

            /// <summary>
            /// Represents view types, which limit happenings to a particular group of nations.
            /// </summary>
            public enum ViewType
            {
                /// <summary>
                /// Represents the nation view type, which limits happenings to the specified nation.
                /// </summary>
                Nation,

                /// <summary>
                /// Represents the region view type, which limits happenings to the nations in the specified region.
                /// </summary>
                Region
            }

            /// <summary>
            /// Represents filter types, which limit happenings to a particular type.
            /// </summary>
            [System.FlagsAttribute]
            public enum FilterType
            {
                /// <summary>
                /// Represents the <c>law</c> national happenings filter. The <c>law</c> filter limits happenings to the passage of national legislation.
                /// </summary>
                NationalLegislation = 1,

                /// <summary>
                /// Represents the <c>change</c> national happenings filter. The <c>change</c> filter limits happenings to changes to national attributes.
                /// </summary>
                NationalChanges = 2,

                /// <summary>
                /// Represents the <c>dispatch</c> national happenings filter. The <c>dispatch</c> filter limits happenings to the publishing of national dispatches.
                /// </summary>
                NationalDispatches = 4,

                /// <summary>
                /// Represents the <c>rmb</c> regional happenings filter. The <c>rmb</c> filter limits happenings to events related to the lodging of posts on regional message boards.
                /// </summary>
                RegionalMessageBoard = 8,

                /// <summary>
                /// Represents the <c>embassy</c> regional happenings filter. The <c>embassy</c> filter limits happenings to events related to regional embassies.
                /// </summary>
                RegionalEmbassies = 16,

                /// <summary>
                /// Represents the <c>eject</c> regional happenings filter. The <c>eject</c> filter limits happenings to ejections from regions.
                /// </summary>
                RegionalEjections = 32,

                /// <summary>
                /// Represents the <c>admin</c> regional happenings filter. The <c>admin</c> filter limits happenings to events related to regional administration.
                /// </summary>
                RegionalAdministrationChanges = 64,

                /// <summary>
                /// Represents the <c>move</c> movement happenings filter. The <c>move</c> filter limits happenings to nations moving between regions.
                /// </summary>
                MovementMoves = 128,

                /// <summary>
                /// Represents the <c>founding</c> movement happenings filter. The <c>founding</c> filter limits happenings to nations being founded.
                /// </summary>
                MovementFoundings = 256,

                /// <summary>
                /// Represents the <c>cte</c> movement happenings filter. The <c>cte</c> filter limits happenings to nations ceasing to exist.
                /// </summary>
                MovementEndings = 512,

                /// <summary>
                /// Represents the <c>vote</c> World Assembly happenings filter. The <c>vote</c> filter limits happenings to votes by nations on World Assembly resolutions.
                /// </summary>
                WorldAssemblyVotes = 1024,

                /// <summary>
                /// Represents the <c>resolution</c> World Assembly happenings filter. The <c>resolution</c> filter limits happenings to events related to World Assembly proposals and resolutions, such as submissions and approvals.
                /// </summary>
                WorldAssemblyResolutions = 2048,

                /// <summary>
                /// Represents the <c>member</c> World Assembly happenings filter. The <c>member</c> filter limits happenings to World Assembly membership changes.
                /// </summary>
                WorldAssemblyMembers = 4096,

                /// <summary>
                /// Represents the <c>endo</c> World Assembly happenings filter. The <c>endo</c> filter limits happenings to events related to World Assembly endorsements.
                /// </summary>
                WorldAssemblyEndorsements = 8196
            }

            /// <summary>
            /// Gets or sets the view, which limits happenings to a particular group of nations.
            /// </summary>
            /// <value>The view, which limits happenings to a particular group of nations.</value>
            public ViewType? View
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the value associated with the view.
            /// </summary>
            /// <value>The value associated with the view.</value>
            public string ViewValue
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the filter types, which limit happenings to a particular type. Multiple filter types can be specified using bitwise operators.
            /// </summary>
            /// <value>The filter types, which limit happenings to a particular type.</value>
            public FilterType? Filter
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the maximum number of results to be returned by the API.
            /// </summary>
            /// <value>The maximum number of results to be returned by the API.</value>
            public int? Limit
            {
                get;
                set;
            }
            
            /// <summary>
            /// Gets or sets the minimum event ID for the results returned by the API.
            /// </summary>
            /// <value>The minimum event ID for the results returned by the API.</value>
            public int? SinceId
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the maximum event ID for the results returned by the API.
            /// </summary>
            /// <value>The maximum event ID for the results returned by the API.</value>
            public int? BeforeId
            {
                get;
                set;
            }
        }

        /// <summary>
        /// Represents the configuration for the <c>regionsbytag</c> world API shard.
        /// </summary>
        public class RegionsByTagConfigurationData
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="RegionsByTagConfigurationData"/> class.
            /// </summary>
            public RegionsByTagConfigurationData()
            {
                this.IncludeRegionsWithTags = null;
                this.IncludeRegionsWithoutTags = null;
            }

            /// <summary>
            /// Gets or sets the tags that regions must have in order to be included in the regions returned from the API, up to a maximum of ten tags between the two arrays.
            /// </summary>
            /// <value>The tags that regions must have in order to be included in the regions returned from the API</value>
            public string[] IncludeRegionsWithTags
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the tags that regions must not have in order to be included in the regions returned from the API, up to a maximum of ten tags between the two arrays.
            /// </summary>
            /// <value>The tags that regions must not have in order to be included in the regions returned from the API</value>
            public string[] IncludeRegionsWithoutTags
            {
                get;
                set;
            }
        }

        /// <summary>
        /// Represents the configuration for the <c>dispatchlist</c> world API shard.
        /// </summary>
        public class DispatchListConfigurationData
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DispatchListConfigurationData"/> class.
            /// </summary>
            public DispatchListConfigurationData()
            {
                this.Author = null;
                this.Category = null;
                this.Subcategory = null;
                this.Sort = null;
            }

            /// <summary>
            /// Represents sort types, which sort the list of dispatches in a particular manner.
            /// </summary>
            public enum SortType
            {
                /// <summary>
                /// Represents the <c>new</c> sort type, which sorts the list of dispatches in order from newest to oldest.
                /// </summary>
                New = 1,

                /// <summary>
                /// Represents the <c>best</c> sort type, which sorts the list of dispatches in order from most votes to least votes.
                /// </summary>
                Best = 2
            }

            /// <summary>
            /// Gets or sets the author search term, which limits the dispatches returned to the specified author.
            /// </summary>
            /// <value>The author search term, which limits the dispatches returned to the specified author.</value>
            public string Author
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the category search term, which limits the dispatches returned to the specified category.
            /// </summary>
            /// <value>The category search term, which limits the dispatches returned to the specified category.</value>
            public string Category
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the subcategory search term, which limits the dispatches returned to the specified subcategory.
            /// </summary>
            /// <value>The subcategory search term, which limits the dispatches returned to the specified subcategory.</value>
            public string Subcategory
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the sort type, which sorts the list of dispatches returned in a particular manner.
            /// </summary>
            /// <value>The sort type, which sorts the list of dispatches returned in a particular manner.</value>
            public SortType? Sort
            {
                get;
                set;
            }
        }
    }
}
