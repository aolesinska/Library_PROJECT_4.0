using LIBRARY_PROJECT_4._0.ValidationRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AuthorValidationTest
    {
        private AuthorValidation validation = new AuthorValidation();
        [TestInitialize]
        public void Initialize()
        {
            validation = new AuthorValidation();
        }



        // ---------- FIRST NAME CHECK ---------- //

        [TestMethod]
        public void FirstNameCheck_MinLength_ReturnsTrue()
        {
            //Act
            var result = validation.Validation("aaa","aaaaa");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.Validation("aa", "aaaaa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be shorter than 3 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_MaxLength_ReturnsTrue()
        {
            //Act
            var result = validation.Validation("aaaaaaaaaabbbbbbbbbbaaaaaaaaaa", "aaaaa");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_TooLong_ReturnFalse()
        {
            //Act
            var result = validation.Validation("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be longer than 30 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_IsEmpty_ReturnFalse()
        {
            //Act
            var result = validation.Validation("", "aaaaa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be empty", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_IsWhiteSpace_ReturnFalse()
        {
            //Act
            var result = validation.Validation("   ", "aaaaa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be empty", result.ErrorMsg);
        }

        // ---------- LAST NAME CHECK ---------- //


        [TestMethod]
        public void LastNameCheck_MinLength_ReturnsTrue()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaa");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "aa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be shorter than 3 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_MaxLength_ReturnsTrue()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaaaaaaabbbbbbbbbbaaaaaaaaaa");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_TooLong_ReturnFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be longer than 30 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_IsEmpty_ReturnFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be empty", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_IsWhiteSpace_ReturnFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "   ");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be empty", result.ErrorMsg);
        }
    }
}
