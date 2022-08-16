using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCsharp

{

    public class Tests

    {

        IWebDriver driver;

        [OneTimeSetUp]

        public void Setup()

        {

            //Below code is to get the drivers folder path dynamically.

            //You can also specify chromedriver.exe path dircly ex: C:/MyProject/Project/drivers

            //Creates the ChomeDriver object, Executes tests on Google Chrome
            System.Environment.SetEnvironmentVariable("webDriver.chrome.driver", @"C:\\chromedriver_win32\\chromedriver.exe");

            driver = new ChromeDriver();

            //If you want to Execute Tests on Firefox uncomment the below code

            // Specify Correct location of geckodriver.exe folder path. Ex: C:/Project/drivers

            //driver= new FirefoxDriver(path + @"\drivers\");

        }

        [Test]

        public void Registration()

        {

            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.ClassName("header_user_info")).Click();
            driver.FindElement(By.Name("email_create")).SendKeys("test2@test.co.nz");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            
            //Click Gender
            Thread.Sleep(5000);
            driver.FindElement(By.Id("id_gender1")).Click();
            //Enter First Name
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Michael");
            //Enter Last Name
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Cooper");
            //Enter Password Name
            driver.FindElement(By.Id("passwd")).SendKeys("6SP6AMS8i@b4Mmu");

            //Date of birth
            new SelectElement(driver.FindElement(By.Id("days"))).SelectByValue("9");
            new SelectElement(driver.FindElement(By.Id("months"))).SelectByIndex(6);
            new SelectElement(driver.FindElement(By.Id("years"))).SelectByValue("1990");

            //Address
            driver.FindElement(By.Id("address1")).SendKeys("10 Beachroad Ave");
            driver.FindElement(By.Id("city")).SendKeys("Sydney");
            new SelectElement(driver.FindElement(By.Id("id_state"))).SelectByIndex(2);
            driver.FindElement(By.Id("city")).SendKeys("Sydney");
            driver.FindElement(By.Id("postcode")).SendKeys("11005");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("907-200-1655");

            //Click submit
            driver.FindElement(By.Id("SubmitAccount")).Click();
            string actualvalue = driver.FindElement(By.ClassName("account")).Text;
            Assert.IsTrue(actualvalue.Contains("Michael Cooper"));
            Thread.Sleep(4000);
            driver.Close();

        }

        [Test]

        public void SignIn()

        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.ClassName("header_user_info")).Click();
            //Enter Email
            driver.FindElement(By.Id("email")).SendKeys("test1@test.co.nz");
            //Enter Password
            driver.FindElement(By.Id("passwd")).SendKeys("6SP6AMS8i@b4Mmu");
            
            //Login
            driver.FindElement(By.Id("SubmitLogin")).Click();
            string actualvalue = driver.FindElement(By.ClassName("account")).Text;
            Assert.IsTrue(actualvalue.Contains("Michael Cooper"));

            Thread.Sleep(4000);
            driver.Quit();
        }

        [Test]

        public void SignInWithWrongPassword()

        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.ClassName("header_user_info")).Click();
            //Enter Email
            driver.FindElement(By.Id("email")).SendKeys("test1@test.co.nz");
            //Enter Password
            driver.FindElement(By.Id("passwd")).SendKeys("Thispasswordiswrong");
            
            //Login
            driver.FindElement(By.Id("SubmitLogin")).Click();
            Thread.Sleep(4000);
            string errorM = driver.FindElement(By.CssSelector("[class*='alert alert-danger']")).Text;
            Assert.IsTrue(errorM.Contains("There is 1 error"));
            driver.Quit();
        }


        }





    }
