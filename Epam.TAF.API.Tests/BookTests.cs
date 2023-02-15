using Epam.TAF.API.Controllers;
using Epam.TAF.API.Models.ResponseModels;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TAF.API.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void CheckAllBooksReturnedByAudioBibleId()
        {
            var audioBibles = new BiblesController(new CustomRestClient()).GetAudioBibles<AllBiblesModel>().Bibles.Data;

            var books = new BiblesController(new CustomRestClient()).GetBooksByAudioBibleId<BooksModel>(audioBibles.ElementAt(3).Id);

            var response = new BiblesController(new CustomRestClient()).GetBooksByAudioBibleId<RestResponse>(audioBibles.ElementAt(3).Id);

            Assert.Multiple(() =>
            {
                Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Invalid status code was returned while sending GET request to /v1/audio-bibles/{audioBibles.ElementAt(2).Id}/books");
                Assert.That(books.Books.Data.All(x => x.BibleId.Equals(audioBibles.ElementAt(3).Id)), Is.True, "GET request to /v1/audio-bibles/{audioBibleId}/books doesn't return nothing");
            }
            );
        }
    }
}
