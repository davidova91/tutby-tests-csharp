using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutBySharp;

namespace TutBySharpTests
{
    [TestClass]
    public class TutByTest
    {
        [TestMethod]
        public void Search_results_count_is_in_allowed_range()
        {
            var findText = "специалист по тестированию";
            var maxCountPerPage = 20;
            var minCount = 0;

            TutByPage.Open();
            TutByPage.GoToWorkPage();
            TutByPage.SearchText(findText);

            var result = TutByPage.CheckCount(findText);
            Console.WriteLine("retrieved " + result + " results.");

            Assert.IsTrue(result <= maxCountPerPage);
            Assert.IsTrue(result >= minCount);

            TutByPage.Close();
        }
    }
}
