/*
 * Randon Hyman
 * ITSE 1430
 * Lab 3
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Data
{
    /// <summary>Provides extension methods for <see cref="IMovieDatabase"/>.</summary>
    public static class MovieDatabaseExtensions
    {
        public static void Seed ( this IMovieDatabase source )
        {
            var message = "";
            source.Add(new Movie() {
                Name = "Scarface",
                IsDiscontinued = true,
                Length = 1500, }, out message);
            source.Add(new Movie() {
                Name = "Deadpool",
                IsDiscontinued = true,
                Length = 15, }, out message);
            source.Add(new Movie() {
                Name = "Seven",
                IsDiscontinued = false,
                Length = 800
            }, out message);
        }
    }
}
