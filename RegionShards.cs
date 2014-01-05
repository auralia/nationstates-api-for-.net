//-----------------------------------------------------------------------
// <copyright file="RegionShards.cs" company="Auralia">
//     Copyright (C) 2013 Auralia
// </copyright>
//-----------------------------------------------------------------------

namespace Auralia.NationStates.Api
{
    using System;

    /// <summary>
    /// Represents the shards included in a NationStates region API request. If no shards are enabled, the API will return a standard set of region data.
    /// </summary>
    public class RegionShards
    {
        /// <summary>
        /// The offset associated with the <c>messages</c> region API shard in the request.
        /// </summary>
        private int messagesOffset;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RegionShards"/> class.
        /// </summary>
        /// <param name="enableAll">A value indicating whether all shards are enabled in the request.</param>
        public RegionShards(bool enableAll = false)
        {
            this.Name = enableAll;
            this.Factbook = enableAll;
            this.NumberOfNations = enableAll;
            this.Nations = enableAll;
            this.Delegate = enableAll;
            this.NumberOfDelegateVotes = enableAll;
            this.GeneralAssemblyVote = enableAll;
            this.SecurityCouncilVote = enableAll;
            this.Founder = enableAll;
            this.Power = enableAll;
            this.Flag = enableAll;
            this.Embassies = enableAll;
            this.Tags = enableAll;
            this.Happenings = enableAll;
            this.Messages = enableAll;
            this.MessagesOffset = 0;
            this.History = enableAll;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>name</c> region API shard is enabled in the request. The <c>name</c> shard retrieves the region's name.
        /// </summary>
        /// <value>A value indicating whether the <c>name</c> region API shard is enabled in the request.</value>
        public bool Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>factbook</c> region API shard is enabled in the request. The <c>factbook</c> shard retrieves the region's name.
        /// </summary>
        /// <value>A value indicating whether the <c>factbook</c> region API shard is enabled in the request.</value>
        public bool Factbook
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>numnations</c> region API shard is enabled in the request. The <c>numnations</c> shard retrieves the number of nations in the region.
        /// </summary>
        /// <value>A value indicating whether the <c>numnations</c> region API shard is enabled in the request.</value>
        public bool NumberOfNations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>nations</c> region API shard is enabled in the request. The <c>nations</c> shard retrieves the nations in the region.
        /// </summary>
        /// <value>A value indicating whether the <c>nations</c> region API shard is enabled in the request.</value>
        public bool Nations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>delegate</c> region API shard is enabled in the request. The <c>delegate</c> shard retrieves the delegate of the region.
        /// </summary>
        /// <value>A value indicating whether the <c>delegate</c> region API shard is enabled in the request.</value>
        public bool Delegate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>delegatevotes</c> region API shard is enabled in the request. The <c>delegatevotes</c> shard retrieves the delegate's number of votes in the World Assembly.
        /// </summary>
        /// <value>A value indicating whether the <c>delegatevotes</c> region API shard is enabled in the request.</value>
        public bool NumberOfDelegateVotes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>gavote</c> region API shard is enabled in the request. The <c>gavote</c> shard retrieves the number of votes by the region's nations on the General Assembly resolution at vote.
        /// </summary>
        /// <value>A value indicating whether the <c>gavote</c> region API shard is enabled in the request.</value>
        public bool GeneralAssemblyVote
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>scvote</c> region API shard is enabled in the request. The <c>scvote</c> shard retrieves the number of votes by the region's nations on the Security Council resolution at vote.
        /// </summary>
        /// <value>A value indicating whether the <c>scvote</c> region API shard is enabled in the request.</value>
        public bool SecurityCouncilVote
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>founder</c> region API shard is enabled in the request. The <c>founder</c> shard retrieves the region's founder.
        /// </summary>
        /// <value>A value indicating whether the <c>founder</c> region API shard is enabled in the request.</value>
        public bool Founder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>power</c> region API shard is enabled in the request. The <c>power</c> shard retrieves the region's power.
        /// </summary>
        /// <value>A value indicating whether the <c>power</c> region API shard is enabled in the request.</value>
        public bool Power
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>flag</c> region API shard is enabled in the request. The <c>flag</c> shard retrieves the region's flag.
        /// </summary>
        /// <value>A value indicating whether the <c>flag</c> region API shard is enabled in the request.</value>
        public bool Flag
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>embassies</c> region API shard is enabled in the request. The <c>embassies</c> shard retrieves the region's embassies.
        /// </summary>
        /// <value>A value indicating whether the <c>embassies</c> region API shard is enabled in the request.</value>
        public bool Embassies
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>tags</c> region API shard is enabled in the request. The <c>tags</c> shard retrieves the region's tags.
        /// </summary>
        /// <value>A value indicating whether the <c>tags</c> region API shard is enabled in the request.</value>
        public bool Tags
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>happenings</c> region API shard is enabled in the request. The <c>happenings</c> shard retrieves the region's happenings.
        /// </summary>
        /// <value>A value indicating whether the <c>happenings</c> region API shard is enabled in the request.</value>
        public bool Happenings
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>messages</c> region API shard is enabled in the request. The <c>messages</c> shard retrieves the ten most recent messages posted on the region's message board prior to the offset specified in the request.
        /// </summary>
        /// <value>A value indicating whether the <c>messages</c> region API shard is enabled in the request.</value>
        public bool Messages
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the offset associated with the <c>messages</c> region API shard in the request. The offset represents the number of messages that will be skipped. The default offset is 0.
        /// </summary>
        /// <value>The offset associated with the <c>messages</c> region API shard in the request.</value>
        public int MessagesOffset
        {
            get
            {
                return this.messagesOffset;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The messages offset cannot be less than zero.", "MessagesOffset");
                }
                else
                {
                    this.messagesOffset = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>history</c> region API shard is enabled in the request. The <c>history</c> shard retrieves the region's history.
        /// </summary>
        /// <value>A value indicating whether the <c>history</c> region API shard is enabled in the request.</value>
        public bool History
        {
            get;
            set;
        }
    }
}
