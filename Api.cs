//-----------------------------------------------------------------------
// <copyright file="Api.cs" company="Auralia">
//     Copyright (C) 2013 Auralia
// </copyright>
//-----------------------------------------------------------------------

namespace Auralia.NationStates.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Xml;

    /// <summary>
    /// Represents an interface for accessing the NationStates API.
    /// </summary>
    public class Api
    {
        /// <summary>
        /// The API version specified in API requests.
        /// </summary>
        public const int ApiVersion = 4;

        /// <summary>
        /// A <see cref="DateTime"/> object representing the Unix epoch.
        /// </summary>
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// The user agent specified in API requests.
        /// </summary>
        private string userAgent;

        /// <summary>
        /// The delay between API requests in milliseconds.
        /// </summary>
        private int standardDelay;

        /// <summary>
        /// The delay between recruitment telegrams in milliseconds.
        /// </summary>
        private int recruitmentTelegramDelay;

        /// <summary>
        /// The delay between non-recruitment telegrams in milliseconds.
        /// </summary>
        private int nonRecruitmentTelegramDelay;

        /// <summary>
        /// A <see cref="DateTime"/> object representing the date and time of the last API request.
        /// </summary>
        private DateTime lastNormalRequestTime;

        /// <summary>
        /// A <see cref="DateTime"/> object representing the date and time of the last telegram.
        /// </summary>
        private DateTime lastTelegramRequestTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="Api"/> class.
        /// </summary>
        /// <param name="userAgent">The user agent specified in API requests.</param>
        public Api(string userAgent)
        {
            this.UserAgent = userAgent;

            this.DelayEnabled = true;

            this.StandardDelay = 600;
            this.RecruitmentTelegramDelay = 180000;
            this.NonRecruitmentTelegramDelay = 60000;
        }

        /// <summary>
        /// Represents the councils of the World Assembly.
        /// </summary>
        public enum WorldAssemblyCouncil
        {
            /// <summary>
            /// Represents the General Assembly.
            /// </summary>
            GeneralAssembly = 1,

            /// <summary>
            /// Represents the Security Council.
            /// </summary>
            SecurityCouncil = 2
        }

        /// <summary>
        /// Represents the types of delays between API requests.
        /// </summary>
        private enum DelayType
        {
            /// <summary>
            /// Represents the delay between all API requests.
            /// </summary>
            Standard,

            /// <summary>
            /// Represents the delay between recruitment telegrams.
            /// </summary>
            RecruitmentTelegram,

            /// <summary>
            /// Represents the delay between non-recruitment telegrams.
            /// </summary>
            NonRecruitmentTelegram
        }

        /// <summary>
        /// Gets or sets the user agent specified in API requests.
        /// </summary>
        /// <value>The user agent specified in API requests.</value>
        public string UserAgent
        {
            get
            {
                return this.userAgent;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("UserAgent", "The user agent must not be null.");
                }
                else if (value.Equals(string.Empty))
                {
                    throw new ArgumentException("The user agent must not be empty.", "UserAgent");
                }
                else
                {
                    this.userAgent = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a delay is introduced between API requests.
        /// </summary>
        /// <value>A value indicating whether a delay is introduced between API requests.</value>
        public bool DelayEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the delay between API requests in milliseconds. The minimum delay is 600 milliseconds.
        /// </summary>
        /// <value>The delay between API requests in milliseconds.</value>
        public int StandardDelay
        {
            get
            {
                return this.standardDelay;
            }

            set
            {
                if (value < 600)
                {
                    throw new ArgumentOutOfRangeException("StandardDelay", "The delay must not be less than 600.");
                }
                else
                {
                    this.standardDelay = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the delay between recruitment telegrams in milliseconds.
        /// </summary>
        /// <value>The delay between recruitment telegrams in milliseconds.</value>
        public int RecruitmentTelegramDelay
        {
            get
            {
                return this.recruitmentTelegramDelay;
            }

            set
            {
                if (value < 180000)
                {
                    throw new ArgumentOutOfRangeException("RecruitmentTelegramDelay", "The delay must not be less than 180000.");
                }
                else
                {
                    this.recruitmentTelegramDelay = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the delay between non-recruitment telegrams in milliseconds.
        /// </summary>
        /// <value>The delay between non-recruitment telegrams in milliseconds.</value>
        public int NonRecruitmentTelegramDelay
        {
            get
            {
                return this.nonRecruitmentTelegramDelay;
            }

            set
            {
                if (value < 30000)
                {
                    throw new ArgumentOutOfRangeException("NonRecruitmentTelegramDelay", "The delay must not be less than 30000.");
                }
                else
                {
                    this.nonRecruitmentTelegramDelay = value;
                }
            }
        }

        /// <summary>
        /// Creates a nation API request.
        /// </summary>
        /// <param name="nation">The nation that is the subject of the request.</param>
        /// <param name="shards">The shards to include in the request.</param>
        /// <returns>A <see cref="NationData"/> object representing the data returned from the nation API.</returns>
        public NationData CreateNationApiRequest(string nation, NationShards shards)
        {
            Uri uri = this.CreateNationApiUri(nation, shards);
            HttpWebResponse response = this.CreateRequest(uri, DelayType.Standard);

            XmlDocument responseXml = this.GetResponseAsXml(response);
            XmlNode responseNode = responseXml.FirstChild;

            NationData nationData = this.ParseNationApiResponse(responseNode);

            return nationData;
        }

        /// <summary>
        /// Creates a region API request.
        /// </summary>
        /// <param name="region">The region that is the subject of the request.</param>
        /// <param name="shards">The shards to include in the request.</param>
        /// <returns>The data returned from the API.</returns>
        public RegionData CreateRegionApiRequest(string region, RegionShards shards)
        {
            Uri uri = this.CreateRegionApiUri(region, shards);
            HttpWebResponse response = this.CreateRequest(uri, DelayType.Standard);

            XmlDocument responseXml = this.GetResponseAsXml(response);
            XmlNode responseNode = responseXml.FirstChild;

            RegionData regionData = this.ParseRegionApiResponse(responseNode);

            return regionData;
        }

        /// <summary>
        /// Creates a world API request.
        /// </summary>
        /// <param name="shards">The shards to include in the request.</param>
        /// <returns>The data returned from the API.</returns>
        public WorldData CreateWorldApiRequest(WorldShards shards)
        {
            Uri uri = this.CreateWorldApiUri(shards);
            HttpWebResponse response = this.CreateRequest(uri, DelayType.Standard);

            XmlDocument responseXml = this.GetResponseAsXml(response);
            XmlNode responseNode = responseXml.FirstChild;

            WorldData worldData = this.ParseWorldApiResponse(responseNode);

            return worldData;
        }

        /// <summary>
        /// Creates a World Assembly API request.
        /// </summary>
        /// <param name="council">The World Assembly council that is the subject of the request.</param>
        /// <param name="shards">The shards to include in the request.</param>
        /// <returns>The data returned from the API.</returns>
        public WorldAssemblyData CreateWorldAssemblyApiRequest(WorldAssemblyCouncil council, WorldAssemblyShards shards)
        {
            Uri uri = this.CreateWorldAssemblyApiUri(council, shards);
            HttpWebResponse response = this.CreateRequest(uri, DelayType.Standard);

            XmlDocument responseXml = this.GetResponseAsXml(response);
            XmlNode responseNode = responseXml.FirstChild;

            WorldAssemblyData worldAssemblyData = this.ParseWorldAssemblyApiResponse(responseNode);

            return worldAssemblyData;
        }

        /// <summary>
        /// Creates a nation data dump request.
        /// </summary>
        /// <returns>The data returned from the API.</returns>
        public NationData[] CreateNationDataDumpApiRequest()
        {
            Uri uri = this.CreateNationDataDumpApiUri();
            HttpWebResponse response = this.CreateRequest(uri, DelayType.Standard);

            XmlDocument responseXml = this.GetResponseAsZippedXml(response);
            XmlNode responseNode = responseXml["NATIONS"];

            NationData[] nationDataArray = this.ParseNationDataDumpApiResponse(responseNode);

            return nationDataArray;
        }

        /// <summary>
        /// Creates a region data dump request.
        /// </summary>
        /// <returns>The data returned from the API.</returns>
        public RegionData[] CreateRegionDataDumpApiRequest()
        {
            Uri uri = this.CreateRegionDataDumpApiUri();
            HttpWebResponse response = this.CreateRequest(uri, DelayType.Standard);

            XmlDocument responseXml = this.GetResponseAsZippedXml(response);
            XmlNode responseNode = responseXml["REGIONS"];

            RegionData[] regionDataArray = this.ParseRegionDataDumpApiResponse(responseNode);

            return regionDataArray;
        }

        /// <summary>
        /// Creates a telegram API request.
        /// </summary>
        /// <param name="clientKey">The sender's telegram API client key.</param>
        /// <param name="telegramId">The telegram ID.</param>
        /// <param name="telegramSecretKey">The telegram secret key.</param>
        /// <param name="recipientNation">The recipient nation.</param>
        /// <param name="isRecruitmentTelegram">A value indicating whether the telegram is a recruitment telegram.</param>
        public void CreateTelegramApiRequest(string clientKey, string telegramId, string telegramSecretKey, string recipientNation, bool isRecruitmentTelegram)
        {
            Uri uri = this.CreateTelegramApiUri(clientKey, telegramId, telegramSecretKey, recipientNation);

            HttpWebResponse response = this.CreateRequest(uri, isRecruitmentTelegram ? DelayType.RecruitmentTelegram : DelayType.NonRecruitmentTelegram);

            string responseString = this.GetResponseAsString(response);

            if (!responseString.Equals("queued\n"))
            {
                throw new ApiResponseException("The API response must be the string 'queued'.");
            }
        }

        /// <summary>
        /// Creates a authentication API request.
        /// </summary>
        /// <param name="nation">The name of the nation to be authenticated.</param>
        /// <param name="loginVerificationCode">The nation's login verification code.</param>
        /// <param name="siteSpecificToken">A site specific token, or a null reference if no site specific token is specified.</param>
        /// <returns>A value indicating whether the authentication was successful.</returns>
        public bool CreateAuthenticationApiRequest(string nation, string loginVerificationCode, string siteSpecificToken = null)
        {
            Uri uri = this.CreateAuthenticationApiUri(nation, loginVerificationCode, siteSpecificToken);

            HttpWebResponse response = this.CreateRequest(uri, DelayType.Standard);

            int responseInt = this.GetResponseAsInteger(response);

            if (responseInt == 0)
            {
                return false;
            }
            else if (responseInt == 1)
            {
                return true;
            }
            else
            {
                throw new ApiResponseException("The API response must be 0 or 1.");
            }
        }

        /// <summary>
        /// Converts a Unix timestamp to a <see cref="DateTime"/> object.
        /// </summary>
        /// <param name="unixTime">A Unix timestamp.</param>
        /// <returns>A <see cref="DateTime"/> object that corresponds to the Unix timestamp.</returns>
        private static DateTime FromUnixTime(int unixTime)
        {
            return UnixEpoch.AddSeconds(unixTime);
        }

        /// <summary>
        /// Delays the application between API requests.
        /// </summary>
        /// <param name="delayType">The <see cref="DelayType"/> that represents the type of delay.</param>
        private void Delay(DelayType delayType)
        {
            if (this.DelayEnabled)
            {
                if (delayType == DelayType.Standard)
                {
                    while (DateTime.UtcNow.Ticks - this.lastNormalRequestTime.Ticks < this.StandardDelay * TimeSpan.TicksPerMillisecond)
                    {
                        // Do nothing.
                    }
                }
                else if (delayType == DelayType.RecruitmentTelegram)
                {
                    while (DateTime.UtcNow.Ticks - this.lastTelegramRequestTime.Ticks < this.RecruitmentTelegramDelay * TimeSpan.TicksPerMillisecond)
                    {
                        // Do nothing.
                    }

                    while (DateTime.UtcNow.Ticks - this.lastNormalRequestTime.Ticks < this.StandardDelay * TimeSpan.TicksPerMillisecond)
                    {
                        // Do nothing.
                    }
                }
                else if (delayType == DelayType.NonRecruitmentTelegram)
                {
                    while (DateTime.UtcNow.Ticks - this.lastTelegramRequestTime.Ticks < this.NonRecruitmentTelegramDelay * TimeSpan.TicksPerMillisecond)
                    {
                        // Do nothing.
                    }

                    while (DateTime.UtcNow.Ticks - this.lastNormalRequestTime.Ticks < this.StandardDelay * TimeSpan.TicksPerMillisecond)
                    {
                        // Do nothing.
                    }
                }
            }
        }

        /// <summary>
        /// Creates an HTTP GET request to a <see cref="Uri"/> preceded by an appropriate delay.
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/> that contains the web resource to which the request is made.</param>
        /// <param name="delayType">The <see cref="DelayType"/> that represents the type of delay.</param>
        /// <returns>The <see cref="HttpWebResponse"/> containing the response from the request.</returns>
        private HttpWebResponse CreateRequest(Uri uri, DelayType delayType)
        {
            try
            {
                this.Delay(delayType);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";
                request.UserAgent = this.UserAgent;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (delayType == DelayType.Standard)
                {
                    this.lastNormalRequestTime = DateTime.UtcNow;
                }
                else if (delayType == DelayType.RecruitmentTelegram)
                {
                    this.lastNormalRequestTime = DateTime.UtcNow;
                    this.lastTelegramRequestTime = DateTime.UtcNow;
                }
                else if (delayType == DelayType.NonRecruitmentTelegram)
                {
                    this.lastNormalRequestTime = DateTime.UtcNow;
                    this.lastTelegramRequestTime = DateTime.UtcNow;
                }

                return response;
            }
            catch (ProtocolViolationException ex)
            {
                throw new ApiRequestException("A network error occurred during a request to the API.", ex);
            }
            catch (WebException ex)
            {
                throw new ApiRequestException("A network error occurred during a request to the API.", ex);
            }
        }
        
        /// <summary>
        /// Retrieves the content of an <see cref="HttpWebResponse"/> as a string.
        /// </summary>
        /// <param name="response">An <see cref="HttpWebResponse"/>.</param>
        /// <returns>A string containing the content of the <see cref="HttpWebResponse"/>.</returns>
        private string GetResponseAsString(HttpWebResponse response)
        {
            try
            {
                Stream responseStream = response.GetResponseStream();

                StreamReader streamReader = new StreamReader(responseStream);
                string responseString = streamReader.ReadToEnd();

                responseStream.Close();
                response.Close();

                return responseString;
            }
            catch (ProtocolViolationException ex)
            {
                throw new ApiResponseException("The API response is empty.", ex);
            }
        }

        /// <summary>
        /// Retrieves the content of an <see cref="HttpWebResponse"/> as an integer.
        /// </summary>
        /// <param name="response">An <see cref="HttpWebResponse"/>.</param>
        /// <returns>An integer representing the content of the <see cref="HttpWebResponse"/>.</returns>
        private int GetResponseAsInteger(HttpWebResponse response)
        {
            try
            {
                Stream responseStream = response.GetResponseStream();

                StreamReader streamReader = new StreamReader(responseStream);
                int responseInt = Convert.ToInt32(streamReader.ReadToEnd());

                responseStream.Close();
                response.Close();

                return responseInt;
            }
            catch (ProtocolViolationException ex)
            {
                throw new ApiResponseException("The API response is empty.", ex);
            }
            catch (FormatException ex)
            {
                throw new ApiResponseException("The API response could not be parsed as a valid integer.", ex);
            }
            catch (OverflowException ex)
            {
                throw new ApiResponseException("The API response could not be parsed as a valid integer.", ex);
            }
        }

        /// <summary>
        /// Retrieves the content of an <see cref="HttpWebResponse"/> as an <see cref="XmlDocument"/>.
        /// </summary>
        /// <param name="response">An <see cref="HttpWebResponse"/>.</param>
        /// <returns>An <see cref="XmlDocument"/> containing the content of the <see cref="HttpWebResponse"/>.</returns>
        private XmlDocument GetResponseAsXml(HttpWebResponse response)
        {
            try
            {
                Stream responseStream = response.GetResponseStream();

                XmlDocument responseXml = new XmlDocument();
                responseXml.Load(responseStream);

                responseStream.Close();
                response.Close();

                return responseXml;
            }
            catch (ProtocolViolationException ex)
            {
                throw new ApiResponseException("The API response is empty.", ex);
            }
            catch (XmlException ex)
            {
                throw new ApiResponseException("The API response could not be parsed as XML.", ex);
            }
        }

        /// <summary>
        /// Retrieves the content of an <see cref="HttpWebResponse"/> as an <see cref="XmlDocument"/>, assuming that the XML is contained within a GZIP file.
        /// </summary>
        /// <param name="response">An <see cref="HttpWebResponse"/>.</param>
        /// <returns>An <see cref="XmlDocument"/> containing the content of the <see cref="HttpWebResponse"/>.</returns>
        private XmlDocument GetResponseAsZippedXml(HttpWebResponse response)
        {
            try
            {
                var responseStream = response.GetResponseStream();

                GZipStream gzip = new GZipStream(responseStream, CompressionMode.Decompress);

                XmlDocument responseXml = new XmlDocument();
                responseXml.Load(gzip);

                responseStream.Close();
                response.Close();
                gzip.Close();

                return responseXml;
            }
            catch (ProtocolViolationException ex)
            {
                throw new ApiResponseException("The API response is empty.", ex);
            }
            catch (XmlException ex)
            {
                throw new ApiResponseException("The API response could not be parsed as XML.", ex);
            }
        }

        /// <summary>
        /// Parses a response from the nation API into a <see cref="NationData"/> object.
        /// </summary>
        /// <param name="responseNode">An <see cref="XmlNode"/> representing the response from the nation API.</param>
        /// <returns>A <see cref="NationData"/> object representing the response from the nation API.</returns>
        private NationData ParseNationApiResponse(XmlNode responseNode)
        {
            // No error checking is done here, under the assumption that the NationStates API will comply with its own specifications.
            var nationData = new NationData();

            if (responseNode["NAME"] != null) 
            {
                nationData.Name = responseNode["NAME"].InnerText;
            }

            if (responseNode["FULLNAME"] != null) 
            {
                nationData.FullName = responseNode["FULLNAME"].InnerText;
            }

            if (responseNode["TYPE"] != null) 
            {
                nationData.Type = responseNode["TYPE"].InnerText;
            }

            if (responseNode["MOTTO"] != null) 
            {
                nationData.Motto = responseNode["MOTTO"].InnerText;
            }

            if (responseNode["CATEGORY"] != null) 
            {
                nationData.Category = responseNode["CATEGORY"].InnerText;
            }
            
            if (responseNode["UNSTATUS"] != null) 
            {
                nationData.WorldAssemblyMembership = responseNode["UNSTATUS"].InnerText;
            }

            if (responseNode["ENDORSEMENTS"] != null)
            {
                var endorsements = responseNode["ENDORSEMENTS"].InnerText.Split(',');

                if (endorsements.Length == 1 && endorsements[0].Equals(string.Empty))
                {
                    nationData.WorldAssemblyEndorsements = new string[] { };
                }
                else 
                {
                    nationData.WorldAssemblyEndorsements = endorsements;
                }
            }

            if (responseNode["GAVOTE"] != null)
            {
                nationData.GeneralAssemblyVote = responseNode["GAVOTE"].InnerText;
            }

            if (responseNode["SCVOTE"] != null)
            {
                nationData.SecurityCouncilVote = responseNode["SCVOTE"].InnerText;
            }

            if (responseNode["FREEDOM"] != null)
            {
                nationData.FreedomDescriptions = new NationData.FreedomDescriptionsData();

                nationData.FreedomDescriptions.CivilRights = responseNode["FREEDOM"]["CIVILRIGHTS"].InnerText;
                nationData.FreedomDescriptions.Economy = responseNode["FREEDOM"]["ECONOMY"].InnerText;
                nationData.FreedomDescriptions.PoliticalFreedoms = responseNode["FREEDOM"]["POLITICALFREEDOM"].InnerText;
            }

            if (responseNode["REGION"] != null)
            {
                nationData.Region = responseNode["REGION"].InnerText;
            }

            if (responseNode["POPULATION"] != null)
            {
                nationData.Population = Convert.ToInt32(responseNode["POPULATION"].InnerText);
            }

            if (responseNode["TAX"] != null)
            {
                nationData.TaxPercentage = Convert.ToInt32(responseNode["TAX"].InnerText);
            }

            if (responseNode["ANIMAL"] != null)
            {
                nationData.Animal = responseNode["ANIMAL"].InnerText;
            }

            if (responseNode["ANIMALTRAIT"] != null)
            {
                nationData.AnimalDescription = responseNode["ANIMALTRAIT"].InnerText;
            }

            if (responseNode["CURRENCY"] != null)
            {
                nationData.Currency = responseNode["CURRENCY"].InnerText;
            }

            if (responseNode["FLAG"] != null)
            {
                nationData.Flag = new Uri(responseNode["FLAG"].InnerText);
            }

            if (responseNode["MAJORINDUSTRY"] != null)
            {
                nationData.MajorIndustry = responseNode["MAJORINDUSTRY"].InnerText;
            }

            if (responseNode["CRIME"] != null)
            {
                nationData.Crime = responseNode["CRIME"].InnerText;
            }

            if (responseNode["SENSIBILITIES"] != null)
            {
                nationData.Sensibilities = responseNode["SENSIBILITIES"].InnerText;
            }

            if (responseNode["GOVTPRIORITY"] != null)
            {
                nationData.GovernmentBudgetPriority = responseNode["GOVTPRIORITY"].InnerText;
            }

            if (responseNode["GOVT"] != null)
            {
                nationData.GovernmentBudget = new NationData.GovernmentBudgetData();

                nationData.GovernmentBudget.EnvironmentPercentage = Convert.ToInt32(responseNode["GOVT"]["ENVIRONMENT"].InnerText.Substring(0, responseNode["GOVT"]["ENVIRONMENT"].InnerText.Length - 1));
                nationData.GovernmentBudget.SocialEqualityPercentage = Convert.ToInt32(responseNode["GOVT"]["SOCIALEQUALITY"].InnerText.Substring(0, responseNode["GOVT"]["SOCIALEQUALITY"].InnerText.Length - 1));
                nationData.GovernmentBudget.EducationPercentage = Convert.ToInt32(responseNode["GOVT"]["EDUCATION"].InnerText.Substring(0, responseNode["GOVT"]["EDUCATION"].InnerText.Length - 1));
                nationData.GovernmentBudget.LawAndOrderPercentage = Convert.ToInt32(responseNode["GOVT"]["LAWANDORDER"].InnerText.Substring(0, responseNode["GOVT"]["LAWANDORDER"].InnerText.Length - 1));
                nationData.GovernmentBudget.AdministrationPercentage = Convert.ToInt32(responseNode["GOVT"]["ADMINISTRATION"].InnerText.Substring(0, responseNode["GOVT"]["ADMINISTRATION"].InnerText.Length - 1));
                nationData.GovernmentBudget.WelfarePercentage = Convert.ToInt32(responseNode["GOVT"]["WELFARE"].InnerText.Substring(0, responseNode["GOVT"]["WELFARE"].InnerText.Length - 1));
                nationData.GovernmentBudget.SpiritualityPercentage = Convert.ToInt32(responseNode["GOVT"]["SPIRITUALITY"].InnerText.Substring(0, responseNode["GOVT"]["SPIRITUALITY"].InnerText.Length - 1));
                nationData.GovernmentBudget.DefensePercentage = Convert.ToInt32(responseNode["GOVT"]["DEFENCE"].InnerText.Substring(0, responseNode["GOVT"]["DEFENCE"].InnerText.Length - 1));
                nationData.GovernmentBudget.PublicTransportPercentage = Convert.ToInt32(responseNode["GOVT"]["PUBLICTRANSPORT"].InnerText.Substring(0, responseNode["GOVT"]["PUBLICTRANSPORT"].InnerText.Length - 1));
                nationData.GovernmentBudget.HealthcarePercentage = Convert.ToInt32(responseNode["GOVT"]["HEALTHCARE"].InnerText.Substring(0, responseNode["GOVT"]["HEALTHCARE"].InnerText.Length - 1));
                nationData.GovernmentBudget.CommercePercentage = Convert.ToInt32(responseNode["GOVT"]["COMMERCE"].InnerText.Substring(0, responseNode["GOVT"]["COMMERCE"].InnerText.Length - 1));
            }

            if (responseNode["GOVTDESC"] != null)
            {
                nationData.GovernmentDescription = responseNode["GOVTDESC"].InnerText;
            }

            if (responseNode["INDUSTRYDESC"] != null)
            {
                nationData.EconomyDescription = responseNode["INDUSTRYDESC"].InnerText;
            }

            if (responseNode["NOTABLE"] != null)
            {
                nationData.Notable = responseNode["NOTABLE"].InnerText;
            }

            if (responseNode["ADMIRABLE"] != null)
            {
                nationData.Admirable = responseNode["ADMIRABLE"].InnerText;
            }

            if (responseNode["FOUNDED"] != null)
            {
                nationData.Founded = responseNode["FOUNDED"].InnerText;
            }

            if (responseNode["FIRSTLOGIN"] != null)
            {
                nationData.FirstLogin = FromUnixTime(Convert.ToInt32(responseNode["FIRSTLOGIN"].InnerText));
            }

            if (responseNode["LASTLOGIN"] != null)
            {
                nationData.LastLogin = FromUnixTime(Convert.ToInt32(responseNode["LASTLOGIN"].InnerText));
            }

            if (responseNode["LASTACTIVITY"] != null)
            {
                nationData.LastActivity = responseNode["LASTACTIVITY"].InnerText;
            }

            if (responseNode["INFLUENCE"] != null)
            {
                nationData.Influence = responseNode["INFLUENCE"].InnerText;
            }

            if (responseNode["FREEDOMSCORES"] != null)
            {
                nationData.FreedomScores = new NationData.FreedomScoresData();

                nationData.FreedomScores.CivilRights = Convert.ToInt32(responseNode["FREEDOMSCORES"]["CIVILRIGHTS"].InnerText);
                nationData.FreedomScores.Economy = Convert.ToInt32(responseNode["FREEDOMSCORES"]["ECONOMY"].InnerText);
                nationData.FreedomScores.PoliticalFreedoms = Convert.ToInt32(responseNode["FREEDOMSCORES"]["POLITICALFREEDOM"].InnerText);
            }

            if (responseNode["PUBLICSECTOR"] != null)
            {
                nationData.PublicSectorPercentage = Convert.ToInt32(responseNode["PUBLICSECTOR"].InnerText.Substring(0, responseNode["PUBLICSECTOR"].InnerText.Length - 1));
            }

            if (responseNode["DEATHS"] != null)
            {
                var causesOfDeath = new List<NationData.CauseOfDeath>();

                foreach (XmlNode causeOfDeathNode in responseNode["DEATHS"].SelectNodes("CAUSE"))
                {
                    var causeOfDeath = new NationData.CauseOfDeath();

                    causeOfDeath.Percentage = Convert.ToInt32(causeOfDeathNode.InnerText.Substring(0, causeOfDeathNode.InnerText.Length - 1));
                    causeOfDeath.Name = causeOfDeathNode.Attributes["type"].InnerText;

                    causesOfDeath.Add(causeOfDeath);
                }

                nationData.CausesOfDeath = causesOfDeath.ToArray();
            }

            if (responseNode["LEADER"] != null)
            {
                nationData.Leader = responseNode["LEADER"].InnerText;
            }

            if (responseNode["CAPITAL"] != null)
            {
                nationData.Capital = responseNode["CAPITAL"].InnerText;
            }

            if (responseNode["RELIGION"] != null)
            {
                nationData.Religion = responseNode["RELIGION"].InnerText;
            }

            if (responseNode["RCENSUS"] != null)
            {
                nationData.RegionalCensusRanking = Convert.ToInt32(responseNode["RCENSUS"].InnerText);
            }

            if (responseNode["WCENSUS"] != null)
            {
                nationData.WorldCensusRanking = Convert.ToInt32(responseNode["WCENSUS"].InnerText);
            }

            if (responseNode.SelectNodes("CENSUSSCORE").Count >= 1)
            {
                var censusStatistics = new List<NationData.CensusStatistic>();

                foreach (XmlNode censusNode in responseNode.SelectNodes("CENSUSSCORE")) 
                {
                    var censusStatistic = new NationData.CensusStatistic();
                    
                    censusStatistic.Value = Convert.ToDouble(responseNode["CENSUSSCORE"].InnerText);
                    censusStatistic.Id = Convert.ToInt32(responseNode["CENSUSSCORE"].Attributes["id"].InnerText);

                    censusStatistics.Add(censusStatistic);
                }

                nationData.CensusStatistics = censusStatistics.ToArray();
            }

            if (responseNode["LEGISLATION"] != null)
            {
                var legislation = new List<string>();

                foreach (XmlNode lawNode in responseNode["LEGISLATION"].SelectNodes("LAW"))
                {
                    legislation.Add(lawNode.InnerText);
                }

                nationData.Legislation = legislation.ToArray();
            }

            if (responseNode["HAPPENINGS"] != null)
            {
                var happenings = new List<NationData.Happening>();

                foreach (XmlNode happeningNode in responseNode["HAPPENINGS"].SelectNodes("EVENT"))
                {
                    var happening = new NationData.Happening();

                    happening.Text = happeningNode["TEXT"].InnerText;
                    happening.Timestamp = FromUnixTime(Convert.ToInt32(happeningNode["TIMESTAMP"].InnerText));

                    happenings.Add(happening);
                }

                nationData.Happenings = happenings.ToArray();
            }

            return nationData;
        }

        /// <summary>
        /// Parses a response from the region API into a <see cref="RegionData"/> object.
        /// </summary>
        /// <param name="responseNode">An <see cref="XmlNode"/> representing the response from the region API.</param>
        /// <returns>A <see cref="RegionData"/> object representing the response from the region API.</returns>
        private RegionData ParseRegionApiResponse(XmlNode responseNode)
        {
            // No error checking is done here, under the assumption that the NationStates API will comply with its own specifications.
            var regionData = new RegionData();

            if (responseNode["NAME"] != null)
            {
                regionData.Name = responseNode["NAME"].InnerText;
            }

            if (responseNode["FACTBOOK"] != null)
            {
                regionData.Factbook = responseNode["FACTBOOK"].InnerText;
            }

            if (responseNode["NUMNATIONS"] != null)
            {
                regionData.NumberOfNations = Convert.ToInt32(responseNode["NUMNATIONS"].InnerText);
            }

            if (responseNode["NATIONS"] != null) 
            {
                var nations = responseNode["NATIONS"].InnerText.Split(':');

                if (nations.Length == 1 && nations[0].Equals(string.Empty))
                {
                    regionData.Nations = new string[] { };
                }
                else 
                {
                    regionData.Nations = nations;
                }
            }

            if (responseNode["DELEGATE"] != null) 
            {
                regionData.Delegate = responseNode["DELEGATE"].InnerText;
            }

            if (responseNode["DELEGATEVOTES"] != null)
            {
                regionData.NumberOfDelegateVotes = Convert.ToInt32(responseNode["DELEGATEVOTES"].InnerText);
            }

            if (responseNode["GAVOTE"] != null)
            {
                regionData.GeneralAssemblyVote = new RegionData.Votes();

                regionData.GeneralAssemblyVote.For = Convert.ToInt32(responseNode["GAVOTE"]["FOR"].InnerText);
                regionData.GeneralAssemblyVote.Against = Convert.ToInt32(responseNode["GAVOTE"]["AGAINST"].InnerText);
            }

            if (responseNode["SCVOTE"] != null)
            {
                regionData.SecurityCouncilVote = new RegionData.Votes();

                regionData.SecurityCouncilVote.For = Convert.ToInt32(responseNode["SCVOTE"]["FOR"].InnerText);
                regionData.SecurityCouncilVote.Against = Convert.ToInt32(responseNode["SCVOTE"]["AGAINST"].InnerText);
            }

            if (responseNode["FOUNDER"] != null)
            {
                regionData.Founder = responseNode["FOUNDER"].InnerText;
            }

            if (responseNode["POWER"] != null)
            {
                regionData.Power = responseNode["POWER"].InnerText;
            }

            if (responseNode["FLAG"] != null)
            {
                regionData.Flag = new Uri(responseNode["FLAG"].InnerText);
            }

            if (responseNode["EMBASSIES"] != null)
            {
                var embassies = new List<RegionData.Embassy>();

                foreach (XmlNode embassyNode in responseNode["EMBASSIES"].SelectNodes("EMBASSY"))
                {
                    var embassy = new RegionData.Embassy();

                    embassy.Region = embassyNode.InnerText;

                    if (embassyNode.Attributes["type"] != null)
                    {
                        embassy.Status = embassyNode.Attributes["type"].InnerText;
                    }

                    embassies.Add(embassy);
                }

                regionData.Embassies = embassies.ToArray();
            }

            if (responseNode["TAGS"] != null)
            {
                var tags = new List<string>();

                foreach (XmlNode tagNode in responseNode["TAGS"].SelectNodes("TAG"))
                {
                    tags.Add(tagNode.InnerText);
                }

                regionData.Tags = tags.ToArray();
            }

            if (responseNode["HAPPENINGS"] != null)
            {
                var happenings = new List<RegionData.Happening>();

                foreach (XmlNode happeningNode in responseNode["HAPPENINGS"].SelectNodes("EVENT"))
                {
                    var happening = new RegionData.Happening();

                    happening.Text = happeningNode["TEXT"].InnerText;
                    happening.Timestamp = FromUnixTime(Convert.ToInt32(happeningNode["TIMESTAMP"].InnerText));

                    happenings.Add(happening);
                }

                regionData.Happenings = happenings.ToArray();
            }

            if (responseNode["MESSAGES"] != null)
            {
                var messages = new List<RegionData.Message>();

                foreach (XmlNode messageNode in responseNode["MESSAGES"].SelectNodes("POST"))
                {
                    var message = new RegionData.Message();

                    message.Text = messageNode["MESSAGE"].InnerText;
                    message.Nation = messageNode["NATION"].InnerText;
                    message.Timestamp = FromUnixTime(Convert.ToInt32(messageNode["TIMESTAMP"].InnerText));

                    messages.Add(message);
                }

                regionData.Messages = messages.ToArray();
            }

            if (responseNode["HISTORY"] != null)
            {
                var historyEntries = new List<RegionData.HistoryEntry>();

                foreach (XmlNode historyEntryNode in responseNode["HISTORY"].SelectNodes("EVENT"))
                {
                    var historyEntry = new RegionData.HistoryEntry();

                    historyEntry.Text = historyEntryNode["TEXT"].InnerText;
                    historyEntry.Timestamp = FromUnixTime(Convert.ToInt32(historyEntryNode["TIMESTAMP"].InnerText));

                    historyEntries.Add(historyEntry);
                }

                regionData.History = historyEntries.ToArray();
            }

            return regionData;
        }

        /// <summary>
        /// Parses a response from the world API into a <see cref="WorldData"/> object.
        /// </summary>
        /// <param name="responseNode">An <see cref="XmlNode"/> representing the response from the world API.</param>
        /// <returns>A <see cref="WorldData"/> object representing the response from the world API.</returns>
        private WorldData ParseWorldApiResponse(XmlNode responseNode)
        {
            // No error checking is done here, under the assumption that the NationStates API will comply with its own specifications.
            WorldData worldData = new WorldData();

            if (responseNode["NUMNATIONS"] != null)
            {
                worldData.NumberOfNations = Convert.ToInt32(responseNode["NUMNATIONS"].InnerText);
            }

            if (responseNode["NUMREGIONS"] != null)
            {
                worldData.NumberOfRegions = Convert.ToInt32(responseNode["NUMREGIONS"].InnerText);
            }

            if (responseNode["CENSUS"] != null)
            {
                worldData.CensusName = responseNode["CENSUS"].InnerText;
                worldData.CensusId = Convert.ToInt32(responseNode["CENSUS"].Attributes["id"].InnerText);
            }

            if (responseNode["CENSUSID"] != null)
            {
                worldData.CensusId = Convert.ToInt32(responseNode["CENSUSID"].InnerText);
            }

            if (responseNode["CENSUSSIZE"] != null)
            {
                worldData.CensusSize = Convert.ToInt32(responseNode["CENSUSSIZE"].InnerText);
            }

            if (responseNode["CENSUSSCALE"] != null)
            {
                worldData.CensusScale = responseNode["CENSUSSCALE"].InnerText;
            }

            if (responseNode["CENSUSMEDIAN"] != null)
            {
                worldData.CensusMedian = Convert.ToInt32(responseNode["CENSUSMEDIAN"].InnerText);
            }

            if (responseNode["FEATUREDREGION"] != null)
            {
                worldData.FeaturedRegion = responseNode["FEATUREDREGION"].InnerText;
            }

            if (responseNode["HAPPENINGS"] != null)
            {
                var happenings = new List<WorldData.Happening>();

                foreach (XmlNode happeningNode in responseNode["HAPPENINGS"].SelectNodes("EVENT"))
                {
                    var happening = new WorldData.Happening();

                    happening.Text = happeningNode["TEXT"].InnerText;
                    happening.Timestamp = FromUnixTime(Convert.ToInt32(happeningNode["TIMESTAMP"].InnerText));
                    happening.Id = Convert.ToInt32(happeningNode.Attributes["id"].InnerText);

                    happenings.Add(happening);
                }

                worldData.Happenings = happenings.ToArray();
            }

            if (responseNode["NEWNATIONS"] != null)
            {
                var newNations = responseNode["NEWNATIONS"].InnerText.Split(',');

                if (newNations.Length == 1 && newNations[0].Equals(string.Empty))
                {
                    worldData.NewNations = new string[] { };
                }
                else
                {
                    worldData.NewNations = newNations;
                }
            }

            if (responseNode["REGIONS"] != null)
            {
                var regions = responseNode["REGIONS"].InnerText.Split(',');

                if (regions.Length == 1 && regions[0].Equals(string.Empty))
                {
                    worldData.RegionsByTag = new string[] { };
                }
                else
                {
                    worldData.RegionsByTag = regions;
                }
            }

            return worldData;
        }

        /// <summary>
        /// Parses a response from the World Assembly API into a <see cref="WorldAssemblyData"/> object.
        /// </summary>
        /// <param name="responseNode">An <see cref="XmlNode"/> representing the response from the World Assembly API.</param>
        /// <returns>A <see cref="WorldAssemblyData"/> object representing the response from the World Assembly API.</returns>
        private WorldAssemblyData ParseWorldAssemblyApiResponse(XmlNode responseNode)
        {
            // No error checking is done here, under the assumption that the NationStates API will comply with its own specifications.
            var worldAssemblyData = new WorldAssemblyData();

            if (responseNode["NUMNATIONS"] != null) 
            {
                worldAssemblyData.NumberOfMembers = Convert.ToInt32(responseNode["NUMNATIONS"].InnerText);
            }

            if (responseNode["NUMDELEGATES"] != null)
            {
                worldAssemblyData.NumberOfDelegates = Convert.ToInt32(responseNode["NUMDELEGATES"].InnerText);
            }

            if (responseNode["DELEGATES"] != null)
            {
                var delegates = responseNode["DELEGATES"].InnerText.Split(',');

                if (delegates.Length == 1 && delegates[0].Equals(string.Empty))
                {
                    worldAssemblyData.Delegates = new string[] { };
                }
                else
                {
                    worldAssemblyData.Delegates = delegates;
                }
            }

            if (responseNode["MEMBERS"] != null)
            {
                var members = responseNode["MEMBERS"].InnerText.Split(',');

                if (members.Length == 1 && members[0].Equals(string.Empty))
                {
                    worldAssemblyData.Members = new string[] { };
                }
                else
                {
                    worldAssemblyData.Members = members;
                }
            }

            if (responseNode["HAPPENINGS"] != null)
            {
                var happenings = new List<WorldAssemblyData.Happening>();

                foreach (XmlNode happeningNode in responseNode["HAPPENINGS"].SelectNodes("EVENT"))
                {
                    var happening = new WorldAssemblyData.Happening();

                    happening.Text = happeningNode["TEXT"].InnerText;
                    happening.Timestamp = FromUnixTime(Convert.ToInt32(happeningNode["TIMESTAMP"].InnerText));

                    happenings.Add(happening);
                }

                worldAssemblyData.Happenings = happenings.ToArray();
            }

            if (responseNode["MEMBERLOG"] != null)
            {
                var memberHappenings = new List<WorldAssemblyData.Happening>();

                foreach (XmlNode happeningNode in responseNode["MEMBERLOG"].SelectNodes("EVENT"))
                {
                    var happening = new WorldAssemblyData.Happening();

                    happening.Text = happeningNode["TEXT"].InnerText;
                    happening.Timestamp = FromUnixTime(Convert.ToInt32(happeningNode["TIMESTAMP"].InnerText));

                    memberHappenings.Add(happening);
                }

                worldAssemblyData.MembershipHappenings = memberHappenings.ToArray();
            }

            if (responseNode["RESOLUTION"] != null)
            {
                var resolution = new WorldAssemblyData.Resolution();

                resolution.Category = responseNode["RESOLUTION"]["CATEGORY"].InnerText;
                resolution.Created = FromUnixTime(Convert.ToInt32(responseNode["RESOLUTION"]["CREATED"].InnerText));
                resolution.Text = responseNode["RESOLUTION"]["DESC"].InnerText;
                resolution.Title = responseNode["RESOLUTION"]["NAME"].InnerText;
                resolution.Subcategory = responseNode["RESOLUTION"]["OPTION"].InnerText;
                resolution.Author = responseNode["RESOLUTION"]["PROPOSED_BY"].InnerText;
                resolution.VotesAgainst = Convert.ToInt32(responseNode["RESOLUTION"]["TOTAL_VOTES_AGAINST"].InnerText);
                resolution.VotesFor = Convert.ToInt32(responseNode["RESOLUTION"]["TOTAL_VOTES_FOR"].InnerText);

                worldAssemblyData.ResolutionAtVote = resolution;
            }

            if (responseNode["RESOLUTION"] != null && responseNode["RESOLUTION"]["VOTE_TRACK_AGAINST"] != null && responseNode["RESOLUTION"]["VOTE_TRACK_FOR"] != null)
            {
                var voteTrackAgainstEntries = new List<int>();

                foreach (XmlNode voteTrackAgainstNode in responseNode["RESOLUTION"]["VOTE_TRACK_AGAINST"].SelectNodes("N"))
                {
                    voteTrackAgainstEntries.Add(Convert.ToInt32(voteTrackAgainstNode.InnerText));
                }

                worldAssemblyData.ResolutionAtVote.VotesAgainstHistory = voteTrackAgainstEntries.ToArray();

                var voteTrackForEntries = new List<int>();

                foreach (XmlNode voteTrackForNode in responseNode["RESOLUTION"]["VOTE_TRACK_FOR"].SelectNodes("N"))
                {
                    voteTrackForEntries.Add(Convert.ToInt32(voteTrackForNode.InnerText));
                }

                worldAssemblyData.ResolutionAtVote.VotesForHistory = voteTrackForEntries.ToArray();
            }

            if (responseNode["RESOLUTION"] != null && responseNode["RESOLUTION"]["DELLOG"] != null)
            {
                var delegateVoteHistoryEntries = new List<WorldAssemblyData.Resolution.DelegateVoteAction>();

                foreach (XmlNode delegateVoteHistoryEntryNode in responseNode["RESOLUTION"]["DELLOG"].SelectNodes("ENTRY"))
                {
                    var delegateVoteHistoryEntry = new WorldAssemblyData.Resolution.DelegateVoteAction();

                    delegateVoteHistoryEntry.Timestamp = FromUnixTime(Convert.ToInt32(delegateVoteHistoryEntryNode["TIMESTAMP"].InnerText));
                    delegateVoteHistoryEntry.Name = delegateVoteHistoryEntryNode["NATION"].InnerText;
                    delegateVoteHistoryEntry.Action = delegateVoteHistoryEntryNode["ACTION"].InnerText;
                    delegateVoteHistoryEntry.Votes = Convert.ToInt32(delegateVoteHistoryEntryNode["VOTES"].InnerText);

                    delegateVoteHistoryEntries.Add(delegateVoteHistoryEntry);
                }

                worldAssemblyData.ResolutionAtVote.DelegateVotesHistory = delegateVoteHistoryEntries.ToArray();
            }

            if (responseNode["RESOLUTION"] != null && responseNode["RESOLUTION"]["DELVOTES_FOR"] != null && responseNode["RESOLUTION"]["DELVOTES_AGAINST"] != null)
            {
                var delegateVotesForEntries = new List<WorldAssemblyData.Resolution.DelegateVote>();

                foreach (XmlNode delegateVotesForEntryNode in responseNode["RESOLUTION"]["DELVOTES_FOR"].SelectNodes("DELEGATE"))
                {
                    var delegateVotesForEntry = new WorldAssemblyData.Resolution.DelegateVote();

                    delegateVotesForEntry.Name = delegateVotesForEntryNode["NATION"].InnerText;
                    delegateVotesForEntry.Votes = Convert.ToInt32(delegateVotesForEntryNode["VOTES"].InnerText);
                    delegateVotesForEntry.Timestamp = FromUnixTime(Convert.ToInt32(delegateVotesForEntryNode["TIMESTAMP"].InnerText));

                    delegateVotesForEntries.Add(delegateVotesForEntry);
                }

                worldAssemblyData.ResolutionAtVote.DelegateVotesFor = delegateVotesForEntries.ToArray();

                var delegateVotesAgainstEntries = new List<WorldAssemblyData.Resolution.DelegateVote>();

                foreach (XmlNode delegateVotesAgainstEntryNode in responseNode["RESOLUTION"]["DELVOTES_AGAINST"].SelectNodes("DELEGATE"))
                {
                    var delegateVotesAgainstEntry = new WorldAssemblyData.Resolution.DelegateVote();

                    delegateVotesAgainstEntry.Name = delegateVotesAgainstEntryNode["NATION"].InnerText;
                    delegateVotesAgainstEntry.Votes = Convert.ToInt32(delegateVotesAgainstEntryNode["VOTES"].InnerText);
                    delegateVotesAgainstEntry.Timestamp = FromUnixTime(Convert.ToInt32(delegateVotesAgainstEntryNode["TIMESTAMP"].InnerText));

                    delegateVotesAgainstEntries.Add(delegateVotesAgainstEntry);
                }

                worldAssemblyData.ResolutionAtVote.DelegateVotesAgainst = delegateVotesAgainstEntries.ToArray();
            }

            if (responseNode["LASTRESOLUTION"] != null)
            {
                worldAssemblyData.LastResolution = responseNode["LASTRESOLUTION"].InnerText;
            }

            return worldAssemblyData;
        }

        /// <summary>
        /// Parses a response from the nation data dump API into an array of <see cref="NationData"/> objects.
        /// </summary>
        /// <param name="responseNode">An <see cref="XmlNode"/> representing the response from the nation data dump API.</param>
        /// <returns>An array of <see cref="NationData"/> objects representing the response from the nation data dump API.</returns>
        private NationData[] ParseNationDataDumpApiResponse(XmlNode responseNode)
        {
            var nationDataEntries = new List<NationData>();

            foreach (XmlNode nationDataNode in responseNode.SelectNodes("NATION"))
            {
                var nationData = this.ParseNationApiResponse(nationDataNode);

                nationDataEntries.Add(nationData);
            }

            return nationDataEntries.ToArray();
        }

        /// <summary>
        /// Parses a response from the region data dump API into an array of <see cref="RegionData"/> objects.
        /// </summary>
        /// <param name="responseNode">An <see cref="XmlNode"/> representing the response from the region data dump API.</param>
        /// <returns>An array of <see cref="RegionData"/> objects representing the response from the region data dump API.</returns>
        private RegionData[] ParseRegionDataDumpApiResponse(XmlNode responseNode)
        {
            var regionDataEntries = new List<RegionData>();

            foreach (XmlNode regionDataNode in responseNode.SelectNodes("REGION"))
            {
                var regionData = this.ParseRegionApiResponse(regionDataNode);

                regionDataEntries.Add(regionData);
            }

            return regionDataEntries.ToArray();
        }

        /// <summary>
        /// Generates a <see cref="Uri"/> to the nation API containing the selected shards.
        /// </summary>
        /// <param name="nation">The nation that is the subject of the request.</param>
        /// <param name="shards">The <see cref="NationShards"/> object that represents the shards to include in the request.</param>
        /// <returns>A <see cref="Uri"/> to the nation API containing the selected shards.</returns>
        private Uri CreateNationApiUri(string nation, NationShards shards)
        {
            if (nation == null)
            {
                throw new ArgumentNullException("nation", "The name of the nation must not be null.");
            }
            else if (nation.Equals(string.Empty))
            {
                throw new ArgumentException("The name of the nation must not be empty.", "nation");
            }

            if (shards == null)
            {
                throw new ArgumentNullException("shards", "The shards object must not be null.");
            }

            try
            {
                var uri = "http://www.nationstates.net/cgi-bin/api.cgi?nation=" + WebUtility.UrlEncode(nation) + "&q=";

                if (shards.Name)
                {
                    uri += "name+";
                }

                if (shards.FullName)
                {
                    uri += "fullname+";
                }

                if (shards.Type)
                {
                    uri += "type+";
                }

                if (shards.Motto)
                {
                    uri += "motto+";
                }

                if (shards.Category)
                {
                    uri += "category+";
                }

                if (shards.WorldAssemblyMembership)
                {
                    uri += "wa+";
                }

                if (shards.WorldAssemblyEndorsements)
                {
                    uri += "endorsements+";
                }

                if (shards.GeneralAssemblyVote)
                {
                    uri += "gavote+";
                }

                if (shards.SecurityCouncilVote)
                {
                    uri += "scvote+";
                }

                if (shards.FreedomDescriptions)
                {
                    uri += "freedom+";
                }

                if (shards.Region)
                {
                    uri += "region+";
                }

                if (shards.Population)
                {
                    uri += "population+";
                }

                if (shards.TaxPercentage)
                {
                    uri += "tax+";
                }

                if (shards.Animal)
                {
                    uri += "animal+";
                }

                if (shards.AnimalDescription)
                {
                    uri += "animaltrait+";
                }

                if (shards.Currency)
                {
                    uri += "currency+";
                }

                if (shards.Flag)
                {
                    uri += "flag+";
                }

                if (shards.MajorIndustry)
                {
                    uri += "majorindustry+";
                }

                if (shards.Crime)
                {
                    uri += "crime+";
                }

                if (shards.Sensibilities)
                {
                    uri += "sensibilities+";
                }

                if (shards.GovernmentBudgetPriority)
                {
                    uri += "govtpriority+";
                }

                if (shards.GovernmentBudget)
                {
                    uri += "govt+";
                }

                if (shards.GovernmentDescription)
                {
                    uri += "govtdesc+";
                }

                if (shards.EconomyDescription)
                {
                    uri += "industrydesc+";
                }

                if (shards.Notable)
                {
                    uri += "notable+";
                }

                if (shards.Admirable)
                {
                    uri += "admirable+";
                }

                if (shards.Founded)
                {
                    uri += "founded+";
                }

                if (shards.FirstLogin)
                {
                    uri += "firstlogin+";
                }

                if (shards.LastLogin)
                {
                    uri += "lastlogin+";
                }

                if (shards.LastActivity)
                {
                    uri += "lastactivity+";
                }

                if (shards.Influence)
                {
                    uri += "influence+";
                }

                if (shards.FreedomScores)
                {
                    uri += "freedomscores+";
                }

                if (shards.PublicSectorPercentage)
                {
                    uri += "publicsector+";
                }

                if (shards.CausesOfDeath)
                {
                    uri += "deaths+";
                }

                if (shards.Leader)
                {
                    uri += "leader+";
                }

                if (shards.Capital)
                {
                    uri += "capital+";
                }

                if (shards.Religion)
                {
                    uri += "religion+";
                }

                if (shards.RegionalCensusRanking)
                {
                    uri += "rcensus+";
                }

                if (shards.WorldCensusRanking)
                {
                    uri += "wcensus+";
                }

                if (shards.CensusStatistics)
                {
                    if (shards.CensusStatisticsIds == null)
                    {
                        throw new ArgumentNullException("shards", "shards.CensusStatisticsIds must not be null when shards.CensusStatistics is true.");
                    }
                    else if (shards.CensusStatisticsIds.Count == 0)
                    {
                        throw new ArgumentException("Length of shards.CensusStatisticsIds must not be zero when shards.CensusStatistics is true.", "shards");
                    }

                    for (var i = 0; i < shards.CensusStatisticsIds.Count; i++)
                    {
                        if (shards.CensusStatisticsIds[i] == null)
                        {
                            uri += "censusscore+";
                        }
                        else
                        {
                            uri += "censusscore" + "-" + shards.CensusStatisticsIds[i] + "+";
                        }
                    }
                }

                if (shards.Legislation)
                {
                    uri += "legislation+";
                }

                if (shards.Happenings)
                {
                    uri += "happenings+";
                }

                if (uri.Substring(uri.Length - 1).Equals("+"))
                {
                    // Remove the extra "+"
                    uri = uri.Substring(0, uri.Length - 1);
                }
                else
                {
                    // Remove "&q=" (no shards)
                    uri = uri.Substring(0, uri.Length - 3);
                }

                uri += "&v=" + ApiVersion;

                return new Uri(uri);
            }
            catch (UriFormatException ex)
            {
                throw new ArgumentException("The name of the nation contains characters that cannot be included in a valid URI.", "nation", ex);
            }
        }

        /// <summary>
        /// Generates a <see cref="Uri"/> to the region API containing the specified shards and other information.
        /// </summary>
        /// <param name="region">The name of the region that is the subject of the request.</param>
        /// <param name="shards">The <see cref="RegionShards"/> object that represents the shards to include in the request.</param>
        /// <returns>A <see cref="Uri"/> to the region API containing the specified shards and other information.</returns>
        private Uri CreateRegionApiUri(string region, RegionShards shards)
        {
            if (region == null)
            {
                throw new ArgumentNullException("region", "The name of the region must not be null.");
            }
            else if (region.Equals(string.Empty))
            {
                throw new ArgumentException("The name of the region must not be empty.", "region");
            }

            if (shards == null)
            {
                throw new ArgumentNullException("shards", "The shards object must not be null.");
            }

            try
            {
                var uri = "http://www.nationstates.net/cgi-bin/api.cgi?region=" + WebUtility.UrlEncode(region) + "&q=";

                if (shards.Name)
                {
                    uri += "name+";
                }

                if (shards.Factbook)
                {
                    uri += "factbook+";
                }

                if (shards.NumberOfNations)
                {
                    uri += "numnations+";
                }

                if (shards.Nations)
                {
                    uri += "nations+";
                }

                if (shards.Delegate)
                {
                    uri += "delegate+";
                }

                if (shards.NumberOfDelegateVotes)
                {
                    uri += "delegatevotes+";
                }

                if (shards.GeneralAssemblyVote)
                {
                    uri += "gavote+";
                }

                if (shards.SecurityCouncilVote)
                {
                    uri += "scvote+";
                }

                if (shards.Founder)
                {
                    uri += "founder+";
                }

                if (shards.Power)
                {
                    uri += "power+";
                }

                if (shards.Flag)
                {
                    uri += "flag+";
                }

                if (shards.Embassies)
                {
                    uri += "embassies+";
                }

                if (shards.Tags)
                {
                    uri += "tags+";
                }

                if (shards.Happenings)
                {
                    uri += "happenings+";
                }

                if (shards.History)
                {
                    uri += "history+";
                }

                // This shard must be the last shard in the URL.
                if (shards.Messages)
                {
                    uri += "messages;offset=" + shards.MessagesOffset + "+";
                }

                if (uri.Substring(uri.Length - 1).Equals("+"))
                {
                    // Remove the extra "+"
                    uri = uri.Substring(0, uri.Length - 1);
                }
                else
                {
                    // Remove "&q=" (no shards)
                    uri = uri.Substring(0, uri.Length - 3);
                }

                uri += "&v=" + ApiVersion;

                return new Uri(uri);
            }
            catch (UriFormatException ex)
            {
                throw new ArgumentException("The name of the region contains characters that cannot be included in a valid URI.", "region", ex);
            }
        }

        /// <summary>
        /// Generates a <see cref="Uri"/> to the world API containing the specified shards.
        /// </summary>
        /// <param name="shards">The <see cref="WorldShards"/> object that represents the shards to include in the request.</param>
        /// <returns>A <see cref="Uri"/> to the world API containing the specified shards.</returns>
        private Uri CreateWorldApiUri(WorldShards shards)
        {
            if (shards == null)
            {
                throw new ArgumentNullException("shards", "The shards object must not be null.");
            }

            if (!shards.NumberOfNations && !shards.NumberOfRegions && !shards.CensusName && !shards.CensusId && !shards.CensusSize && !shards.CensusScale && !shards.CensusMedian && !shards.FeaturedRegion && !shards.Happenings && !shards.NewNations && !shards.RegionsByTag)
            {
                throw new ArgumentException("At least one shard must be enabled in the request.", "shards");
            }

            var uri = "http://www.nationstates.net/cgi-bin/api.cgi?q=";

            if (shards.NumberOfNations)
            {
                uri += "numnations+";
            }

            if (shards.NumberOfRegions)
            {
                uri += "numregions+";
            }

            if (shards.CensusName)
            {
                uri += "census+";
            }

            if (shards.CensusId)
            {
                uri += "censusid+";
            }

            if (shards.CensusSize)
            {
                uri += "censussize+";
            }

            if (shards.CensusScale)
            {
                uri += "censusscale+";
            }

            if (shards.CensusMedian)
            {
                uri += "censusmedian+";
            }

            if (shards.FeaturedRegion)
            {
                uri += "featuredregion+";
            }

            if (shards.Happenings)
            {
                uri += "happenings";

                if (shards.HappeningsConfiguration == null)
                {
                    throw new ArgumentNullException("shards", "shards.HappeningsConfiguration must not be null when shards.Happenings is true.");
                }

                if (shards.HappeningsConfiguration.View != null && shards.HappeningsConfiguration.ViewValue == null) 
                {
                    throw new ArgumentNullException("shards", "shards.ViewValue must not be null when shards.View is not null.");
                }

                if (shards.HappeningsConfiguration.View == WorldShards.HappeningsConfigurationData.ViewType.Nation)
                {
                    uri += ";view=nation." + shards.HappeningsConfiguration.ViewValue;
                }                
                else if (shards.HappeningsConfiguration.View == WorldShards.HappeningsConfigurationData.ViewType.Region)
                {
                    uri += ";view=region." + shards.HappeningsConfiguration.ViewValue;
                }

                if (shards.HappeningsConfiguration.Filter != null)
                {
                    uri += ";filter=";

                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.NationalLegislation) == WorldShards.HappeningsConfigurationData.FilterType.NationalLegislation)
                    {
                        uri += "law+";
                    }
                    
                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.NationalChanges) == WorldShards.HappeningsConfigurationData.FilterType.NationalChanges)
                    {
                        uri += "change+";
                    }
                    
                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.NationalDispatches) == WorldShards.HappeningsConfigurationData.FilterType.NationalDispatches)
                    {
                        uri += "dispatch+";
                    }

                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.RegionalMessageBoard) == WorldShards.HappeningsConfigurationData.FilterType.RegionalMessageBoard)
                    {
                        uri += "rmb+";
                    }
                    
                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.RegionalEmbassies) == WorldShards.HappeningsConfigurationData.FilterType.RegionalEmbassies)
                    {
                        uri += "embassy+";
                    }
                    
                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.RegionalEjections) == WorldShards.HappeningsConfigurationData.FilterType.RegionalEjections)
                    {
                        uri += "eject+";
                    }
                    
                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.RegionalAdministrationChanges) == WorldShards.HappeningsConfigurationData.FilterType.RegionalAdministrationChanges)
                    {
                        uri += "admin+";
                    }

                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.MovementMoves) == WorldShards.HappeningsConfigurationData.FilterType.MovementMoves)
                    {
                        uri += "move+";
                    }
                    
                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.MovementFoundings) == WorldShards.HappeningsConfigurationData.FilterType.MovementFoundings)
                    {
                        uri += "founding+";
                    }
                    
                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.MovementEndings) == WorldShards.HappeningsConfigurationData.FilterType.MovementEndings)
                    {
                        uri += "cte+";
                    }

                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.WorldAssemblyVotes) == WorldShards.HappeningsConfigurationData.FilterType.WorldAssemblyVotes)
                    {
                        uri += "vote+";
                    }
                    
                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.WorldAssemblyResolutions) == WorldShards.HappeningsConfigurationData.FilterType.WorldAssemblyResolutions)
                    {
                        uri += "resolution+";
                    }
                    
                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.WorldAssemblyMembers) == WorldShards.HappeningsConfigurationData.FilterType.WorldAssemblyMembers)
                    {
                        uri += "member+";
                    }
                    
                    if ((shards.HappeningsConfiguration.Filter & WorldShards.HappeningsConfigurationData.FilterType.WorldAssemblyEndorsements) == WorldShards.HappeningsConfigurationData.FilterType.WorldAssemblyEndorsements)
                    {
                        uri += "endo+";
                    }

                    // Remove the extra "+"
                    uri = uri.Substring(0, uri.Length - 1);
                }

                if (shards.HappeningsConfiguration.Limit != null)
                {
                    uri += ";limit=" + shards.HappeningsConfiguration.Limit;
                }

                if (shards.HappeningsConfiguration.SinceId != null)
                {
                    uri += ";sinceid=" + shards.HappeningsConfiguration.SinceId;
                }

                if (shards.HappeningsConfiguration.BeforeId != null)
                {
                    uri += ";beforeid=" + shards.HappeningsConfiguration.BeforeId;
                }

                uri += "+";
            }

            if (shards.NewNations)
            {
                uri += "newnations+";
            }

            if (shards.RegionsByTag)
            {
                uri += "regionsbytag";
                
                if (shards.RegionsByTagConfiguration == null)
                {
                    throw new ArgumentNullException("shards", "shards.RegionsByTagConfiguration must not be null when shards.RegionsByTag is true.");
                }
                else if ((shards.RegionsByTagConfiguration.IncludeRegionsWithoutTags == null || shards.RegionsByTagConfiguration.IncludeRegionsWithoutTags.Length == 0) &&
                    (shards.RegionsByTagConfiguration.IncludeRegionsWithTags == null || shards.RegionsByTagConfiguration.IncludeRegionsWithoutTags.Length == 0))
                {
                    throw new ArgumentException("shards.IncludeRegionsWithoutTags and shards.IncludeRegionsWithTags must not both be null or empty when shards.RegionsByTag is true.", "shards");
                }
                else if ((shards.RegionsByTagConfiguration.IncludeRegionsWithoutTags == null && shards.RegionsByTagConfiguration.IncludeRegionsWithTags.Length > 10) ||
                    (shards.RegionsByTagConfiguration.IncludeRegionsWithTags == null && shards.RegionsByTagConfiguration.IncludeRegionsWithoutTags.Length > 10) ||
                    (shards.RegionsByTagConfiguration.IncludeRegionsWithoutTags.Length + shards.RegionsByTagConfiguration.IncludeRegionsWithTags.Length > 10))
                {
                    throw new ArgumentException("shards.IncludeRegionsWithoutTags and shards.IncludeRegionsWithTags cannot have a combined length exceeding 10.", "shards");
                }

                uri += ";tags=";

                if (shards.RegionsByTagConfiguration.IncludeRegionsWithoutTags != null)
                {
                    foreach (var tag in shards.RegionsByTagConfiguration.IncludeRegionsWithoutTags)
                    {
                        uri += "-" + tag + ",";
                    }
                }

                if (shards.RegionsByTagConfiguration.IncludeRegionsWithTags != null)
                {
                    foreach (var tag in shards.RegionsByTagConfiguration.IncludeRegionsWithoutTags)
                    {
                        uri += tag + ",";
                    }
                }
                
                // Remove the extra ","
                uri = uri.Substring(0, uri.Length - 1);

                uri += "+";
            }

            // Remove the extra "+"
            uri = uri.Substring(0, uri.Length - 1);
            
            uri += "&v=" + ApiVersion;

            return new Uri(uri);
        }

        /// <summary>
        /// Generates a <see cref="Uri"/> to the World Assembly API containing the specified shards and other information.
        /// </summary>
        /// <param name="council">The <see cref="WorldAssemblyCouncil"/> that is the subject of the request.</param>
        /// <param name="shards">The <see cref="WorldAssemblyShards"/> object that represents the shards to include in the request.</param>
        /// <returns>A <see cref="Uri"/> to the World Assembly API containing the specified shards and other information.</returns>
        private Uri CreateWorldAssemblyApiUri(WorldAssemblyCouncil council, WorldAssemblyShards shards)
        {
            if (shards == null)
            {
                throw new ArgumentNullException("shards", "The shards object must not be null.");
            }

            if (!shards.NumberOfNations && !shards.NumberOfDelegates && !shards.Delegates && !shards.Members && !shards.Happenings && !shards.MembershipHappenings && !shards.Resolution && !shards.LastResolution)
            {
                throw new ArgumentException("At least one shard (that is not shards.VotesHistory, shards.DelegateVotesHistory or shards.DelegateVotes) must be enabled in the request.", "shards");
            }

            var uri = "http://www.nationstates.net/cgi-bin/api.cgi?wa=" + ((int)council) + "&q=";

            if (shards.NumberOfNations)
            {
                uri += "numnations+";
            }

            if (shards.NumberOfDelegates)
            {
                uri += "numdelegates+";
            }

            if (shards.Delegates)
            {
                uri += "delegates+";
            }

            if (shards.Members)
            {
                uri += "members+";
            }

            if (shards.Happenings)
            {
                uri += "happenings+";
            }

            if (shards.MembershipHappenings)
            {
                uri += "memberlog+";
            }

            if (shards.Resolution)
            {
                uri += "resolution+";
            }

            if (shards.VotesHistory)
            {
                if (!shards.Resolution)
                {
                    throw new ArgumentException("shards.VotesHistory must not be true unless shards.Resolution is also true.", "shards");
                }

                uri += "votetrack+";
            }

            if (shards.DelegateVotesHistory)
            {
                if (!shards.Resolution)
                {
                    throw new ArgumentException("shards.DelegateVotesHistory must not be true unless shards.Resolution is also true.", "shards");
                }

                uri += "dellog+";
            }

            if (shards.DelegateVotes)
            {
                if (!shards.Resolution)
                {
                    throw new ArgumentException("shards.DelegateVotes must not be true unless shards.Resolution is also true.", "shards");
                }

                uri += "delvotes+";
            }

            if (shards.LastResolution)
            {
                uri += WebUtility.UrlEncode("lastresolution");
                uri += "+";
            }

            // Remove the extra "+"
            uri = uri.Substring(0, uri.Length - 1);

            uri += "&v=" + ApiVersion;

            return new Uri(uri);
        }

        /// <summary>
        /// Generates a <see cref="Uri"/> to the telegram API with the specified information.
        /// </summary>
        /// <param name="clientKey">The sender's telegram API client key.</param>
        /// <param name="telegramId">The telegram ID.</param>
        /// <param name="telegramSecretKey">The telegram secret key.</param>
        /// <param name="recipientNation">The recipient nation.</param>
        /// <returns>A <see cref="Uri"/> to the telegram API with the specified information.</returns>
        private Uri CreateTelegramApiUri(string clientKey, string telegramId, string telegramSecretKey, string recipientNation)
        {
            if (clientKey == null)
            {
                throw new ArgumentNullException("clientKey", "The client key must not be null.");
            }
            else if (clientKey.Equals(string.Empty))
            {
                throw new ArgumentException("The client key must not be empty.", "clientKey");
            }

            if (telegramId == null)
            {
                throw new ArgumentNullException("telegramId", "The telegram ID must not be null.");
            }
            else if (telegramId.Equals(string.Empty))
            {
                throw new ArgumentException("The telegram ID must not be empty.", "telegramId");
            }

            if (telegramSecretKey == null)
            {
                throw new ArgumentNullException("telegramSecretKey", "The telegram secret key must not be null.");
            }
            else if (telegramSecretKey.Equals(string.Empty))
            {
                throw new ArgumentException("The telegram secret key must not be empty.", "telegramSecretKey");
            }

            if (recipientNation == null)
            {
                throw new ArgumentNullException("recipientNation", "The recipient nation must not be null.");
            }
            else if (recipientNation.Equals(string.Empty))
            {
                throw new ArgumentException("The recipient nation must not be empty.", "recipientNation");
            }

            try
            {
                var uri = "http://www.nationstates.net/cgi-bin/api.cgi?a=sendTG";
                uri += "&client=" + WebUtility.UrlEncode(clientKey);
                uri += "&tgid=" + WebUtility.UrlEncode(telegramId);
                uri += "&key=" + WebUtility.UrlEncode(telegramSecretKey);
                uri += "&to=" + WebUtility.UrlEncode(recipientNation);
                uri += "&v=" + ApiVersion;

                return new Uri(uri);
            }
            catch (UriFormatException ex)
            {
                throw new ArgumentException("The client key, the telegram ID, the telegram secret key or the name of the recipient nation contains characters that cannot be included in a valid URI.", ex);
            }
        }

        /// <summary>
        /// Generates a <see cref="Uri"/> to the authentication API with the specified information.
        /// </summary>
        /// <param name="nation">The name of the nation to be authenticated.</param>
        /// <param name="loginVerificationCode">The nation's login verification code.</param>
        /// <param name="siteSpecificToken">A site specific token, or a null reference if no site specific token is specified.</param>
        /// <returns>A <see cref="Uri"/> to the authentication API with the specified information.</returns>
        private Uri CreateAuthenticationApiUri(string nation, string loginVerificationCode, string siteSpecificToken = null)
        {
            if (nation == null)
            {
                throw new ArgumentNullException("nation", "The name of the nation must not be null.");
            }
            else if (nation.Equals(string.Empty))
            {
                throw new ArgumentException("The name of the nation must not be empty.", "nation");
            }

            if (loginVerificationCode == null)
            {
                throw new ArgumentNullException("loginVerificationCode", "The login verification code must not be null.");
            }
            else if (loginVerificationCode.Equals(string.Empty))
            {
                throw new ArgumentException("The login verification code must not be empty.", "loginVerificationCode");
            }

            if (siteSpecificToken != null && siteSpecificToken.Equals(string.Empty))
            {
                throw new ArgumentException("The site specific token must not be empty.", "nation");
            }

            try
            {
                var uri = "http://www.nationstates.net/cgi-bin/api.cgi?a=verify";
                uri += "&nation=" + WebUtility.UrlEncode(nation);
                uri += "&checksum=" + WebUtility.UrlEncode(loginVerificationCode);
                uri += siteSpecificToken != null ? "&token=" + WebUtility.UrlEncode(siteSpecificToken) : string.Empty;
                uri += "&v=" + ApiVersion;

                return new Uri(uri);
            }
            catch (UriFormatException ex)
            {
                throw new ArgumentException("The name of the nation, the checksum or the site specific token contains characters that cannot be included in a valid URI.", ex);
            }
        }

        /// <summary>
        /// Retrieves a <see cref="Uri"/> to the nation data dump API.
        /// </summary>
        /// <returns>A <see cref="Uri"/> to the nation data dump API.</returns>
        private Uri CreateNationDataDumpApiUri()
        {
            return new Uri("http://www.nationstates.net/pages/nations.xml.gz");
        }

        /// <summary>
        /// Retrieves a <see cref="Uri"/> to the region data dump API.
        /// </summary>
        /// <returns>A <see cref="Uri"/> to the region data dump API.</returns>
        private Uri CreateRegionDataDumpApiUri()
        {
            return new Uri("http://www.nationstates.net/pages/regions.xml.gz");
        }
    }
}