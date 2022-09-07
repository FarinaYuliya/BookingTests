using BookingTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BookingTests
{
    public class StaysSearchTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.booking.com/index.en-us.html");
        }

        [Test]
        public void ShouldHaveSelectedCityAndDateOnSearchResults()
        {
            var mainPage = new MainPageObject(driver);
            var city = "New York";
            mainPage.SetCity(city);

            mainPage.SetDates("1 December 2022", "31 December 2022");

            var staysResultsPage = mainPage.ClickSearchButton();

            foreach (var link in staysResultsPage.GetAddressLinks())
            {
                StringAssert.EndsWith(city, link.Text, $"The selected {city} does not match {link.Text}");
            }
            var checkInDate = staysResultsPage.GetCheckInDate();
            var checkOutDate = staysResultsPage.GetCheckOutDate();

            StringAssert.Contains("Thursday, December 1, 2022", checkInDate, $"The selected date does not match date on Search page");
            StringAssert.Contains("Saturday, December 31, 2022", checkOutDate, $"The selected date does not match date on Search page");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}