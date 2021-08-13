using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Zadanie2.Tests.Benchmark
{
    [TestFixture]
    public class BenchmarkToDoTests
    {
        private const int NumberOfGroups = 50;
        private const int NumberOfPeoplePerGroup = 1000;
        private const int NumberOfEmailsPerPerson = 4;

        [Test]
        public void GIVEN_big_sample_data_WHEN_matching_people_to_accounts_THEN_accounts_counts_match_emails_count_and_load_in_less_then_a_second()
        {
            var benchmarkTestData = BenchmarkTestData.GenerateBenchmarkTestData(NumberOfGroups, NumberOfPeoplePerGroup, NumberOfEmailsPerPerson);

            var groups = benchmarkTestData.Groups;
            var accounts = benchmarkTestData.Accounts;
            var emails = benchmarkTestData.Emails;

            Assert.That(
                Time(() => ToDo.MatchPersonToAccount(groups, accounts, emails)),
                Is.LessThanOrEqualTo(TimeSpan.FromSeconds(1)));

            // After collecting some data - in general execute time is about 00:00:00.06 for numbers mentioned in the task

            var result = ToDo.MatchPersonToAccount(groups, accounts, emails);

            Assert.AreEqual(emails.Count(), result.Count());
        }

        private TimeSpan Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
        }
    }
}