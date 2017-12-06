using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LambdaPractice.Tests
{
    [TestClass]
    public class CommonTest
    {
        Lambdas lambdas;

        [TestInitialize]
        public void Initialize()
        {
            lambdas = new Lambdas();
        }

        [TestMethod]
        public void LambdaCheck_Test()
        {
            lambdas.CreateLambda();
            Assert.AreEqual("(firstName, lastName) => new User() {FirstName = firstName, LastName = lastName}", lambdas.stringLambda);
        }
    }
}
