﻿using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.WPF.Converters;

namespace PIT.Tests.WPF.Converters
{
    [TestClass]
    public class EnumToArrayConverterTests
    {
        private const string EnumDescription = "Enum description";
        private EnumToArrayConverter _converter;

        private object ConvertEnum()
        {
            return _converter.Convert(EnumTest.Enum1, typeof(EnumTest), null, null);
        }

        [TestInitialize]
        public void SetUp()
        {
            _converter = new EnumToArrayConverter();
        }

        [TestMethod]
        public void ReturnTypeIsArrayList()
        {
            object enumList = ConvertEnum();
            Assert.IsInstanceOfType(enumList, typeof(ArrayList));
        }

        [TestMethod]
        public void ConvertsEnumsToList()
        {
            var enumList = (ArrayList) ConvertEnum();

            Assert.AreEqual("[Enum1, Enum1]", enumList[0].ToString());
        }

        [TestMethod]
        public void DeterminesDescriptionsOfEnumValuesIfDefined()
        {
            var enumList = (ArrayList) ConvertEnum();
            Assert.AreEqual(string.Format("[Enum2, {0}]", EnumDescription), enumList[1].ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void FailsIfConvertBackIsInvoked()
        {
            _converter.ConvertBack(EnumTest.Enum1, typeof(EnumTest), null, null);
        }

        private enum EnumTest
        {
            Enum1,
            [System.ComponentModel.Description(EnumDescription)] Enum2
        }
    }
}