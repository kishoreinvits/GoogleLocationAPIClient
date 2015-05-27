using System;

namespace GooglePlacesCSharp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter Your Search Term below");
            var searchTerm = Console.ReadLine();
            PlacesResponse places = GoogleApiClient.GetTextSearchResponse(searchTerm);

            Console.WriteLine("--------------------------------------");
            if (places != null)
                foreach (var place in places.results)
                {
                    //Feel free to explore all othet variables Google is exposing like rating placeId etc..
                    Console.WriteLine("Name: {0}", place.name);
                    Console.WriteLine("Address: {0}", place.formatted_address);
                    Console.WriteLine("Latituide: {0}", place.geometry.location.lat);
                    Console.WriteLine("Longitude: {0}", place.geometry.location.lng);
                    Console.WriteLine("Type: {0}", string.Join(";", place.types));
                    Console.WriteLine("--------------------------------------");
                }

            Console.ReadLine();
        }
    }
}
