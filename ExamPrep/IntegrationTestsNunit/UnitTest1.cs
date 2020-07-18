using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationTestsNunit
{
    public class Tests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri("https://libraryjuly.azurewebsites.net/");
        }

        [Test]
        public async Task CreateAuthor()
        {
            var Author = new Author();
            Author.FirstName = "Ventsi";
            Author.LastName = "Ventsislavov";
            Author.Genre = "Male";

            var content = new StringContent(Author.ToJson(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/authors", content);
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            var actualAuthor = Author.FromJson(responseAsString);

            var expectedAuthor = new Author()
            {
                Name = $"{Author.FirstName} {Author.LastName}",
                Genre = Author.Genre
            };

            Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name);
            Assert.AreEqual(expectedAuthor.Genre, actualAuthor.Genre);
        }

        [Test]
        public async Task PostAuthorInvalid()
        {
            var Author = new Author();
            Author.FirstName = "Ventsi";
            Author.LastName = "Ventsislavov";
            Author.DateofBirth = "Invalid Date";
            Author.Genre = "Male";

            var content = new StringContent(Author.ToJson(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/authors", content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }



        [Test]
        public async Task GetAuthor()
        {
            var authorId = "76053df4-6687-4353-8937-b45556748abe";
            var response = await _client.GetAsync($"/api/authors/{authorId}");
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            var actualAuthor = Author.FromJson(responseAsString);

            var expectedAuthor = new Author()
            {
                Name = $"George RR Martin",
                Genre = "Fantasy"
            };

            Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name);
            Assert.AreEqual(expectedAuthor.Genre, actualAuthor.Genre);
        }

        [Test]
        public async Task GetAuthorInvalid()
        {
            var authorId = new Guid();
            var response = await _client.GetAsync($"/api/authors/{authorId}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}