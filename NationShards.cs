//-----------------------------------------------------------------------
// <copyright file="NationShards.cs" company="Auralia">
//     Copyright (C) 2013 Auralia
// </copyright>
//-----------------------------------------------------------------------

namespace Auralia.NationStates.Api
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the shards included in a NationStates nation API request. If no shards are enabled, the API will return a standard set of nation data.
    /// </summary>
    public class NationShards
    {
        /// <summary>
        /// A list containing the census IDs associated with the <c>censusscore</c> or <c>censusscore-N</c> nation API shards in the request.
        /// </summary>
        private List<int?> censusStatisticsIds;

        /// <summary>
        /// Initializes a new instance of the <see cref="NationShards"/> class.
        /// </summary>
        /// <param name="enableAll">A value indicating whether all shards are enabled in the request.</param>
        public NationShards(bool enableAll = false)
        {
            this.Name = enableAll;
            this.FullName = enableAll;
            this.Type = enableAll;
            this.Motto = enableAll;
            this.Category = enableAll;
            this.WorldAssemblyMembership = enableAll;
            this.WorldAssemblyEndorsements = enableAll;
            this.GeneralAssemblyVote = enableAll;
            this.SecurityCouncilVote = enableAll;
            this.FreedomDescriptions = enableAll;
            this.Region = enableAll;
            this.Population = enableAll;
            this.TaxPercentage = enableAll;
            this.Animal = enableAll;
            this.AnimalDescription = enableAll;
            this.Currency = enableAll;
            this.Flag = enableAll;
            this.MajorIndustry = enableAll;
            this.Crime = enableAll;
            this.Sensibilities = enableAll;
            this.GovernmentBudgetPriority = enableAll;
            this.GovernmentBudget = enableAll;
            this.GovernmentDescription = enableAll;
            this.EconomyDescription = enableAll;
            this.Notable = enableAll;
            this.Admirable = enableAll;
            this.Founded = enableAll;
            this.FirstLogin = enableAll;
            this.LastLogin = enableAll;
            this.LastActivity = enableAll;
            this.Influence = enableAll;
            this.FreedomScores = enableAll;
            this.PublicSectorPercentage = enableAll;
            this.CausesOfDeath = enableAll;
            this.Leader = enableAll;
            this.Capital = enableAll;
            this.Religion = enableAll;
            this.RegionalCensusRanking = enableAll;
            this.WorldCensusRanking = enableAll;
            this.CensusStatistics = enableAll;
            this.CensusStatisticsIds = new List<int?>(new int?[] { null });
            this.Legislation = enableAll;
            this.Happenings = enableAll;
            this.DemonymAdjective = enableAll;
            this.DemonymNoun = enableAll;
            this.DemonymNounPlural = enableAll;
            this.NumberOfFactbooks = enableAll;
            this.FactbookMetadata = enableAll;
            this.NumberOfDispatches = enableAll;
            this.DispatchMetadata = enableAll;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>name</c> nation API shard is enabled in the request. The <c>name</c> shard retrieves the nation's name.
        /// </summary>
        /// <value>A value indicating whether the <c>name</c> nation API shard is enabled in the request.</value>
        public bool Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>fullname</c> nation API shard is enabled in the request. The <c>fullname</c> shard retrieves the nation's full name.
        /// </summary>
        /// <value>A value indicating whether the <c>fullname</c> nation API shard is enabled in the request.</value>
        public bool FullName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>type</c> nation API shard is enabled in the request. The <c>type</c> shard retrieves the nation's type.
        /// </summary>
        /// <value>A value indicating whether the <c>type</c> nation API shard is enabled in the request.</value>
        public bool Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>motto</c> nation API shard is enabled in the request. The <c>motto</c> shard retrieves the nation's motto.
        /// </summary>
        /// <value>A value indicating whether the <c>motto</c> nation API shard is enabled in the request.</value>
        public bool Motto
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>category</c> nation API shard is enabled in the request. The <c>category</c> shard retrieves the nation's category.
        /// </summary>
        /// <value>A value indicating whether the <c>category</c> nation API shard is enabled in the request.</value>
        public bool Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>wa</c> nation API shard is enabled in the request. The <c>wa</c> shard retrieves the nation's World Assembly membership status.
        /// </summary>
        /// <value>A value indicating whether the <c>wa</c> nation API shard is enabled in the request.</value>
        public bool WorldAssemblyMembership
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>endorsements</c> nation API shard is enabled in the request. The <c>endorsements</c> shard retrieves the World Assembly endorsements the nation has received.
        /// </summary>
        /// <value>A value indicating whether the <c>endorsements</c> nation API shard is enabled in the request.</value>
        public bool WorldAssemblyEndorsements
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>gavote</c> nation API shard is enabled in the request. The <c>gavote</c> shard retrieves the nation's vote on the General Assembly resolution at vote.
        /// </summary>
        /// <value>A value indicating whether the <c>gavote</c> nation API shard is enabled in the request.</value>
        public bool GeneralAssemblyVote
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>scvote</c> nation API shard is enabled in the request. The <c>scvote</c> shard retrieves the nation's vote on the Security Council resolution at vote.
        /// </summary>
        /// <value>A value indicating whether the <c>scvote</c> nation API shard is enabled in the request.</value>
        public bool SecurityCouncilVote
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>freedom</c> nation API shard is enabled in the request. The <c>freedom</c> shard retrieves the nation's Civil Rights, Economy and Political Freedoms descriptions.
        /// </summary>
        /// <value>A value indicating whether the <c>freedom</c> nation API shard is enabled in the request.</value>
        public bool FreedomDescriptions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>region</c> nation API shard is enabled in the request. The <c>region</c> shard retrieves the nation's region.
        /// </summary>
        /// <value>A value indicating whether the <c>region</c> nation API shard is enabled in the request.</value>
        public bool Region
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>population</c> nation API shard is enabled in the request. The <c>population</c> shard retrieves the nation's population.
        /// </summary>
        /// <value>A value indicating whether the <c>population</c> nation API shard is enabled in the request.</value>
        public bool Population
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>tax</c> nation API shard is enabled in the request. The <c>tax</c> shard retrieves the nation's tax percentage.
        /// </summary>
        /// <value>A value indicating whether the <c>tax</c> nation API shard is enabled in the request.</value>
        public bool TaxPercentage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>animal</c> nation API shard is enabled in the request. The <c>animal</c> shard retrieves the nation's national animal.
        /// </summary>
        /// <value>A value indicating whether the <c>animal</c> nation API shard is enabled in the request.</value>
        public bool Animal
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>animaltrait</c> nation API shard is enabled in the request. The <c>animaltrait</c> shard retrieves a description of the nation's national animal.
        /// </summary>
        /// <value>A value indicating whether the <c>animaltrait</c> nation API shard is enabled in the request.</value>
        public bool AnimalDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>currency</c> nation API shard is enabled in the request. The <c>currency</c> shard retrieves the nation's currency.
        /// </summary>
        /// <value>A value indicating whether the <c>currency</c> nation API shard is enabled in the request.</value>
        public bool Currency
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>flag</c> nation API shard is enabled in the request. The <c>flag</c> shard retrieves the nation's flag.
        /// </summary>
        /// <value>A value indicating whether the <c>flag</c> nation API shard is enabled in the request.</value>
        public bool Flag
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>majorindustry</c> nation API shard is enabled in the request. The <c>majorindustry</c> shard retrieves the nation's major industry.
        /// </summary>
        /// <value>A value indicating whether the <c>majorindustry</c> nation API shard is enabled in the request.</value>
        public bool MajorIndustry
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>crime</c> nation API shard is enabled in the request. The <c>crime</c> shard retrieves a description of the nation's crime rate.
        /// </summary>
        /// <value>A value indicating whether the <c>crime</c> nation API shard is enabled in the request.</value>
        public bool Crime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>sensibilities</c> nation API shard is enabled in the request. The <c>sensibilities</c> shard retrieves the nation's sensibilities.
        /// </summary>
        /// <value>A value indicating whether the <c>sensibilities</c> nation API shard is enabled in the request.</value>
        public bool Sensibilities
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>govtpriority</c> nation API shard is enabled in the request. The <c>flag</c> shard retrieves the category that is allocated the most funds from the nation's government budget.
        /// </summary>
        /// <value>A value indicating whether the <c>govtpriority</c> nation API shard is enabled in the request.</value>
        public bool GovernmentBudgetPriority
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>govt</c> nation API shard is enabled in the request. The <c>govt</c> shard retrieves the nation's government budget.
        /// </summary>
        /// <value>A value indicating whether the <c>govt</c> nation API shard is enabled in the request.</value>
        public bool GovernmentBudget
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>govtdesc</c> nation API shard is enabled in the request. The <c>govtdesc</c> shard retrieves a description of the nation's government.
        /// </summary>
        /// <value>A value indicating whether the <c>govtdesc</c> nation API shard is enabled in the request.</value>
        public bool GovernmentDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>industrydesc</c> nation API shard is enabled in the request. The <c>industrydesc</c> shard retrieves a description of the nation's economy.
        /// </summary>
        /// <value>A value indicating whether the <c>industrydesc</c> nation API shard is enabled in the request.</value>
        public bool EconomyDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>notable</c> nation API shard is enabled in the request. The <c>notable</c> shard retrieves the nation's notable characteristic.
        /// </summary>
        /// <value>A value indicating whether the <c>notable</c> nation API shard is enabled in the request.</value>
        public bool Notable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>admirable</c> nation API shard is enabled in the request. The <c>admirable</c> shard retrieves the nation's admirable characteristic.
        /// </summary>
        /// <value>A value indicating whether the <c>admirable</c> nation API shard is enabled in the request.</value>
        public bool Admirable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>founded</c> nation API shard is enabled in the request. The <c>founded</c> shard retrieves the date and time of the nation's founding.
        /// </summary>
        /// <value>A value indicating whether the <c>founded</c> nation API shard is enabled in the request.</value>
        public bool Founded
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>firstlogin</c> nation API shard is enabled in the request. The <c>firstlogin</c> shard retrieves the date and time of the nation's first login.
        /// </summary>
        /// <value>A value indicating whether the <c>firstlogin</c> nation API shard is enabled in the request.</value>
        public bool FirstLogin
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>lastlogin</c> nation API shard is enabled in the request. The <c>lastlogin</c> shard retrieves the date and time of the nation's most recent login.
        /// </summary>
        /// <value>A value indicating whether the <c>lastlogin</c> nation API shard is enabled in the request.</value>
        public bool LastLogin
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>lastactivity</c> nation API shard is enabled in the request. The <c>lastactivity</c> shard retrieves the date and time of the nation's most recent activity.
        /// </summary>
        /// <value>A value indicating whether the <c>lastactivity</c> nation API shard is enabled in the request.</value>
        public bool LastActivity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>influence</c> nation API shard is enabled in the request. The <c>influence</c> shard retrieves the nation's influence.
        /// </summary>
        /// <value>A value indicating whether the <c>influence</c> nation API shard is enabled in the request.</value>
        public bool Influence
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>freedomscores</c> nation API shard is enabled in the request. The <c>freedomscores</c> shard retrieves the nation's Civil Rights, Economy and Political Freedoms scores.
        /// </summary>
        /// <value>A value indicating whether the <c>freedomscores</c> nation API shard is enabled in the request.</value>
        public bool FreedomScores
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>publicsector</c> nation API shard is enabled in the request. The <c>publicsector</c> shard retrieves the percentage of the nation's economy that consists of the public sector.
        /// </summary>
        /// <value>A value indicating whether the <c>publicsector</c> nation API shard is enabled in the request.</value>
        public bool PublicSectorPercentage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>deaths</c> nation API shard is enabled in the request. The <c>deaths</c> shard retrieves the causes of death in the nation.
        /// </summary>
        /// <value>A value indicating whether the <c>deaths</c> nation API shard is enabled in the request.</value>
        public bool CausesOfDeath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>leader</c> nation API shard is enabled in the request. The <c>leader</c> shard retrieves the nation's leader.
        /// </summary>
        /// <value>A value indicating whether the <c>leader</c> nation API shard is enabled in the request.</value>
        public bool Leader
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>capital</c> nation API shard is enabled in the request. The <c>capital</c> shard retrieves the nation's capital.
        /// </summary>
        /// <value>A value indicating whether the <c>capital</c> nation API shard is enabled in the request.</value>
        public bool Capital
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>religion</c> nation API shard is enabled in the request. The <c>religion</c> shard retrieves the nation's religion.
        /// </summary>
        /// <value>A value indicating whether the <c>religion</c> nation API shard is enabled in the request.</value>
        public bool Religion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>rcensus</c> nation API shard is enabled in the request. The <c>rcensus</c> shard retrieves the nation's regional ranking for the daily census.
        /// </summary>
        /// <value>A value indicating whether the <c>rcensus</c> nation API shard is enabled in the request.</value>
        public bool RegionalCensusRanking
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>wcensus</c> nation API shard is enabled in the request. The <c>wcensus</c> shard retrieves the nation's world ranking for the daily census.
        /// </summary>
        /// <value>A value indicating whether the <c>wcensus</c> nation API shard is enabled in the request.</value>
        public bool WorldCensusRanking
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>censusscore</c> or <c>censusscore-N</c> nation API shard is enabled in the request. The <c>censusscore</c> and <c>censusscore-N</c> shard retrieves the nation's census statistics with the IDs specified in the request.
        /// </summary>
        /// <value>A value indicating whether the <c>censusscore</c> or <c>censusscore-N</c> nation API shard is enabled in the request.</value>
        public bool CensusStatistics
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a list containing the census IDs associated with the <c>censusscore</c> or <c>censusscore-N</c> nation API shards in the request. A value of null in the array represents the ID of the daily census. The default list contains a single null reference.
        /// </summary>
        /// <value>The census IDs associated with the <c>censusscore</c> or <c>censusscore-N</c> nation API shards in the request.</value>
        public List<int?> CensusStatisticsIds
        {
            get
            {
                return this.censusStatisticsIds;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("CensusStatisticsIds", "The list containing the census IDs cannot be null.");
                }
                else
                {
                    this.censusStatisticsIds = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>legislation</c> nation API shard is enabled in the request. The <c>legislation</c> shard retrieves the nation's legislation.
        /// </summary>
        /// <value>A value indicating whether the <c>legislation</c> nation API shard is enabled in the request.</value>
        public bool Legislation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>happenings</c> nation API shard is enabled in the request. The <c>happenings</c> shard retrieves the nation's happenings.
        /// </summary>
        /// <value>A value indicating whether the <c>happenings</c> nation API shard is enabled in the request.</value>
        public bool Happenings
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>denonym</c> nation API shard is enabled in the request. The <c>demonym</c> shard retrieves the nation's demonym in adjective form.
        /// </summary>
        /// <value>A value indicating whether the <c>denonym</c> nation API shard is enabled in the request.</value>
        public bool DemonymAdjective
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>denonym2</c> nation API shard is enabled in the request. The <c>demonym</c> shard retrieves the nation's demonym in noun form.
        /// </summary>
        /// <value>A value indicating whether the <c>denonym2</c> nation API shard is enabled in the request.</value>
        public bool DemonymNoun
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>denonym2plural</c> nation API shard is enabled in the request. The <c>demonym</c> shard retrieves the nation's demonym in plural noun form.
        /// </summary>
        /// <value>A value indicating whether the <c>denonym2plural</c> nation API shard is enabled in the request.</value>
        public bool DemonymNounPlural
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>factbooks</c> nation API shard is enabled in the request. The <c>factbooks</c> shard retrieves the number of factbooks the nation has created.
        /// </summary>
        /// <value>A value indicating whether the <c>factbooks</c> nation API shard is enabled in the request.</value>
        public bool NumberOfFactbooks
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>factbooklist</c> nation API shard is enabled in the request. The <c>factbooklist</c> shard retrieves metadata for each of the factbooks the nation has created.
        /// </summary>
        /// <value>A value indicating whether the <c>factbooklist</c> nation API shard is enabled in the request.</value>
        public bool FactbookMetadata
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>dispatches</c> nation API shard is enabled in the request. The <c>dispatches</c> shard retrieves the number of dispatches the nation has created.
        /// </summary>
        /// <value>A value indicating whether the <c>dispatches</c> nation API shard is enabled in the request.</value>
        public bool NumberOfDispatches
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <c>dispatchlist</c> nation API shard is enabled in the request. The <c>dispatchlist</c> shard retrieves metadata for each of the dispatches the nation has created.
        /// </summary>
        /// <value>A value indicating whether the <c>dispatchlist</c> nation API shard is enabled in the request.</value>
        public bool DispatchMetadata
        {
            get;
            set;
        }
    }
}