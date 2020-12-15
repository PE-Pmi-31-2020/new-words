using System;
using BLL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestNewWords
{
    [TestClass]
    public class UnitTestAuthorization
    {
        //[TestMethod]
        //public void TestLoginValidData()
        //{
        //    Mock<IAuthorization> authorization = new Mock<IAuthorization>();
        //    authorization.Setup(a => a.TryLogin("diana", "diana")).Returns(true);
        //    Assert.IsTrue(authorization.Object.TryLogin("diana", "diana"));

        //}

        //[TestMethod]
        //public void TestLoginNotValidData()
        //{
        //    Mock<IAuthorization> authorization = new Mock<IAuthorization>();
        //    authorization.Setup(a => a.TryLogin("d", "d")).Returns(false);
        //    Assert.IsFalse(authorization.Object.TryLogin("d", "d"));

        //}

        //[TestMethod]
        //public void TestLoginNotValidDataEmpty()
        //{
        //    Mock<IAuthorization> authorization = new Mock<IAuthorization>();
        //    authorization.Setup(a => a.TryLogin("", "")).Returns(false);
        //    Assert.IsFalse(authorization.Object.TryLogin("", ""));

        //}

        //[TestMethod]
        //public void TestSignUpValidData()
        //{
        //    Mock<IAuthorization> authorization = new Mock<IAuthorization>();
        //    authorization.Setup(a => a.TrySignup("diana", "diana")).Returns(true);
        //    Assert.IsTrue(authorization.Object.TrySignup("diana", "diana"));

        //}

        //[TestMethod]
        //public void TestSignUpNotValidData()
        //{
        //    Mock<IAuthorization> authorization = new Mock<IAuthorization>();
        //    authorization.Setup(a => a.TrySignup("d", "d")).Returns(false);
        //    Assert.IsFalse(authorization.Object.TrySignup("d", "d"));
        //}


        [TestMethod]
        public void TestSignUpValidData()
        {
            Mock<IAuthorization> authorization = new Mock<IAuthorization>();
            authorization.Setup(a => a.TrySignup("diana", "diana"));

        }

        [TestMethod]
        public void TestLoginValidData()
        {
            Mock<IAuthorization> authorization = new Mock<IAuthorization>();
            authorization.Setup(a => a.TryLogin("diana", "diana"));

        }

        [TestMethod]
        public void TestLoginNotValidData()
        {
            Mock<IAuthorization> authorization = new Mock<IAuthorization>();
            authorization.Setup(a => a.TryLogin("", ""));

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataCustomerException),
            "INVALID DATA!")]
        public void TestSignUpNotValidData()
        {
            Mock<IAuthorization> authorization = new Mock<IAuthorization>();
            authorization.Setup(a => a.TrySignup("d", "d"));

        }

    }
}
