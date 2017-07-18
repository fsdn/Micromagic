using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MicroUtils
{
    /// <summary>
    /// https://developer.accuweather.com/apis
    /// Email：1296696830@qq.com
    /// </summary>
    public class AccuWeather
    {
        #region var

        private const string Acc_API_Key = "nn9WG0LmwgXLkoCVtgDeoFAM5NLwAITE";

        #endregion

        #region class

        /// <summary>
        /// Admin Area List
        /// http://dataservice.accuweather.com/locations/v1/adminareas/{countryCode}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsAdminareasCountryCodeRspModel LocationsAdminareasCountryCode(LocationsAdminareasCountryCodeReqModel model)
        {
            LocationsAdminareasCountryCodeRspModel ret = new LocationsAdminareasCountryCodeRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsAdminareasCountryCode;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsAdminareasCountryCodeDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Country List
        /// http://dataservice.accuweather.com/locations/v1/countries/{regionCode}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsCountriesRegionCodeRspModel LocationsCountriesRegionCode(LocationsCountriesRegionCodeReqModel model)
        {
            LocationsCountriesRegionCodeRspModel ret = new LocationsCountriesRegionCodeRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsCountriesRegionCode;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsCountriesRegionCodeDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Region List
        /// http://dataservice.accuweather.com/locations/v1/regions
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsRegionsRspModel LocationsRegions(LocationsRegionsReqModel model)
        {
            LocationsRegionsRspModel ret = new LocationsRegionsRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsRegions;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsRegionsDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Top Cities List
        /// http://dataservice.accuweather.com/locations/v1/topcities/{group}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsTopcitiesRspModel LocationsTopcitiesGroup(LocationsTopcitiesReqModel model)
        {
            LocationsTopcitiesRspModel ret = new LocationsTopcitiesRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsTopcitiesGroup;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsTopcitiesDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Autocomplete search
        /// http://dataservice.accuweather.com/locations/v1/cities/autocomplete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsCitiesAutocompleteRspModel LocationsCitiesAutocomplete(LocationsCitiesAutocompleteReqModel model)
        {
            LocationsCitiesAutocompleteRspModel ret = new LocationsCitiesAutocompleteRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsCitiesAutocomplete;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsCitiesAutocompleteDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// City Neighbors by locationKey
        /// http://dataservice.accuweather.com/locations/v1/cities/neighbors/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsCitiesNeighborsLocationKeyRspModel LocationsCitiesNeighborsLocationKey(LocationsCitiesNeighborsLocationKeyReqModel model)
        {
            LocationsCitiesNeighborsLocationKeyRspModel ret = new LocationsCitiesNeighborsLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsCitiesNeighborsLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsCitiesNeighborsLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Search by locationKey
        /// http://dataservice.accuweather.com/locations/v1/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsLocationKeyRspModel LocationsLocationKey(LocationsLocationKeyReqModel model)
        {
            LocationsLocationKeyRspModel ret = new LocationsLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// City Search
        /// http://dataservice.accuweather.com/locations/v1/cities/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsCitiesSearchRspModel LocationsCitiesSearch(LocationsCitiesSearchReqModel model)
        {
            LocationsCitiesSearchRspModel ret = new LocationsCitiesSearchRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsCitiesSearch;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsCitiesSearchDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// City Search (results narrowed by countryCode and adminCode)
        /// http://dataservice.accuweather.com/locations/v1/cities/{countryCode}/{adminCode}/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsCitiesCountryCodeAdminCodeSearchRspModel LocationsCitiesCountryCodeAdminCodeSearch(LocationsCitiesCountryCodeAdminCodeSearchReqModel model)
        {
            LocationsCitiesCountryCodeAdminCodeSearchRspModel ret = new LocationsCitiesCountryCodeAdminCodeSearchRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsCitiesCountryCodeAdminCodeSearch;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsCitiesCountryCodeAdminCodeSearchDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// City Search (results narrowed by countryCode)
        /// http://dataservice.accuweather.com/locations/v1/cities/{countryCode}/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsCitiesCountryCodeSearchRspModel LocationsCitiesCountryCodeSearch(LocationsCitiesCountryCodeSearchReqModel model)
        {
            LocationsCitiesCountryCodeSearchRspModel ret = new LocationsCitiesCountryCodeSearchRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsCitiesCountryCodeSearch;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsCitiesCountryCodeSearchDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// POI Search
        /// http://dataservice.accuweather.com/locations/v1/poi/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsPoiSearchRspModel LocationsPoiSearch(LocationsPoiSearchReqModel model)
        {
            LocationsPoiSearchRspModel ret = new LocationsPoiSearchRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsPoiSearch;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsPoiSearchDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// POI Search (results narrowed by countryCode and adminCode)
        /// http://dataservice.accuweather.com/locations/v1/poi/{countryCode}/{adminCode}/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsPoiCountryCodeAdminCodeSearchRspModel LocationsPoiCountryCodeAdminCodeSearch(LocationsPoiCountryCodeAdminCodeSearchReqModel model)
        {
            LocationsPoiCountryCodeAdminCodeSearchRspModel ret = new LocationsPoiCountryCodeAdminCodeSearchRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsPoiCountryCodeAdminCodeSearch;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsPoiCountryCodeAdminCodeSearchDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// POI Search (results narrowed by countryCode)
        /// http://dataservice.accuweather.com/locations/v1/poi/{countryCode}/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsPoiCountryCodeSearchRspModel LocationsPoiCountryCodeSearch(LocationsPoiCountryCodeSearchReqModel model)
        {
            LocationsPoiCountryCodeSearchRspModel ret = new LocationsPoiCountryCodeSearchRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsPoiCountryCodeSearch;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsPoiCountryCodeSearchDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Postal Code Search
        /// http://dataservice.accuweather.com/locations/v1/postalcodes/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsPostalcodesSearchRspModel LocationsPostalcodesSearch(LocationsPostalcodesSearchReqModel model)
        {
            LocationsPostalcodesSearchRspModel ret = new LocationsPostalcodesSearchRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsPostalcodesSearch;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsPostalcodesSearchDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Postal Code Search (results narrowed by countryCode)
        /// http://dataservice.accuweather.com/locations/v1/postalcodes/{countryCode}/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsPostalcodesCountryCodeSearchRspModel LocationsPostalcodesCountryCodeSearch(LocationsPostalcodesCountryCodeSearchReqModel model)
        {
            LocationsPostalcodesCountryCodeSearchRspModel ret = new LocationsPostalcodesCountryCodeSearchRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsPostalcodesCountryCodeSearch;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsPostalcodesCountryCodeSearchDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Text Search
        /// http://dataservice.accuweather.com/locations/v1/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsSearchRspModel LocationsSearch(LocationsSearchReqModel model)
        {
            LocationsSearchRspModel ret = new LocationsSearchRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsSearch;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsSearchDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Text Search (results narrowed by countryCode and adminCode)
        /// http://dataservice.accuweather.com/locations/v1/{countryCode}/{adminCode}/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsCountryCodeAdminCodeSearchRspModel LocationsCountryCodeAdminCodeSearch(LocationsCountryCodeAdminCodeSearchReqModel model)
        {
            LocationsCountryCodeAdminCodeSearchRspModel ret = new LocationsCountryCodeAdminCodeSearchRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsCountryCodeAdminCodeSearch;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsCountryCodeAdminCodeSearchDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Text Search (results narrowed by countryCode)
        /// http://dataservice.accuweather.com/locations/v1/{countryCode}/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsCountryCodeSearchRspModel LocationsCountryCodeSearch(LocationsCountryCodeSearchReqModel model)
        {
            LocationsCountryCodeSearchRspModel ret = new LocationsCountryCodeSearchRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsCountryCodeSearch;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsCountryCodeSearchDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Geoposition Search
        /// http://dataservice.accuweather.com/locations/v1/cities/geoposition/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsCitiesGeopositionSearchRspModel LocationsCitiesGeopositionSearch(LocationsCitiesGeopositionSearchReqModel model)
        {
            LocationsCitiesGeopositionSearchRspModel ret = new LocationsCitiesGeopositionSearchRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsCitiesGeopositionSearch;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsCitiesGeopositionSearchDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// IP Address Search
        /// http://dataservice.accuweather.com/locations/v1/cities/ipaddress
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LocationsCitiesIpaddressRspModel LocationsCitiesIpaddress(LocationsCitiesIpaddressReqModel model)
        {
            LocationsCitiesIpaddressRspModel ret = new LocationsCitiesIpaddressRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.LocationsCitiesIpaddress;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<LocationsCitiesIpaddressDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 1 Day of Daily Forecasts
        /// http://dataservice.accuweather.com/forecasts/v1/daily/1day/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ForecastsDaily1dayLocationKeyRspModel ForecastsDaily1dayLocationKey(ForecastsDaily1dayLocationKeyReqModel model)
        {
            ForecastsDaily1dayLocationKeyRspModel ret = new ForecastsDaily1dayLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.ForecastsDaily1dayLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<ForecastsDaily1dayLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }


        /// <summary>
        /// 10 Day of Daily Forecasts
        /// http://dataservice.accuweather.com/forecasts/v1/daily/10day/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ForecastsDaily10dayLocationKeyRspModel ForecastsDaily10dayLocationKey(ForecastsDaily10dayLocationKeyReqModel model)
        {
            ForecastsDaily10dayLocationKeyRspModel ret = new ForecastsDaily10dayLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.ForecastsDaily10dayLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<ForecastsDaily10dayLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 15 Day of Daily Forecasts
        /// http://dataservice.accuweather.com/forecasts/v1/daily/15day/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ForecastsDaily15dayLocationKeyRspModel ForecastsDaily15dayLocationKey(ForecastsDaily15dayLocationKeyReqModel model)
        {
            ForecastsDaily15dayLocationKeyRspModel ret = new ForecastsDaily15dayLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.ForecastsDaily15dayLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<ForecastsDaily15dayLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 5 Day of Daily Forecasts
        /// http://dataservice.accuweather.com/forecasts/v1/daily/5day/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ForecastsDaily5dayLocationKeyRspModel ForecastsDaily5dayLocationKey(ForecastsDaily5dayLocationKeyReqModel model)
        {
            ForecastsDaily5dayLocationKeyRspModel ret = new ForecastsDaily5dayLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.ForecastsDaily5dayLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<ForecastsDaily5dayLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 1 Hour of Hourly Forecasts
        /// http://dataservice.accuweather.com/forecasts/v1/hourly/1hour/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ForecastsHourly1hourLocationKeyRspModel ForecastsHourly1hourLocationKey(ForecastsHourly1hourLocationKeyReqModel model)
        {
            ForecastsHourly1hourLocationKeyRspModel ret = new ForecastsHourly1hourLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.ForecastsHourly1hourLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<ForecastsHourly1hourLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 12 Hour of Hourly Forecasts
        /// http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ForecastsHourly12hourLocationKeyRspModel ForecastsHourly12hourLocationKey(ForecastsHourly12hourLocationKeyReqModel model)
        {
            ForecastsHourly12hourLocationKeyRspModel ret = new ForecastsHourly12hourLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.ForecastsHourly12hourLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<ForecastsHourly12hourLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 120 Hour of Hourly Forecasts
        /// http://dataservice.accuweather.com/forecasts/v1/hourly/120hour/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ForecastsHourly120hourLocationKeyRspModel ForecastsHourly120hourLocationKey(ForecastsHourly120hourLocationKeyReqModel model)
        {
            ForecastsHourly120hourLocationKeyRspModel ret = new ForecastsHourly120hourLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.ForecastsHourly120hourLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<ForecastsHourly120hourLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 24 Hour of Hourly Forecasts
        /// http://dataservice.accuweather.com/forecasts/v1/hourly/24hour/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ForecastsHourly24hourLocationKeyRspModel ForecastsHourly24hourLocationKey(ForecastsHourly24hourLocationKeyReqModel model)
        {
            ForecastsHourly24hourLocationKeyRspModel ret = new ForecastsHourly24hourLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.ForecastsHourly24hourLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<ForecastsHourly24hourLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 72 Hour of Hourly Forecasts
        /// http://dataservice.accuweather.com/forecasts/v1/hourly/72hour/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ForecastsHourly72hourLocationKeyRspModel ForecastsHourly72hourLocationKey(ForecastsHourly72hourLocationKeyReqModel model)
        {
            ForecastsHourly72hourLocationKeyRspModel ret = new ForecastsHourly72hourLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.ForecastsHourly72hourLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<ForecastsHourly72hourLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Current Conditions
        /// http://dataservice.accuweather.com/currentconditions/v1/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CurrentconditionsLocationKeyRspModel CurrentconditionsLocationKey(CurrentconditionsLocationKeyReqModel model)
        {
            CurrentconditionsLocationKeyRspModel ret = new CurrentconditionsLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.CurrentconditionsLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<CurrentconditionsLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Historical Current Conditions (past 24 hours)
        /// http://dataservice.accuweather.com/currentconditions/v1/{locationKey}/historical/24
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CurrentconditionsLocationKeyHistorical24RspModel CurrentconditionsLocationKeyHistorical24(CurrentconditionsLocationKeyHistorical24ReqModel model)
        {
            CurrentconditionsLocationKeyHistorical24RspModel ret = new CurrentconditionsLocationKeyHistorical24RspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.CurrentconditionsLocationKeyHistorical24;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<CurrentconditionsLocationKeyHistorical24DataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Historical Current Conditions (past 6 hours)
        /// http://dataservice.accuweather.com/currentconditions/v1/{locationKey}/historical
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CurrentconditionsLocationKeyHistoricalRspModel CurrentconditionsLocationKeyHistorical(CurrentconditionsLocationKeyHistoricalReqModel model)
        {
            CurrentconditionsLocationKeyHistoricalRspModel ret = new CurrentconditionsLocationKeyHistoricalRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.CurrentconditionsLocationKeyHistorical;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<CurrentconditionsLocationKeyHistoricalDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Current Conditions for Top Cities
        /// http://dataservice.accuweather.com/currentconditions/v1/topcities/{group}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CurrentconditionsTopcitiesGroupRspModel CurrentconditionsTopcitiesGroup(CurrentconditionsTopcitiesGroupReqModel model)
        {
            CurrentconditionsTopcitiesGroupRspModel ret = new CurrentconditionsTopcitiesGroupRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.CurrentconditionsTopcitiesGroup;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<CurrentconditionsTopcitiesGroupDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 1 Day of Daily Index Values for a Group of Indices
        /// http://dataservice.accuweather.com/indices/v1/daily/1day/{locationKey}/groups/{ID}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDaily1dayLocationKeyGroupsIDRspModel IndicesDaily1dayLocationKeyGroupsID(IndicesDaily1dayLocationKeyGroupsIDReqModel model)
        {
            IndicesDaily1dayLocationKeyGroupsIDRspModel ret = new IndicesDaily1dayLocationKeyGroupsIDRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily1dayLocationKeyGroupsID;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDaily1dayLocationKeyGroupsIDDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 1 Day of Daily Index Values for a Specific Index
        /// http://dataservice.accuweather.com/indices/v1/daily/1day/{locationKey}/{ID}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDaily1dayLocationKeyIDRspModel IndicesDaily1dayLocationKeyID(IndicesDaily1dayLocationKeyIDReqModel model)
        {
            IndicesDaily1dayLocationKeyIDRspModel ret = new IndicesDaily1dayLocationKeyIDRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily1dayLocationKeyID;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDaily1dayLocationKeyIDDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 1 Day of Daily Index Values for All Indices
        /// http://dataservice.accuweather.com/indices/v1/daily/1day/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDaily1dayLocationKeyRspModel IndicesDaily1dayLocationKey(IndicesDaily1dayLocationKeyReqModel model)
        {
            IndicesDaily1dayLocationKeyRspModel ret = new IndicesDaily1dayLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily1dayLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDaily1dayLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 10 Day of Daily Index Values for a Group of Indices
        /// http://dataservice.accuweather.com/indices/v1/daily/10day/{locationKey}/groups/{ID}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDaily10dayLocationKeyGroupsIDRspModel IndicesDaily10dayLocationKeyGroupsID(IndicesDaily10dayLocationKeyGroupsIDReqModel model)
        {
            IndicesDaily10dayLocationKeyGroupsIDRspModel ret = new IndicesDaily10dayLocationKeyGroupsIDRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily10dayLocationKeyGroupsID;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDaily10dayLocationKeyGroupsIDDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 10 Day of Daily Index Values for a Specific Index
        /// http://dataservice.accuweather.com/indices/v1/daily/10day/{locationKey}/{ID}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDaily10dayLocationKeyIDRspModel IndicesDaily10dayLocationKeyID(IndicesDaily10dayLocationKeyIDReqModel model)
        {
            IndicesDaily10dayLocationKeyIDRspModel ret = new IndicesDaily10dayLocationKeyIDRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily10dayLocationKeyID;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDaily10dayLocationKeyIDDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 10 Day of Daily Index Values for All Indices
        /// http://dataservice.accuweather.com/indices/v1/daily/10day/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDaily10dayLocationKeyRspModel IndicesDaily10dayLocationKey(IndicesDaily10dayLocationKeyReqModel model)
        {
            IndicesDaily10dayLocationKeyRspModel ret = new IndicesDaily10dayLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily10dayLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDaily10dayLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 15 Day of Daily Index Values for a Group of Indices
        /// http://dataservice.accuweather.com/indices/v1/daily/15day/{locationKey}/groups/{ID}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDaily15dayLocationKeyGroupsIDRspModel IndicesDaily15dayLocationKeyGroupsID(IndicesDaily15dayLocationKeyGroupsIDReqModel model)
        {
            IndicesDaily15dayLocationKeyGroupsIDRspModel ret = new IndicesDaily15dayLocationKeyGroupsIDRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily15dayLocationKeyGroupsID;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDaily15dayLocationKeyGroupsIDDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 15 Day of Daily Index Values for a Specific Index
        /// http://dataservice.accuweather.com/indices/v1/daily/15day/{locationKey}/{ID}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDaily15dayLocationKeyIDRspModel IndicesDaily15dayLocationKeyID(IndicesDaily15dayLocationKeyIDReqModel model)
        {
            IndicesDaily15dayLocationKeyIDRspModel ret = new IndicesDaily15dayLocationKeyIDRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily15dayLocationKeyID;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDaily15dayLocationKeyIDDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 15 Day of Daily Index Values for All Indices
        /// http://dataservice.accuweather.com/indices/v1/daily/15day/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDaily15dayLocationKeyRspModel IndicesDaily15dayLocationKey(IndicesDaily15dayLocationKeyReqModel model)
        {
            IndicesDaily15dayLocationKeyRspModel ret = new IndicesDaily15dayLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily15dayLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDaily15dayLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 5 Day of Daily Index Values for a Group of Indices
        /// http://dataservice.accuweather.com/indices/v1/daily/5day/{locationKey}/groups/{ID}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDaily5dayLocationKeyGroupsIDRspModel IndicesDaily5dayLocationKeyGroupsID(IndicesDaily5dayLocationKeyGroupsIDReqModel model)
        {
            IndicesDaily5dayLocationKeyGroupsIDRspModel ret = new IndicesDaily5dayLocationKeyGroupsIDRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily5dayLocationKeyGroupsID;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDaily5dayLocationKeyGroupsIDDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 5 Day of Daily Index Values for a Specific Index
        /// http://dataservice.accuweather.com/indices/v1/daily/5day/{locationKey}/{ID}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDaily5dayLocationKeyIDRspModel IndicesDaily5dayLocationKeyID(IndicesDaily5dayLocationKeyIDReqModel model)
        {
            IndicesDaily5dayLocationKeyIDRspModel ret = new IndicesDaily5dayLocationKeyIDRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily5dayLocationKeyID;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDaily5dayLocationKeyIDDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 5 Day of Daily Index Values for All Indices
        /// http://dataservice.accuweather.com/indices/v1/daily/5day/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDaily5dayLocationKeyRspModel IndicesDaily5dayLocationKey(IndicesDaily5dayLocationKeyReqModel model)
        {
            IndicesDaily5dayLocationKeyRspModel ret = new IndicesDaily5dayLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily5dayLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDaily5dayLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// List of Daily Indices
        /// http://dataservice.accuweather.com/indices/v1/daily
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDailyRspModel IndicesDaily(IndicesDailyReqModel model)
        {
            IndicesDailyRspModel ret = new IndicesDailyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDaily;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDailyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// List of Index Groups
        /// http://dataservice.accuweather.com/indices/v1/daily/groups
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDailyGroupsRspModel IndicesDailyGroups(IndicesDailyGroupsReqModel model)
        {
            IndicesDailyGroupsRspModel ret = new IndicesDailyGroupsRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDailyGroups;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDailyGroupsDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// List of Indices in a Specific Group
        /// http://dataservice.accuweather.com/indices/v1/daily/groups/{ID}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDailyGroupsIDRspModel IndicesDailyGroupsID(IndicesDailyGroupsIDReqModel model)
        {
            IndicesDailyGroupsIDRspModel ret = new IndicesDailyGroupsIDRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDailyGroupsID;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDailyGroupsIDDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Metadata for a Specific Index
        /// http://dataservice.accuweather.com/indices/v1/daily/{ID}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IndicesDailyIDRspModel IndicesDailyID(IndicesDailyIDReqModel model)
        {
            IndicesDailyIDRspModel ret = new IndicesDailyIDRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.IndicesDailyID;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<IndicesDailyIDDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 1 Day of Weather Alarms
        /// http://dataservice.accuweather.com/alarms/v1/1day/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Alarms1dayLocationKeyRspModel Alarms1dayLocationKey(Alarms1dayLocationKeyReqModel model)
        {
            Alarms1dayLocationKeyRspModel ret = new Alarms1dayLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.Alarms1dayLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<Alarms1dayLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 10 Day of Weather Alarms
        /// http://dataservice.accuweather.com/alarms/v1/10day/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Alarms10dayLocationKeyRspModel Alarms10dayLocationKey(Alarms10dayLocationKeyReqModel model)
        {
            Alarms10dayLocationKeyRspModel ret = new Alarms10dayLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.Alarms1dayLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<Alarms10dayLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 15 Day of Weather Alarms
        /// http://dataservice.accuweather.com/alarms/v1/15day/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Alarms15dayLocationKeyRspModel Alarms15dayLocationKey(Alarms15dayLocationKeyReqModel model)
        {
            Alarms15dayLocationKeyRspModel ret = new Alarms15dayLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.Alarms15dayLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<Alarms15dayLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// 5 Day of Weather Alarms
        /// http://dataservice.accuweather.com/alarms/v1/5day/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Alarms5dayLocationKeyRspModel Alarms5dayLocationKey(Alarms5dayLocationKeyReqModel model)
        {
            Alarms5dayLocationKeyRspModel ret = new Alarms5dayLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.Alarms5dayLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<Alarms5dayLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Alerts by LocationKey
        /// http://dataservice.accuweather.com/alerts/v1/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public AlertsLocationKeyRspModel AlertsLocationKey(AlertsLocationKeyReqModel model)
        {
            AlertsLocationKeyRspModel ret = new AlertsLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.AlertsLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<AlertsLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Radar and Satellite Imagery
        /// http://dataservice.accuweather.com/imagery/v1/maps/radsat/{resolution}/{locationKey}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ImageryMapsRadsatResolutionLocationKeyRspModel ImageryMapsRadsatResolutionLocationKey(ImageryMapsRadsatResolutionLocationKeyReqModel model)
        {
            ImageryMapsRadsatResolutionLocationKeyRspModel ret = new ImageryMapsRadsatResolutionLocationKeyRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.ImageryMapsRadsatResolutionLocationKey;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<ImageryMapsRadsatResolutionLocationKeyDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }


        /// <summary>
        /// Search Tropical Cyclones by Year, Basin and ID
        /// http://dataservice.accuweather.com/tropical/v1/storms/{yyyy}/{basinId}/{depressionId}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TropicalStormsYyyyBasinIdDepressionIdRspModel TropicalStormsYyyyBasinIdDepressionId(TropicalStormsYyyyBasinIdDepressionIdReqModel model)
        {
            TropicalStormsYyyyBasinIdDepressionIdRspModel ret = new TropicalStormsYyyyBasinIdDepressionIdRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.TropicalStormsYyyyBasinIdDepressionId;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<TropicalStormsYyyyBasinIdDepressionIdDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Search Tropical Cyclones by Year and Basin
        /// http://dataservice.accuweather.com/tropical/v1/storms/{yyyy}/{basinId}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TropicalStormsYyyyBasinIdRspModel TropicalStormsYyyyBasinId(TropicalStormsYyyyBasinIdReqModel model)
        {
            TropicalStormsYyyyBasinIdRspModel ret = new TropicalStormsYyyyBasinIdRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.TropicalStormsYyyyBasinId;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<TropicalStormsYyyyBasinIdDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Active Tropical Cyclones by Basin and ID
        /// http://dataservice.accuweather.com/tropical/v1/storms/active/{basinId}/{depressionId}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TropicalStormsActiveBasinIdDepressionIdRspModel TropicalStormsActiveBasinIdDepressionId(TropicalStormsActiveBasinIdDepressionIdReqModel model)
        {
            TropicalStormsActiveBasinIdDepressionIdRspModel ret = new TropicalStormsActiveBasinIdDepressionIdRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.TropicalStormsActiveBasinIdDepressionId;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<TropicalStormsActiveBasinIdDepressionIdDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Active Tropical Cyclones by Basin
        /// http://dataservice.accuweather.com/tropical/v1/storms/active/{basinId}/{depressionId}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TropicalStormsActiveBasinIdRspModel TropicalStormsActiveBasinId(TropicalStormsActiveBasinIdReqModel model)
        {
            TropicalStormsActiveBasinIdRspModel ret = new TropicalStormsActiveBasinIdRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.TropicalStormsActiveBasinId;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<TropicalStormsActiveBasinIdDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Active Tropical Cyclones
        /// http://dataservice.accuweather.com/tropical/v1/storms/active
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TropicalStormsActiveRspModel TropicalStormsActive(TropicalStormsActiveReqModel model)
        {
            TropicalStormsActiveRspModel ret = new TropicalStormsActiveRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.TropicalStormsActive;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<TropicalStormsActiveDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Tropical Cyclone Forecasts
        /// http://dataservice.accuweather.com/tropical/v1/storms/{yyyy}/{basinId}/{depressionId}/forecasts
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TropicalStormsYyyyBasinIdDepressionIdForecastsRspModel TropicalStormsYyyyBasinIdDepressionIdForecasts(TropicalStormsYyyyBasinIdDepressionIdForecastsReqModel model)
        {
            TropicalStormsYyyyBasinIdDepressionIdForecastsRspModel ret = new TropicalStormsYyyyBasinIdDepressionIdForecastsRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.TropicalStormsYyyyBasinIdDepressionIdForecasts;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<TropicalStormsYyyyBasinIdDepressionIdForecastsDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Tropical Cyclone Positions
        /// http://dataservice.accuweather.com/tropical/v1/storms/{yyyy}/{basinId}/{depressionId}/positions
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TropicalStormsYyyyBasinIdDepressionIdPositionsRspModel TropicalStormsYyyyBasinIdDepressionIdPositions(TropicalStormsYyyyBasinIdDepressionIdPositionsReqModel model)
        {
            TropicalStormsYyyyBasinIdDepressionIdPositionsRspModel ret = new TropicalStormsYyyyBasinIdDepressionIdPositionsRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.TropicalStormsYyyyBasinIdDepressionIdPositions;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<TropicalStormsYyyyBasinIdDepressionIdPositionsDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// Tropical Cyclone Current Position
        /// http://dataservice.accuweather.com/tropical/v1/storms/{yyyy}/{basinId}/{depressionId}/positions/current
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TropicalStormsYyyyBasinIdDepressionIdPositionsCurrentRspModel TropicalStormsYyyyBasinIdDepressionIdPositionsCurrent(TropicalStormsYyyyBasinIdDepressionIdPositionsCurrentReqModel model)
        {
            TropicalStormsYyyyBasinIdDepressionIdPositionsCurrentRspModel ret = new TropicalStormsYyyyBasinIdDepressionIdPositionsCurrentRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.TropicalStormsYyyyBasinIdDepressionIdPositionsCurrent;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<TropicalStormsYyyyBasinIdDepressionIdPositionsCurrentDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// List all Languages
        /// http://dataservice.accuweather.com/translations/v1/languages
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TranslationsLanguagesRspModel TranslationsLanguages(TranslationsLanguagesReqModel model)
        {
            TranslationsLanguagesRspModel ret = new TranslationsLanguagesRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.TranslationsLanguages;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<TranslationsLanguagesDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// List all Languages
        /// http://dataservice.accuweather.com/translations/v1/languages
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TranslationsGroupsRspModel TranslationsGroups(TranslationsGroupsReqModel model)
        {
            TranslationsGroupsRspModel ret = new TranslationsGroupsRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.TranslationsGroups;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<TranslationsGroupsDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }

        /// <summary>
        /// List all Languages
        /// http://dataservice.accuweather.com/translations/v1/languages
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TranslationsGroupsGroupIDRspModel TranslationsGroupsGroupID(TranslationsGroupsGroupIDReqModel model)
        {
            TranslationsGroupsGroupIDRspModel ret = new TranslationsGroupsGroupIDRspModel();
            try
            {
                AccAPITypeModel type = AccAPITypeModel.TranslationsGroupsGroupID;
                string json = ApiWebClient(model, type);
                ret.Data = JsonHelper.DeserializeObject<List<TranslationsGroupsGroupIDDataModel>>(json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, this);
            }
            return ret;
        }


        #endregion

        #region model

        private enum AccAPITypeModel
        {
            None = 0,
            LocationsAdminareasCountryCode,
            LocationsCountriesRegionCode,
            LocationsRegions,
            LocationsTopcitiesGroup,
            LocationsCitiesAutocomplete,
            LocationsCitiesNeighborsLocationKey,
            LocationsLocationKey,
            LocationsCitiesSearch,
            LocationsCitiesCountryCodeAdminCodeSearch,
            LocationsCitiesCountryCodeSearch,
            LocationsPoiSearch,
            LocationsPoiCountryCodeAdminCodeSearch,
            LocationsPoiCountryCodeSearch,
            LocationsPostalcodesSearch,
            LocationsPostalcodesCountryCodeSearch,
            LocationsSearch,
            LocationsCountryCodeAdminCodeSearch,
            LocationsCountryCodeSearch,
            LocationsCitiesGeopositionSearch,
            LocationsCitiesIpaddress,
            ForecastsDaily1dayLocationKey,
            ForecastsDaily10dayLocationKey,
            ForecastsDaily15dayLocationKey,
            ForecastsDaily5dayLocationKey,
            ForecastsHourly1hourLocationKey,
            ForecastsHourly12hourLocationKey,
            ForecastsHourly120hourLocationKey,
            ForecastsHourly24hourLocationKey,
            ForecastsHourly72hourLocationKey,
            CurrentconditionsLocationKey,
            CurrentconditionsLocationKeyHistorical24,
            CurrentconditionsLocationKeyHistorical,
            CurrentconditionsTopcitiesGroup,
            IndicesDaily1dayLocationKeyGroupsID,
            IndicesDaily1dayLocationKeyID,
            IndicesDaily1dayLocationKey,
            IndicesDaily10dayLocationKeyGroupsID,
            IndicesDaily10dayLocationKeyID,
            IndicesDaily10dayLocationKey,
            IndicesDaily15dayLocationKeyGroupsID,
            IndicesDaily15dayLocationKeyID,
            IndicesDaily15dayLocationKey,
            IndicesDaily5dayLocationKeyGroupsID,
            IndicesDaily5dayLocationKeyID,
            IndicesDaily5dayLocationKey,
            IndicesDaily,
            IndicesDailyGroups,
            IndicesDailyGroupsID,
            IndicesDailyID,
            Alarms1dayLocationKey,
            Alarms10dayLocationKey,
            Alarms15dayLocationKey,
            Alarms5dayLocationKey,
            AlertsLocationKey,
            ImageryMapsRadsatResolutionLocationKey,
            TropicalStormsYyyyBasinIdDepressionId,
            TropicalStormsYyyyBasinId,
            TropicalStormsActiveBasinIdDepressionId,
            TropicalStormsActiveBasinId,
            TropicalStormsActive,
            TropicalStormsYyyyBasinIdDepressionIdForecasts,
            TropicalStormsYyyyBasinIdDepressionIdPositions,
            TropicalStormsYyyyBasinIdDepressionIdPositionsCurrent,
            TranslationsLanguages,
            TranslationsGroups,
            TranslationsGroupsGroupID,
            ServiceConnectionFailed = 1000
        }

        #endregion

        #region function

        private string ApiRequestUrl(string str)
        {
            return string.Format("http://dataservice.accuweather.com/{0}", str);
        }
        private string ApiQueryModel(string name, Dictionary<string, object> dic)
        {
            string ret = string.Empty;
            foreach (var item in dic)
            {
                if (item.Key.ToLower() == name.ToLower())
                {
                    ret = Convert.ToString(item.Value);
                    break;
                }
            }
            return ret;
        }

        private string ApiWebClient<T>(T model, AccAPITypeModel type)
        {
            string ret = string.Empty;
            string url = string.Empty;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            Type tt = typeof(T);
            foreach (PropertyInfo pi in tt.GetProperties())
            {
                string name = pi.Name; // 属性名
                object value = pi.GetValue(model, null); // 属性值
                string valueStr = Convert.ToString(value);
                dic.Add(name, valueStr);
            }
            try
            {
                switch (type)
                {
                    case AccAPITypeModel.None:
                        break;
                    case AccAPITypeModel.LocationsAdminareasCountryCode:
                        url = ApiRequestUrl(string.Format("locations/v1/adminareas/{0}", ApiQueryModel("countryCode", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsCountriesRegionCode:
                        url = ApiRequestUrl(string.Format("locations/v1/countries/{0}", ApiQueryModel("regionCode", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsRegions:
                        url = ApiRequestUrl(string.Format("locations/v1/regions"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsTopcitiesGroup:
                        url = ApiRequestUrl(string.Format("locations/v1/topcities/{0}", ApiQueryModel("group", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsCitiesAutocomplete:
                        url = ApiRequestUrl(string.Format("locations/v1/cities/autocomplete"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsCitiesNeighborsLocationKey:
                        url = ApiRequestUrl(string.Format("locations/v1/cities/neighbors/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsLocationKey:
                        url = ApiRequestUrl(string.Format("locations/v1/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsCitiesSearch:
                        url = ApiRequestUrl(string.Format("locations/v1/cities/search"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsCitiesCountryCodeAdminCodeSearch:
                        url = ApiRequestUrl(string.Format("locations/v1/cities/{0}/{1}/search", ApiQueryModel("countryCode", dic), ApiQueryModel("adminCode", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsCitiesCountryCodeSearch:
                        url = ApiRequestUrl(string.Format("locations/v1/cities/{0}/search", ApiQueryModel("countryCode", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsPoiSearch:
                        url = ApiRequestUrl(string.Format("locations/v1/poi/search"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsPoiCountryCodeAdminCodeSearch:
                        url = ApiRequestUrl(string.Format("locations/v1/poi/{0}/{1}/search", ApiQueryModel("countryCode", dic), ApiQueryModel("adminCode", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsPoiCountryCodeSearch:
                        url = ApiRequestUrl(string.Format("locations/v1/poi/{0}/search", ApiQueryModel("countryCode", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsPostalcodesSearch:
                        url = ApiRequestUrl(string.Format("locations/v1/postalcodes/search"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsPostalcodesCountryCodeSearch:
                        url = ApiRequestUrl(string.Format("locations/v1/postalcodes/{0}/search", ApiQueryModel("countryCode", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsSearch:
                        url = ApiRequestUrl(string.Format("locations/v1/search"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsCountryCodeAdminCodeSearch:
                        url = ApiRequestUrl(string.Format("locations/v1/{0}/{1}/search", ApiQueryModel("countryCode", dic), ApiQueryModel("adminCode", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsCountryCodeSearch:
                        url = ApiRequestUrl(string.Format("locations/v1/{0}/search", ApiQueryModel("countryCode", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsCitiesGeopositionSearch:
                        url = ApiRequestUrl(string.Format("locations/v1/cities/geoposition/search"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.LocationsCitiesIpaddress:
                        url = ApiRequestUrl(string.Format("locations/v1/cities/ipaddress"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.ForecastsDaily1dayLocationKey:
                        url = ApiRequestUrl(string.Format("forecasts/v1/daily/1day/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.ForecastsDaily10dayLocationKey:
                        url = ApiRequestUrl(string.Format("forecasts/v1/daily/10day/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.ForecastsDaily15dayLocationKey:
                        url = ApiRequestUrl(string.Format("forecasts/v1/daily/15day/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.ForecastsDaily5dayLocationKey:
                        url = ApiRequestUrl(string.Format("forecasts/v1/daily/5day/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.ForecastsHourly1hourLocationKey:
                        url = ApiRequestUrl(string.Format("forecasts/v1/hourly/1hour/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.ForecastsHourly12hourLocationKey:
                        url = ApiRequestUrl(string.Format("forecasts/v1/hourly/12hour/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.ForecastsHourly120hourLocationKey:
                        url = ApiRequestUrl(string.Format("forecasts/v1/hourly/120hour/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.ForecastsHourly24hourLocationKey:
                        url = ApiRequestUrl(string.Format("forecasts/v1/hourly/24hour/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.ForecastsHourly72hourLocationKey:
                        url = ApiRequestUrl(string.Format("forecasts/v1/hourly/72hour/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.CurrentconditionsLocationKey:
                        url = ApiRequestUrl(string.Format("currentconditions/v1/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.CurrentconditionsLocationKeyHistorical24:
                        url = ApiRequestUrl(string.Format("currentconditions/v1/{0}/historical/24", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.CurrentconditionsLocationKeyHistorical:
                        url = ApiRequestUrl(string.Format("currentconditions/v1/{0}/historical", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.CurrentconditionsTopcitiesGroup:
                        url = ApiRequestUrl(string.Format("currentconditions/v1/topcities/{0}", ApiQueryModel("group", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily1dayLocationKeyGroupsID:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/1day/{0}/groups/{1}", ApiQueryModel("locationKey", dic), ApiQueryModel("ID", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily1dayLocationKeyID:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/1day/{0}/{0}", ApiQueryModel("locationKey", dic), ApiQueryModel("ID", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily1dayLocationKey:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/1day/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily10dayLocationKeyGroupsID:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/10day/{0}/groups/{1}", ApiQueryModel("locationKey", dic), ApiQueryModel("ID", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily10dayLocationKeyID:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/10day/{0}/{1}", ApiQueryModel("locationKey", dic), ApiQueryModel("ID", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily10dayLocationKey:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/10day/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily15dayLocationKeyGroupsID:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/15day/{0}/groups/{1}", ApiQueryModel("locationKey", dic), ApiQueryModel("ID", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily15dayLocationKeyID:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/15day/{0}/{1}", ApiQueryModel("locationKey", dic), ApiQueryModel("ID", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily15dayLocationKey:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/15day/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily5dayLocationKeyGroupsID:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/5day/{0}/groups/{1}", ApiQueryModel("locationKey", dic), ApiQueryModel("ID", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily5dayLocationKeyID:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/5day/{0}/{1}", ApiQueryModel("locationKey", dic), ApiQueryModel("ID", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily5dayLocationKey:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/5day/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDaily:
                        url = ApiRequestUrl(string.Format("indices/v1/daily"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDailyGroups:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/groups"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDailyGroupsID:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/groups/{0}", ApiQueryModel("ID", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.IndicesDailyID:
                        url = ApiRequestUrl(string.Format("indices/v1/daily/{0}", ApiQueryModel("ID", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.Alarms1dayLocationKey:
                        url = ApiRequestUrl(string.Format("/alarms/v1/1day/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.Alarms10dayLocationKey:
                        url = ApiRequestUrl(string.Format("alarms/v1/10day/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.Alarms15dayLocationKey:
                        url = ApiRequestUrl(string.Format("alarms/v1/15day/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.Alarms5dayLocationKey:
                        url = ApiRequestUrl(string.Format("alarms/v1/5day/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.AlertsLocationKey:
                        url = ApiRequestUrl(string.Format("alerts/v1/{0}", ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.ImageryMapsRadsatResolutionLocationKey:
                        url = ApiRequestUrl(string.Format("imagery/v1/maps/radsat/{0}/{1}", ApiQueryModel("resolution", dic), ApiQueryModel("locationKey", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.TropicalStormsYyyyBasinIdDepressionId:
                        url = ApiRequestUrl(string.Format("tropical/v1/storms/{0}/{1}/{2}", ApiQueryModel("yyyy", dic), ApiQueryModel("basinId", dic), ApiQueryModel("depressionId", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.TropicalStormsYyyyBasinId:
                        url = ApiRequestUrl(string.Format("tropical/v1/storms/{0}/{1}", ApiQueryModel("yyyy", dic), ApiQueryModel("basinId", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.TropicalStormsActiveBasinIdDepressionId:
                        url = ApiRequestUrl(string.Format("tropical/v1/storms/active/{0}/{1}", ApiQueryModel("basinId", dic), ApiQueryModel("depressionId", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.TropicalStormsActiveBasinId:
                        url = ApiRequestUrl(string.Format("tropical/v1/storms/active/{0}", ApiQueryModel("basinId", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.TropicalStormsActive:
                        url = ApiRequestUrl(string.Format("tropical/v1/storms/active"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.TropicalStormsYyyyBasinIdDepressionIdForecasts:
                        url = ApiRequestUrl(string.Format("tropical/v1/storms/{0}/{1}/{2}/forecasts", ApiQueryModel("yyyy", dic), ApiQueryModel("basinId", dic), ApiQueryModel("depressionId", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.TropicalStormsYyyyBasinIdDepressionIdPositions:
                        url = ApiRequestUrl(string.Format("tropical/v1/storms/{0}/{1}/{2}/positions", ApiQueryModel("yyyy", dic), ApiQueryModel("basinId", dic), ApiQueryModel("depressionId", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.TropicalStormsYyyyBasinIdDepressionIdPositionsCurrent:
                        url = ApiRequestUrl(string.Format("tropical/v1/storms/{0}/{1}/{2}/positions/current", ApiQueryModel("yyyy", dic), ApiQueryModel("basinId", dic), ApiQueryModel("depressionId", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.TranslationsLanguages:
                        url = ApiRequestUrl(string.Format("translations/v1/languages"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.TranslationsGroups:
                        url = ApiRequestUrl(string.Format("translations/v1/groups"));
                        ret = GetWebClient(url, dic);
                        break;
                    case AccAPITypeModel.TranslationsGroupsGroupID:
                        url = ApiRequestUrl(string.Format("translations/v1/groups/{0}", ApiQueryModel("groupID", dic)));
                        ret = GetWebClient(url, dic);
                        break;
                    default:
                        break;
                }
                if (string.IsNullOrEmpty(ret))
                {
                    dic = new Dictionary<string, object>();
                    dic.Add("code", "1000");
                    dic.Add("message", "服务连接失败");
                    dic.Add("data", new List<object>());
                    ret = JsonHelper.SerializeObject(dic);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);
            }
            return ret;
        }

        /// <summary>
        /// 创建Client Get请求，GET请求JSON数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        private string GetWebClient(string url, Dictionary<string, object> dic)
        {
            string ret = string.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in dic)
                {
                    sb.Append(string.Format("&{0}={1}", item.Key, item.Value));
                }
                string paras = sb.ToString();
                if (!string.IsNullOrEmpty(paras))
                {
                    paras = "?" + paras.Substring(1);
                }
                url = url + paras;
                WebClient wc = new WebClient();
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Encoding = Encoding.UTF8;
                ret = wc.DownloadString(url);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);
                if (ex.GetType().Name == "WebException")
                {
                    var e = (WebException)ex;
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        HttpStatusCode errorCode = ((HttpWebResponse)e.Response).StatusCode;
                        string statusDescription = ((HttpWebResponse)e.Response).StatusDescription;
                        using (StreamReader sr = new StreamReader(((HttpWebResponse)e.Response).GetResponseStream(), Encoding.UTF8))
                        {
                            string rstResponseContent = sr.ReadToEnd();
                            ret = rstResponseContent;
                        }
                        string rstExceptionString = e.Message;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// 创建Client Post请求，POST提交JSON数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        private string PostWebClient(string url, string json)
        {
            string ret = string.Empty;
            try
            {
                string param = json;
                WebClient wc = new WebClient();
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Encoding = Encoding.UTF8;
                ret = wc.UploadString(url, json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);
                if (ex.GetType().Name == "WebException")
                {
                    var e = (WebException)ex;
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        HttpStatusCode errorCode = ((HttpWebResponse)e.Response).StatusCode;
                        string statusDescription = ((HttpWebResponse)e.Response).StatusDescription;
                        using (StreamReader sr = new StreamReader(((HttpWebResponse)e.Response).GetResponseStream(), Encoding.UTF8))
                        {
                            string rstResponseContent = sr.ReadToEnd();
                            ret = rstResponseContent;
                        }
                        string rstExceptionString = e.Message;
                    }
                }
            }
            return ret;
        }

        #endregion
    }

    #region model

    public class AccReqModel
    {
        public string apikey { get; set; }
        public string language { get; set; }

        public AccReqModel()
        {
            this.apikey = "nn9WG0LmwgXLkoCVtgDeoFAM5NLwAITE";
            this.language = "zh-cn";
        }
    }
    public class AccRspModel
    {
    }

    public class LocationsAdminareasCountryCodeReqModel : AccReqModel
    {
        public string countryCode { get; set; }
        public int offset { get; set; }
    }
    public class LocationsAdminareasCountryCodeRspModel : AccRspModel
    {
        public List<LocationsAdminareasCountryCodeDataModel> Data { get; set; }
    }
    public class LocationsAdminareasCountryCodeDataModel
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public int Level { get; set; }
        public string LocalizedType { get; set; }
        public string EnglishType { get; set; }
        public string CountryID { get; set; }
    }

    public class LocationsCountriesRegionCodeReqModel : AccReqModel
    {
        public string regionCode { get; set; }
    }
    public class LocationsCountriesRegionCodeRspModel : AccRspModel
    {
        public List<LocationsCountriesRegionCodeDataModel> Data { get; set; }
    }
    public class LocationsCountriesRegionCodeDataModel
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public class LocationsRegionsReqModel : AccReqModel
    {
    }
    public class LocationsRegionsRspModel : AccRspModel
    {
        public List<LocationsRegionsDataModel> Data { get; set; }
    }
    public class LocationsRegionsDataModel
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public class LocationsTopcitiesReqModel : AccReqModel
    {
        public int group { get; set; }
        public bool details { get; set; }
    }
    public class LocationsTopcitiesRspModel : AccRspModel
    {
        public List<LocationsTopcitiesDataModel> Data { get; set; }
    }
    public class LocationsTopcitiesDataModel
    {
    }

    public class LocationsCitiesAutocompleteReqModel : AccReqModel
    {
        public string q { get; set; }
    }
    public class LocationsCitiesAutocompleteRspModel : AccRspModel
    {
        public List<LocationsCitiesAutocompleteDataModel> Data { get; set; }
    }
    public class LocationsCitiesAutocompleteDataModel
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public CountryModel Country { get; set; }
        public class CountryModel
        {
            public string ID { get; set; }
            public string LocalizedName { get; set; }
        }
        public AdministrativeAreaModel AdministrativeArea { get; set; }
        public class AdministrativeAreaModel
        {
            public string ID { get; set; }
            public string LocalizedName { get; set; }
        }
    }

    public class LocationsCitiesNeighborsLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
    }
    public class LocationsCitiesNeighborsLocationKeyRspModel : AccRspModel
    {
        public List<LocationsCitiesNeighborsLocationKeyDataModel> Data { get; set; }
    }
    public class LocationsCitiesNeighborsLocationKeyDataModel
    {
    }

    public class LocationsLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
    }
    public class LocationsLocationKeyRspModel : AccRspModel
    {
        public List<LocationsLocationKeyDataModel> Data { get; set; }
    }
    public class LocationsLocationKeyDataModel
    {
    }

    public class LocationsCitiesSearchReqModel : AccReqModel
    {
        public string q { get; set; }
        public bool details { get; set; }
        public int offset { get; set; }
        public string alias { get; set; }
    }
    public class LocationsCitiesSearchRspModel : AccRspModel
    {
        public List<LocationsCitiesSearchDataModel> Data { get; set; }
    }
    public class LocationsCitiesSearchDataModel
    {
    }

    public class LocationsCitiesCountryCodeAdminCodeSearchReqModel : AccReqModel
    {
        public string countryCode { get; set; }
        public string adminCode { get; set; }
        public string q { get; set; }
        public bool details { get; set; }
        public int offset { get; set; }
        public string alias { get; set; }
    }
    public class LocationsCitiesCountryCodeAdminCodeSearchRspModel : AccRspModel
    {
        public List<LocationsCitiesCountryCodeAdminCodeSearchDataModel> Data { get; set; }
    }
    public class LocationsCitiesCountryCodeAdminCodeSearchDataModel
    {
    }

    public class LocationsCitiesCountryCodeSearchReqModel : AccReqModel
    {
        public string countryCode { get; set; }
        public string q { get; set; }
        public bool details { get; set; }
        public int offset { get; set; }
        public string alias { get; set; }
    }
    public class LocationsCitiesCountryCodeSearchRspModel : AccRspModel
    {
        public List<LocationsCitiesCountryCodeSearchDataModel> Data { get; set; }
    }
    public class LocationsCitiesCountryCodeSearchDataModel
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public string PrimaryPostalCode { get; set; }
        public RegionModel Region { get; set; }
        public class RegionModel
        {
            public string ID { get; set; }
            public string LocalizedName { get; set; }
            public string EnglishName { get; set; }
        }
        public CountryModel Country { get; set; }
        public class CountryModel
        {
            public string ID { get; set; }
            public string LocalizedName { get; set; }
            public string EnglishName { get; set; }
        }
        public AdministrativeAreaModel AdministrativeArea { get; set; }
        public class AdministrativeAreaModel
        {
            public string ID { get; set; }
            public string LocalizedName { get; set; }
            public string EnglishName { get; set; }
            public int Level { get; set; }
            public string LocalizedType { get; set; }
            public string EnglishType { get; set; }
            public string CountryID { get; set; }
        }
        public TimeZoneModel TimeZone { get; set; }
        public class TimeZoneModel
        {
            public string Code { get; set; }
            public string Name{ get; set; }
            public int GmtOffset { get; set; }
            public bool IsDaylightSaving { get; set; }
            public string NextOffsetChange { get; set; }
        }
        public GeoPositionModel GeoPosition { get; set; }
        public class GeoPositionModel
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public ElevationModel Elevation { get; set; }
            public class ElevationModel
            {
                public MetricModel Metric { get; set; }
                public class MetricModel
                {
                    public int Value { get; set; }
                    public string Unit { get; set; }
                    public int UnitType { get; set; }
                }
                public ImperialModel Imperial { get; set; }
                public class ImperialModel
                {
                    public int Value { get; set; }
                    public string Unit { get; set; }
                    public int UnitType { get; set; }
                }
            }
        }
        public bool IsAlias { get; set; }
        public Array SupplementalAdminAreas { get; set; }
        public Array DataSets { get; set; }
        public DetailsModel Details { get; set; }
        public class DetailsModel {
            public string Key { get; set; }
            public string StationCode { get; set; }
            public string StationGmtOffset { get; set; }
            public string BandMap { get; set; }
            public string Climo { get; set; }
            public string LocalRadar { get; set; }
            public string MediaRegion { get; set; }
            public string Metar { get; set; }
            public string NXMetro { get;set; }
            public string NXState { get; set; }
            public string Population { get; set; }
            public string PrimaryWarningCountyCode { get; set; }
            public string PrimaryWarningZoneCode { get;set; }
            public string Satellite { get; set; }
            public string Synoptic { get; set; }
            public string MarineStation { get; set; }
            public string MarineStationGMTOffset { get; set; }
            public string VideoCode { get; set; }
            public string PartnerID { get; set; }
            public List<SourcesModel> Sources { get; set; }
            public class SourcesModel
            {
                public string DataType { get; set; }
                public string Source { get; set; }
                public int SourceId { get; set; }
            }
            public string CanonicalPostalCode { get; set; }
            public string CanonicalLocationKey { get; set; }
        }
    }

    public class LocationsPoiSearchReqModel : AccReqModel
    {
        public string q { get; set; }
        public string type { get; set; }
        public bool details { get; set; }
    }
    public class LocationsPoiSearchRspModel : AccRspModel
    {
        public List<LocationsPoiSearchDataModel> Data { get; set; }
    }
    public class LocationsPoiSearchDataModel
    {
    }

    public class LocationsPoiCountryCodeAdminCodeSearchReqModel : AccReqModel
    {
        public string q { get; set; }
        public string type { get; set; }
        public bool details { get; set; }
    }
    public class LocationsPoiCountryCodeAdminCodeSearchRspModel : AccRspModel
    {
        public List<LocationsPoiCountryCodeAdminCodeSearchDataModel> Data { get; set; }
    }
    public class LocationsPoiCountryCodeAdminCodeSearchDataModel
    {
    }

    public class LocationsPoiCountryCodeSearchReqModel : AccReqModel
    {
        public string countryCode { get; set; }
        public string adminCode { get; set; }
        public string q { get; set; }
        public string type { get; set; }
        public bool details { get; set; }
    }
    public class LocationsPoiCountryCodeSearchRspModel : AccRspModel
    {
        public List<LocationsPoiCountryCodeSearchDataModel> Data { get; set; }
    }
    public class LocationsPoiCountryCodeSearchDataModel
    {
    }

    public class LocationsPostalcodesSearchReqModel : AccReqModel
    {
        public string q { get; set; }
        public bool details { get; set; }
    }
    public class LocationsPostalcodesSearchRspModel : AccRspModel
    {
        public List<LocationsPostalcodesSearchDataModel> Data { get; set; }
    }
    public class LocationsPostalcodesSearchDataModel
    {
    }

    public class LocationsPostalcodesCountryCodeSearchReqModel : AccReqModel
    {
        public string countryCode { get; set; }
        public string q { get; set; }
        public bool details { get; set; }
    }
    public class LocationsPostalcodesCountryCodeSearchRspModel : AccRspModel
    {
        public List<LocationsPostalcodesCountryCodeSearchDataModel> Data { get; set; }
    }
    public class LocationsPostalcodesCountryCodeSearchDataModel
    {
    }

    public class LocationsSearchReqModel : AccReqModel
    {
        public string q { get; set; }
        public bool details { get; set; }
        public int offset { get; set; }
        public string alias { get; set; }
    }
    public class LocationsSearchRspModel : AccRspModel
    {
        public List<LocationsSearchDataModel> Data { get; set; }
    }
    public class LocationsSearchDataModel
    {
    }

    public class LocationsCountryCodeAdminCodeSearchReqModel : AccReqModel
    {
        public string countryCode { get; set; }
        public string adminCode { get; set; }
        public string q { get; set; }
        public bool details { get; set; }
        public int offset { get; set; }
        public string alias { get; set; }
    }
    public class LocationsCountryCodeAdminCodeSearchRspModel : AccRspModel
    {
        public List<LocationsCountryCodeAdminCodeSearchDataModel> Data { get; set; }
    }
    public class LocationsCountryCodeAdminCodeSearchDataModel
    {
    }

    public class LocationsCountryCodeSearchReqModel : AccReqModel
    {
        public string countryCode { get; set; }
        public string q { get; set; }
        public bool details { get; set; }
        public int offset { get; set; }
        public string alias { get; set; }
    }
    public class LocationsCountryCodeSearchRspModel : AccRspModel
    {
        public List<LocationsCountryCodeSearchDataModel> Data { get; set; }
    }
    public class LocationsCountryCodeSearchDataModel
    {
    }

    public class LocationsCitiesGeopositionSearchReqModel : AccReqModel
    {
        public string q { get; set; }
        public bool details { get; set; }
        public bool toplevel { get; set; }
    }
    public class LocationsCitiesGeopositionSearchRspModel : AccRspModel
    {
        public List<LocationsCitiesGeopositionSearchDataModel> Data { get; set; }
    }
    public class LocationsCitiesGeopositionSearchDataModel
    {
    }

    public class LocationsCitiesIpaddressReqModel : AccReqModel
    {
        public string q { get; set; }
        public bool details { get; set; }
    }
    public class LocationsCitiesIpaddressRspModel : AccRspModel
    {
        public List<LocationsCitiesIpaddressDataModel> Data { get; set; }
    }
    public class LocationsCitiesIpaddressDataModel
    {
    }

    public class ForecastsDaily1dayLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
        public bool metric { get; set; }
    }
    public class ForecastsDaily1dayLocationKeyRspModel : AccRspModel
    {
        public List<ForecastsDaily1dayLocationKeyDataModel> Data { get; set; }
    }
    public class ForecastsDaily1dayLocationKeyDataModel
    {
    }

    public class ForecastsDaily10dayLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
        public bool metric { get; set; }
    }
    public class ForecastsDaily10dayLocationKeyRspModel : AccRspModel
    {
        public List<ForecastsDaily10dayLocationKeyDataModel> Data { get; set; }
    }
    public class ForecastsDaily10dayLocationKeyDataModel
    {
    }

    public class ForecastsDaily15dayLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
        public bool metric { get; set; }
    }
    public class ForecastsDaily15dayLocationKeyRspModel : AccRspModel
    {
        public List<ForecastsDaily15dayLocationKeyDataModel> Data { get; set; }
    }
    public class ForecastsDaily15dayLocationKeyDataModel
    {
    }

    public class ForecastsDaily5dayLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
        public bool metric { get; set; }
    }
    public class ForecastsDaily5dayLocationKeyRspModel : AccRspModel
    {
        public List<ForecastsDaily5dayLocationKeyDataModel> Data { get; set; }
    }
    public class ForecastsDaily5dayLocationKeyDataModel
    {
    }

    public class ForecastsHourly1hourLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
        public bool metric { get; set; }
    }
    public class ForecastsHourly1hourLocationKeyRspModel : AccRspModel
    {
        public List<ForecastsHourly1hourLocationKeyDataModel> Data { get; set; }
    }
    public class ForecastsHourly1hourLocationKeyDataModel
    {
    }

    public class ForecastsHourly12hourLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
        public bool metric { get; set; }
    }
    public class ForecastsHourly12hourLocationKeyRspModel : AccRspModel
    {
        public List<ForecastsHourly12hourLocationKeyDataModel> Data { get; set; }
    }
    public class ForecastsHourly12hourLocationKeyDataModel
    {
    }

    public class ForecastsHourly120hourLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
        public bool metric { get; set; }
    }
    public class ForecastsHourly120hourLocationKeyRspModel : AccRspModel
    {
        public List<ForecastsHourly120hourLocationKeyDataModel> Data { get; set; }
    }
    public class ForecastsHourly120hourLocationKeyDataModel
    {
    }

    public class ForecastsHourly24hourLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
        public bool metric { get; set; }
    }
    public class ForecastsHourly24hourLocationKeyRspModel : AccRspModel
    {
        public List<ForecastsHourly24hourLocationKeyDataModel> Data { get; set; }
    }
    public class ForecastsHourly24hourLocationKeyDataModel
    {
    }

    public class ForecastsHourly72hourLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
        public bool metric { get; set; }
    }
    public class ForecastsHourly72hourLocationKeyRspModel : AccRspModel
    {
        public List<ForecastsHourly72hourLocationKeyDataModel> Data { get; set; }
    }
    public class ForecastsHourly72hourLocationKeyDataModel
    {
    }

    public class CurrentconditionsLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
    }
    public class CurrentconditionsLocationKeyRspModel : AccRspModel
    {
        public List<CurrentconditionsLocationKeyDataModel> Data { get; set; }
    }
    public class CurrentconditionsLocationKeyDataModel
    {
    }

    public class CurrentconditionsLocationKeyHistorical24ReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
    }
    public class CurrentconditionsLocationKeyHistorical24RspModel : AccRspModel
    {
        public List<CurrentconditionsLocationKeyHistorical24DataModel> Data { get; set; }
    }
    public class CurrentconditionsLocationKeyHistorical24DataModel
    {
    }

    public class CurrentconditionsLocationKeyHistoricalReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
    }
    public class CurrentconditionsLocationKeyHistoricalRspModel : AccRspModel
    {
        public List<CurrentconditionsLocationKeyHistoricalDataModel> Data { get; set; }
    }
    public class CurrentconditionsLocationKeyHistoricalDataModel
    {
    }

    public class CurrentconditionsTopcitiesGroupReqModel : AccReqModel
    {
        public int group { get; set; }
        public bool details { get; set; }
    }
    public class CurrentconditionsTopcitiesGroupRspModel : AccRspModel
    {
        public List<CurrentconditionsTopcitiesGroupDataModel> Data { get; set; }
    }
    public class CurrentconditionsTopcitiesGroupDataModel
    {
    }

    public class IndicesDaily1dayLocationKeyGroupsIDReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public int ID { get; set; }
        public bool details { get; set; }
    }
    public class IndicesDaily1dayLocationKeyGroupsIDRspModel : AccRspModel
    {
        public List<IndicesDaily1dayLocationKeyGroupsIDDataModel> Data { get; set; }
    }
    public class IndicesDaily1dayLocationKeyGroupsIDDataModel
    {
    }

    public class IndicesDaily1dayLocationKeyIDReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public int ID { get; set; }
        public bool details { get; set; }
    }
    public class IndicesDaily1dayLocationKeyIDRspModel : AccRspModel
    {
        public List<IndicesDaily1dayLocationKeyIDDataModel> Data { get; set; }
    }
    public class IndicesDaily1dayLocationKeyIDDataModel
    {
    }

    public class IndicesDaily1dayLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
    }
    public class IndicesDaily1dayLocationKeyRspModel : AccRspModel
    {
        public List<IndicesDaily1dayLocationKeyDataModel> Data { get; set; }
    }
    public class IndicesDaily1dayLocationKeyDataModel
    {
    }

    public class IndicesDaily10dayLocationKeyGroupsIDReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public int ID { get; set; }
        public bool details { get; set; }
    }
    public class IndicesDaily10dayLocationKeyGroupsIDRspModel : AccRspModel
    {
        public List<IndicesDaily10dayLocationKeyGroupsIDDataModel> Data { get; set; }
    }
    public class IndicesDaily10dayLocationKeyGroupsIDDataModel
    {
    }

    public class IndicesDaily10dayLocationKeyIDReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public int ID { get; set; }
        public bool details { get; set; }
    }
    public class IndicesDaily10dayLocationKeyIDRspModel : AccRspModel
    {
        public List<IndicesDaily10dayLocationKeyIDDataModel> Data { get; set; }
    }
    public class IndicesDaily10dayLocationKeyIDDataModel
    {
    }

    public class IndicesDaily10dayLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
    }
    public class IndicesDaily10dayLocationKeyRspModel : AccRspModel
    {
        public List<IndicesDaily10dayLocationKeyDataModel> Data { get; set; }
    }
    public class IndicesDaily10dayLocationKeyDataModel
    {
    }

    public class IndicesDaily15dayLocationKeyGroupsIDReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public int ID { get; set; }
        public bool details { get; set; }
    }
    public class IndicesDaily15dayLocationKeyGroupsIDRspModel : AccRspModel
    {
        public List<IndicesDaily15dayLocationKeyGroupsIDDataModel> Data { get; set; }
    }
    public class IndicesDaily15dayLocationKeyGroupsIDDataModel
    {
    }

    public class IndicesDaily15dayLocationKeyIDReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public int ID { get; set; }
        public bool details { get; set; }
    }
    public class IndicesDaily15dayLocationKeyIDRspModel : AccRspModel
    {
        public List<IndicesDaily15dayLocationKeyIDDataModel> Data { get; set; }
    }
    public class IndicesDaily15dayLocationKeyIDDataModel
    {
    }

    public class IndicesDaily15dayLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
    }
    public class IndicesDaily15dayLocationKeyRspModel : AccRspModel
    {
        public List<IndicesDaily15dayLocationKeyDataModel> Data { get; set; }
    }
    public class IndicesDaily15dayLocationKeyDataModel
    {
    }

    public class IndicesDaily5dayLocationKeyGroupsIDReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public int ID { get; set; }
        public bool details { get; set; }
    }
    public class IndicesDaily5dayLocationKeyGroupsIDRspModel : AccRspModel
    {
        public List<IndicesDaily5dayLocationKeyGroupsIDDataModel> Data { get; set; }
    }
    public class IndicesDaily5dayLocationKeyGroupsIDDataModel
    {
    }

    public class IndicesDaily5dayLocationKeyIDReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public int ID { get; set; }
        public bool details { get; set; }
    }
    public class IndicesDaily5dayLocationKeyIDRspModel : AccRspModel
    {
        public List<IndicesDaily5dayLocationKeyIDDataModel> Data { get; set; }
    }
    public class IndicesDaily5dayLocationKeyIDDataModel
    {
    }

    public class IndicesDaily5dayLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
    }
    public class IndicesDaily5dayLocationKeyRspModel : AccRspModel
    {
        public List<IndicesDaily5dayLocationKeyDataModel> Data { get; set; }
    }
    public class IndicesDaily5dayLocationKeyDataModel
    {
    }

    public class IndicesDailyReqModel : AccReqModel
    {
    }
    public class IndicesDailyRspModel : AccRspModel
    {
        public List<IndicesDailyDataModel> Data { get; set; }
    }
    public class IndicesDailyDataModel
    {
    }

    public class IndicesDailyGroupsReqModel : AccReqModel
    {
    }
    public class IndicesDailyGroupsRspModel : AccRspModel
    {
        public List<IndicesDailyGroupsDataModel> Data { get; set; }
    }
    public class IndicesDailyGroupsDataModel
    {
    }

    public class IndicesDailyGroupsIDReqModel : AccReqModel
    {
        public int ID { get; set; }
    }
    public class IndicesDailyGroupsIDRspModel : AccRspModel
    {
        public List<IndicesDailyGroupsIDDataModel> Data { get; set; }
    }
    public class IndicesDailyGroupsIDDataModel
    {
    }

    public class IndicesDailyIDReqModel : AccReqModel
    {
        public int ID { get; set; }
    }
    public class IndicesDailyIDRspModel : AccRspModel
    {
        public List<IndicesDailyIDDataModel> Data { get; set; }
    }
    public class IndicesDailyIDDataModel
    {
    }

    public class Alarms1dayLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
    }
    public class Alarms1dayLocationKeyRspModel : AccRspModel
    {
        public List<Alarms1dayLocationKeyDataModel> Data { get; set; }
    }
    public class Alarms1dayLocationKeyDataModel
    {
    }

    public class Alarms10dayLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
    }
    public class Alarms10dayLocationKeyRspModel : AccRspModel
    {
        public List<Alarms10dayLocationKeyDataModel> Data { get; set; }
    }
    public class Alarms10dayLocationKeyDataModel
    {
    }

    public class Alarms15dayLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
    }
    public class Alarms15dayLocationKeyRspModel : AccRspModel
    {
        public List<Alarms15dayLocationKeyDataModel> Data { get; set; }
    }
    public class Alarms15dayLocationKeyDataModel
    {
    }

    public class Alarms5dayLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
    }
    public class Alarms5dayLocationKeyRspModel : AccRspModel
    {
        public List<Alarms5dayLocationKeyDataModel> Data { get; set; }
    }
    public class Alarms5dayLocationKeyDataModel
    {
    }

    public class AlertsLocationKeyReqModel : AccReqModel
    {
        public string locationKey { get; set; }
        public bool details { get; set; }
    }
    public class AlertsLocationKeyRspModel : AccRspModel
    {
        public List<AlertsLocationKeyDataModel> Data { get; set; }
    }
    public class AlertsLocationKeyDataModel
    {
    }

    public class ImageryMapsRadsatResolutionLocationKeyReqModel : AccReqModel
    {
        public string resolution { get; set; }
        public string locationKey { get; set; }
    }
    public class ImageryMapsRadsatResolutionLocationKeyRspModel : AccRspModel
    {
        public List<ImageryMapsRadsatResolutionLocationKeyDataModel> Data { get; set; }
    }
    public class ImageryMapsRadsatResolutionLocationKeyDataModel
    {
    }

    public class TropicalStormsYyyyBasinIdDepressionIdReqModel : AccReqModel
    {
        public string yyyy { get; set; }
        public string basinId { get; set; }
        public string depressionId { get; set; }
    }
    public class TropicalStormsYyyyBasinIdDepressionIdRspModel : AccRspModel
    {
        public List<TropicalStormsYyyyBasinIdDepressionIdDataModel> Data { get; set; }
    }
    public class TropicalStormsYyyyBasinIdDepressionIdDataModel
    {
    }

    public class TropicalStormsYyyyBasinIdReqModel : AccReqModel
    {
        public string yyyy { get; set; }
        public string basinId { get; set; }
    }
    public class TropicalStormsYyyyBasinIdRspModel : AccRspModel
    {
        public List<TropicalStormsYyyyBasinIdDataModel> Data { get; set; }
    }
    public class TropicalStormsYyyyBasinIdDataModel
    {
    }

    public class TropicalStormsActiveBasinIdDepressionIdReqModel : AccReqModel
    {
        public string basinId { get; set; }
        public string depressionId { get; set; }
    }
    public class TropicalStormsActiveBasinIdDepressionIdRspModel : AccRspModel
    {
        public List<TropicalStormsActiveBasinIdDepressionIdDataModel> Data { get; set; }
    }
    public class TropicalStormsActiveBasinIdDepressionIdDataModel
    {
    }

    public class TropicalStormsActiveBasinIdReqModel : AccReqModel
    {
        public string basinId { get; set; }
    }
    public class TropicalStormsActiveBasinIdRspModel : AccRspModel
    {
        public List<TropicalStormsActiveBasinIdDataModel> Data { get; set; }
    }
    public class TropicalStormsActiveBasinIdDataModel
    {
    }

    public class TropicalStormsActiveReqModel : AccReqModel
    {
    }
    public class TropicalStormsActiveRspModel : AccRspModel
    {
        public List<TropicalStormsActiveDataModel> Data { get; set; }
    }
    public class TropicalStormsActiveDataModel
    {
    }

    public class TropicalStormsYyyyBasinIdDepressionIdForecastsReqModel : AccReqModel
    {
        public string yyyy { get; set; }
        public string basinId { get; set; }
        public string depressionId { get; set; }
    }
    public class TropicalStormsYyyyBasinIdDepressionIdForecastsRspModel : AccRspModel
    {
        public List<TropicalStormsYyyyBasinIdDepressionIdForecastsDataModel> Data { get; set; }
    }
    public class TropicalStormsYyyyBasinIdDepressionIdForecastsDataModel
    {
    }

    public class TropicalStormsYyyyBasinIdDepressionIdPositionsReqModel : AccReqModel
    {
        public string yyyy { get; set; }
        public string basinId { get; set; }
        public string depressionId { get; set; }
    }
    public class TropicalStormsYyyyBasinIdDepressionIdPositionsRspModel : AccRspModel
    {
        public List<TropicalStormsYyyyBasinIdDepressionIdPositionsDataModel> Data { get; set; }
    }
    public class TropicalStormsYyyyBasinIdDepressionIdPositionsDataModel
    {
    }

    public class TropicalStormsYyyyBasinIdDepressionIdPositionsCurrentReqModel : AccReqModel
    {
        public string yyyy { get; set; }
        public string basinId { get; set; }
        public string depressionId { get; set; }
    }
    public class TropicalStormsYyyyBasinIdDepressionIdPositionsCurrentRspModel : AccRspModel
    {
        public List<TropicalStormsYyyyBasinIdDepressionIdPositionsCurrentDataModel> Data { get; set; }
    }
    public class TropicalStormsYyyyBasinIdDepressionIdPositionsCurrentDataModel
    {
    }

    public class TranslationsLanguagesReqModel : AccReqModel
    {
    }
    public class TranslationsLanguagesRspModel : AccRspModel
    {
        public List<TranslationsLanguagesDataModel> Data { get; set; }
    }
    public class TranslationsLanguagesDataModel
    {
    }

    public class TranslationsGroupsReqModel : AccReqModel
    {
    }
    public class TranslationsGroupsRspModel : AccRspModel
    {
        public List<TranslationsGroupsDataModel> Data { get; set; }
    }
    public class TranslationsGroupsDataModel
    {
    }

    public class TranslationsGroupsGroupIDReqModel : AccReqModel
    {
        public int groupID { get; set; }
    }
    public class TranslationsGroupsGroupIDRspModel : AccRspModel
    {
        public List<TranslationsGroupsGroupIDDataModel> Data { get; set; }
    }
    public class TranslationsGroupsGroupIDDataModel
    {
    }

    #endregion
}
