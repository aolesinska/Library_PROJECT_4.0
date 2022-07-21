using LIBRARY_PROJECT_4._0.ValidationRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ReaderValidationTest
    {
        private ReaderValidation validation = new ReaderValidation();
        [TestInitialize]
        public void Initialize()
        {
            validation = new ReaderValidation();
        }



        // ---------- FIRST NAME CHECK ---------- //

        [TestMethod]
        public void FirstNameCheck_MinLength_ReturnsTrue()
        {
            //Act
            var result = validation.FirstNameValidation("aaa");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.FirstNameValidation("aa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be shorter than 3 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_MaxLength_ReturnsTrue()
        {
            //Act
            var result = validation.FirstNameValidation("aaaaaaaaaabbbbbbbbbbaaaaaaaaaa");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_TooLong_ReturnFalse()
        {
            //Act
            var result = validation.FirstNameValidation("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be longer than 30 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_IsEmpty_ReturnFalse()
        {
            //Act
            var result = validation.FirstNameValidation("");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be empty", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_IsWhiteSpace_ReturnFalse()
        {
            //Act
            var result = validation.FirstNameValidation("   ");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be empty", result.ErrorMsg);
        }

        // ---------- LAST NAME CHECK ---------- //


        [TestMethod]
        public void LastNameCheck_MinLength_ReturnsTrue()
        {
            //Act
            var result = validation.LastNameValidation("aaa");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.LastNameValidation("aa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be shorter than 3 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_MaxLength_ReturnsTrue()
        {
            //Act
            var result = validation.LastNameValidation("aaaaaaaaaabbbbbbbbbbaaaaaaaaaa");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_TooLong_ReturnFalse()
        {
            //Act
            var result = validation.LastNameValidation("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be longer than 30 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_IsEmpty_ReturnFalse()
        {
            //Act
            var result = validation.LastNameValidation("");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be empty", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_IsWhiteSpace_ReturnFalse()
        {
            //Act
            var result = validation.LastNameValidation("   ");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be empty", result.ErrorMsg);
        }

        // ---------- EMAIL CHECK ---------- //

        [TestMethod]
        public void EmailCheck_MinLength_ReturnsTrue()
        {
            //Act
            var result = validation.EmailValidation("aaaaa@gmail.com");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void EmailCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.EmailValidation("aaa@gmail.com");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Email cannot be shorter than 15 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void EmailCheck_MaxLength_ReturnsTrue()
        {
            //Act
            var result = validation.EmailValidation("aaaaaaaaaabbbbbbbbbbaaaaaaaaaabbbbbbbbbb@gmail.com");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void EmailCheck_TooLong_ReturnFalse()
        {
            //Act
            var result = validation.EmailValidation("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbba@gmail.com");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Email cannot be longer than 50 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void EmailCheck_SignLack_ReturnFalse()
        {
            //Act
            var result = validation.EmailValidation("aaaaaagmail.com");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Email has incorrect syntax. Please provide correct email", result.ErrorMsg);
        }

        [TestMethod]
        public void EmailCheck_SignLack2_ReturnFalse()
        {
            //Act
            var result = validation.EmailValidation("aaaaaa@gmailcom");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Email has incorrect syntax. Please provide correct email", result.ErrorMsg);
        }


        // ---------- PESEL CHECK ---------- //

        [TestMethod]
        public void PeselCheck_Ideal_ReturnsTrue()
        {
            //Act
            var result = validation.PeselValidation("12345678912");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void PeselCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.PeselValidation("1111111111");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("PESEL cannot be shorter than 11 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void PeselCheck_TooLong_ReturnsFalse()
        {
            //Act
            var result = validation.PeselValidation("111111111111");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("PESEL cannot be longer than 11 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void PeselCheck_WrongSyntax_ReturnsFalse()
        {
            //Act
            var result = validation.PeselValidation("11ab4761111");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("PESEL can contain only numbers", result.ErrorMsg);
        }
    }
}