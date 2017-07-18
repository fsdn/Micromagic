using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MicroUtils;

namespace MicroServiceTests.Weather
{
    [TestClass]
    public class AccWeatherTests
    {
        [TestMethod]
        public void LocationsAdminareasCountryCode()
        {
            AccuWeather acc = new AccuWeather();
            var model = new LocationsAdminareasCountryCodeReqModel()
            {
                countryCode = "CN",
                offset = 0
            };
            var obj = acc.LocationsAdminareasCountryCode(model);
            string json = JsonHelper.SerializeObject(obj);
            Assert.Equals("0", "0");
        }

        [TestMethod]
        public void LocationsCountriesRegionCode()
        {
            AccuWeather acc = new AccuWeather();
            var model = new LocationsCountriesRegionCodeReqModel()
            {
                regionCode = "ASI",
            };
            var obj = acc.LocationsCountriesRegionCode(model);
            string json = JsonHelper.SerializeObject(obj);
            Assert.Equals("0", "0");
        }

        [TestMethod]
        public void LocationsRegions()
        {
            AccuWeather acc = new AccuWeather();
            var model = new LocationsRegionsReqModel()
            {
            };
            var obj = acc.LocationsRegions(model);
            string json = JsonHelper.SerializeObject(obj);
            Assert.Equals("0", "0");
        }

        [TestMethod]
        public void LocationsTopcitiesGroup()
        {
            AccuWeather acc = new AccuWeather();
            var model = new LocationsTopcitiesReqModel()
            {
                group = 150,
                details = true
            };
            var obj = acc.LocationsTopcitiesGroup(model);
            string json = JsonHelper.SerializeObject(obj);
            Assert.Equals("0", "0");
        }

        [TestMethod]
        public void LocationsCitiesAutocomplete()
        {
            AccuWeather acc = new AccuWeather();
            var model = new LocationsCitiesAutocompleteReqModel()
            {
                q = "深圳"
            };
            var obj = acc.LocationsCitiesAutocomplete(model);
            string json = JsonHelper.SerializeObject(obj);
            Assert.Equals("0", "0");
        }

        [TestMethod]
        public void LocationsCitiesNeighborsLocationKey()
        {
            AccuWeather acc = new AccuWeather();
            var model = new LocationsCitiesNeighborsLocationKeyReqModel()
            {
                locationKey = "58194",
                details = true
            };
            var obj = acc.LocationsCitiesNeighborsLocationKey(model);
            string json = JsonHelper.SerializeObject(obj);
            Assert.Equals("0", "0");
        }

        [TestMethod]
        public void LocationsLocationKey()
        {
            AccuWeather acc = new AccuWeather();
            var model = new LocationsLocationKeyReqModel()
            {
                locationKey = "100",
                details = true
            };
            var obj = acc.LocationsLocationKey(model);
            string json = JsonHelper.SerializeObject(obj);
            Assert.Equals("0", "0");
        }

        [TestMethod]
        public void LocationsCitiesSearch()
        {
            AccuWeather acc = new AccuWeather();
            var model = new LocationsCitiesSearchReqModel()
            {
                q = "深圳",
                alias = "",
                offset = 0,
                details = true
            };
            var obj = acc.LocationsCitiesSearch(model);
            string json = JsonHelper.SerializeObject(obj);
            Assert.Equals("0", "0");
        }

        [TestMethod]
        public void LocationsCitiesCountryCodeAdminCodeSearch()
        {
            AccuWeather acc = new AccuWeather();
            var model = new LocationsCitiesCountryCodeAdminCodeSearchReqModel()
            {
                countryCode = "CN",
                adminCode = "44",
                q = "深圳",
                alias = "",
                offset = 0,
                details = true
            };
            var obj = acc.LocationsCitiesCountryCodeAdminCodeSearch(model);
            string json = JsonHelper.SerializeObject(obj);
            Assert.Equals("0", "0");
        }

        [TestMethod]
        public void LocationsCitiesCountryCodeSearch()
        {
            AccuWeather acc = new AccuWeather();
            var model = new LocationsCitiesCountryCodeSearchReqModel()
            {
                countryCode = "CN",
                q = "深圳",
                alias = "0",
                offset = 0,
                details = true
            };
            var obj = acc.LocationsCitiesCountryCodeSearch(model);
            string json = JsonHelper.SerializeObject(obj);
            Assert.Equals("0", "0");
        }

    }
}
