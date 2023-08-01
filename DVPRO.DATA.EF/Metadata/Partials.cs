using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DVPRO.DATA.EF.Models
{
    //internal class Partials
    //{
    //}

    [ModelMetadataType(typeof(CustomerMetadata))]
    public partial class Customer { }

    [ModelMetadataType(typeof(SaleMetadata))]

    public partial class Sale 
    {
        public string? SaleProdSum 
        { 
            get 
            { 
              return $"{SaleId} - {Customer.CustomerName}"; 
            } 
        }
      
        public string? SalesPersonFullName
        {
            get
            {
                if (Salesperson == null)
                {
                    return null;
                }
                else
                {
                    return string.Format($"{Salesperson.FirstName} {Salesperson.LastName}");
                }
                
            }
        }
    }

    [ModelMetadataType(typeof(SaleProductMetadata))]
    public partial class SaleProduct {
    
        
    }

    [ModelMetadataType(typeof(ProductStatusMetadata))]
    public partial class ProductStatus { }

    [ModelMetadataType(typeof(EmployeeMetadata))]
    public partial class Employee 
    { 
        public string FullName
        {
            get
            {
                return string.Format($"{FirstName} {LastName}");
            }
        }
    }

    [ModelMetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
        [NotMapped]
        public IFormFile? Image { get; set; }
    }

    [ModelMetadataType(typeof(ProductTypeMetadata))]
    public partial class ProductType { }

    [ModelMetadataType(typeof(DepartmentMetadata))]
    public partial class Department { }

    [ModelMetadataType(typeof(CountryMetadata))]
    public partial class Country { }

    [ModelMetadataType(typeof(OrderMetadata))]
    public partial class Order { }

    [ModelMetadataType(typeof(OrderProductMetadata))]
    public partial class OrderProduct { }

    [ModelMetadataType(typeof(LocationMetadata))]
    public partial class Location 
    {
        public string? Branch
        {
            get
            {
                return string.Format($"{LocationCity} Branch");
            }
        }

    }

    [ModelMetadataType(typeof(RegionMetadata))]
    public partial class Region { }

    [ModelMetadataType(typeof(VendorMetadata))]
    public partial class Vendor { }


}
