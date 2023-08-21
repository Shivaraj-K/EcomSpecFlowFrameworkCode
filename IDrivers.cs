using EcomerceTesting.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceTesting
{
    public interface IDrivers
    {
        ProductCatalog productCatalog { get; }
    }
    public class DriverClass : IDrivers
    {

        public DriverClass()
        {
           // productCatalog = new LoginPage().LoginToEcom();
        }

        public ProductCatalog productCatalog { get; }
    }
}
