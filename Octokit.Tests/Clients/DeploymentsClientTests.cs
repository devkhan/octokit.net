using System;
using System.Threading.Tasks;
using NSubstitute;
using Octokit;
using Octokit.Tests;
using Xunit;

public class DeploymentsClientTests
{
    public class TheGetAllMethod
    {
        private const string name = "name";
<<<<<<< 489130dd90472985c1ad0b8c60ce9ae859e5a801
<<<<<<< d2cc926af9c6b4210d0d46b5bfafd4e086d6d14b
        private const string owner = "owner";
=======
        private const string owner = "name";
>>>>>>> Small fixes in DeploymentsClientTests
=======
        private const string owner = "owner";
>>>>>>> Fix for prev commit.

        [Fact]
        public async Task EnsuresNonNullArguments()
        {
            var client = new DeploymentsClient(Substitute.For<IApiConnection>());

<<<<<<< d2cc926af9c6b4210d0d46b5bfafd4e086d6d14b
<<<<<<< 59c85110382ba173b2914239fb07badff276c505
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(null, name));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(owner, null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(owner, name, null));
=======
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(null, "name"));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll("owner", null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll("owner", "name", null));
>>>>>>> DeploymentsClientTests were updated
=======
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(null, name));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(owner, null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(owner, name, null));
>>>>>>> Small fixes in DeploymentsClientTests
        }

        [Fact]
        public async Task EnsuresNonEmptyArguments()
        {
            var client = new DeploymentsClient(Substitute.For<IApiConnection>());

            await Assert.ThrowsAsync<ArgumentException>(() => client.GetAll("", name));
            await Assert.ThrowsAsync<ArgumentException>(() => client.GetAll(owner, ""));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("\t")]
        [InlineData("  ")]
        [InlineData("\n\r")]
        public async Task EnsuresNonWhitespaceArguments(string whitespace)
        {
            var client = new DeploymentsClient(Substitute.For<IApiConnection>());

            await Assert.ThrowsAsync<ArgumentException>(() => client.GetAll(whitespace, name));
            await Assert.ThrowsAsync<ArgumentException>(() => client.GetAll(owner, whitespace));
        }

        [Fact]
        public void RequestsCorrectUrl()
        {
            var connection = Substitute.For<IApiConnection>();
            var client = new DeploymentsClient(connection);
<<<<<<< d2cc926af9c6b4210d0d46b5bfafd4e086d6d14b
<<<<<<< 59c85110382ba173b2914239fb07badff276c505
            var expectedUrl = string.Format("repos/{0}/{1}/deployments", owner, name);

            client.GetAll(owner, name);
            connection.Received(1)
                .GetAll<Deployment>(Arg.Is<Uri>(u => u.ToString() == expectedUrl), Args.ApiOptions);
        }

=======
            var expectedUrl = ApiUrls.Deployments("owner", "name");
=======
            var expectedUrl = ApiUrls.Deployments(owner, name);
>>>>>>> Small fixes in DeploymentsClientTests

            client.GetAll(owner, name);
            connection.Received(1)
                .GetAll<Deployment>(Arg.Is<Uri>(u => u == expectedUrl), Args.ApiOptions);
        }

>>>>>>> DeploymentsClientTests were updated
        [Fact]
        public void RequestsCorrectUrlWithApiOptions()
        {
            var connection = Substitute.For<IApiConnection>();
            var client = new DeploymentsClient(connection);
<<<<<<< d2cc926af9c6b4210d0d46b5bfafd4e086d6d14b
<<<<<<< 59c85110382ba173b2914239fb07badff276c505
            var expectedUrl = string.Format("repos/{0}/{1}/deployments", owner, name);
=======
            var expectedUrl = ApiUrls.Deployments("owner", "name");
>>>>>>> DeploymentsClientTests were updated
=======
            var expectedUrl = ApiUrls.Deployments(owner, name);
>>>>>>> Small fixes in DeploymentsClientTests

            var options = new ApiOptions
            {
                PageSize = 1,
                PageCount = 1,
                StartPage = 1
            };

<<<<<<< HEAD
<<<<<<< d2cc926af9c6b4210d0d46b5bfafd4e086d6d14b
<<<<<<< 59c85110382ba173b2914239fb07badff276c505
            client.GetAll(owner, name, options);
            connection.Received(1)
                .GetAll<Deployment>(Arg.Is<Uri>(u => u.ToString() == expectedUrl), options);
=======
            client.GetAll("owner", "name");
=======
            client.GetAll(owner, name);
>>>>>>> Small fixes in DeploymentsClientTests
            connection.Received(1).GetAll<Deployment>(Arg.Is<Uri>(u => u == expectedUrl), options);
>>>>>>> DeploymentsClientTests were updated
=======
            client.GetAll(owner, name, options);
            connection.Received(1)
                .GetAll<Deployment>(Arg.Is<Uri>(u => u == expectedUrl), options);
>>>>>>> Fix red test.
        }
    }

    public class TheCreateMethod
    {
<<<<<<< 59c85110382ba173b2914239fb07badff276c505
        private readonly NewDeployment newDeployment = new NewDeployment("aRef");
=======
        private readonly NewDeployment _newDeployment = new NewDeployment("aRef");
>>>>>>> DeploymentsClientTests were updated

        [Fact]
        public async Task EnsuresNonNullArguments()
        {
            var client = new DeploymentsClient(Substitute.For<IApiConnection>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null, "name", _newDeployment));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create("owner", null, _newDeployment));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create("owner", "name", null));
        }

        [Fact]
        public async Task EnsuresNonEmptyArguments()
        {
            var client = new DeploymentsClient(Substitute.For<IApiConnection>());

            await Assert.ThrowsAsync<ArgumentException>(() => client.Create("", "name", _newDeployment));
            await Assert.ThrowsAsync<ArgumentException>(() => client.Create("owner", "", _newDeployment));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("\t")]
        [InlineData("  ")]
        [InlineData("\n\r")]
        public async Task EnsuresNonWhitespaceArguments(string whitespace)
        {
            var client = new DeploymentsClient(Substitute.For<IApiConnection>());

            await Assert.ThrowsAsync<ArgumentException>(() => client.Create(whitespace, "name", _newDeployment));
            await Assert.ThrowsAsync<ArgumentException>(() => client.Create("owner", whitespace, _newDeployment));
        }

        [Fact]
        public void PostsToDeploymentsUrl()
        {
            var connection = Substitute.For<IApiConnection>();
            var client = new DeploymentsClient(connection);
            var expectedUrl = ApiUrls.Deployments("owner", "name");

            client.Create("owner", "name", _newDeployment);

            connection.Received(1).Post<Deployment>(Arg.Is<Uri>(u => u == expectedUrl),
                                                    Arg.Any<NewDeployment>());
        }

        [Fact]
        public void PassesNewDeploymentRequest()
        {
            var connection = Substitute.For<IApiConnection>();
            var client = new DeploymentsClient(connection);

            client.Create("owner", "name", _newDeployment);

            connection.Received(1).Post<Deployment>(Arg.Any<Uri>(),
                                                    _newDeployment);
        }
    }

    public class TheCtor
    {
        [Fact]
        public void EnsuresNonNullArguments()
        {
            Assert.Throws<ArgumentNullException>(() => new DeploymentsClient(null));
        }

        [Fact]
        public void SetsStatusesClient()
        {
            var client = new DeploymentsClient(Substitute.For<IApiConnection>());
            Assert.NotNull(client.Status);
        }
    }
}