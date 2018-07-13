using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
    {

        public void Dispose() => Stylist.DeleteAll();

        public StylistTest() => DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eliran_maimon_test;";

        [TestMethod]
        public void GetSetProperties_GetsSetsProperties_True()
        {
            Stylist newStylist = new Stylist("Elly Maimon", "3 to 6", "Coloring", "513-213-0982");
            newStylist.Name = "Carrie Zamboni";
            Assert.AreEqual("Carrie Zamboni", newStylist.Name);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamesAreTheSame_Stylist()
        {
            Stylist firstStylist = new Stylist("Elly Maimon", "3 to 6", "Coloring", "513-213-0982");
            Stylist secondStylist = new Stylist("Elly Maimon", "3 to 6", "Coloring", "513-213-0982");
            Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
            int result = Stylist.GetAll().Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_StylistList()
        {
            Stylist newStylist = new Stylist("Elly Maimon", "3 to 6", "Coloring", "513-213-0982");
            newStylist.Save();
            List<Stylist> actualList = Stylist.GetAll();
            List<Stylist> expectedList = new List<Stylist> { newStylist };
            CollectionAssert.AreEqual(actualList, expectedList);
        }

        [TestMethod]
        public void Find_FindsStylistInDatabaseById_Stylist()
        {
            Stylist newStylist = new Stylist("Elly Maimon", "3 to 6", "Coloring", "513-213-0982");
            newStylist.Id = 1;
            newStylist.Save();
            Stylist foundStylist = Stylist.Find(newStylist.Id);
            Assert.AreEqual(newStylist, foundStylist);
        }

        [TestMethod]
        public void Delete_DeletesRecordFromDatabase_StylistList()
        {
            Stylist newStylist = new Stylist("Elly Maimon", "3 to 6", "Coloring", "513-213-0982");
            Stylist newStylist2 = new Stylist("Carrie Zamboni", "10+", "All-Around", "555-222-1111");
            newStylist.Id = 1;
            newStylist2.Id = 2;
            newStylist.Save();
            newStylist2.Save();

            // Client newClient = new Client("Jojo Peters", "Male", newStylist.Id);
            // newClient.Save();

            newStylist.Delete();

            List<Stylist> actualList = Stylist.GetAll();
            List<Stylist> expectedList = new List<Stylist>{ newStylist2 };
            // List<Client> clientResult = Client.GetAll();
            // List<Client> clientTest = new List<Client>() {};
            CollectionAssert.AreEqual(actualList, expectedList);
            // CollectionAssert.AreEqual(clientResult, clientTest);
        }   

        [TestMethod]
        public void Update_UpdatesColumnInDatabase_StylistList()
        {
            Stylist newStylist = new Stylist("Elly Maimon", "3 to 6", "Coloring", "513-213-0982");
            newStylist.Id = 1;
            newStylist.Save();
            newStylist.Name = "Carrie Zamboni";
            newStylist.Update();
            List<Stylist> actualList = Stylist.GetAll();
            List<Stylist> expectedList = new List<Stylist>{ newStylist };
            CollectionAssert.AreEqual(expectedList, actualList);
        }        
    }
}
