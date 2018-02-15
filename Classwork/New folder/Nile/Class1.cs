using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
  
    /// <summary>Procides information about a product.</summary>

    public class Product
    {
        internal decimal DiscountPercentage = 0.10M;
        /// <summary>Get the product name.</summary>
        /// <returns>The name.</returns>

            public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        //Using auto property here
        public decimal Price
        {
            //get { return _price; }
            // set { _price = value; }
            get; set;
        }

      //  public int ShowingOffAccessibility
        {
            
            internal set { }
        }
        public decimal ActualPrice
        {
            get {
                if (IsDiscontinued)
                    return (Price * DiscountPercentage);
                return Price;
            }
            //set { }
        }
        public bool IsDiscontinued
        {
            get { return _isDiscontinued; }
            set { _isDiscontinued = value; }
        }
        // public string GetName()
        //  {
        //     return _name ?? "";
        // }

        /// <summary>Sets the product name,</summary>
        /// <param name="value">The name.</param>
        public void SetName(string value) 
        {
            _name = value ?? "";
        }
        /// <summary>Validates the product.</summary>
        /// <returns>Error message, if any.</returns>
            public string Validate()
        {

            if (String.IsNullOrEmpty(_name))
                return "Name cannot be empty";

        //    if (_price < 0)
                return "Price must be >= 0";
            return "";
        }
        
        
        private string _name = " ";
        private string _description;
        //private decimal _price;
        private bool _isDiscontinued;
    }
}
