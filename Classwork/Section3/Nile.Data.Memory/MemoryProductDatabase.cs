using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Data.Memory
{
    /// <summary>Provides an in-memory product database.</summary>
    public class MemoryProductDatabase
    {
        public MemoryProductDatabase()
        {
            _products = new Product[25];

            var product = new Product();
            product.Id = _nextId++;
            product.Name = "iPhone X";
            product.IsDiscontinued = false;
            product.Price = 1500;
            _products[0] = product;

            product = new Product();
            product.Id = _nextId++;
            product.Name = "Windows Phone";
            product.IsDiscontinued = true;
            product.Price = 15;
            _products[1] = product;

            product = new Product();
            product.Id = _nextId++;
            product.Name = "Samsung S8";
            product.IsDiscontinued = false;
            product.Price = 800;
            _products[2] = product;
        }

        public Product Add ( Product product, out string message )
        {
            // Check for null
            if (product == null)
            {
                message = "Product cannot be null.";
                return null;
            };

            // Validate product
            var error = product.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                message = error;
                return null;
            };

            // TODO: Verify unique product

            // Add
            var index = FindEmptyProductIndex();
            if (index < 0)
            {
                message = "Out of memory";
                return null;
            };

            // Clone the object
            product.Id = _nextId++;
            _products[index] = Clone(product);
            message = null;
            
            // Return a copy
            return product;
        }

        public Product Edit ( Product product, out string message )
        {
            //Check for null
            if (product == null)
            {
                message = "Not Working";
                return null;
            }
            //Validate product
            var error = product.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                message = error;
                return null;
            };

            //TODO: Verify unique product except current product

            //Find existing
            var existingIndex = GetById(product.Id);
            if (existingIndex < 0)
            {
                message = "Product not found.";
                return null;
            };

            // Clone the product
            _products[existingIndex] = Clone(product);
            message = null;

            // Return a copy
            return product;
        }

        public Product[] GetAll ()
        {
            //Returna copy so caller cannot change the underlying data
            var items = new Product[_products.Length];
            for (var index = 0; index < _products.Length; ++index)
            {
                if (_products[index] != null)
                    items[index] = Clone(_products[index]);
            }
            return items;
        }

        public void Remove ( int id )
        {
            if (id > 0)
            {
                var index = GetById(id);
                if (index >= 0)
                    _products[index] = null;
            };
        }

        private int FindEmptyProductIndex()
        {
            for (var index = 0; index < _products.Length; ++index)
            {
                if (_products[index] == null)
                    return index;
            };

            return -1;
        }
        private Product Clone ( Product item )
        {
            var newProduct = new Product();
            newProduct.Id = item.Id;
            newProduct.Name = item.Name;
            newProduct.Description = item.Description;
            newProduct.Price = item.Price;
            newProduct.IsDiscontinued = item.IsDiscontinued;

            return newProduct;
        }
        private int GetById ( int id )
        {
            for (var index = 0; index < _products.Length; ++index)
            {
                if (_products[index]?.Id == id)
                    return index;
            };

            return -1;
        }

        private Product[] _products;
        private int _nextId = 1;
    }
}
