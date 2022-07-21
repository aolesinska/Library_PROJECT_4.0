using LIBRARY_PROJECT_4._0.ValidationRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PublisherValidationTest
    {
        private PublisherValidation validation = new PublisherValidation();
        [TestInitialize]
        public void Initialize()
        {
            validation = new PublisherValidation();
        }

        // ---------- POSTCODE CHECK ---------- //

        [TestMethod]
        public void PostcodeCheck_Ideal_ReturnsTrue()
        {
            //Act
            var result = validation.PostcodeValidation("11-111");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void PostcodeCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.PostcodeValidation("11-11");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Postcode cannot be shorter than 6 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void PostcodeCheck_TooLong_ReturnsFalse()
        {
            //Act
            var result = validation.PostcodeValidation("11-1111");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Postcode cannot be longer than 6 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void PostcodeCheck_WrongSyntax_ReturnsFalse()
        {
            //Act
            var result = validation.PostcodeValidation("111111");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Invalid Postcode", result.ErrorMsg);
        }

    }
}