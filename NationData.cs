//-----------------------------------------------------------------------
// <copyright file="NationData.cs" company="Auralia">
//     Copyright (C) 2013 Auralia
// </copyright>
//-----------------------------------------------------------------------

namespace Auralia.NationStates.Api
{
    using System;

    /// <summary>
    /// Represents the data returned from a NationStates nation API request.
    /// </summary>
    [Serializable]
    public class NationData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NationData"/> class.
        /// </summary>
        public NationData()
        {
            this.Name = null;
            this.FullName = null;
            this.Type = null;
            this.Motto = null;
            this.Category = null;
            this.WorldAssemblyMembership = null;
            this.WorldAssemblyEndorsements = null;
            this.GeneralAssemblyVote = null;
            this.SecurityCouncilVote = null;
            this.FreedomDescriptions = null;
            this.Region = null;
            this.Population = null;
            this.TaxPercentage = null;
            this.Animal = null;
            this.AnimalDescription = null;
            this.Currency = null;
            this.Flag = null;
            this.MajorIndustry = null;
            this.Crime = null;
            this.Sensibilities = null;
            this.GovernmentBudgetPriority = null;
            this.GovernmentBudget = null;
            this.GovernmentDescription = null;
            this.EconomyDescription = null;
            this.Notable = null;
            this.Admirable = null;
            this.Founded = null;
            this.FirstLogin = null;
            this.LastLogin = null;
            this.LastActivity = null;
            this.Influence = null;
            this.FreedomScores = null;
            this.PublicSectorPercentage = null;
            this.CausesOfDeath = null;
            this.Leader = null;
            this.Capital = null;
            this.Religion = null;
            this.RegionalCensusRanking = null;
            this.WorldCensusRanking = null;
            this.CensusStatistics = null;
            this.Legislation = null;
            this.Happenings = null;
            this.DemonymAdjective = null;
            this.DemonymNoun = null;
            this.DemonymNounPlural = null;
            this.NumberOfFactbooks = null;
            this.FactbookMetadata = null;
            this.NumberOfDispatches = null;
            this.DispatchMetadata = null;
        }

        /// <summary>
        /// Gets the nation's name. Corresponds to the <c>name</c> nation API shard.
        /// </summary>
        /// <value>The nation's name.</value>
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's full name. Corresponds to the <c>fullname</c> nation API shard.
        /// </summary>
        /// <value>The nation's full name.</value>
        public string FullName
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's type. Corresponds to the <c>type</c> nation API shard. 
        /// </summary>
        /// <value>The nation's type.</value>
        public string Type
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's motto. Corresponds to the <c>motto</c> nation API shard.
        /// </summary>
        /// <value>The nation's motto.</value>
        public string Motto
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's category. Corresponds to the <c>category</c> nation API shard.
        /// </summary>
        /// <value>The nation's category.</value>
        public string Category
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's World Assembly membership status. Corresponds to the <c>wa</c> nation API shard.
        /// </summary>
        /// <value>The nation's World Assembly membership status.</value>
        public string WorldAssemblyMembership
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the World Assembly endorsements the nation has received. Corresponds to the <c>endorsements</c> nation API shard.
        /// </summary>
        /// <value>The World Assembly endorsements the nation has received.</value>
        public string[] WorldAssemblyEndorsements
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's vote on the General Assembly resolution at vote. Corresponds to the <c>gavote</c> nation API shard.
        /// </summary>
        /// <value>The nation's vote on the General Assembly resolution at vote.</value>
        public string GeneralAssemblyVote
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's vote on the Security Council resolution at vote. Corresponds to the <c>scvote</c> nation API shard.
        /// </summary>
        /// <value>The nation's vote on the Security Council resolution at vote.</value>
        public string SecurityCouncilVote
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's Civil Rights, Economy and Political Freedoms descriptions. Corresponds to the <c>freedom</c> nation API shard.
        /// </summary>
        /// <value>The nation's Civil Rights, Economy and Political Freedoms descriptions.</value>
        public FreedomDescriptionsData FreedomDescriptions
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's region. Corresponds to the <c>region</c> nation API shard.
        /// </summary>
        /// <value>The nation's region.</value>
        public string Region
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's population in millions. Corresponds to the <c>population</c> nation API shard.
        /// </summary>
        /// <value>The nation's population.</value>
        public int? Population
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's tax percentage. Corresponds to the <c>tax</c> nation API shard.
        /// </summary>
        /// <value>The nation's tax percentage.</value>
        public int? TaxPercentage
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's national animal. Corresponds to the <c>animal</c> nation API shard.
        /// </summary>
        /// <value>The nation's national animal.</value>
        public string Animal
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets a description of the nation's national animal. Corresponds to the <c>animaltrait</c> nation API shard.
        /// </summary>
        /// <value>A description of the nation's national animal.</value>
        public string AnimalDescription
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's currency. Corresponds to the <c>currency</c> nation API shard.
        /// </summary>
        /// <value>The nation's currency.</value>
        public string Currency
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's flag. Corresponds to the <c>flag</c> nation API shard.
        /// </summary>
        /// <value>The nation's flag.</value>
        public Uri Flag
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's major industry. Corresponds to the <c>majorindustry</c> nation API shard.
        /// </summary>
        /// <value>The nation's major industry.</value>
        public string MajorIndustry
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets a description of the nation's crime rate. Corresponds to the <c>crime</c> nation API shard.
        /// </summary>
        /// <value>A description of the nation's crime rate.</value>
        public string Crime
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's sensibilities. Corresponds to the <c>sensibilities</c> nation API shard.
        /// </summary>
        /// <value>The nation's sensibilities.</value>
        public string Sensibilities
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the category that is allocated the most funds from the nation's government budget. Corresponds to the <c>govtpriority</c> nation API shard.
        /// </summary>
        /// <value>The category that is allocated the most funds from the nation's government budget.</value>
        public string GovernmentBudgetPriority
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's government budget. Corresponds to the <c>govt</c> nation API shard.
        /// </summary>
        /// <value>The nation's government budget.</value>
        public GovernmentBudgetData GovernmentBudget
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets a description of the nation's government. Corresponds to the <c>govtdesc</c> nation API shard.
        /// </summary>
        /// <value>A description of the nation's government.</value>
        public string GovernmentDescription
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets a description of the nation's economy. Corresponds to the <c>industrydesc</c> nation API shard.
        /// </summary>
        /// <value>A description of the nation's economy.</value>
        public string EconomyDescription
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's notable characteristic. Corresponds to the <c>notable</c> nation API shard.
        /// </summary>
        /// <value>The nation's notable characteristic.</value>
        public string Notable
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's admirable characteristic. Corresponds to the <c>admirable</c> nation API shard.
        /// </summary>
        /// <value>The nation's admirable characteristic.</value>
        public string Admirable
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the date and time of the nation's founding. Corresponds to the <c>founded</c> nation API shard.
        /// </summary>
        /// <value>The date and time of the nation's founding.</value>
        public string Founded
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the date and time of the nation's first login. Corresponds to the <c>firstlogin</c> nation API shard.
        /// </summary>
        /// <value>The date and time of the nation's first login.</value>
        public DateTime? FirstLogin
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the date and time of the nation's most recent login. Corresponds to the <c>lastlogin</c> nation API shard.
        /// </summary>
        /// <value>The date and time of the nation's most recent login.</value>
        public DateTime? LastLogin
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the date and time of the nation's most recent activity. Corresponds to the <c>lastactivity</c> nation API shard.
        /// </summary>
        /// <value>The date and time of the nation's most recent activity.</value>
        public string LastActivity
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's influence. Corresponds to the <c>influence</c> nation API shard.
        /// </summary>
        /// <value>The nation's influence.</value>
        public string Influence
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's Civil Rights, Economy and Political Freedoms scores. Corresponds to the <c>freedomscores</c> nation API shard.
        /// </summary>
        /// <value>The nation's Civil Rights, Economy and Political Freedoms scores</value>
        public FreedomScoresData FreedomScores
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the percentage of the nation's economy that consists of the public sector. Corresponds to the <c>publicsector</c> nation API shard.
        /// </summary>
        /// <value>The percentage of the nation's economy that consists of the public sector.</value>
        public double? PublicSectorPercentage
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the causes of death in the nation. Corresponds to the <c>deaths</c> nation API shard.
        /// </summary>
        /// <value>The causes of death in the nation.</value>
        public CauseOfDeath[] CausesOfDeath
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's leader. Corresponds to the <c>leader</c> nation API shard.
        /// </summary>
        /// <value>The nation's leader.</value>
        public string Leader
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's capital. Corresponds to the <c>capital</c> nation API shard.
        /// </summary>
        /// <value>The nation's capital.</value>
        public string Capital
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's religion. Corresponds to the <c>religion</c> nation API shard.
        /// </summary>
        /// <value>The nation's religion.</value>
        public string Religion
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's regional ranking for the daily census. Corresponds to the <c>rcensus</c> nation API shard.
        /// </summary>
        /// <value>The nation's regional ranking for the daily census.</value>
        public int? RegionalCensusRanking
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's world ranking for the daily census. Corresponds to the <c>wcensus</c> nation API shard.
        /// </summary>
        /// <value>The nation's world ranking for the daily census.</value>
        public int? WorldCensusRanking
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's census statistics with the IDs specified in the request. Corresponds to the <c>censusscore</c> and <c>censusscore-N</c> nation API shards.
        /// </summary>
        /// <value>The nation's census statistics with the IDs specified in the request.</value>
        public CensusStatistic[] CensusStatistics
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's most recent passed legislation. Corresponds to the <c>legislation</c> nation API shard.
        /// </summary>
        /// <value>The nation's most recent passed legislation.</value>
        public string[] Legislation
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's happenings. Corresponds to the <c>happenings</c> nation API shard.
        /// </summary>
        /// <value>The nation's happenings.</value>
        public Happening[] Happenings
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's demonym in adjective form. Corresponds to the <c>demonym</c> nation API shard.
        /// </summary>
        /// <value>The nation's demonym in adjective form.</value>
        public string DemonymAdjective
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's demonym in noun form. Corresponds to the <c>demonym2</c> nation API shard.
        /// </summary>
        /// <value>The nation's demonym in noun form.</value>
        public string DemonymNoun
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the nation's demonym in plural noun form. Corresponds to the <c>demonym2plural</c> nation API shard.
        /// </summary>
        /// <value>The nation's demonym in plural noun form.</value>
        public string DemonymNounPlural
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the number of factbooks the nation has created. Corresponds to the <c>factbooks</c> nation API shard.
        /// </summary>
        /// <value>The number of factbooks the nation has created.</value>
        public int? NumberOfFactbooks
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the metadata for the factbooks specified in the request. Corresponds to the <c>factbooklist</c> nation API shard.
        /// </summary>
        /// <value>The metadata for the factbooks specified in the request.</value>
        public FactbookMetadataData[] FactbookMetadata
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the number of dispatches the nation has created. Corresponds to the <c>dispatches</c> nation API shard.
        /// </summary>
        /// <value>The number of dispatches the nation has created.</value>
        public int? NumberOfDispatches
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the metadata for the dispatches specified in the request. Corresponds to the <c>dispatchlist</c> nation API shard.
        /// </summary>
        /// <value>The metadata for the dispatches specified in the request.</value>
        public DispatchMetadataData[] DispatchMetadata
        {
            get;
            internal set;
        }

        /// <summary>
        /// Represents the nation's Civil Rights, Economy and Political Freedoms descriptions.
        /// </summary>
        public class FreedomDescriptionsData
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FreedomDescriptionsData"/> class.
            /// </summary>
            public FreedomDescriptionsData()
            {
                this.CivilRights = null;
                this.Economy = null;
                this.PoliticalFreedoms = null;
            }

            /// <summary>
            /// Gets the nation's Civil Rights description.
            /// </summary>
            /// <value>The nation's Civil Rights description.</value>
            public string CivilRights
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the nation's Economy description.
            /// </summary>
            /// <value>The nation's Economy description.</value>
            public string Economy
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the nation's Political Freedoms description.
            /// </summary>
            /// <value>The nation's Political Freedoms description.</value>
            public string PoliticalFreedoms
            {
                get;
                internal set;
            }
        }

        /// <summary>
        /// Represents the nation's government budget.
        /// </summary>
        public class GovernmentBudgetData
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="GovernmentBudgetData"/> class.
            /// </summary>
            public GovernmentBudgetData()
            {
                this.EnvironmentPercentage = null;
                this.SocialEqualityPercentage = null;
                this.EducationPercentage = null;
                this.LawAndOrderPercentage = null;
                this.AdministrationPercentage = null;
                this.WelfarePercentage = null;
                this.SpiritualityPercentage = null;
                this.DefensePercentage = null;
                this.PublicTransportPercentage = null;
                this.HealthcarePercentage = null;
                this.CommercePercentage = null;
            }

            /// <summary>
            /// Gets the percentage of the government budget allocated to the Environment.
            /// </summary>
            /// <value>The percentage of the government budget allocated to the Environment.</value>
            public double? EnvironmentPercentage
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the percentage of the government budget allocated to Social Equality.
            /// </summary>
            /// <value>The percentage of the government budget allocated to Social Equality.</value>
            public double? SocialEqualityPercentage
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the percentage of the government budget allocated to Education.
            /// </summary>
            /// <value>The percentage of the government budget allocated to Education.</value>
            public double? EducationPercentage
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the percentage of the government budget allocated to Law and Order.
            /// </summary>
            /// <value>The percentage of the government budget allocated to Law and Order.</value>
            public double? LawAndOrderPercentage
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the percentage of the government budget allocated to Administration.
            /// </summary>
            /// <value>The percentage of the government budget allocated to Administration.</value>
            public double? AdministrationPercentage
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the percentage of the government budget allocated to Welfare.
            /// </summary>
            /// <value>The percentage of the government budget allocated to Welfare.</value>
            public double? WelfarePercentage
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the percentage of the government budget allocated to Spirituality.
            /// </summary>
            /// <value>The percentage of the government budget allocated to Spirituality.</value>
            public double? SpiritualityPercentage
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the percentage of the government budget allocated to Defense.
            /// </summary>
            /// <value>The percentage of the government budget allocated to Defense.</value>
            public double? DefensePercentage
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the percentage of the government budget allocated to Public Transport.
            /// </summary>
            /// <value>The percentage of the government budget allocated to Public Transport.</value>
            public double? PublicTransportPercentage
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the percentage of the government budget allocated to Healthcare.
            /// </summary>
            /// <value>The percentage of the government budget allocated to Healthcare.</value>
            public double? HealthcarePercentage
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the percentage of the government budget allocated to Commerce.
            /// </summary>
            /// <value>The percentage of the government budget allocated to Commerce.</value>
            public double? CommercePercentage
            {
                get;
                internal set;
            }
        }

        /// <summary>
        /// Represents the nation's Civil Rights, Economy and Political Freedoms scores.
        /// </summary>
        public class FreedomScoresData
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FreedomScoresData"/> class.
            /// </summary>
            public FreedomScoresData()
            {
                this.CivilRights = null;
                this.Economy = null;
                this.PoliticalFreedoms = null;
            }

            /// <summary>
            /// Gets the nation's Civil Rights score.
            /// </summary>
            /// <value>The nation's Civil Rights score.</value>
            public int? CivilRights
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the nation's Economy score.
            /// </summary>
            /// <value>The nation's Economy score.</value>
            public int? Economy
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the nation's Political Freedoms score.
            /// </summary>
            /// <value>The nation's Political Freedoms score.</value>
            public int? PoliticalFreedoms
            {
                get;
                internal set;
            }
        }

        /// <summary>
        /// Represents a cause of death in a nation.
        /// </summary>
        public class CauseOfDeath
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CauseOfDeath"/> class.
            /// </summary>
            public CauseOfDeath()
            {
                this.Name = null;
                this.Percentage = null;
            }

            /// <summary>
            /// Gets the name of the cause of death.
            /// </summary>
            /// <value>The name of the cause of death.</value>
            public string Name
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the percentage of the nation's deaths resulting from the cause of death.
            /// </summary>
            /// <value>The percentage of the nation's deaths resulting from the cause of death.</value>
            public double? Percentage
            {
                get;
                internal set;
            }
        }

        /// <summary>
        /// Represents a census statistic.
        /// </summary>
        public class CensusStatistic
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CensusStatistic"/> class.
            /// </summary>
            public CensusStatistic()
            {
                this.Id = null;
                this.Value = null;
            }

            /// <summary>
            /// Gets the ID of the census statistic.
            /// </summary>
            /// <value>The ID of the census statistic.</value>
            public int? Id
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the value of the census statistic.
            /// </summary>
            /// <value>The value of the census statistic.</value>
            public double? Value
            {
                get;
                internal set;
            }
        }

        /// <summary>
        /// Represents an entry in a nation's happenings.
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
        /// Represents the metadata associated with a factbook.
        /// </summary>
        public class FactbookMetadataData
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FactbookMetadataData"/> class.
            /// </summary>
            public FactbookMetadataData()
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
            /// Gets the factbook's ID.
            /// </summary>
            /// <value>The factbook's ID.</value>
            public int? Id
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the factbook's title.
            /// </summary>
            /// <value>The factbook's title.</value>
            public string Title
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the factbook's author.
            /// </summary>
            /// <value>The factbook's author.</value>
            public string Author
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the factbook's category.
            /// </summary>
            /// <value>The factbook's category.</value>
            public string Category
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the factbook's subcategory.
            /// </summary>
            /// <value>The factbook's subcategory.</value>
            public string Subcategory
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the date on which the factbook was created.
            /// </summary>
            /// <value>The date on which the factbook was created.</value>
            public DateTime? DateCreated
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the date on which the factbook was last edited.
            /// </summary>
            /// <value>The date on which the factbook was last edited.</value>
            public DateTime? DateEdited
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the number of views the factbook has received.
            /// </summary>
            /// <value>The number of views the factbook has received.</value>
            public int? NumberOfViews
            {
                get;
                internal set;
            }

            /// <summary>
            /// Gets the factbook's score.
            /// </summary>
            /// <value>The factbook's score.</value>
            public int? Score
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
    }
}