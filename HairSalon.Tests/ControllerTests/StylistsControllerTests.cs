using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistsControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_StylistList()
        {
            StylistsController controller = new StylistsController();
            IActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }

        [TestMethod]
        public void AddStylist_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult addView = controller.AddStylist();
            Assert.IsInstanceOfType(addView, typeof(ViewResult));
        }   

        [TestMethod]
        public void Detail_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult addView = controller.Detail(1);
            Assert.IsInstanceOfType(addView, typeof(ViewResult));
        }  

        [TestMethod]
        public void Detail_HasCorrectModelType_StylistObject()
        {
            StylistsController controller = new StylistsController();
            IActionResult actionResult = controller.Detail(1);
            ViewResult detailView = controller.Detail(1) as ViewResult;

            var result = detailView.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(Stylist));
        }
    }
}




