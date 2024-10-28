using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoscout24_listing_scraper.Model
{

    public class Rootobject
    {
        public Pageprops pageProps { get; set; }
        public bool __N_SSP { get; set; }
    }

    public class Pageprops
    {
        public string pageTitle { get; set; }
        public string pageid { get; set; }
        public Cultureinfo cultureInfo { get; set; }
        public string eTldPlusOne { get; set; }
        public Pagequery pageQuery { get; set; }
        public int numberOfResults { get; set; }
        public int numberOfPages { get; set; }
        public Listing[] listings { get; set; }
        public int numberOfOcsResults { get; set; }
        public string trackingId { get; set; }
        public bool isMobile { get; set; }
        public object taxonomy { get; set; }
        public object translations { get; set; }
        public string adTargetingString { get; set; }
        public string loggedInCustomerTypeId { get; set; }
        public object[] recommendations { get; set; }
        public Usersession userSession { get; set; }
        public object seoText { get; set; }
        public object latestUserSession { get; set; }
        public Togglingparams togglingParams { get; set; }
        public object interlinking { get; set; }
        public Optimizelyresults optimizelyResults { get; set; }
        public string isoCulture { get; set; }
        public string pagePath { get; set; }
        public bool collectWebVitals { get; set; }
        public bool isTradeInCampaign { get; set; }
        public string locationSuggestion { get; set; }
        public object resumeFinancing { get; set; }
        public string listHeaderTitle { get; set; }
        public int deliverableTailTotalItems { get; set; }
        public bool newTaxonomyAvailable { get; set; }
    }

    public class Cultureinfo
    {
        public string isoCulture { get; set; }
        public string tld { get; set; }
        public string country { get; set; }
    }

    public class Pagequery
    {
        public string sort { get; set; }
        public string desc { get; set; }
        public string atype { get; set; }
        public string ustate { get; set; }
        public string powertype { get; set; }
        public string cy { get; set; }
        public string priceto { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string zip { get; set; }
        public string zipr { get; set; }
        public string fregfrom { get; set; }
        public string source { get; set; }
        public string show_nfm { get; set; }
        public string pricetype { get; set; }
        public string tier_rotation { get; set; }
    }

    public class Usersession
    {
        public string visitorId { get; set; }
        public bool isLoggedIn { get; set; }
        public bool hasConsentCookie { get; set; }
    }

    public class Togglingparams
    {
        public bool activate_abtest229_historicalctr_ltr_model_v34 { get; set; }
        public bool activate_abtest272_personalised_ltr_model_v41 { get; set; }
        public bool ugacq1066sellingcta { get; set; }
        public bool abtest383ltrv50withoutsmylefeature { get; set; }
        public bool as24searchfunnelnfmenabled { get; set; }
        public bool disableadsandtracking { get; set; }
        public bool disableadssearchfunnel { get; set; }
        public bool ocssmylecheckoutfinancingdisabled { get; set; }
        public bool disabletrackingsearchfunnel { get; set; }
        public bool enable404forinvalidparameter { get; set; }
        public bool enable404redirects { get; set; }
        public bool enable404redirectslogging { get; set; }
        public bool abtest234_core_cars_show_option_for_online_purchase_smyle { get; set; }
        public bool abtest344savedsearchfloatingctaonlistpage { get; set; }
        public bool seenewlistpageaisearch { get; set; }
        public bool abtest380miaupliftcounterfactualexperiment { get; set; }
        public bool abtest393dealerleveltest { get; set; }
        public bool abtest402check24wordings { get; set; }
        public bool abtest421as24experts { get; set; }
        public bool abtest447_ltr_6_0_personalized_targeting_leads { get; set; }
        public bool abtest456_ltrmodelv5_1targetingleadswithpositiondebias { get; set; }
        public bool abtest482dealeroptimisedmiaselectionwithdeeplearning { get; set; }
        public bool enablecustomsearchbuttoncaption { get; set; }
        public bool enableabtest525filterscounters { get; set; }
        public bool enableabtest543filterscounters { get; set; }
        public bool enableabtest547declutterlistpagecard { get; set; }
        public bool abtest549useuserlocationforallsearchesv2 { get; set; }
        public bool abtest556listpagefavoritebuttontooltip { get; set; }
        public bool abtest559listpagefavoritebuttontooltipcontentcopy { get; set; }
        public bool enableabtest560declutterlistpagecard { get; set; }
        public bool enableabtest561personalizedfilterrecommendationonlistpage { get; set; }
        public bool ign2007listpagenwlsmylefilter { get; set; }
        public bool enableabtest_566_additional_slide_in_image_carousel_on_listcards { get; set; }
        public bool enableabtest451highlightdealerrating { get; set; }
        public bool ign1825superdealrenaming { get; set; }
        public bool cptintegrateaddefendat { get; set; }
        public bool enableaisearchde { get; set; }
        public bool cpcheck24fallbacknewwording { get; set; }
        public bool enableclsdatadoglogging { get; set; }
        public bool enablecustomlistpages { get; set; }
        public bool srdebugrankinginlistpage { get; set; }
        public bool cptnewlistpagedirectfinanceapicall { get; set; }
        public bool dualpricefeatureat { get; set; }
        public bool dualpricefeaturebe { get; set; }
        public bool dualpricefeaturede { get; set; }
        public bool dualpricefeaturees { get; set; }
        public bool dualpricefeaturenl { get; set; }
        public bool electricvehicleexperience { get; set; }
        public bool enableexplorercounters { get; set; }
        public bool snsenablefilterrecommendations { get; set; }
        public bool cptfinancingandinsurancenllistpage { get; set; }
        public bool enableinjectedjserrorslogging { get; set; }
        public bool enableinpdatadoglogging { get; set; }
        public bool leasint661leasingnotification { get; set; }
        public bool limodelgroup { get; set; }
        public bool enablelistingcounters { get; set; }
        public bool nwlmvpgolive { get; set; }
        public bool enablenationallistingsuichanges { get; set; }
        public bool feedbackformdetailpagefeature { get; set; }
        public bool see1969displaynewconditions { get; set; }
        public bool newpricelabelstranslations { get; set; }
        public bool ocssmylerestorecheckoutsessionlistpage { get; set; }
        public bool ocssmylerestorecheckoutofflinesessionlistpage { get; set; }
        public bool ocssmyleconciselistitem { get; set; }
        public bool enableocssmylefinancingcta { get; set; }
        public bool enablequeryparamvalidationinsf { get; set; }
        public bool cptenableresumefinancinglistpage { get; set; }
        public bool enabletooltipinsase { get; set; }
        public bool enable_savesearch_without_login { get; set; }
        public bool ugaa1798savelaseonlistpage { get; set; }
        public bool srenableshowingsmylelistingafterlocationsearch { get; set; }
        public bool ocssmyleenablechangeoffinancingdirection { get; set; }
        public bool enabletradeinfilter { get; set; }
        public bool enableunderstitialadsize { get; set; }
        public bool lsapiextralogs { get; set; }
        public bool expriment553appbannerafterdeniedlogin { get; set; }
        public bool forceabtest421variation { get; set; }
        public bool forceabtest486variation1 { get; set; }
        public bool forceabtest486variation2 { get; set; }
        public bool forceabtest547560variation1 { get; set; }
        public bool forceabtest547560variation2 { get; set; }
        public bool ugact1081navigationredesign { get; set; }
        public bool ugaa1081lastsearchbellnotification { get; set; }
        public bool leasinglistpageitaly { get; set; }
        public bool see1939newvehicleaccidentfilter { get; set; }
        public bool reservemaxheightadsmobile { get; set; }
        public bool abtest419showonlyleasingmarktinventory { get; set; }
        public bool ugaa1452saseapicors { get; set; }
    }

    public class Optimizelyresults
    {
        public object abTest344FloatingSaseCtaDesktop { get; set; }
        public object abTest272PersonalisedLtrModelV41Variation { get; set; }
        public object enableAbTest275NavigationSellingCTA { get; set; }
        public object abTest229CtrLtrModelV34 { get; set; }
        public object abTest383LtrV50WithoutSmyleFeature { get; set; }
        public object abTest393DealerOptimisationWithContinuousRotation { get; set; }
        public object abTest380MiaUpliftCounterfactualExperiment { get; set; }
        public object abTest402LpCheck24Wordings { get; set; }
        public object abTest421As24Experts { get; set; }
        public object abTest419ShowOnlyLeasingMarktInventory { get; set; }
        public object abTest549UseUserLocationForAllSearches { get; set; }
        public object abTest451HighlightDealerRatingOnLP { get; set; }
        public object abTest468SuperDealRebranding { get; set; }
        public object abTest456LtrModelV51 { get; set; }
        public object abTest482DealerOptimisedMiaSelectionWithDeepLearning { get; set; }
        public object abTest486CustomSearchButtonCaption { get; set; }
        public object abTest556ListPageFavoriteButtonTooltip { get; set; }
        public object abTest559ListPageFavoriteButtonTooltipContentCopy { get; set; }
        public object abTest566AdditionalSlideInImageCarouselOnListcards { get; set; }
        public object abTest525FilterCounters { get; set; }
        public object abTest543FilterCounters { get; set; }
        public object abTest447LtrModelV60 { get; set; }
        public object abTest547DeclutterListPageCard { get; set; }
        public object abTest553AppBannerAfterDeniedLoginWindow { get; set; }
        public object abTest560DeclutterListPageCardIt { get; set; }
        public object abTest561PersonalizedFilterRecommendationOnListPage { get; set; }
        public object abTest563SmyleNWLFilter { get; set; }
        public object abTest522ExtendedModelFilter { get; set; }
    }

    public class Listing
    {
        public string id { get; set; }
        public string[] images { get; set; }
        public object[] ocsImagesA { get; set; }
        public Price price { get; set; }
        public bool availableNow { get; set; }
        public Superdeal superDeal { get; set; }
        public string url { get; set; }
        public Vehicle vehicle { get; set; }
        public Location location { get; set; }
        public Ratings ratings { get; set; }
        public Seller seller { get; set; }
        public string appliedAdTier { get; set; }
        public string adTier { get; set; }
        public bool isOcs { get; set; }
        public object[] specialConditions { get; set; }
        public Statistics statistics { get; set; }
        public string searchResultType { get; set; }
        public string searchResultSection { get; set; }
        public Tracking tracking { get; set; }
        public float coverImageAttractiveness { get; set; }
        public Vehicledetail[] vehicleDetails { get; set; }
        public bool isOfferNew { get; set; }
    }

    public class Price
    {
        public string priceFormatted { get; set; }
        public int priceEvaluation { get; set; }
        public string priceSuperscriptString { get; set; }
        public bool isPriceEvaluationEnabled { get; set; }
        public string oldSuperDealPrice { get; set; }
    }

    public class Superdeal
    {
        public string oldPriceFormatted { get; set; }
        public bool isEligible { get; set; }
    }

    public class Vehicle
    {
        public string articleType { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string modelVersionInput { get; set; }
        public string subtitle { get; set; }
        public string offerType { get; set; }
    }

    public class Location
    {
        public string countryCode { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
    }

    public class Ratings
    {
        public int ratingsCount { get; set; }
        public float ratingsStars { get; set; }
        public bool ratingsEnabled { get; set; }
    }

    public class Seller
    {
        public string id { get; set; }
        public string type { get; set; }
        public Logo logo { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public Links links { get; set; }
        public Phone[] phones { get; set; }
    }

    public class Logo
    {
        public Small small { get; set; }
    }

    public class Small
    {
        public string href { get; set; }
    }

    public class Links
    {
        public string infoPage { get; set; }
        public string imprint { get; set; }
    }

    public class Phone
    {
        public string phoneType { get; set; }
        public string formattedNumber { get; set; }
        public string callTo { get; set; }
    }

    public class Statistics
    {
        public string leadsRange { get; set; }
    }

    public class Tracking
    {
        public string firstRegistration { get; set; }
        public string fuelType { get; set; }
        public string imageContent { get; set; }
        public string isSmyleEligible { get; set; }
        public string mileage { get; set; }
        public string priceLabel { get; set; }
        public string price { get; set; }
        public string orderBucket { get; set; }
        public string modelTaxonomy { get; set; }
    }

    public class Vehicledetail
    {
        public string data { get; set; }
        public string iconName { get; set; }
    }

}
