using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DVPRO.DATA.EF.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using ChartJSCore.Models;
using ChartJSCore.Helpers;
using ChartJSCore.Plugins.Zoom;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DVPRO.UI.MVC.Controllers
{   
    public class Charts : Controller
    {
        private readonly DVPROContext _context;

        public Charts(DVPROContext context)
        {
            _context = context;
        }
        //The below actions are available from NuGet Package ChartJSCore
        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard()
        {
            //Retrieves all Sales records from the past 6 months
            var salesData = _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Customer.Country)
                .Include(s => s.Customer.Country.Region)
                .Include(s => s.Salesperson)
                .Where(s => s.SaleDate.Year == (DateTime.Today.Year))
                .OrderBy(s => s.SaleDate)
                .ToList();

            var totalSalesData = _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Customer.Country)
                .Include(s => s.Customer.Country.Region)
                .Include(s => s.Salesperson)
                .ToList();

            
                
                

            #region Sales BarChart
            #region Collect totals by month


            //Totals the sales by month, saves as a list
                List<decimal?> monthlyTotalSales = salesData
                    .GroupBy(sale => new { sale.SaleDate.Year, sale.SaleDate.Month })
                    .Select(group => group.Sum(sale => sale.SaleTotal))
                    .ToList();

                //Converts list to doubles for use in ChartJS

                List<double?> monthlySalesAsDoubles = monthlyTotalSales.ConvertAll(s => (double?)s);
                #endregion

                #region Collect Month Names

                //Retrieves distinct abbreviated month names that are present in the data
                List<string> monthNames = salesData
                    .Select(sale => sale.SaleDate.ToString("MMM"))
                    .Distinct()
                    .ToList();
                #endregion

                #region BarChart creation
                //Create the Chart object
                Chart salesBarChart = new Chart();

                //Assign the type using the enum (provided with ChartJS)
                salesBarChart.Type = Enums.ChartType.Bar;

                //Create the chart data object
                ChartJSCore.Models.Data barChartData = new ChartJSCore.Models.Data();

                //Assign month names to the label
                barChartData.Labels = monthNames;

                BarDataset barDataset = new BarDataset()
                {
                    Label = $"Sales {DateTime.Now.Year}",
                    Data = monthlySalesAsDoubles,
                    BackgroundColor = new List<ChartColor>
                    {
                        ChartColor.FromRgb(28, 200, 138)
                    },
                    BorderColor = new List<ChartColor>
                    {
                        ChartColor.FromRgb(28, 200, 138)
                    },
                    BorderWidth = new List<int>() { 1 },
                    BarPercentage = 1,
                    BarThickness = 20,
                    MaxBarThickness = 30,
                    MinBarLength = 2
                };


                #endregion

                #region Packaging and passing to the view

                //Create a List<Dataset> to store our Chart data
                barChartData.Datasets = new List<Dataset>();

                //Adds the customized BarDataset to the list
                barChartData.Datasets.Add(barDataset);

                //Assings the List<Dataset> to the data porperty of our chart object
                salesBarChart.Data = barChartData;

                //Create and customize formatting options to be used with our chart
                var options = new Options
                {
                    Responsive = true,
                    MaintainAspectRatio = false
                };

                //Stores the completed chart in the ViewData
                ViewData["BarChart"] = salesBarChart;
            #endregion
            #endregion

            #region Top SalesPerson Pie Chart
            #region Collect Totals by Month and sales person
            //Totals the sales by Year and sales person, saves as a list
            List<decimal?> monthlyTotalSalesPerson = salesData
                .GroupBy(sale => new {sale.Salesperson})
            .Select(group => group.Sum(sale => sale.SaleTotal))
                .ToList();

            //Converts list to doubles for use in ChartJS

            List<double?> monthlySalesPersonAsDoubles = monthlyTotalSalesPerson.ConvertAll(s => (double?)s);

            #endregion

            #region Collect Names for Labels
            List<string> salesNames = salesData
                    .Select(sale => sale.Salesperson.FullName)
                    .Distinct()
                    .ToList();
            #endregion

            #region PieChart creation
            //Create the chart object
            Chart salesPieChart = new Chart();

            //Define the chart type
            salesPieChart.Type = Enums.ChartType.Pie;

            //Create the chart data object
            ChartJSCore.Models.Data pieChartData = new ChartJSCore.Models.Data();

            //Assign lables
            pieChartData.Labels = salesNames;

            //Create dataset object
            PieDataset pieDataset = new PieDataset()
            {
                Label = $"Total Sales",
                BackgroundColor = new List<ChartColor>()
                {
                    ChartColor.FromHexString("#C0C0C0"),
                    ChartColor.FromHexString("#2F539B"),
                    ChartColor.FromHexString("#0909FF"),
                    ChartColor.FromHexString("#006A4E"),
                    ChartColor.FromHexString("#00FF00"),
                    ChartColor.FromHexString("#FFFF00"),
                    ChartColor.FromHexString("#EB5406"),
                    ChartColor.FromHexString("#FD1C03"),
                    ChartColor.FromHexString("#FF00FF")
                },
                HoverBackgroundColor = new List<ChartColor>()
                {
                    ChartColor.FromHexString("#C0C0C0"),
                    ChartColor.FromHexString("#2F539B"),
                    ChartColor.FromHexString("#0909FF"),
                    ChartColor.FromHexString("#006A4E"),
                    ChartColor.FromHexString("#00FF00"),
                    ChartColor.FromHexString("#FFFF00"),
                    ChartColor.FromHexString("#EB5406"),
                    ChartColor.FromHexString("#FD1C03"),
                    ChartColor.FromHexString("#FF00FF")
                },
                Data = monthlySalesPersonAsDoubles

            };
            #endregion
            #region Packaging and passing to the view
            //Create a List<Dataset> to store our Chart data
            pieChartData.Datasets = new List<Dataset>();

            //Adds the customized PieDataset to the list
            pieChartData.Datasets.Add(pieDataset);

            //Assings the List<Dataset> to the data porperty of our chart object
            salesPieChart.Data = pieChartData;

            //Stores the completed chart in the ViewData
            ViewData["PieChart"] = salesPieChart;

            #endregion
            #endregion

            #region Total Sales By Customer
            //All time sales by customer
            var totalCustSales = totalSalesData
                .GroupBy(sale => new {sale.Customer.CustomerName})
                .Select(group => new {group.Key.CustomerName, TotalSales = group.Sum(sale => sale.SaleTotal) })
                .OrderByDescending(t => t.TotalSales)
                .Take(10)
                .ToList();

            
            //Convert list to doubles for ChartJS
            List<double?> totalCustSalesDoubles = totalCustSales.ConvertAll(s => (double?)s.TotalSales);

            //Create list of Customer names for column lables
            List<string> custNames = totalCustSales
                .Select(sale => sale.CustomerName)
                .Distinct()
                .ToList();

            #region BarChart creation
            //Create the Chart Object
            Chart custSalesBar = new Chart();

            //Assing the chart type
            custSalesBar.Type = Enums.ChartType.Bar;

            //Create the chart data object
            ChartJSCore.Models.Data custSalesChartData = new ChartJSCore.Models.Data();

            //Assing the label 
            custSalesChartData.Labels = custNames;

            //Create the dataset object

            BarDataset custSalesDataSet = new BarDataset()
            {
                Label = "Total Sales",
                Data = totalCustSalesDoubles,
                BackgroundColor = new List<ChartColor>
                    {
                        ChartColor.FromHexString("#C04000")
                    },
                BorderColor = new List<ChartColor>
                    {
                        ChartColor.FromHexString("#C04000")
                    },
                BorderWidth = new List<int>() { 1 },
                BarPercentage = 1,
                BarThickness = 20,
                MaxBarThickness = 30,
                MinBarLength = 2
            };

            //Packaging and passing to the view

            custSalesChartData.Datasets = new List<Dataset>();

            custSalesChartData.Datasets.Add(custSalesDataSet);

            custSalesBar.Data = custSalesChartData;

            var options2 = new Options
            {
                Responsive = true,
                MaintainAspectRatio = false
            };

            ViewData["CustSalesBar"] = custSalesBar;
            #endregion
            #endregion

            #region All Customer Sales Table

            List<Customer> allCustInfo = _context.Customers
                .Include(s => s.Sales)
                .Include(s => s.Country)
                .ToList();

            ViewData["AllCustInfo"] = allCustInfo;



            #endregion


            return View();
        }
    }
}
