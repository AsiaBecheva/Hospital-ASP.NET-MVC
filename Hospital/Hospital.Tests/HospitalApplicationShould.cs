namespace Hospital.Tests
{
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;
    using Xunit;
    using System.Collections.ObjectModel;
    using System.CodeDom;
    using OpenQA.Selenium.Support.UI;

    public class HospitalApplicationShould
    {
        private const string HomeUrl = "http://localhost:55925/";
        private const string AllDoctors = "http://localhost:55925/Doctors/AllDoctors";
        private const string AllTrials = "http://localhost:55925/ClinicalTrials/AllTrials";


        [Fact]
        [Trait("Category", "Application")]
        public void LoadDoctorsPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();
                IWebElement linkTextDoctors = driver.FindElement(By.LinkText("Doctors"));

                linkTextDoctors.Click();
                DemoHelper.Pause();

                Assert.Equal(AllDoctors, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void LoadSelectedDoctorPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                string firstDoc = "a[href*='/Doctors/GetDoctorById/3']";

                driver.Navigate().GoToUrl(AllDoctors);
                DemoHelper.Pause();
                IWebElement linkTextDoctors = driver.FindElement(By.CssSelector(firstDoc));

                linkTextDoctors.Click();
                DemoHelper.Pause();

                Assert.Equal("http://localhost:55925/Doctors/GetDoctorById/3", driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void CheckFirstDoctorName()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                string firstDoc = "a[href*='/Doctors/GetDoctorById/3']";
                string firstDocName = "Doctor - UJfiIjgAY YWRfffjfUEhI";

                driver.Navigate().GoToUrl(AllDoctors);
                DemoHelper.Pause();
                IWebElement linkTextDoctors = driver.FindElement(By.CssSelector(firstDoc));
                linkTextDoctors.Click();

                DemoHelper.Pause();
                IWebElement findFirstDocName = driver.FindElement(By.TagName("h2"));

                Assert.Equal(findFirstDocName.Text, firstDocName);
            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void CheckSecondDoctorNameWithXPath()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                string secondDocName = "Doctor - QMhICRMPN FUBdCaADtBN";

                driver.Navigate().GoToUrl(AllDoctors);
                DemoHelper.Pause();
                IWebElement linkTextDoctors = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[2]/a"));
                linkTextDoctors.Click();

                DemoHelper.Pause();
                IWebElement findFirstDocName = driver.FindElement(By.TagName("h2"));

                Assert.Equal(findFirstDocName.Text, secondDocName);
            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void LoadRegisterPageAfterLogin()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                string registerUrl = "http://localhost:55925/Account/Register";

                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                IWebElement loginButton = driver.FindElement(By.LinkText("Login"));
                loginButton.Click();
                DemoHelper.Pause();

                IWebElement registerLink = driver.FindElement(By.LinkText("Register"));
                registerLink.Click();
                DemoHelper.Pause();

                Assert.Equal(registerUrl, driver.Url);
            }
        }
    }
}
