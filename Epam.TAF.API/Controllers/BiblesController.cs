
using Epam.TAF.API.Controllers;
using Epam.TAF.API.Models.ResponseModels;
using Epam.TAF.API;
using RestSharp;

namespace Epam.TAF.API.Controllers
{
    /// <summary>
    /// Class that contains methods and resources for /v1 micro service
    /// </summary>
    public class BiblesController : BaseController
    {
        public BiblesController(CustomRestClient client, string apiKey = "") : base(client, Service.Bibles, apiKey)
        {
        }

        public BiblesController(CustomRestClient client) : base(client, Service.Bibles, client._apiConfig.ApiKey)
        {
        }

        private const string AllBiblesResource = "/v1/bibles";
        private const string BiblesById = "/v1/bibles/{0}";
        private const string AllAudioBibles = "/v1/audio-bibles";
        private const string AudioBibledById = "/v1/audio-bibles/{0}";
        private const string BooksByAudioBiblesId = "/v1/audio-bibles/{0}/books";

        /// <summary>
        /// Request that recieve all list of bibles
        /// </summary>
        /// <typeparam name="T"><see cref="AllBiblesModel"/></typeparam>
        /// <returns>response typeof<see cref="RestResponse"/> and <see cref="AllBiblesModel"/></returns>
        public (RestResponse Response, T Bibles) GetBibles<T>()
        {
            return Get<T>(AllBiblesResource);
        }

        /// <summary>
        /// Request that recieve single bibles by ID
        /// </summary>
        /// <typeparam name="T"><see cref="AllBiblesModel"/></typeparam>
        /// <param name="id"></param>
        /// <returns>response typeof<see cref="RestResponse"/> and <see cref="AllBiblesModel"/></returns>
        public (RestResponse Response, T Bibles) GetBibleById<T>(string id)
        {
            return Get<T>(string.Format(BiblesById, id));
        }

        /// <summary>
        /// Request that recieve all list of bibles
        /// </summary>
        /// <typeparam name="T"><see cref="AllBiblesModel"/></typeparam>
        /// <returns>response typeof<see cref="RestResponse"/> and <see cref="AllBiblesModel"/></returns>
        public (RestResponse Response, T Bibles) GetAudioBibles<T>()
        {
            return Get<T>(AllAudioBibles);
        }

        /// <summary>
        /// Request that recieve single bibles by ID
        /// </summary>
        /// <typeparam name="T"><see cref="AllBiblesModel"/></typeparam>
        /// <param name="id"></param>
        /// <returns>response typeof<see cref="RestResponse"/> and <see cref="AllBiblesModel"/></returns>
        public (RestResponse Response, T Bibles) GetSingleAudioBibleById<T>(string id)
        {
            return Get<T>(string.Format(AudioBibledById, id));
        }

        /// <summary>
        /// Request that receive books by audio-bible ID
        /// </summary>
        /// <typeparam name="T"><see cref="BooksModel"/></typeparam>
        /// <param name="id"></param>
        /// <returns>response typeof<see cref="RestResponse"/> and <see cref="BooksModel"/></returns>
        public (RestResponse Response, T Books) GetBooksByAudioBibleId<T>(string id)
        {
            return Get<T>(string.Format(BooksByAudioBiblesId, id));
        }
    }
}

