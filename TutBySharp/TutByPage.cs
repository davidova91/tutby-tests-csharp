using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TutBySharp
{
    public class TutByPage
    {
        public static IWebDriver instance;
        private static string baseUrl = "http://tut.by";
        public static void Open()
        {
            instance = new FirefoxDriver();
            instance.Manage().Window.Maximize();
            instance.Navigate().GoToUrl(baseUrl);
        }

        public static void GoToWorkPage()
        {
            instance.FindElement(By.LinkText("Работа")).Click();
        }

        public static void SearchText(string findText)
        {
            instance.FindElement(By.XPath("//input[@data-qa='vacancy-serp__query']")).SendKeys(findText);
            instance.FindElement(By.XPath("//button[@data-qa='navi-search__button']")).Click();
        }

        public static int CheckCount(string findText)
        {
            var elements = new List<IWebElement>(instance.FindElements(By.XPath("//div[@class='search-result-item__description']")));

            return elements.Select(t => t.Text.ToLower()).Count(text => text.Contains(findText));
        }

        public static int CheckCount2(string findText)
        {
            var res = 0;
            var elements = new List<IWebElement>(instance.FindElements(By.XPath("//div[@class='search-result-item__description']")));

            for (var i = 0; i < elements.Count; i++)
            {
                var text = elements[i].Text.ToLower();
                if (text.Contains(findText))
                {
                    res++;
                }
            }
            return res;
        }

        public static void Close()
        {
            instance.Close();
        }
    }
}

