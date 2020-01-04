using NUnit.Framework;

namespace AdventOfCode2019.Day04.Tests
{
    [TestFixture]
    public class PasswordValidatorTests
    {
        [TestCase(42)]
        public void IsSixDigit_GivenLessThan6DigitNumber_ReturnsTrue(int number) =>
            Assert.IsTrue(PasswordValidator.IsSixDigit(number));

        [TestCase(426905)]
        public void IsSixDigit_Given6DigitNumber_ReturnsTrue(int number) =>
            Assert.IsTrue(PasswordValidator.IsSixDigit(number));

        [TestCase(4269051)]
        public void IsSixDigit_GivenMoreThan6DigitNumber_ReturnsFalse(int number) =>
            Assert.IsFalse(PasswordValidator.IsSixDigit(number));

        [TestCase(123456, 111111, 666666, true)]
        [TestCase(123456, 123567, 666666, false)]
        [TestCase(678901, 123567, 666666, false)]
        public void IsWithinRange_GivenValidArguments_ReturnsCorrectResult(int password, int min, int max,
            bool expectedResult) =>
            Assert.AreEqual(expectedResult, PasswordValidator.IsWithinRange(password, min, max));

        [TestCase(122345, true)]
        [TestCase(112345, true)]
        [TestCase(123455, true)]
        [TestCase(111111, true)]
        [TestCase(123789, false)]
        public void ContainsSameAdjacentDigits_GivenValidArgument_ReturnsCorrectResult(int password,
            bool expectedResult) =>
            Assert.AreEqual(expectedResult, PasswordValidator.ContainsSameAdjacentDigits(password));

        [TestCase(111123, true)]
        [TestCase(135679, true)]
        [TestCase(111111, true)]
        [TestCase(223450, false)]
        public void DigitsNeverDecrease_GivenValidArgument_ReturnsCorrectResult(int password,
            bool expectedResult) =>
            Assert.AreEqual(expectedResult, PasswordValidator.DigitsNeverDecrease(password));

        [TestCase(111123, 0, 999999, true)]
        [TestCase(223450, 0, 999999, false)]
        [TestCase(123789, 0, 999999, false)]
        public void MeetsCriteria_GivenValidArguments_ReturnsCorrectResult(int password, int min, int max,
            bool expectedResult) =>
            Assert.AreEqual(expectedResult, PasswordValidator.MeetsCriteria(password, min, max));

        [TestCase(112233, true)]
        [TestCase(111122, true)]
        [TestCase(111113, false)]
        [TestCase(111111, false)]
        [TestCase(123444, false)]
        public void
            ContainsTwoAdjacentDigits_GivenValidArgument_ReturnsCorrectResult(int password, bool expectedResult) =>
            Assert.AreEqual(expectedResult, PasswordValidator.ContainsTwoAdjacentDigits(password));
    }
}
