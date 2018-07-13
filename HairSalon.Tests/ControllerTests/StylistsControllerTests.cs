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

    }
}




