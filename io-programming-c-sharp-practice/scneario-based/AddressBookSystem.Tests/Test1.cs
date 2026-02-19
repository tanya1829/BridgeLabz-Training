using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookSystem;

namespace AddressBookSystem.Tests
{
    [TestClass]
    public class EasyTests
    {
        private AddressBookUtility book;

        [TestInitialize]
        public void Setup()
        {
            book = new AddressBookUtility();
        }

        //  Test 1: Check initial count is 0
        [TestMethod]
        public void ContactCount_ShouldBeZero_WhenBookCreated()
        {
            int count = book.GetContactCount();
            Assert.AreEqual(0, count);
        }

        //  Test 2: Add one contact
        [TestMethod]
        public void AddContact_ShouldIncreaseCount()
        {
            var c = new Contact("Navya", "Yadav", "", "", "", "", "", "");
            book.AddContactDirect(c);

            int count = book.GetContactCount();
            Assert.AreEqual(1, count);
        }

        //  Test 3: Delete contact
        [TestMethod]
        public void DeleteContact_ShouldMakeCountZero()
        {
            var c = new Contact("A", "B", "", "", "", "", "", "");
            book.AddContactDirect(c);

            book.DeleteContactDirect("A B");

            int count = book.GetContactCount();
            Assert.AreEqual(0, count);
        }

        //  Test 4: Count by city
        [TestMethod]
        public void CountByCity_ShouldReturnCorrectNumber()
        {
            book.AddContactDirect(new Contact("A", "B", "", "Delhi", "", "", "", ""));
            book.AddContactDirect(new Contact("C", "D", "", "Delhi", "", "", "", ""));

            int count = book.CountByCity("Delhi");

            Assert.AreEqual(2, count);
        }

        //  Test 5: Add two contacts and check total
        [TestMethod]
        public void AddTwoContacts_TotalCountShouldBeTwo()
        {
            book.AddContactDirect(new Contact("A", "B", "", "", "", "", "", ""));
            book.AddContactDirect(new Contact("C", "D", "", "", "", "", "", ""));

            int count = book.GetContactCount();

            Assert.AreEqual(2, count);
        }
    }
}