/*
 * Randon Hyman
 * ITSE 1430
 * Lab 3
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nile.Data.Memory
{
    /// <summary>Provides an in-memory product database.</summary>
    public class MemoryProductDatabase : MovieDatabase
    {
        protected override Movie AddCore ( Movie product )
        {
            // Clone the object
            product.Id = _nextId++;
            _products.Add(Clone(product));

            // Return a copy
            return product;
        }

        protected override Movie GetCore( int id )
        {
            //for (var index = 0; index < _products.Length; ++index)
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;
            };

            return null;
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            //Iterator syntax
            foreach (var product in _products)
            {
                if (product != null)
                    yield return Clone(product);
            };
        }
        
        protected override void RemoveCore ( int id )
        {
            var existing = GetCore(id);
            if (existing != null)
                _products.Remove(existing);
        }

        protected override Movie UpdateCore ( Movie product )
        {
            var existing = GetCore(product.Id);

            // Clone the object
            Copy(existing, product);

            //Return a copy
            return product;
        }

        protected override Movie GetMovieByNameCore( string name )
        {
            foreach (var product in _products)
            {
                //product.Name.CompareTo
                if (String.Compare(product.Name, name, true) == 0)
                    return product;
            };

            return null;
        }

        #region Private Members

        //Clone a product
        private Movie Clone ( Movie item )
        {
            var newProduct = new Movie();
            Copy(newProduct, item);

            return newProduct;
        }

        //Copy a product from one object to another
        private void Copy ( Movie target, Movie source )
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Length = source.Length;
            target.IsDiscontinued = source.IsDiscontinued;
        }

        //Find a product by its ID               
        private readonly List<Movie> _products = new List<Movie>();
        private int _nextId = 1;

        #endregion
    }
}
