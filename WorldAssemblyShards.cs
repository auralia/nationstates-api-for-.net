//-----------------------------------------------------------------------
// <copyright file="WorldAssemblyShards.cs" company="Auralia">
//     Copyright (C) 2013 Auralia
// </copyright>
//-----------------------------------------------------------------------

namespace Auralia.NationStates.Api
{
    using System;

    /// <summary>
    /// Represents the shards included in a NationStates World Assembly API request. At least one shard (that is not <c>votetrack</c>, <c>dellog</c> or <c>delvotes</c>) must be enabled.
    /// </summary>
    public class WorldAssemblyShards
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldAssemblyShards"/> class.
        /// </summary>
        /// <param name="enableAll">A value indicating whether all shards are enabled in the request.</param>
        public WorldAssemblyShards(bool enableAll = false)
        {
            this.NumberOfNations = enableAll;
            this.NumberOfDelegates = enableAll;
            this.Members = enableAll;
            this.Delegates = enableAll;
            this.Happenings = enableAll;
            this.MembershipHappenings = enableAll;
            this.Resolution = enableAll;
            this.VotesHistory = enableAll;
            this.DelegateVotesHistory = enableAll;
            this.DelegateVotes = enableAll;
            this.LastResolution = enableAll;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>numnations</c> World Assembly API shard is enabled in the request. The <c>numnations</c> shard retrieves the number of World Assembly member nations.
        /// </summary>
        /// <value>A value indicating whether the <c>numnations</c> World Assembly API shard is enabled in the request.</value>
        public bool NumberOfNations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>numdelegates</c> World Assembly API shard is enabled in the request. The <c>numdelegates</c> shard retrieves the number of World Assembly regional delegates.
        /// </summary>
        /// <value>A value indicating whether the <c>numdelegates</c> World Assembly API shard is enabled in the request.</value>
        public bool NumberOfDelegates
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>members</c> World Assembly API shard is enabled in the request. The <c>members</c> shard retrieves the World Assembly's member nations.
        /// </summary>
        /// <value>A value indicating whether the <c>members</c> World Assembly API shard is enabled in the request.</value>
        public bool Members
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>delegates</c> World Assembly API shard is enabled in the request. The <c>delegates</c> shard retrieves the World Assembly's regional delegates.
        /// </summary>
        /// <value>A value indicating whether the <c>delegates</c> World Assembly API shard is enabled in the request.</value>
        public bool Delegates
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>happenings</c> World Assembly API shard is enabled in the request. The <c>happenings</c> shard retrieves the World Assembly's happenings.
        /// </summary>
        /// <value>A value indicating whether the <c>happenings</c> World Assembly API shard is enabled in the request.</value>
        public bool Happenings
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>memberlog</c> World Assembly API shard is enabled in the request. The <c>memberlog</c> shard retrieves the World Assembly's membership happenings.
        /// </summary>
        /// <value>A value indicating whether the <c>memberlog</c> World Assembly API shard is enabled in the request.</value>
        public bool MembershipHappenings
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>resolution</c> World Assembly API shard is enabled in the request. The <c>resolution</c> shard retrieves the General Assembly or Security Council resolution at vote, depending on the council specified in the request.
        /// </summary>
        /// <value>A value indicating whether the <c>resolution</c> World Assembly API shard is enabled in the request.</value>
        public bool Resolution
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>votetrack</c> World Assembly API shard is enabled in the request. The <c>votetrack</c> shard retrieves the number of votes on the resolution at each hour since the resolution went to vote.
        /// </summary>
        /// <value>A value indicating whether the <c>votetrack</c> World Assembly API shard is enabled in the request.</value>
        public bool VotesHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>dellog</c> World Assembly API shard is enabled in the request. The <c>dellog</c> shard retrieves a record of delegate vote actions with respect to the resolution since it went to vote.
        /// </summary>
        /// <value>A value indicating whether the <c>dellog</c> World Assembly API shard is enabled in the request.</value>
        public bool DelegateVotesHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>delvotes</c> World Assembly API shard is enabled in the request. The <c>delvotes</c> shard retrieves the delegates that have voted on of the resolution.
        /// </summary>
        /// <value>A value indicating whether the <c>delvotes</c> World Assembly API shard is enabled in the request.</value>
        public bool DelegateVotes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>lastresolution</c> World Assembly API shard is enabled in the request. The <c>lastresolution</c> shard retrieves a description of the last General Assembly or Security Council resolution at vote, depending on the council specified in the request.
        /// </summary>
        /// <value>A value indicating whether the <c>lastresolution</c> World Assembly API shard is enabled in the request.</value>
        public bool LastResolution
        {
            get;
            set;
        }
    }
}
