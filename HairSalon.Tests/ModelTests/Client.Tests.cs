using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTest : IDisposable
    {

        public void Dispose() => Client.DeleteAll();

        public ClientTest() => DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eliran_maimon_test;";

        [TestMethod]
        public void GetSetProperties_GetsSetsProperties_True()
        {
            Client newClient = new Client("Elly Maimon", "Male");
            newClient.Name = "Carrie Zamboni";
            Assert.AreEqual("Carrie Zamboni", newClient.Name);
        }  

        [TestMethod]
        public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
        {
            Client firstClient = new Client("Elly Maimon", "Male");
            Client secondClient = new Client("Elly Maimon", "Male");
            Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
            int result = Client.GetAll().Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ClientList()
        {
            Client newClient = new Client("Elly Maimon", "Male");
            newClient.Save();
            List<Client> actualList = Client.GetAll();
            List<Client> expectedList = new List<Client> { newClient };
            CollectionAssert.AreEqual(actualList, expectedList);
        }

        [TestMethod]
        public void Find_FindsClientInDatabaseById_Client()
        {
            Client newClient = new Client("Elly Maimon", "Male");
            newClient.Id = 1;
            newClient.Save();
            Client foundClient = Client.Find(newClient.Id);
            Assert.AreEqual(newClient, foundClient);
        }            
    }
}
