# NationStates API for .NET #

## Summary ##

NationStates API for .NET is a free and open source library that allows .NET applications to easily access the NationStates API without worrying about making HTTP requests, decoding XML or rate limiting.

## Features ##

* Complete interface to the NationStates API (supports the nation, region, world, World Assembly, telegram, authentication and data dump APIs)
* Rate-limiting to prevent blocked access to the API, including for the telegram API (recruitment and non-recruitment)
* XML decoding (all data is returned in simple C# data structures)
* Currently supports version 7 of the API

## Documentation ##

### System Requirements ###
* The [.NET Framework 4.5](http://www.microsoft.com/en-ca/download/details.aspx?id=30653)

### Help ###

The .NET interface is relatively intuitive, and all methods and properties are documented using standard C# XML documentation. You will need to have a working understanding of the NationStates API, whose documentation is available [here](http://www.nationstates.net/pages/api.html).

#### Examples ####

The following is a simple example (written in C#) that retrieves a nation's full name and prints it to the console:

	using Auralia.NationStates.Api;

	class SimpleExample {

		static void Main(string[] args) {
			
			// Create main API object
			var api = new Api("<INSERT USER AGENT HERE>");

			// Specify shards to be requested from the nation API
			// (In this case, the "fullname" shard, which represents the nation's full name)
		    var nationShards = new NationShards();
		    nationShards.FullName = true;
		
			// Retrieve those shards from the nation API
		    var nationData = api.CreateNationApiRequest("<INSERT NATION HERE>", nationShards);
		
			// Print the nation's full name 
		    Console.WriteLine(nationData.FullName);
		
			// Prevent the console from closing immediately
		    Console.ReadKey();
		}
	}

The following is a more complex example that retrieves and sorts a list of nations in a region by their influence score, then prints the list to the console:

	using Auralia.NationStates.Api;

	class ComplexExample {

		static void Main(string[] args) {
			
			// List of nations and their corresponding influence scores
			var influence = new List<Tuple<string, double>>();
            
			// Constant representing the census ID for influence
			var influenceId = 65;

			// Create main API object
            var api = new Api("<INSERT USER AGENT HERE>");

			// Specify shards to be requested from the region API
			// (In this case, the "nations" shard, which retrieves a list of nations in the region)
            var regionShards = new RegionShards();
            regionShards.Nations = true;

			// Retrieve those shards from the region API
            var regionData = api.CreateRegionApiRequest("<INSERT REGION HERE>", regionShards);
            var nations = regionData.Nations;

			// For each nation, request its name and influence score from the API and add it to the list
            for (var i = 0; i < nations.Length; i++)
            {
                var nationShards = new NationShards();
                nationShards.Name = true;
                nationShards.CensusStatistics = true;
                nationShards.CensusStatisticsIds = new List<int?>(new int?[] { influenceId });

                var nationData = api.CreateNationApiRequest(nations[i], nationShards);
                
                var name = nationData.Name;
                var score = nationData.CensusStatistics[0].Value.Value;
                influence.Add(new Tuple<string, double>(name, score));
            }

			// Order the list, first by nation name and then by influence score
            influence = influence.OrderBy(x => x.Item1).ToList();
            influence = influence.OrderByDescending(x => x.Item2).ToList();

			// Print the influence score of each nation in the region
            Console.WriteLine(String.Format("{0, -50} {1, -10}", "Nation", "Influence"));
            Console.WriteLine("================================================== ==========");
            foreach (Tuple<string, double> tuple in influence)
            {
                Console.WriteLine(String.Format("{0, -50} {1, -10}", tuple.Item1, tuple.Item2));
            }

			// Prevent the console from closing immediately
            Console.ReadKey();
		}
	}

## Downloads ##

Source code and binary downloads are available from [the project's GitHub page](https://github.com/auralia/nationstates-api-for-.net).

## Copyright and License ##

Copyright (C) 2013 Auralia.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.