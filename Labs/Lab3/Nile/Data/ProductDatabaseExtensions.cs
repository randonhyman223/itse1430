﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Data
{
    public static class ProductDatabaseExtensions
    {
        public static void Seed ( this IProductDatabase source )
        {
            var message = "";
            source.Add(new Product() {
                Name = "Scarface",
                IsDiscontinued = true,
                Price = 180, }, out message);
            source.Add(new Product() {
                Name = "Goodfellas",
                IsDiscontinued = true,
                Price = 120, }, out message);
            source.Add(new Product() {
                Name = "Deadpool",
                IsDiscontinued = false,
                Price = 120
            }, out message);
        }
    }
}