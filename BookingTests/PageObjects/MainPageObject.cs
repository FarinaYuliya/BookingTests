using OpenQA.Selenium;


namespace BookingTests.PageObjects
{
    internal class MainPageObject
    {
        private IWebDriver webDriver;

        private readonly By cityInput = By.XPath("//input[@name='ss']");
        private readonly By dateCheckInButton = By.CssSelector(".xp__dates-inner.xp__dates__checkin>div");
        private readonly By calendarNextButton = By.XPath("//div[@data-bui-ref='calendar-next']");
        private readonly By searchButton = By.CssSelector(".js-sb-submit-text");

        public MainPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void SetCity(string city)
        {
            webDriver.FindElement(cityInput).SendKeys(city);
        }
        /// <summary>
        /// Sets dates 
        /// </summary>
        /// <param name="startDate">should be in "1 Month 2022"  format </param>
        /// <param name="endDate">should be in "31 Month 2022"  format </param>

        public void SetDates(string startDate, string endDate)
        {
            var startDateButton = By.XPath($"//span[@aria-label='{startDate}']");
            var endDateButton = By.XPath($"//span[@aria-label='{endDate}']");

            webDriver.FindElement(dateCheckInButton).Click();
            var calendarNext = webDriver.FindElement(calendarNextButton);


            while (!webDriver.FindElements(startDateButton).Any())
            {
                calendarNext.Click();
            }

            webDriver.FindElement(startDateButton).Click();
            webDriver.FindElement(endDateButton).Click();
        }


        public StaysResultsPageObject ClickSearchButton()
        {
            webDriver.FindElement(searchButton).Click();
            return new StaysResultsPageObject(webDriver);
        }

    }

}
