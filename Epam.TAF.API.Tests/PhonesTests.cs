using Epam.TAF.API.Controllers;
using NUnit.Framework;
using RestSharp;
using System.Net;
using Epam.TAF.API.Models.ResponseModels;
using Epam.TAF.API.Models.RequestModels;
using Epam.TAF.API.Models.SharedModels;

namespace Epam.TAF.API.Tests
{
    [TestFixture]
    public class PhonesTests
    {
        [Test]
        public void CheckGetAllPhonesResponseWithStatusCodeOK()
        {
            var response = new PhonesController(new CustomRestClient()).GetPhones<List<AllPhonesModel>>();
            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET request to /objects");
        }

        [Test]
        public void CheckThatListOfObjectsReturnedByIds()
        {
            var expectedCountOfPhone = 3;

            var phones = new PhonesController(new CustomRestClient()).GetPhones<List<AllPhonesModel>>().AllPhones;

            var response = new PhonesController(new CustomRestClient()).GetPhonesBySevrelIds<List<AllPhonesModel>>(phones.ElementAt(0).Id, phones.ElementAt(2).Id, phones.ElementAt(3).Id).Phones;

            Assert.Multiple(() =>
            {
                Assert.That(response.Count, Is.EqualTo(expectedCountOfPhone), $"Get request returned more or less result than expected {expectedCountOfPhone}");
                Assert.That(response.First().Id, Is.EqualTo(phones.ElementAt(0).Id), $"Get request returned incorrect element.");
                Assert.That(response.Last().Id, Is.EqualTo(phones.ElementAt(3).Id), $"Get request returned incorrect element.");

            });
        }

        [Test]
        public void CheckReturnOnePhoneModelById()
        {
            var phone = new PhonesController(new CustomRestClient()).GetPhones<List<AllPhonesModel>>().AllPhones.ElementAt(1);
    
            var response = new PhonesController(new CustomRestClient()).GetSinglePhone<AllPhonesModel>(phone.Id);

            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET request to /objects/{id}");
        }

        [Test]
        public void CheckAbilitiToAddPhone()
        {
            var phoneToCreate = new PhoneRequestModel
            {
                Name = "Samsung S9+",
                Data = new PhoneData
                {
                    Price = 170,
                    Year = 2019
                }
            };
            var createPhone = new PhonesController(new CustomRestClient()).AddPhone<AllPhonesModel>(phoneToCreate).Phone;

            var receivedPhone = new PhonesController(new CustomRestClient()).GetSinglePhone<AllPhonesModel>(createPhone.Id).Phone;

            new PhonesController(new CustomRestClient()).DeletePhone<AllPhonesModel>(createPhone.Id);

            Assert.That(receivedPhone, Is.Not.Null, $"Phone with id {createPhone.Id} was not created.");
        }

        [Test]
        public void VerifyAbilitiToUpdatePhone()
        {
            var newColor = "black";
            var phoneToCreate = new PhoneRequestModel
            {
                Name = "Samsung S9+",
                Data = new PhoneData
                {
                    Price = 1000,
                    Year = 2019,
                    Color = "green"

                }
            };

            var createPhone = new PhonesController(new CustomRestClient()).AddPhone<AllPhonesModel>(phoneToCreate).Phone;

            var receivedCreatedPhone = new PhonesController(new CustomRestClient()).GetSinglePhone<AllPhonesModel>(createPhone.Id).Phone;

            var phoneUpdate = new PhoneRequestModel
            {
                Name = "Samsung S9+",
                Data = new PhoneData
                {
                    Price = 1000,
                    Year = 2019,
                    Color = newColor
                }
            };

            var updatedPhone = new PhonesController(new CustomRestClient()).UpdatePhone<AllPhonesModel>(receivedCreatedPhone.Id, phoneUpdate).Phone;

            var receivedUpdatedPhone = new PhonesController(new CustomRestClient()).GetSinglePhone<AllPhonesModel>(updatedPhone.Id).Phone;

            new PhonesController(new CustomRestClient()).DeletePhone<AllPhonesModel>(receivedUpdatedPhone.Id);

            Assert.Multiple(() =>
            {
                Assert.That(receivedCreatedPhone.Data.Year, Is.EqualTo(receivedUpdatedPhone.Data.Year), $"Phone after update has different manufactoring year.");
                Assert.That(receivedUpdatedPhone.Data.Color, Is.EqualTo(newColor), $"Phone after updating doesn't have {newColor} color.");
                Assert.That(receivedUpdatedPhone.Data.Color, Is.Not.EqualTo(receivedCreatedPhone.Data.Color), $"Phone after updating doesn't change color to {newColor}.");
                Assert.That(receivedCreatedPhone.Data.Price, Is.EqualTo(receivedUpdatedPhone.Data.Price), $"Phone after update has different price.");
                Assert.That(receivedCreatedPhone.Name, Is.EqualTo(receivedUpdatedPhone.Name), $"Phone after update has different name.");
            }
            );
        }

        [Test]
        public void VerifyThatPhoneDeleted()
        {
            string deleteMessage = "Object with id = {0} has been deleted.";

            var phoneToCreate = new PhoneRequestModel
            {
                Name = "Samsung S22+",
                Data = new PhoneData
                {
                    Price = "2500",
                    Year = 2022,
                    Color = "blue",
                }
            };

            var createdPhone = new PhonesController(new CustomRestClient()).AddPhone<AllPhonesModel>(phoneToCreate).Phone;

            var receivedPhone = new PhonesController(new CustomRestClient()).GetSinglePhone<AllPhonesModel>(createdPhone.Id).Phone;

            var response = new PhonesController(new CustomRestClient()).DeletePhone<AllPhonesModel>(receivedPhone.Id);

            var receivedPhoneAfterDelete = new PhonesController(new CustomRestClient()).GetSinglePhone<AllPhonesModel>(createdPhone.Id);

            var content = response.Response.Content;

            Assert.Multiple(() =>
            {
                Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Invalid status code for DELETE request.");
                Assert.That(receivedPhoneAfterDelete.Response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(content.Contains(string.Format(deleteMessage, receivedPhone.Id)), Is.True, "Delete message is absent");

            });
        }

        [Test]
        public void VerifyThatAllFieldsArePresentAfterUpdate()
        {
            var capacityGb = 512;
            var phoneToCreate = new PhoneRequestModel
            {
                Name = "Samsung S22+",
                Data = new PhoneData
                {
                    Price = "2500",
                    Year = 2022,
                    СapacityGb = capacityGb,
                    Capacity = "128",
                }
            };

            var createdPhone = new PhonesController(new CustomRestClient()).AddPhone<AllPhonesModel>(phoneToCreate).Phone;

            var receivedPhone = new PhonesController(new CustomRestClient()).GetSinglePhone<AllPhonesModel>(createdPhone.Id);

            var responceContent = receivedPhone.Response.Content;

            new PhonesController(new CustomRestClient()).DeletePhone<AllPhonesModel>(createdPhone.Id);

            Assert.That(responceContent.Contains(capacityGb.ToString()), Is.True, $"Capacity GB {capacityGb} isn't equal or missing in the created phone");
        }
    }
}
