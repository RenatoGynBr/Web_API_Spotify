using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

using Newtonsoft.Json;
using SpotifyAPI.Web;

namespace API_Spotify.Spotify
{
    public class Spotify
    {
        // Authorization: Bearer BQDGiNauhAKeyexB_ZhZMS4O4J9odX_0VTSmTMw1QEYtJ59ySvmO58z6fXqgz7rS9yTAQZmGYyX-EcVcnHEqa3u6xVBbUZvpKxvAT_qgRmuTLY_4W6P-qikGHayPR8vcJnJ6w-oi55qgIZTIEyDTLmg0xTWC5Ls
        // https: //api.spotify.com/v1/albums
        // https: //api.spotify.com/v1/recommendations/available-genre-seeds
        // https: //open.spotify.com/album/3a0UOgDWw2pTajw85QPMiz?highlight=spotify:track:6rqhFgbbKwnb9MLmUQDhG6
        // https: //api.spotify.com/v1/playlists/3cEYpjA9oz9GiPac4AsH4n?market=BR&fields=items(added_by.id%2Ctrack(name%2Chref%2Calbum(name%2Chref)))" -H 
        // "Accept: application/json" -H 
        // "Content-Type: application/json" -H 
        // "Authorization: Bearer BQDGiNauhAKeyexB_ZhZMS4O4J9odX_0VTSmTMw1QEYtJ59ySvmO58z6fXqgz7rS9yTAQZmGYyX-EcVcnHEqa3u6xVBbUZvpKxvAT_qgRmuTLY_4W6P-qikGHayPR8vcJnJ6w-oi55qgIZTIEyDTLmg0xTWC5Ls"
        //url: _baseUri + '/recommendations/available-genre-seeds'

        public object getSpotifyListByGenre(int genre)
        {
            var spotify = new SpotifyClient("YourAccessToken");

            var baseUri = $"https://api.spotify.com/v1";
            var accessToken = "d60d720e5428f4cf880e4d04aa424ae7";
            //var promiseImplementation = null;

            string url = $"" + baseUri + "/listbygenre?g=" + genre + "&token=" + accessToken;
            var client = new WebClient();
            var content = client.DownloadString(url);
            object o = JsonConvert.DeserializeObject(content);
            string jsoncontent = JsonConvert.SerializeObject(o, Formatting.Indented);
            return jsoncontent;
        }
    }
}
