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
            this.Happenings = null;
            this.NewNations = null;
            this.RegionsByTag = null;
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
        public int? CensusMedian
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
        /// Gets the world's happenings. Corresponds to the <c>happenings</c> world API shard.
        /// </summary>
        public Happening[] Happenings
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