using BookingTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BookingTests
{
    public class FlightsSearchTests
    {
        private IWebDriver driver;



        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.booking.com/flights/index.en-us.html");

        }


        [Test]
        public void ShouldNotHaveSearchResultsAfterEnteringNonExistentFlyDirection()
        {
            var flightsPage = new FlightsPageObject(driver);
            flightsPage.SetDepartureAirport("Kharkiv");
            flightsPage.SelectOneWayButton();
            flightsPage.SetDestinationAirport("Ivano-Frankivsk");
            Thread.Sleep(100);   //wait for validation script//
            flightsPage.ClickSearchButton();

            CollectionAssert.IsEmpty(flightsPage.GetFlightsLinks(), "No results are expected");

            var noSearchFlightsMessage = flightsPage.GetNoResultsText();

            Assert.AreEqual("We don't have any flights matching your search on our site. Try changing some details.", noSearchFlightsMessage,
                "Validation message about no flights results is expected");


        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}