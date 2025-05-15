using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace WebPanelTests
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // arka planda çalıştırmak için
            driver = new ChromeDriver(options);
        }

        [Test]
        public void Test_PLC_Verisi_Gonder()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");

            var input = driver.FindElement(By.Id("giris"));
            input.SendKeys("Deneme Verisi");

            var button = driver.FindElement(By.XPath("//button"));
            button.Click();

            var sonuc = driver.FindElement(By.XPath("//p[strong[contains(text(),'Deneme Verisi')]]"));

            if (!sonuc.Text.Contains("Deneme Verisi"))
                Assert.Fail("Test Failed");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
