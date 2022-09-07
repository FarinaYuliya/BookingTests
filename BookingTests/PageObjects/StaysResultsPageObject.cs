using OpenQA.Selenium;

namespace BookingTests.PageObjects
{
    internal class StaysResultsPageObject
    {
        private IWebDriver webDriver;

        private readonly By addressLinksButton = By.XPath("//span[@data-testid='address']");
        private readonly By checkInDateButton = By.XPath("//button[@data-testid='date-display-field-start']");
        private readonly By checkOutDateButton = By.XPath("//button[@data-testid='date-display-field-end']");

        public StaysResultsPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public ICollection<IWebElement> GetAddressLinks()
        {
            return webDriver.FindElements(addressLinksButton);
        }

        public string GetCheckInDate()
        {
            return webDriver.FindElement(checkInDateButton).Text;
        }

        public string GetCheckOutDate()
        {
            return webDriver.FindElement(checkOutDateButton).Text;
        }

    }

}
