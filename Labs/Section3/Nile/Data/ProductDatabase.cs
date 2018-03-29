/*
 * ITSE1430  
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nile.Data
{
    public abstract class ProductDatabase : IProductDatabase
    {        
        public Product Add ( Product product, out string message )
        {
            //Check for null
            if (product == null)
            {
                message = "Product cannot be null.";
                return null;
            };

            //Validate product using IValidatableObject
            var errors = product.Validate();
            
            var error = errors.FirstOrDefault();
            if (error != null)
            {
                message = error.ErrorMessage;
                return null;
            };

            // Verify unique product
            var existing = GetProductByNameCore(product.Name);
            if (existing != null)
            {
                message = "Product already exists.";
                return null;
            };

            message = null;
            return AddCore(product);
        }
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }        
        public void Remove ( int id )
        {
            //TODO: Return an error if id <= 0

            if (id > 0)
            {
                RemoveCore(id);
            };
        }

        public Product Update ( Product product, out string message )
        {
            message = "";

            //Check for null
            if (product == null)
            {
                message = "Movie cannot be null.";
                return null;
            };

            //Validate product using IValidatableObject
            var errors = ObjectValidator.Validate(product);
            if (errors.Count() > 0)
            {
                //Get first error
                message = errors.ElementAt(0).ErrorMessage;
                return null;
            };

            // Verify unique product
            var existing = GetProductByNameCore(product.Name);
            if (existing != null && existing.Id != product.Id)
            {
                message = "Movie already exists.";
                return null;
            };

            //Find existing
            existing = existing ?? GetCore(product.Id);
            if (existing == null)
            {
                message = "Movie not found.";
                return null;
            };

            return UpdateCore(product);
        }

        protected abstract Product AddCore( Product product );
        protected abstract IEnumerable<Product> GetAllCore();
        protected abstract Product GetCore( int id );
        protected abstract void RemoveCore( int id );
        protected abstract Product UpdateCore( Product product );
        protected abstract Product GetProductByNameCore( string name );
    }
}
