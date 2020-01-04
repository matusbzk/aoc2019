using System.Collections.Generic;

namespace AdventOfCode2019.Day04
{
    /// <summary>
    /// Used to do all validation of passwords
    /// </summary>
    public static class PasswordValidator
    {
        /// <summary>
        /// Get all valid passwords in given range - for part 1
        /// </summary>
        /// <param name="min">Min</param>
        /// <param name="max">Max</param>
        /// <returns>All valid passwords in given range</returns>
        public static IEnumerable<int> GetAllValidPasswordsWithinRange(int min, int max)
        {
            for (var i = min; i <= max; i++)
            {
                if (MeetsCriteria(i, min, max))
                {
                    yield return i;
                }
            }
        }

        /// <summary>
        /// Get all valid passwords in given range - for part 2
        /// </summary>
        /// <param name="min">Min</param>
        /// <param name="max">Max</param>
        /// <returns>All valid passwords in given range</returns>
        public static IEnumerable<int> GetAllAdjustedValidPasswordsWithinRange(int min, int max)
        {
            for (var i = min; i <= max; i++)
            {
                if (MeetsAdjustedCriteria(i, min, max))
                {
                    yield return i;
                }
            }
        }

        /// <summary>
        /// Returns whether password matches all criteria for part 1
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="min">Min</param>
        /// <param name="max">Max</param>
        /// <returns>True if password matches criteria</returns>
        public static bool MeetsCriteria(int password, int min, int max) =>
            IsSixDigit(password) && IsWithinRange(password, min, max) && ContainsSameAdjacentDigits(password) &&
            DigitsNeverDecrease(password);

        /// <summary>
        /// Returns whether password matches all criteria for part 2
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="min">Min</param>
        /// <param name="max">Max</param>
        /// <returns>True if password matches criteria</returns>
        public static bool MeetsAdjustedCriteria(int password, int min, int max) =>
            IsSixDigit(password) && IsWithinRange(password, min, max) && ContainsTwoAdjacentDigits(password) &&
            DigitsNeverDecrease(password);

        /// <summary>
        /// Returns whether password can be represented as 6 digit number.
        /// </summary>
        /// <param name="password">Password</param>
        /// <returns>True if password is 6 digit number</returns>
        /// <remarks>Assuming ie. 42 is OK since it can be 000042</remarks>
        public static bool IsSixDigit(int password) => password < 1000000;

        /// <summary>
        /// Returns whether password is in range
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <returns>True if password is in range</returns>
        public static bool IsWithinRange(int password, int min, int max) => password >= min && password <= max;

        /// <summary>
        /// Returns whether two adjacent digits of password are the same.
        /// </summary>
        /// <param name="password">Password</param>
        /// <returns>True if two adjacent digits of password are the same</returns>
        public static bool ContainsSameAdjacentDigits(int password)
        {
            var passwordStr = password.ToString();
            for (var i = 0; i < passwordStr.Length - 1; i++)
            {
                if (passwordStr[i] == passwordStr[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns whether exactly two adjacent digits of password are the same.
        /// </summary>
        /// <param name="password">Password</param>
        /// <returns>True if exactly two adjacent digits of password are the same</returns>
        public static bool ContainsTwoAdjacentDigits(int password)
        {
            var passwordStr = password.ToString();
            var loadedDigits = "";
            foreach (var digit in passwordStr)
            {
                if (loadedDigits == "" || loadedDigits[0] == digit)
                {
                    loadedDigits += digit;
                }
                else
                {
                    if (loadedDigits.Length == 2)
                    {
                        return true;
                    }

                    loadedDigits = $"{digit}";
                }
            }

            return loadedDigits.Length == 2;
        }

        /// <summary>
        /// Returns whether the condition that going from left to right the digits
        /// never decrease is true
        /// </summary>
        /// <param name="password">Password</param>
        /// <returns>True if digits never decrease</returns>
        public static bool DigitsNeverDecrease(int password)
        {
            var passwordStr = password.ToString();
            var maxDigit = 0;
            foreach (var digit in passwordStr)
            {
                if (digit < maxDigit)
                {
                    return false;
                }

                maxDigit = digit;
            }

            return true;
        }
    }
}
