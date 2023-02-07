using RestSharp;
using Epam.TAF.API.Models.ResponseModels;
using Epam.TAF.API.Models.RequestModels;

namespace Epam.TAF.API.Controllers
{
    public class PhonesController : BaseController
    {
        public PhonesController(CustomRestClient client) : base(client, Service.Phones)
        {
        }

        private const string ListOfAllObjectsResourse = "/objects";
        private const string ListOfObjectsByIdResourse = "/objects?id={0}&id={1}&id={2}";
        private const string SingleObgectResourse = "objects/{0}";

        /// <summary>
        /// Request that recieves all Phone objects
        /// </summary>
        /// <typeparam name="T"><see cref="AllPhonesModel"/>AllPhonesModel</typeparam>
        /// <returns>response typeof<see cref="RestResponse"/> and List of <see cref="AllPhonesModel"/></returns>
        public (RestResponse Response, T AllPhones) GetPhones<T>()
        {
            return Get<T>(ListOfAllObjectsResourse);
        }

        /// <summary>
        /// Request that recieves Single Phone object by ID
        /// </summary>
        /// <typeparam name="T"><see cref="AllPhonesModel"/></typeparam>
        /// <param name="phoneId"></param>
        /// <returns>response typeof<see cref="RestResponse"/> and <see cref="AllPhonesModel"/></returns>
        public (RestResponse Response, T Phone) GetSinglePhone<T>(string phoneId)
        {
            return Get<T>(string.Format(SingleObgectResourse, phoneId));
        }

        /// <summary>
        /// Request that recieves List of Phones by ID
        /// </summary>
        /// <typeparam name="T"><see cref="AllPhonesModel"/></typeparam>
        /// <param name="id"></param>
        /// <returns>response typeof<see cref="RestResponse"/> and <see cref="AllPhonesModel"/></returns>
        public (RestResponse Response, T Phones) GetPhonesBySevrelIds<T>(params string[] id)
        {
            return Get<T>(string.Format(ListOfObjectsByIdResourse, id));
        }

        /// <summary>
        /// Request that creates phone that was sent as <see cref="PhoneRequestModel"/> model
        /// </summary>
        /// <typeparam name="T"><see cref="AllPhonesModel"/></typeparam>
        /// <param name="model"><see cref="PhoneRequestModel"/></param>
        /// <returns>response typeof<see cref="RestResponse"/> and <see cref="AllPhonesModel"/></returns>
        public (RestResponse Response, T Phone) AddPhone<T>(PhoneRequestModel model)
        {
            return Post<T, PhoneRequestModel>(ListOfAllObjectsResourse, model);
        }

        /// <summary>
        /// Request that updates phone by ID
        /// </summary>
        /// <typeparam name="T"><see cref="AllPhonesModel"/></typeparam>
        /// <param name="model"><see cref="PhoneRequestModel"/></param>
        /// <returns>response typeof<see cref="RestResponse"/> and <see cref="AllPhonesModel"/></returns>
        public (RestResponse Response, T Phone) UpdatePhone<T>(string phoneId, PhoneRequestModel model)
        {
            return Put<T, PhoneRequestModel>(string.Format(SingleObgectResourse, phoneId), model);
        }

        /// <summary>
        /// Request that delete phone that was sent as <see cref="PhoneRequestModel"/> model
        /// </summary>
        /// <typeparam name="T"><see cref="AllPhonesModel"/></typeparam>
        /// <param name="model"><see cref="PhoneRequestModel"/></param>
        /// <returns>response typeof<see cref="RestResponse"/> and message </returns>
        public (RestResponse Response, T Phone) DeletePhone<T>(string phoneId)
        {
            return Delete<T>(string.Format(SingleObgectResourse, phoneId));
        }

    }
}
