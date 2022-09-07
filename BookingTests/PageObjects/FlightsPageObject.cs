using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BookingTests.PageObjects
{
    internal class FlightsPageObject
    {
        private IWebDriver webDriver;
        private readonly By whereFromBox = By.XPath("//div[@data-testid='searchbox_origin']");
        private readonly By whereFromInput = By.XPath("//input[@data-testid='searchbox_origin_input']");
        private readonly By autocompleteResultItem = By.XPath("//div[@data-testid='autocomplete_result']");
        private readonly By whereToInput = By.XPath("//input[@data-testid='searchbox_destination_input']");
        private readonly By oneWayRadioButton = By.XPath("//div[@data-testid='searchbox_controller_trip_type_ONEWAY']");
        private readonly By searchButton = By.XPath("//button[@data-testid='searchbox_submit']");
        private readonly By flightsResultsList = By.XPath("//div[@data-testid='searchresults_card']");
        private readonly By noResultsText = By.XPath("//div[contains (text(), 'any flights matching your search')]");


        public FlightsPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }


        public void SetDepartureAirport(string city)
        {
            webDriver.FindElement(whereFromBox).Click();
            webDriver.FindElement(autocompleteResultItem).Click();
            webDriver.FindElement(whereFromInput).SendKeys(city);
            SelectAirportItem();
        }
        public void SetDestinationAirport(string city)
        {
            webDriver.FindElement(whereToInput).Click();
            webDriver.FindElement(whereToInput).SendKeys(city);
            SelectAirportItem();
        }
        public void SelectOneWayButton()
        {
            webDriver.FindElement(oneWayRadioButton).Click();
        }

        public void ClickSearchButton()
        {
            webDriver.FindElement(searchButton).Click();

        }

        public ICollection<IWebElement> GetFlightsLinks()
        {
            return webDriver.FindElements(flightsResultsList);
        }

        public string GetNoResultsText()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(noResultsText).Displayed);
            return webDriver.FindElement(noResultsText).Text;
        }

        private void SelectAirportItem()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(autocompleteResultItem).Displayed);
            webDriver.FindElement(autocompleteResultItem).Click();
        }
    }
}
