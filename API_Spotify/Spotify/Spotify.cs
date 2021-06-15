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
        // https: //api.spotify.com/v1/albums
        // https: //api.spotify.com/v1/recommendations/available-genre-seeds
        // https: //open.spotify.com/album/3a0UOgDWw2pTajw85QPMiz?highlight=spotify:track:6rqhFgbbKwnb9MLmUQDhG6
        // https: //api.spotify.com/v1/playlists/3cEYpjA9oz9GiPac4AsH4n?market=BR&fields=items(added_by.id%2Ctrack(name%2Chref%2Calbum(name%2Chref)))" -H 
        // "Accept: application/json" -H 
        // "Content-Type: application/json" -H 
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
