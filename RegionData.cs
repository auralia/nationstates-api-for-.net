//-----------------------------------------------------------------------
// <copyright file="RegionData.cs" company="Auralia">
//     Copyright (C) 2013 Auralia
// </copyright>
//-----------------------------------------------------------------------

namespace Auralia.NationStates.Api
{
    using System;

    /// <summary>
    /// Represents the data returned from a NationStates region API request.
    /// </summary>
    [Serializable]
    public class RegionData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegionData"/> class.
        /// </summary>
        public RegionData()
        {
            this.Name = null;
            this.Factbook = null;
            this.NumberOfNations = null;
            this.Nations = null;
            this.Delegate = null;
            this.NumberOfDelegateVotes = null;
            this.GeneralAssemblyVote = null;
            this.SecurityCouncilVote = null;
            this.Founder = null;
            this.Power = null;
            this.Flag = null;
            this.Embassies = null;
            this.Tags = null;
            this.Happenings = null;
            this.Messages = null;
            this.History = null;
            this.Poll = null;
        }

        /// <summary>
        /// Gets the region's name. Corresponds to the <c>name</c> region API shard.
        /// </summary>
        /// <value>The region's name.</value>
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the region's fact book. Corresponds to the <c>factbook</c> region API shard.
        /// </summary>
        /// <value>The region's fact book.</value>
        public string Factbook
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the number of nations in the region. Corresponds to the <c>numnations</c> region API shard.
        /// </summary>
        /// <value>The number of nations in the region.</value>
        public int? NumberOfNations
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nations in the region. Corresponds to the <c>nations</c> region API shard.
        /// </summary>
        /// <value>The nations in the region.</value>
        public string[] Nations
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the region's World Assembly delegate. Corresponds to the <c>delegate</c> region API shard.
        /// </summary>
        /// <value>The region's World Assembly delegate.</value>
        public string Delegate
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the delegate's number of votes in the World Assembly. Corresponds to the <c>delegatevotes</c> region API shard.
        /// </summary>
        /// <value>The delegate's number of votes in the World Assembly.</value>
        public int? NumberOfDelegateVotes
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the number of votes by the region's nations on the General Assembly resolution at vote. Corresponds to the <c>gavote</c> region API shard.
        /// </summary>
        /// <value>The number of votes by the region's nations on the General Assembly resolution at vote.</value>
        public Votes GeneralAssemblyVote
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the number of votes by the region's nations on the Security Council resolution at vote. Corresponds to the <c>scvote</c> region API shard.
        /// </summary>
        /// <value>The number of votes by the region's nations on the Security Council resolution at vote.</value>
        public Votes SecurityCouncilVote
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the region's founder. Corresponds to the <c>founder</c> region API shard.
        /// </summary>
        /// <value>The region's founder.</value>
        public string Founder
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the region's power. Corresponds to the <c>power</c> region API shard.
        /// </summary>
        /// <value>The region's power.</value>
        public string Power
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the region's flag. Corresponds to the <c>flag</c> region API shard.
        /// </summary>
        /// <value>The region's flag.</value>
        public Uri Flag
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the region's embassies. Corresponds to the <c>embassies</c> region API shard.
        /// </summary>
        /// <value>The region's embassies.</value>
        public Embassy[] Embassies
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the region's tags. Corresponds to the <c>tags</c> region API shard.
        /// </summary>
        /// <value>The region's tags.</value>
        public string[] Tags
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the region's happenings. Corresponds to the <c>happenings</c> region API shard.
        /// </summary>
        /// <value>The region's happenings.</value>
        public Happening[] Happenings
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the ten most recent messages posted on the region's message board prior to the offset specified in the request. Corresponds to the <c>messages</c> region API shard.
        /// </summary>
        /// <value>The ten most recent messages posted on the region's message board prior to the offset specified in the request.</value>
        public Message[] Messages
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the region's history. Corresponds to the <c>history</c> region API shard.
        /// </summary>
        /// <value>The region's history.</value>
        public HistoryEntry[] History
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the region's polls. Corresponds to the <c>poll</c> region API shard.
        /// </summary>
        /// <value>The region's polls.</value>
        public PollData Poll
        {
            get;
            internal set;
        }

        /// <summary>
        /// Represents the number of votes by a region's nations on a World Assembly resolution at vote.
        /// </summary>
        public class Votes
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Votes"/> class.
            /// </summary>
            public Votes()
            {
                this.For = null;
                this.Against = null;
            }

            /// <summary>
            /// Gets the number of votes by the region's nations in favor of the resolution.
            /// </summary>
            /// <value>The number of votes by the region's nations in favor of the resolution.</value>
            public int? For
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the number of votes by the region's nations against the resolution.
            /// </summary>
            /// <value>The number of votes by the region's nations against the resolution.</value>
            public int? Against
            {
                get;
                internal set;
            }
        }

        /// <summary>
        /// Represents an embassy with another region.
        /// </summary>
        public class Embassy
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Embassy"/> class.
            /// </summary>
            public Embassy()
            {
                this.Region = null;
                this.Status = null;
            }

            /// <summary>
            /// Gets the region in which the embassy is located.
            /// </summary>
            /// <value>The region in which the embassy is located.</value>
            public string Region
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the embassy's status.
            /// </summary>
            /// <value>The embassy's status.</value>
            public string Status
            {
                get;
                internal set;
            }
        }

        /// <summary>
        /// Represents an entry in a region's happenings.
        /// </summary>
        public class Happening
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Happening"/> class.
            /// </summary>
            public Happening()
            {
                this.Timestamp = null;
                this.Text = null;
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

        /// <summary>
        /// Represents a message on a region's message board.
        /// </summary>
        public class Message
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Message"/> class.
            /// </summary>
            public Message()
            {
                this.Timestamp = null;
                this.Nation = null;
                this.Text = null;
            }

            /// <summary>
            /// Gets the message's timestamp.
            /// </summary>
            /// <value>The message's timestamp.</value>
            public DateTime? Timestamp
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the nation that posted the message.
            /// </summary>
            /// <value>The nation that posted the message.</value>
            public string Nation
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the message's text.
            /// </summary>
            /// <value>The message's text.</value>
            public string Text
            {
                get;
                internal set;
            }
        }

        /// <summary>
        /// Represents an entry in a region's history.
        /// </summary>
        public class HistoryEntry
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="HistoryEntry"/> class.
            /// </summary>
            public HistoryEntry()
            {
                this.Timestamp = null;
                this.Text = null;
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

        /// <summary>
        /// Represents a region's poll.
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
                this.Text = null;
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
    }
}