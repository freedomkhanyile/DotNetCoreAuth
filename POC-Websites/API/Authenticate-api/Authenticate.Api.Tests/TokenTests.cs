using Authenticate.Api.Data;
using Authenticate.Api.Entities;
using Authenticate.Api.Interfaces;
using Authenticate.Api.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Authenticate.Api.Tests
{
    [TestClass]
    public class TokenTests
    {
        [TestMethod]
        public void GetTokenLogic_MustReturnToken_WithAuthorizedUser()
        {
            var _mockTokenRepository = new Mock<IToken>();
            var response = new TokenResponse() { Token = "eyJhc" } ;
            var request = new TokenRequest() { Username = "Freedom.Khanyile@mail.com" };
            _mockTokenRepository.Setup(x => x.RequestToken(request)).Returns(response);

            var systemUnderTest = new TokenLogic(_mockTokenRepository.Object);

            var result = systemUnderTest.GetToken(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Token, "eyJhc");

        }

        [TestMethod]
        public void GetTokenRepository_MustReturnToken_WithAuthorizedUser()
        {
             
            var _mockFireBaseRepository = new Mock<IBase>();
            var _mockConfigurationRoot = new Mock<IConfigurationRoot>();
            _mockConfigurationRoot.SetupGet(x => x[It.IsAny<string>()]).Returns("dd%88*377f6d&f£$$£$FdddFF33fssDG^!3");

            var users = new List<User>()
           {
               new User {Email = "Freedom.Khanyile@mail.com", Role = "Software Developer", Status = "Active"},
               new User {Email = "Jane.Doe@mail.com", Role = "Databases Developer", Status = "Active"},
               new User {Email = "Rick.Morty@mail.com", Role = "Andriod Developer", Status = "Active"}

           };
            _mockFireBaseRepository.Setup(x => x.GetUsers()).Returns(users);
            var response = new TokenResponse() { Token = "eyJhc" };
            var request = new TokenRequest() { Username = users[0].Email };           

            var systemUnderTest = new TokenRepository(_mockConfigurationRoot.Object, _mockFireBaseRepository.Object);

            var result = systemUnderTest.RequestToken(request);

            Assert.IsNotNull(result);        

        }

    }
}
