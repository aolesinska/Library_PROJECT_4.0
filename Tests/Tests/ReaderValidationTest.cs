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
            var result = validation.Validation("aaa","aaaaa","aaaaa@gmail.com","12345678912");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.Validation("aa", "aaaaa", "aaaaa@gmail.com", "12345678912");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be shorter than 3 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_MaxLength_ReturnsTrue()
        {
            //Act
            var result = validation.Validation("aaaaaaaaaabbbbbbbbbbaaaaaaaaaa", "aaaaa", "aaaaa@gmail.com", "12345678912");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_TooLong_ReturnFalse()
        {
            //Act
            var result = validation.Validation("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaa", "aaaaa@gmail.com", "12345678912");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be longer than 30 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_IsEmpty_ReturnFalse()
        {
            //Act
            var result = validation.Validation("", "aaaaa", "aaaaa@gmail.com", "12345678912");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be empty", result.ErrorMsg);
        }

        [TestMethod]
        public void FirstNameCheck_IsWhiteSpace_ReturnFalse()
        {
            //Act
            var result = validation.Validation("   ", "aaaaa", "aaaaa@gmail.com", "12345678912");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("First Name cannot be empty", result.ErrorMsg);
        }

        // ---------- LAST NAME CHECK ---------- //


        [TestMethod]
        public void LastNameCheck_MinLength_ReturnsTrue()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaa", "aaaaa@gmail.com", "12345678912");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "aa", "aaaaa@gmail.com", "12345678912");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be shorter than 3 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_MaxLength_ReturnsTrue()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaaaaaaabbbbbbbbbbaaaaaaaaaa", "aaaaa@gmail.com", "12345678912");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_TooLong_ReturnFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaa@gmail.com", "12345678912");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be longer than 30 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_IsEmpty_ReturnFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "", "aaaaa@gmail.com", "12345678912");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be empty", result.ErrorMsg);
        }

        [TestMethod]
        public void LastNameCheck_IsWhiteSpace_ReturnFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "   ", "aaaaa@gmail.com", "12345678912");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Last Name cannot be empty", result.ErrorMsg);
        }

        // ---------- EMAIL CHECK ---------- //

        [TestMethod]
        public void EmailCheck_MinLength_ReturnsTrue()
        {
            //Act
            var result = validation.Validation("aaaaa","aaaaa", "aaaaa@gmail.com", "12345678912");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void EmailCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaa", "aaa@gmail.com", "12345678912");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Email cannot be shorter than 15 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void EmailCheck_MaxLength_ReturnsTrue()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaa", "aaaaaaaaaabbbbbbbbbbaaaaaaaaaabbbbbbbbbb@gmail.com", "12345678912");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void EmailCheck_TooLong_ReturnFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbba@gmail.com", "12345678912");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Email cannot be longer than 50 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void EmailCheck_SignLack_ReturnFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaa", "aaaaaagmail.com", "12345678912");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Email has incorrect syntax. Please provide correct email", result.ErrorMsg);
        }

        [TestMethod]
        public void EmailCheck_SignLack2_ReturnFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaa", "aaaaaa@gmailcom", "12345678912");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("Email has incorrect syntax. Please provide correct email", result.ErrorMsg);
        }


        // ---------- PESEL CHECK ---------- //

        [TestMethod]
        public void PeselCheck_Ideal_ReturnsTrue()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaa", "aaaaaa@.gmailcom", "12345678912");

            //Assert
            Assert.IsTrue(result.IsValidate);
            Assert.AreEqual("", result.ErrorMsg);
        }

        [TestMethod]
        public void PeselCheck_TooShort_ReturnsFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaa", "aaaaaa@.gmailcom", "1111111111");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("PESEL cannot be shorter than 11 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void PeselCheck_TooLong_ReturnsFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaa", "aaaaaa@.gmailcom", "111111111111");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("PESEL cannot be longer than 11 chars", result.ErrorMsg);
        }

        [TestMethod]
        public void PeselCheck_WrongSyntax_ReturnsFalse()
        {
            //Act
            var result = validation.Validation("aaaaa", "aaaaa", "aaaaaa@.gmailcom", "11ab4761111");

            //Assert
            Assert.IsFalse(result.IsValidate);
            Assert.AreEqual("PESEL can contain only numbers", result.ErrorMsg);
        }
    }
}