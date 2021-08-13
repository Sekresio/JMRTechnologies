using System.Collections.Generic;
using NUnit.Framework;
using Zadanie1.DemoImplementation;
using Zadanie1.DemoSource;
using Zadanie1.DemoTarget;

namespace Zadanie1.Tests
{
    [TestFixture]
    public class PeopleWIthEmailsConverterTests
    {
        [Test]
        public void
            GIVEN_list_of_people_WHEN_flattened_THEN_actual_flattened_collection_is_equivalent_to_expected_flattened_collection()
        {
            var samplePeople = GetSamplePeople();
            var peopleWithEmails = PeopleWithEmailsConverter.Flatten(samplePeople);

            var expectedPeopleWithEmails = GetSampleFlattenedResult();

            Assert.IsNotNull(expectedPeopleWithEmails);
            Assert.That(peopleWithEmails,
                Is.EquivalentTo(expectedPeopleWithEmails)
                    .Using<PersonWithEmail, PersonWithEmail>(
                        (actual, expected) =>
                            actual.FormattedEmail == expected.FormattedEmail &&
                            actual.SanitizedNameWithId == expected.SanitizedNameWithId));
        }

        [Test]
        public void GIVEN_list_of_people_is_null_WHEN_flattened_THEN_empty_list_is_returned()
        {
            var shouldBeEmptyList = PeopleWithEmailsConverter.Flatten(null);

            Assert.IsNotNull(shouldBeEmptyList);
            Assert.IsEmpty(shouldBeEmptyList);
        }

        [Test]
        public void GIVEN_empty_list_of_people_WHEN_flattened_THEN_empty_list_is_returned()
        {
            var emptyListOfPeople = new List<Person>();
            var shouldBeEmptyList = PeopleWithEmailsConverter.Flatten(emptyListOfPeople);

            Assert.IsNotNull(shouldBeEmptyList);
            Assert.IsEmpty(shouldBeEmptyList);
        }

        [Test]
        public void GIVEN_list_of_people_with_empty_or_null_list_of_emails_WHEN_flattened_THEN_empty_list_is_returned()
        {
            var samplePeople = GetSamplePeopleWithoutEmails();
            var shouldBeEmptyList = PeopleWithEmailsConverter.Flatten(samplePeople);

            Assert.IsNotNull(shouldBeEmptyList);
            Assert.IsEmpty(shouldBeEmptyList);
        }

        [Test]
        public void GIVEN_list_of_people_with_not_sanitized_names_WHEN_flattened_THEN_names_are_sanitized()
        {
            var personOneEmails = new[]
            {
                new EmailAddress("aaa@gmail.com", "x"),
                new EmailAddress("bbb@gmail.com", "y")
            };

            var samplePeople = new Person[]
            {
                new() {Emails = personOneEmails, Id = "1", Name = "Krzyœ"}
            };

            var resultList = PeopleWithEmailsConverter.Flatten(samplePeople);

            Assert.IsNotNull(resultList);
            Assert.IsNotEmpty(resultList);

            foreach (var personWithEmail in resultList)
            {
                Assert.AreEqual("1Krzy", personWithEmail.SanitizedNameWithId);
            }
        }

        private IEnumerable<Person> GetSamplePeople()
        {
            var personOneEmails = new[]
            {
                new EmailAddress("aaa@gmail.com", "x"),
                new EmailAddress("bbb@gmail.com", "y")
            };

            var personTwoEmails = new[]
            {
                new EmailAddress("xxx@gmail.com", "a"),
                new EmailAddress("yyy@gmail.com", "b")
            };

            var personOne = new Person {Id = "1", Name = "AB", Emails = personOneEmails};
            var personTwo = new Person {Id = "2", Name = "XY", Emails = personTwoEmails};

            var people = new List<Person> {personOne, personTwo};
            return people;
        }

        private IEnumerable<Person> GetSamplePeopleWithoutEmails()
        {
            var personOne = new Person {Id = "1", Name = "AB", Emails = null};
            var personTwo = new Person {Id = "2", Name = "XY", Emails = new List<EmailAddress>()};

            var people = new List<Person> {personOne, personTwo};
            return people;
        }

        private IEnumerable<PersonWithEmail> GetSampleFlattenedResult()
        {
            var peopleWithEmails = new[]
            {
                new PersonWithEmail {SanitizedNameWithId = "1AB", FormattedEmail = "xaaa@gmail.com"},
                new PersonWithEmail {SanitizedNameWithId = "1AB", FormattedEmail = "ybbb@gmail.com"},
                new PersonWithEmail {SanitizedNameWithId = "2XY", FormattedEmail = "axxx@gmail.com"},
                new PersonWithEmail {SanitizedNameWithId = "2XY", FormattedEmail = "byyy@gmail.com"}
            };

            return peopleWithEmails;
        }
    }
}