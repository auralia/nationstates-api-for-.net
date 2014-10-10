//-----------------------------------------------------------------------
// <copyright file="WorldAssemblyData.cs" company="Auralia">
//     Copyright (C) 2013 Auralia
// </copyright>
//-----------------------------------------------------------------------

namespace Auralia.NationStates.Api
{
    using System;

    /// <summary>
    /// Represents the data returned from a NationStates World Assembly API request.
    /// </summary>
    [Serializable]
    public class WorldAssemblyData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldAssemblyData"/> class.
        /// </summary>
        public WorldAssemblyData()
        {
            this.NumberOfMembers = null;
            this.NumberOfDelegates = null;
            this.Delegates = null;
            this.Members = null;
            this.Happenings = null;
            this.MembershipHappenings = null;
            this.ResolutionAtVote = null;
            this.LastResolution = null;
        }

        /// <summary>
        /// Gets the number of World Assembly member nations. Corresponds to the <c>numnations</c> World Assembly API shard.
        /// </summary>
        /// <value>The number of World Assembly member nations.</value>
        public int? NumberOfMembers
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the number of World Assembly regional delegates. Corresponds to the <c>numdelegates</c> World Assembly API shard.
        /// </summary>
        /// <value>The number of World Assembly regional delegates.</value>
        public int? NumberOfDelegates
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the World Assembly's member nations. Corresponds to the <c>members</c> World Assembly API shard.
        /// </summary>
        /// <value>The World Assembly's member nations.</value>
        public string[] Members
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the World Assembly's regional delegates. Corresponds to the <c>delegates</c> World Assembly API shard.
        /// </summary>
        /// <value>The World Assembly's regional delegates.</value>
        public string[] Delegates
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the World Assembly's happenings. Corresponds to the <c>happenings</c> World Assembly API shard.
        /// </summary>
        /// <value>The World Assembly's happenings.</value>
        public Happening[] Happenings
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the World Assembly's membership happenings. Corresponds to the <c>memberlog</c> World Assembly API shard.
        /// </summary>
        /// <value>The World Assembly's membership happenings.</value>
        public Happening[] MembershipHappenings
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the General Assembly or Security Council resolution at vote, depending on the council specified in the request. Corresponds to the <c>resolution</c> World Assembly API shard.
        /// </summary>
        /// <value>Gets the General Assembly or Security Council resolution at vote, depending on the council specified in the request.</value>
        public Resolution ResolutionAtVote
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets a description of the last General Assembly or Security Council resolution at vote, depending on the council specified in the request. Corresponds to the <c>lastresolution</c> World Assembly API shard.
        /// </summary>
        /// <value>A description of the last General Assembly or Security Council resolution at vote, depending on the council specified in the request.</value>
        public string LastResolution
        {
            get;
            internal set;
        }

        /// <summary>
        /// Represents an entry in the World Assembly's happenings.
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
        /// Represents the General Assembly or Security Council resolution at vote, depending on the council specified in the request.
        /// </summary>
        public class Resolution
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Resolution"/> class.
            /// </summary>
            public Resolution()
            {
                this.Category = null;
                this.Created = null;
                this.Text = null;
                this.Title = null;
                this.Subcategory = null;
                this.Author = null;
                this.VotesFor = null;
                this.VotesAgainst = null;
                this.VotesForHistory = null;
                this.VotesAgainstHistory = null;
                this.DelegateVotesHistory = null;
                this.DelegateVotesFor = null;
                this.DelegateVotesAgainst = null;
            }

            /// <summary>
            /// Gets the resolution's category.
            /// </summary>
            /// <value>The resolution's category.</value>
            public string Category
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the date and time when the resolution went to vote.
            /// </summary>
            /// <value>The date and time when the resolution went to vote.</value>
            public DateTime? Created
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the resolution's text.
            /// </summary>
            /// <value>The resolution's test.</value>
            public string Text
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the resolution's title.
            /// </summary>
            /// <value>The resolution's title.</value>
            public string Title
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the resolution's subcategory. 
            /// </summary>
            /// <value>The resolution's subcategory.</value>
            public string Subcategory
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the resolution's author.
            /// </summary>
            /// <value>The resolution's author.</value>
            public string Author
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the number of votes in favor of the resolution.
            /// </summary>
            /// <value>The number of votes in favor of the resolution.</value>
            public int? VotesFor
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the number of votes against the resolution.
            /// </summary>
            /// <value>The number of votes against the resolution.</value>
            public int? VotesAgainst
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the number of votes in favor of the resolution at each hour since the resolution went to vote. Corresponds to the <c>votetrack</c> World Assembly resolution API shard.
            /// </summary>
            /// <value>A log of the number of votes in favor of the resolution at each hour since the resolution went to vote.</value>
            public int[] VotesForHistory
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the number of votes against the resolution at each hour since the resolution went to vote. Corresponds to the <c>votetrack</c> World Assembly resolution API shard.
            /// </summary>
            /// <value>A log of the number of votes against the resolution at each hour since the resolution went to vote.</value>
            public int[] VotesAgainstHistory
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets a record of delegate vote actions with respect to the resolution since it went to vote. Corresponds to the <c>dellog</c> World Assembly resolution API shard.
            /// </summary>
            /// <value>A record of delegate vote actions with respect to the resolution since it went to vote.</value>
            public DelegateVoteAction[] DelegateVotesHistory
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the delegates that have voted in favor of the resolution. Corresponds to the <c>delvotes</c> World Assembly resolution API shard.
            /// </summary>
            /// <value>The delegates that have voted in favor of the resolution.</value>
            public DelegateVote[] DelegateVotesFor
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the delegates that have voted against the resolution. Corresponds to the <c>delvotes</c> World Assembly resolution API shard.
            /// </summary>
            /// <value>The delegates that have voted against the resolution.</value>
            public DelegateVote[] DelegateVotesAgainst
            {
                get;
                internal set;
            }

            /// <summary>
            /// Represents a delegate's vote action with respect to the resolution.
            /// </summary>
            public class DelegateVoteAction
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="DelegateVoteAction"/> class.
                /// </summary>
                public DelegateVoteAction()
                {
                    this.Timestamp = null;
                    this.Name = null;
                    this.Action = null;
                    this.Votes = null;
                }

                /// <summary>
                /// Gets the date and time when the vote was made.
                /// </summary>
                /// <value>The date and time when the vote was made.</value>
                public DateTime? Timestamp
                {
                    get;
                    internal set;
                }

                /// <summary>
                /// Gets the delegate's name.
                /// </summary>
                /// <value>The delegate's name.</value>
                public string Name
                {
                    get;
                    internal set;
                }

                /// <summary>
                /// Gets the delegate's vote action.
                /// </summary>
                /// <value>The delegate's vote action.</value>
                public string Action
                {
                    get;
                    internal set;
                }

                /// <summary>
                /// Gets the delegate's number of votes.
                /// </summary>
                /// <value>The delegate's number of votes.</value>
                public int? Votes
                {
                    get;
                    internal set;
                }
            }

            /// <summary>
            /// Represents a delegate's vote on the resolution.
            /// </summary>
            public class DelegateVote
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="DelegateVote"/> class.
                /// </summary>
                public DelegateVote()
                {
                    this.Timestamp = null;
                    this.Name = null;
                    this.Votes = null;
                }

                /// <summary>
                /// Gets the date and time when the vote was made.
                /// </summary>
                /// <value>The date and time when the vote was made.</value>
                public DateTime? Timestamp
                {
                    get;
                    internal set;
                }

                /// <summary>
                /// Gets the delegate's name.
                /// </summary>
                /// <value>The delegate's name.</value>
                public string Name
                {
                    get;
                    internal set;
                }

                /// <summary>
                /// Gets the delegate's number of votes.
                /// </summary>
                /// <value>The delegate's number of votes.</value>
                public int? Votes
                {
                    get;
                    internal set;
                }
            }
        }
    }
}
