/*
 * Randon Hyman
 * ITSE 1430
 * Lab 3
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nile.Data
{
    public abstract class MovieDatabase : IMovieDatabase
    {        
        public Movie Add ( Movie movie, out string message )
        {
            //Check for null
            if (movie == null)
            {
                message = "Movie cannot be null.";
                return null;
            };

            //Validate movie using IValidatableObject
            var errors = movie.Validate();
            
            var error = errors.FirstOrDefault();
            if (error != null)
            {
                message = error.ErrorMessage;
                return null;
            };

            // Verify unique movie
            var existing = GetMovieByNameCore(movie.Name);
            if (existing != null)
            {
                message = "Movie already exists.";
                return null;
            };

            message = null;
            return AddCore(movie);
        }
        public IEnumerable<Movie> GetAll ()
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

        public Movie Update ( Movie movie, out string message )
        {
            message = "";

            //Check for null
            if (movie == null)
            {
                message = "Movie cannot be null.";
                return null;
            };

            //Validate movie using IValidatableObject
            var errors = ObjectValidator.Validate(movie);
            if (errors.Count() > 0)
            {
                //Get first error
                message = errors.ElementAt(0).ErrorMessage;
                return null;
            };

            // Verify unique movie
            var existing = GetMovieByNameCore(movie.Name);
            if (existing != null && existing.Id != movie.Id)
            {
                message = "Movie already exists.";
                return null;
            };

            //Find existing
            existing = existing ?? GetCore(movie.Id);
            if (existing == null)
            {
                message = "Movie not found.";
                return null;
            };

            return UpdateCore(movie);
        }

        protected abstract Movie AddCore( Movie movie );
        protected abstract IEnumerable<Movie> GetAllCore();
        protected abstract Movie GetCore( int id );
        protected abstract void RemoveCore( int id );
        protected abstract Movie UpdateCore( Movie product );
        protected abstract Movie GetMovieByNameCore( string name );
    }
}
