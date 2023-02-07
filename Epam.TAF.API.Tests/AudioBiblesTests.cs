using Epam.TAF.API;
using Epam.TAF.API.Controllers;
using Epam.TAF.API.Models.ResponseModels;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace Epam.TAF.API.Tests
{
    [TestFixture]
    public class AudioBiblesTests
    {
        [Test]
        public void CheckAllAudioBiblesReturnWithStatusOk()
        {
            var response = new BiblesController(new CustomRestClient()).GetAudioBibles<RestResponse>();

            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET request to /v1/audio-bibles resourse.");
        }

        [Test]
        public void CheckSingleAudioBibleReturnAudioBibleById()
        {
            var audioBibles = new BiblesController(new CustomRestClient()).GetAudioBibles<AllBiblesModel>().Bibles.Data;

            var response = new BiblesController(new CustomRestClient()).GetSingleAudioBibleById<RestResponse>(audioBibles.ElementAt(5).Id);

            Assert.Multiple(() =>
            {
                Assert.That(response.Response.IsSuccessStatusCode, Is.True, $"Invalid status code for GET request /v1/audio-bibles/{audioBibles.ElementAt(5).Id}.");
                Assert.That(response.Response.Content, Is.Not.Null, "Response came without content");
            }
            );
        }

        [Test]
        public void CheckAllAudioBiblesResponseWithoutAuthorization()
        {
            var response = new BiblesController(new CustomRestClient(), string.Empty).GetAudioBibles<RestResponse>();

            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Invalid status code was returned while sending GET request to /v1/bibles without authorization");
        }
    }
}