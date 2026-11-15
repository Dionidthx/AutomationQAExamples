
using System.Net;
using System.Net.Http.Json;
using NUnit.Framework;

namespace AutomationQAExamples.Tests;

public class ApiTests
{
    private HttpClient _client = null!;

    [SetUp]
    public void Setup()
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(
                "https://jsonplaceholder.typicode.com/")
        };
    }

    [TearDown]
    public void Cleanup()
    {
        _client.Dispose();
    }

    // TEST 1: GET request
    [Test]
    public async Task GetPost_ShouldReturnCorrectPost()
    {
        var response = await _client.GetAsync("posts/1");

        Assert.That(response.StatusCode,
            Is.EqualTo(HttpStatusCode.OK));

        var post = await response.Content
            .ReadFromJsonAsync<Post>();

        Assert.That(post, Is.Not.Null);
        Assert.That(post!.Id, Is.EqualTo(1));
        Assert.That(post.Title, Is.Not.Empty);
    }

    // TEST 2: POST request
    [Test]
    public async Task CreatePost_ShouldReturnCreatedPost()
    {
        var newPost = new Post
        {
            Title = "Automation QA Test",
            Body = "Testing POST request",
            UserId = 1
        };

        var response = await _client.PostAsJsonAsync(
            "posts", newPost);

        Assert.That(response.StatusCode,
            Is.EqualTo(HttpStatusCode.Created));

        var createdPost = await response.Content
            .ReadFromJsonAsync<Post>();

        Assert.That(createdPost, Is.Not.Null);
        Assert.That(createdPost!.Title,
            Is.EqualTo(newPost.Title));
        Assert.That(createdPost.Body,
            Is.EqualTo(newPost.Body));
    }

    // TEST 3: Data-driven test
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public async Task GetPost_ShouldReturnCorrectId(int postId)
    {
        var response = await _client.GetAsync(
            $"posts/{postId}");

        Assert.That(response.StatusCode,
            Is.EqualTo(HttpStatusCode.OK));

        var post = await response.Content
            .ReadFromJsonAsync<Post>();

        Assert.That(post, Is.Not.Null);
        Assert.That(post!.Id, Is.EqualTo(postId));
    }


    // TEST 4: Negative test
    [Test]
    public async Task GetNonExistingPost_ShouldReturnNotFound()
    {
        var response = await _client.GetAsync("posts/9999");

        Assert.That(response.StatusCode,
            Is.EqualTo(HttpStatusCode.NotFound));
    }

    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
    }
}
