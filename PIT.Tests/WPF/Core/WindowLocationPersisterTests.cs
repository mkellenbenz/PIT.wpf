﻿using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.Business.Entities;
using PIT.WPF.Core;

namespace PIT.Tests.WPF.Core
{
    [TestClass]
    public class WindowLocationPersisterTests
    {
        [TestMethod]
        public void Assigns_Window_Location_To_View()
        {
            var window = new Window();

            var windowLocation = new WindowLocation
            {
                Left = 10,
                Top = 10,
                Width = 100,
                Height = 100
            };

            // ReSharper disable once ObjectCreationAsStatement
            new WindowLocationPersister(window, windowLocation);

            Assert.AreEqual(window.SizeToContent, SizeToContent.Manual, "views SizeToContent is invalid");
            Assert.AreEqual(window.Top, 10, "view top position is invalid");
            Assert.AreEqual(window.Left, 10, "view left position is invalid");
            Assert.AreEqual(window.Width, 100, "view width is invalid");
            Assert.AreEqual(window.Height, 100, "view height is invalid");
        }
    }
}