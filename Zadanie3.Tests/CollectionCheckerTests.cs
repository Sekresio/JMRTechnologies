using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Zadanie3.Tests
{
    [TestFixture]
    public class CollectionCheckerTests
    {
        [Test]
        public void GIVEN_collection_with_inner_collections_bigger_than_5_WHEN_checked_THEN_all_outer_collections_are_returned()
        {
            var bigCollections = new List<IEnumerable<string>>()
            {
                new[] {"1", "2", "3", "4", "5"},
                new[] {"1", "2", "3", "4", "5", "6", "7"},
                new[] {"1", "2", "3", "4", "5", "6", "7", "8"},
                new[] {"1", "2", "3", "4", "5", "6", "7", "8", "9"}
            };

            var checkedCollections = CollectionChecker.OnlyBigCollections(bigCollections);

            Assert.AreEqual(bigCollections.Count, checkedCollections.Count());
        }

        [Test]
        public void GIVEN_collection_with_inner_collections_smaller_than_5_WHEN_checked_THEN_none_of_outer_collections_are_returned()
        {
            var bigCollections = new List<IEnumerable<string>>()
            {
                new[] {"1"},
                new[] {"1", "2"},
                new[] {"1", "2", "3"},
                new[] {"1", "2", "3", "4"}
            };

            var checkedCollections = CollectionChecker.OnlyBigCollections(bigCollections);

            Assert.AreEqual(0, checkedCollections.Count());
        }
    }
}