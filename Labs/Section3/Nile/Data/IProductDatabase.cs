/*
 * ITSE 1430
 */
using System.Collections.Generic;

namespace Nile.Data
{
    /// <summary>Provides access to products.</summary>
    public interface IProductDatabase
    {
        Product Add( Product movie, out string message );

        IEnumerable<Product> GetAll();

        void Remove( int id );

        Product Update( Product movie, out string message );                
    }
}