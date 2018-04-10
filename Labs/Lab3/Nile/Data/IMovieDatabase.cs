/*
 * Randon Hyman
 * ITSE 1430
 * Lab 3
 */
using System.Collections.Generic;

namespace Nile.Data
{
    /// <summary>Provides access to movies.</summary>
    public interface IMovieDatabase
    {
        Movie Add( Movie movie, out string message );

        IEnumerable<Movie> GetAll();

        void Remove( int id );

        Movie Update( Movie movie, out string message );                
    }
}