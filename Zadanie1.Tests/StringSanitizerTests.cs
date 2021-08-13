using NUnit.Framework;
using Zadanie1.DemoImplementation;

namespace Zadanie1.Tests
{
    [TestFixture]
    public class StringSanitizerTests
    {
        [Test]
        [TestCase("Adam","Adam")]
        [TestCase("ŻEŁU","EU")]
        [TestCase("aŚĆ$AaA","aAaA")]
        [TestCase("ŚĆx o","xo")]
        [TestCase("pó  kó","pk")]
        [TestCase("4A$  @ s1", "4As1")]
        [TestCase("  śpó $$$$$  rżó @@ !#$%^&*","pr")]
        public void GIVEN_string_to_sanitize_WHEN_sanitized_THEN_only_letters_and_numbers_are_returned(string stringToSanitize, string expectedSanitizedString)
        {
            var sanitizedString = StringSanitizer.SanitizeString(stringToSanitize);

            Assert.AreEqual(expectedSanitizedString, sanitizedString);
        }
    }
}