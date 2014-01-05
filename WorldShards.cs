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
            this.Happenings = enableAll;
            this.HappeningsConfiguration = new HappeningsConfigurationData();
            this.NewNations = enableAll;
            this.RegionsByTag = enableAll;
            this.RegionsByTagConfiguration = new RegionsByTagConfigurationData();
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
        /// Gets or sets a value indicating whether the <c>happenings</c> world API shard is enabled in the request. The <c>happenings</c> shard retrieves the world's happenings.
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
        /// Gets or sets a value indicating whether the <c>newnations</c> world API shard is enabled in the request. The <c>newnations</c> shard retrieves the most recently created nations.
        /// </summary>
        /// <value>A value indicating whether the <c>newnations</c> world API shard is enabled in the request.</value>
        public bool NewNations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>regionsbytag</c> world API shard is enabled in the request. The <c>regionsbytag</c> shard retrieves the regions with or without the tags specified in the request.
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
    }
}
