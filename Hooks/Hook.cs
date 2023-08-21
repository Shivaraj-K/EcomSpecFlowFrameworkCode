using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using EcomerceTesting.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using TechTalk.SpecFlow;

namespace EcomerceTesting.Hooks
{
    [Binding]
    public sealed class Hook : Extent
    {
        private readonly IObjectContainer _container;
        IWebDriver d;
        DriverIn dd;
        private readonly ICommon _com;
        

        public Hook(IObjectContainer container)
        {
            _container = container;
          //  _com = com;
        }

        [BeforeTestRun]
        public static void ExtendMethod()
        {
            ExtentMethod();
        }

        [AfterTestRun]
        public static void TearDown()
        {
            ExtentTearDown();
        }
        [BeforeFeature]
        public static void FeatureMethod(FeatureContext fc)
        {
            et = e.CreateTest<Feature>(fc.FeatureInfo.Title);
        }

        [BeforeScenario]
        public  void DriverInit()
        {
            
            dd = new DriverIn();
            d= dd.DriverInIt();
            _container.RegisterInstanceAs<IWebDriver>(d);
            ICommon com = new CommonClass(d);
            _container.RegisterInstanceAs<ICommon>(com);

           T= et.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterStep]
        public void ReportMethod(ScenarioContext s)
        {
            String type=s.StepContext.StepInfo.StepDefinitionType.ToString();
            String name = s.StepContext.StepInfo.Text;

          var d=  _container.Resolve<IWebDriver>();

            if(s.TestError==null)
            {
                if(type=="Given")
                {
                    T.CreateNode<Given>(name) ;
                }
                else if(type=="When")
                {
                    T.CreateNode<When>(name);
                }

                else if(type=="Then")
                {
                    T.CreateNode<Then>(name);
                }
            }

            else if(s.TestError!=null)
            {
                if(type=="Given")
                {
                    T.CreateNode<When>(name).Fail(s.TestError.Message,MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShot(d,s)).Build());   
                }
                else if(type=="When")
                {
                    T.CreateNode<When>(name).Fail(s.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShot(d, s)).Build());

                }

                else if(type=="Then")
                {
                    T.CreateNode<Then>(name).Fail(s.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShot(d, s)).Build());
                }
            }

        }
    }
}