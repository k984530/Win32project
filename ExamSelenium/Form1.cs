using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ExamSelenium
{
    public partial class Form1 : Form
    {
        protected ChromeDriverService _driverService = null;
        protected ChromeOptions _options = null;
        protected ChromeDriver _driver = null;

        public Form1()
        {
            InitializeComponent();

            try
            {
                _driverService = ChromeDriverService.CreateDefaultService();
                _driverService.HideCommandPromptWindow = true;

                _options = new ChromeOptions();
                _options.AddArgument("disable-gpu");
            }
            catch(Exception exc)
            {
                Trace.WriteLine(exc.Message);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;
                string pw = textBox2.Text;

                _driver = new ChromeDriver(_driverService, _options);
                id = "2017253020";
                pw = "980408";
//                _driver.Navigate().GoToUrl("https://open.yonsei.ac.kr/passni/sso/coursemosLogin.php?username="+id+"&password="+pw+"&ssoGubun=Login");
                _driver.Navigate().GoToUrl("https://m.blog.naver.com/yug311861/221835061758");

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

               _driver.FindElement(By.XPath("//*[@id='body']/div[4]/div[1]/h1/a/span")).Click();
  /*              var li = title.FindElements(By.CssSelector(".course-title"));
                foreach (var course in li) 
                {
                    var course_name = course.FindElement(By.XPath("/h3")).Text ;
                    Trace.WriteLine(course_name);
                }
 */           }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _driver.Quit();
        }
    }
}
