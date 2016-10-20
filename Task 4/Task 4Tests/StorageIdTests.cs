using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4.Tests
{
    [TestClass]
    public class StorageIdTests
    {
        public StorageId CreateBasicStorageId()
        {
            var storage = new StorageId();

            storage.CreateObject<int>();
            storage.CreateObject<double>();
            storage.CreateObject<double>();
            storage.CreateObject<char>();
            storage.CreateObject<char>();
            storage.CreateObject<char>();

            return storage;
        }

        [TestMethod]
        [ExpectedException(typeof(TypeAccessException))]
        public void Should_ThrowTypeAccessException_When_TypeObjectNotExistsInStorage()
        {
            var storage = CreateBasicStorageId();

            storage.GetGroupObjects<float>();
        }

        [TestMethod]
        public void Should_TrueCountObjectInGroupsObjects_When_CreatedBasicStorageId()
        {
            var storage = CreateBasicStorageId();

            var pairsForInt = storage.GetGroupObjects<int>();
            var pairsForDouble = storage.GetGroupObjects<double>();
            var pairsForChar = storage.GetGroupObjects<char>();

            Assert.AreEqual(pairsForInt.Count(), 1);
            Assert.AreEqual(pairsForDouble.Count(), 2);
            Assert.AreEqual(pairsForChar.Count(), 3);
        }

        [TestMethod]
        public void Should_Null_When_GuidNotExistsInStorage()
        {
            var storage = CreateBasicStorageId();

            Assert.AreEqual(storage.GetObjectForGuid(new Guid()), null);
        }
    }
}