/*
 * ITSE 1430
 */
using System.Collections.Generic;

namespace Nile.Data
{
    /// <summary>Provides access to products.</summary>
    public interface IProductDatabase
    {

        Product Add( Product product, out string message );

        IEnumerable<Product> GetAll();

        void Remove( int id );

        Product Update( Product product, out string message );                
    }
}