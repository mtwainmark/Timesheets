using NUnit.Framework;
using Timesheet.Api.Services;

namespace Timesheet.Tests
{
    public class AuthServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("??????")]
        [TestCase("??????")]
        [TestCase("???????")]
        public void Login_ShouldReturnTrue(string lastName)
        {
            //arrange
            var service = new AuthService();

            //act
            var result = service.Login(lastName);

            //assert
            Assert.IsNotEmpty(UserSession.Sessions);
            Assert.IsNotNull(UserSession.Sessions);
            Assert.IsTrue(UserSession.Sessions.Contains(lastName));

            Assert.IsTrue(result);

        }

        [Test]
        public void Login_InvokeLoginTwiceForOneLastName_ShouldReturnTrue()
        {
            //arrange
            var lastName = "??????";

            var service = new AuthService();

            //act
            var result = service.Login(lastName);
            result = service.Login(lastName);

            //assert
            Assert.IsNotEmpty(UserSession.Sessions);
            Assert.IsNotNull(UserSession.Sessions);
            Assert.IsTrue(UserSession.Sessions.Contains(lastName));


            Assert.IsTrue(result);

        }

        [TestCase("???????")]
        [TestCase(null)]
        [TestCase("")]
        public void Login_ShouldReturnFalse(string lastName)
        {
            //arrange
            var service = new AuthService();

            //act
            var result = service.Login(lastName);

            //assert
            Assert.IsFalse(result);

        }

        [Test]
        public void Logout()
        {
            Assert.Pass();
        }
    }
}