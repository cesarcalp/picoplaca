using Microsoft.VisualStudio.TestTools.UnitTesting;
using PicoPlaca.Domain;
using PicoPlaca.ManagementService;
using PicoPlaca.ManagementService.Rules;
using PicoPlaca.Transversal;
using System;

namespace PicoPlaca.UnitTests
{
    [TestClass]
    public class PredictorTest
    {
        private IPredictorManagementService _predictorManagementService;
        public PredictorTest()
        {
            _predictorManagementService = new PredictorManagementService(new PicoPlacaRule());
        }
        [TestMethod]
        public void AllowedToRoad()
        {
            var saturdayDate = new DateTime(2017, 9, 2, 0, 0, 0);
            var peakHour = new TimeSpan(8, 0, 0);
            var service = _predictorManagementService.ValidatePicoPlaca(new Models.PicoPlacaParam
            {
                Date = saturdayDate.ToString(CustomFormatProvider.ShortDatePattern),
                Time = peakHour.ToString(),
                PlateNumber = "GRS0787"
            });
            Assert.AreEqual(true, service.AllowedToRoad);
        }

        [TestMethod]
        public void NotAllowedToRoad()
        {
            var mondayDate = new DateTime(2017, 9, 4, 0, 0, 0);
            var peakHour = new TimeSpan(8, 30, 0);
            var service = _predictorManagementService.ValidatePicoPlaca(new Models.PicoPlacaParam
            {
                Date = mondayDate.ToString(CustomFormatProvider.ShortDatePattern),
                Time = peakHour.ToString(),
                PlateNumber = "GRS0782"
            });
            Assert.AreEqual(false, service.AllowedToRoad);
        }
    }
}
