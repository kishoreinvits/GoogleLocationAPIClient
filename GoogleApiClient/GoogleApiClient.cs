using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace GooglePlacesCSharp
{
    class GoogleApiClient
    {
        public static PlacesResponse GetTextSearchResponse(string searchTerm)
        {
            PlacesResponse respDes=null;
            //Ref: https://developers.google.com/places/webservice/search#PlaceSearchPaging
            //ToDo: Hardcoded my Key below. replace it with your google API key in below URL - key=[AIzaSyBhBzQ1WX1WEJnzX3PsxEatsIPAWXQJOis]&
            var webRequest = WebRequest
                .Create(
                    @"https://maps.googleapis.com/maps/api/place/textsearch/json?key=AIzaSyBhBzQ1WX1WEJnzX3PsxEatsIPAWXQJOis&query=" +
                    searchTerm
                ) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Timeout = 20000;
                webRequest.Method = "GET";

                var response = webRequest.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    var r = new StreamReader(stream);
                    var resp = r.ReadToEnd();
                    respDes = JsonConvert.DeserializeObject<PlacesResponse>(resp);
                    if (respDes.results.Count > 0)
                    {
                        //Show Them
                    }
                }
                //webRequest.BeginGetResponse(RequestCompleted, webRequest);
            }
            return respDes;
        }

        //Use below if you want an async callback along with commented webRequest.BeginGetResponse(RequestCompleted, webRequest);
        private static void RequestCompleted(IAsyncResult result)
        {
            var request = (HttpWebRequest)result.AsyncState;
            var response = (HttpWebResponse)request.EndGetResponse(result);

            using (var stream = response.GetResponseStream())
            {
                if (stream != null)
                {
                    var r = new StreamReader(stream);
                    var resp = r.ReadToEnd();
                    var respDes = JsonConvert.DeserializeObject<PlacesResponse>(resp);
                    if (respDes.results.Count > 0)
                    {
                        //Show Them
                    }
                }
            }

        }
    }
}