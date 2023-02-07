using NUnit.Framework;
using RestSharp;
using Epam.TAF.API.Controllers;
using System.Net;
using Epam.TAF.API.Models.ResponseModels;

namespace Epam.TAF.API.Tests
{
    [TestFixture]
    public class BiblesTests
    {
        [Test]
        public void CheckAllBiblesResponseWithValidParams()
        {
            var response = new BiblesController(new CustomRestClient()).GetBibles<RestResponse>();
            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET request to /v1/bibles");
        }

        [Test]
        public void CheckAllBiblesResponseWithoutAuthorization()
        {
            var response = new BiblesController(new CustomRestClient(), string.Empty).GetBibles<RestResponse>();
            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Invalid status code was returned while sending GET request to /v1/bibles without authorisation");
        }

        [Test]
        public void CheckSingleBibleResponseWithValidParams()
        {
            string id = "2d5220a02a7aaac6-01";
            var response = new BiblesController(new CustomRestClient()).GetBibleById<RestResponse>(id);
            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Invalid status code was returned while sending GET request to /v1/bibles{id} with valid parametres");
        }

        [Test]
        public void CheckAllBiblesResponseReturnObject()
        {
            var response = new BiblesController(new CustomRestClient()).GetBibles<AllBiblesModel>();
            Assert.That(response.Bibles.Data.Any, Is.True, "GET request to /v1/bibles doesn't return nothing");
        }

        [Test]
        public void CheckSingleBibleResponseReturnBiblesById()
        {
            var bibles = new BiblesController(new CustomRestClient()).GetBibles<AllBiblesModel>().Bibles.Data;

            var response = new BiblesController(new CustomRestClient()).GetBibleById<RestResponse>(bibles.First().Id);

            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Invalid status code was returned while sending GET request to /v1/bibles{bibles.First().Id} with valid parametres");
        }
    }
}
