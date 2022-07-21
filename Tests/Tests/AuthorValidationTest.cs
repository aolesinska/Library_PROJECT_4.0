using Microsoft.VisualStudio.TestTools.UnitTesting;
using LIBRARY_PROJECT_4._0.ValidationRules;

namespace Tests
{
    [TestClass]
    public class AuthorValidationTest
    {
        private AuthorValidation validation = new AuthorValidation();

        // ---------- FIRST NAME CHECK ---------- //

        [TestMethod]
        public void FirstNameCheck_MinLength_ReturnsTrue()
        {
            //Act
            var result = validation.FNameValidation("aaa");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.FNameValidation("aa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be shorter than 3 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_MaxLength_ReturnsTrue()
        {
            //Act
            var result = validation.FNameValidation("aaaaaaaaaabbbbbbbbbbaaaaaaaaaa");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_TooLong_ReturnFalse()
        {
            //Act
            var result = validation.FNameValidation("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be longer than 30 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_IsEmpty_ReturnFalse()
        {
            //Act
            var result = validation.FNameValidation("");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be empty", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_IsWhiteSpace_ReturnFalse()
        {
            //Act
            var result = validation.FNameValidation("   ");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be empty", result.ErrorMsg);
        }

        // ---------- LAST NAME CHECK ---------- //

        [TestMethod]
        public void LastNameCheck_MinLength_ReturnsTrue()
        {
            //Act
            var result = validation.LNameValidation("aaa");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.LNameValidation("aa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be shorter than 3 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_MaxLength_ReturnsTrue()
        {
            //Act
            var result = validation.LNameValidation("aaaaaaaaaabbbbbbbbbbaaaaaaaaaa");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_TooLong_ReturnFalse()
        {
            //Act
            var result = validation.LNameValidation("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be longer than 30 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_IsEmpty_ReturnFalse()
        {
            //Act
            var result = validation.LNameValidation("");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be empty", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_IsWhiteSpace_ReturnFalse()
        {
            //Act
            var result = validation.LNameValidation("   ");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be empty", result.ErrorMsg);
        }
    }
}
