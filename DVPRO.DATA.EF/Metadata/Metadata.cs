using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVPRO.DATA.EF.Models
{
    //internal class Metadata
    //{
    //}


    #region Customers
    public class CustomerMetadata
    {
        //public int CustomerId { get; set; }

        [Required(ErrorMessage = "*Customer Name is required")]
        [StringLength(150, ErrorMessage = "*Max 150 Characters")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = null!;

        [Required(ErrorMessage = "*Contact Name is required")]
        [StringLength(75, ErrorMessage = "*Max 75 Characters")]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; } = null!;

        [Required(ErrorMessage = "*Contact Phone is required")]
        [StringLength(20, ErrorMessage = "*Max 20 Characters")]
        [Display(Name = "Contact Phone")]
        [DataType(DataType.PhoneNumber)]
        public string ContactPhone { get; set; } = null!;
        [Required(ErrorMessage = "*Contact Email is required")]
        [StringLength(100, ErrorMessage = "*Max 100 Characters")]
        [Display(Name = "Contact Email")]
        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; } = null!;

        [Required(ErrorMessage = "*Billing Address is required")]
        [StringLength(100, ErrorMessage = "*Max 100 Characters")]
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; } = null!;

        [Required(ErrorMessage = "*Billing City is required")]
        [StringLength(100, ErrorMessage = "*Max 100 Characters")]
        [Display(Name = "Billing City")]
        public string BillingCity { get; set; } = null!;

        
        [StringLength(2, ErrorMessage = "*Max 2 Characters")]
        [Display(Name = "Billing State")]
        
        public string? BillingState { get; set; }

        
        [StringLength(10, ErrorMessage = "*Max 10 Characters")]
        [Display(Name = "Billing Zip Code")]
        [DataType(DataType.PostalCode)]
        public string? BillingPostalCode { get; set; }
        public int CountryId { get; set; }

        
    }
    #endregion

    #region Sales
    public class SaleMetadata
    {
        //public int SaleId { get; set; }

        [Required(ErrorMessage = "*Sale Date is required")]
        [Display(Name = "Sale Date")]
        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }
        [Required(ErrorMessage = "*Sales Person ID is required")]
        [Display(Name = "Sales Person Id")]
        public int SalespersonId { get; set; }
        [Required(ErrorMessage = "*Customer ID is required")]
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Sale Total")]
        public decimal? SaleTotal { get; set; }
    }
    #endregion

    #region SaleProducts
    public class SaleProductMetadata
    {
        //public int SaleProductId { get; set; }
        [Required(ErrorMessage = "*Sale ID is required")]
        [Display(Name = "Sale ID")]
        public int SaleId { get; set; }
        [Required(ErrorMessage = "*Product ID is required")]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "*Sale Quantity is required")]
        [Display(Name = "Sale Quantity")]
        public short SaleQuantity { get; set; }
    }
    #endregion

    #region ProductStatuses

    public class ProductStatusMetadata
    {
        [Required(ErrorMessage = "*Product Status is required")]
        [StringLength(100, ErrorMessage = "*Max 100 Characters")]
        [Display(Name = "Product Status")]
        public string ProductStatusName { get; set; } = null!;
    }
    #endregion

    #region Employees
    public class EmployeeMetadata
    {


        //public int EmployeeId { get; set; }
        [Required(ErrorMessage = "*First Name is required")]
        [StringLength(25, ErrorMessage = "*Max 25 Characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "*Last Name is required")]
        [StringLength(50, ErrorMessage = "*Max 50 Characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        
        [StringLength(100, ErrorMessage = "*Max 100 Characters")]
        
        public string? Position { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }
        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }
        [Display(Name = "Termination Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(NullDisplayText = "-", DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? TerminationDate { get; set; }

        [StringLength(100, ErrorMessage = "*Max 100 Characters")]

        public string? Address { get; set; }
        [StringLength(100, ErrorMessage = "*Max 100 Characters")]
        public string? City { get; set; }
        [StringLength(2, ErrorMessage = "*Max 2 Characters")]
        public string? State { get; set; }
        [StringLength(10, ErrorMessage = "*Max 10 Characters")]
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public string? PostalCode { get; set; }
        [Display(Name = "Country ID")]
        public int? CountryId { get; set; }
        [StringLength(100, ErrorMessage = "*Max 100 Characters")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [StringLength(20, ErrorMessage = "*Max 20Characters")]
        [DataType(DataType.PhoneNumber)]
        
        public string? Phone { get; set; }
        [Required(ErrorMessage = "*Department ID is required")]   
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }

        [Display(Name = "Manager ID")]
        public int? ManagerId { get; set; }
    }
    #endregion

    #region Products
    public class ProductMetadata
    {
        //public int ProductId { get; set; }

        [Required(ErrorMessage = "*Product Name is required")]
        [StringLength(150, ErrorMessage = "*Max 150 Characters")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = null!;
        
        
        public string? Description { get; set; }

        
        [Display(Name = "Cost Per Unit")]
        [DataType(DataType.Currency)]
        public decimal? CostPerUnit { get; set; }
        [Display(Name = "Price Per Unit")]
        [DataType(DataType.Currency)]
        public decimal? PricePerUnit { get; set; }
        [StringLength(150, ErrorMessage = "*Max 50 Characters")]
        [Display(Name = "Unit Type")]
        [DisplayFormat(NullDisplayText = "-")]
        public string? UnitType { get; set; }
        [Display(Name = "Units in Stock")]
        public short? UnitsInStock { get; set; }
        [Display(Name = "Units on Order")]
        public short? UnitsOnOrder { get; set; }
        [Display(Name = "Product Status ID")]
        public int? ProductStatusId { get; set; }
        [Required(ErrorMessage = "*Product Type ID is required")]
        [Display(Name = "Product Type ID")]
        public int ProductTypeId { get; set; }
        [Display(Name = "Vendor ID")]
        public int? VendorId { get; set; }
        [StringLength(100, ErrorMessage = "*Max 100 Characters")]
        [Display(Name = "Product Image")]
        [DisplayFormat(NullDisplayText = "-")]
        public string? ProductImage { get; set; }

    }
    #endregion

    #region ProductTypes
    public class ProductTypeMetadata
    {
        //public int ProductTypeId { get; set; }

        [Required(ErrorMessage = "*Product Type is required")]
        [StringLength(150, ErrorMessage = "*Max 150 Characters")]
        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; } = null!;
    }

    #endregion

    #region Department

    public class DepartmentMetadata
    {
        //public int DepartmentId { get; set; } PK
        [Required]
        [Display(Name ="Department Name")]
        [StringLength(150, ErrorMessage="* Max 150 characters")]
        public string DepartmentName { get; set; } = null!;

        [Display(Name = "Location")]
        public int? LocationId { get; set; } 
    }

    #endregion

    #region Country

    public class CountryMetadata
    {
        //public int CountryId { get; set; }  PK
        [Required]
        [Display(Name = "Country Name")]
        [StringLength(100, ErrorMessage = "* Max 100 characters")]
        public string CountryName { get; set; } = null!;

        [Display(Name = "Region")]
        public int? RegionId { get; set; }  
    }

    #endregion

    #region Order

    public class OrderMetadata
    {
        //public int OrderId { get; set; } PK
        [StringLength(50, ErrorMessage = "* MAX 50 characters")]
        [Display(Name ="PO #")]
        public string? Ponumber { get; set; }

        [Display(Name = "Vendor")]
        public int VendorId { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]//0:d => MM/dd/yyyy
        [Display(Name = "Order Date")]
        [Required]
        public DateTime OrderDate { get; set; }

        [Display(Name ="Order Total")]
        [DisplayFormat(ApplyFormatInEditMode = false, NullDisplayText = "-", DataFormatString = "{0:c}")]
        [Range(0, (double)decimal.MaxValue)]
        public decimal? OrderTotal { get; set; }
    }

    #endregion

    #region OrderProduct

    public class OrderProductMetadata
    {
        //public int OrderProductId { get; set; }  PK
        [Display(Name = "Order")]
        public int OrderId { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; } 

        [Display(Name ="Order Quantity")]
        [Range(0, (double)short.MaxValue)]
        [Required]
        public short OrderQuantity { get; set; }
    }

    #endregion

    #region Location

    public class LocationMetadata
    {
        //public int LocationId { get; set; }  PK
        [Display(Name = "Address")]
        [StringLength(100, ErrorMessage = "* Max 100 characters")]
        [Required]
        public string LocationAddress { get; set; } = null!;

        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "* Max 100 characters")]
        [Required]
        public string LocationCity { get; set; } = null!;

        [Display(Name = "State")]
        [StringLength(2, ErrorMessage = "* Max 2 characters")]
        [DisplayFormat(NullDisplayText = "-")]
        public string? LocationState { get; set; }

        [Display(Name = "Zip Code")]
        [StringLength(10, ErrorMessage = "* Max 10 characters")]
        [DataType(DataType.PostalCode)]
        [DisplayFormat(NullDisplayText = "-")]
        public string? LocationPostalCode { get; set; }

        [Display(Name = "Country")]
        public int? CountryId { get; set; } 
    }

    #endregion

    #region Region

    public class RegionMetadata
    {
        // public int RegionId { get; set; }  PK

        [Display(Name = "Region Name")]
        [StringLength(100, ErrorMessage = "* Max 100 characters")]
        [Required]
        public string RegionName { get; set; } = null!;
    }

    #endregion

    #region Vendor

    public class VendorMetadata
    {
        //public int VendorId { get; set; }  PK
        [Display(Name ="Vendor Name")]
        [StringLength(150, ErrorMessage ="* Max 150 characters")]
        [Required]
        public string VendorName { get; set; } = null!;

        [Display(Name = "Vendor Contact")]
        [StringLength(75, ErrorMessage = "* Max 75 characters")]
        [Required]
        public string VendorContact { get; set; } = null!;

        [Display(Name = "Vendor Phone")]
        [StringLength(20, ErrorMessage = "* Max 20 characters")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string VendorPhone { get; set; } = null!;

        [Display(Name = "Vendor Email")]
        [StringLength(100, ErrorMessage = "* Max 100 characters")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string VendorEmail { get; set; } = null!;

        [Display(Name = "Vendor Address")]
        [StringLength(100, ErrorMessage = "* Max 100 characters")]
        [Required]
        public string VendorAddress { get; set; } = null!;

        [Display(Name = "Vendor City")]
        [StringLength(100, ErrorMessage = "* Max 100 characters")]
        [Required]
        public string VendorCity { get; set; } = null!;

        [Display(Name = "Vendor State")]
        [StringLength(2, ErrorMessage = "* Max 2 characters")]
        [DisplayFormat(NullDisplayText = "-")]
        public string? VendorState { get; set; }

        [Display(Name = "Vendor Zip Code")]
        [StringLength(10, ErrorMessage = "* Max 10 characters")]
        [DataType(DataType.PostalCode)]
        [DisplayFormat(NullDisplayText = "-")]
        public string? VendorPostalCode { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }  
    }

    #endregion
}
