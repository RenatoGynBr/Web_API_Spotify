using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
//using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace API_Spotify.Spotify
{
    public class Spotify
    {
        public object getSpotifyListByType(int genre)
        {
            var baseUri = "https://api.spotify.com/v1";
            var accessToken = "d60d720e5428f4cf880e4d04aa424ae7";
            //var promiseImplementation = null;

            string url = $"" + baseUri + "/listbygenre?g=" + genre + "&token=" + accessToken;
            var client = new WebClient();
            var content = client.DownloadString(url);
            //var serializer = new JavaScriptSerializer();
            //var jsoncontent = serializer.Deserialize<Object>(content);
            object o = JsonConvert.DeserializeObject(content);
            string jsoncontent = JsonConvert.SerializeObject(o, Formatting.Indented);
            return jsoncontent;
        }
    }
}
