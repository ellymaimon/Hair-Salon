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
    }
}
