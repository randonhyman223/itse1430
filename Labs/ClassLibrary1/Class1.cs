using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
       static void Main( string[] args )
        {
            bool quit = false;
            do
            {
                char choice = GetInput();

                switch (choice)
                {
                    case 'L':
                    ListMovies();
                    break;
                    case 'A':
                    AddMovie();
                    break;
                    case 'R':
                    RemoveMovie();
                    break;
                    case 'Q':
                    quit = true;
                    break;
                }
            } while (!quit);
        }

        private static void AddMovie()
        {
            Console.Write("Enter movie name: ");
            movieName = Console.ReadLine().Trim();

            //Ensure not empty

            Console.Write("Enter movie description: ");
            movieDescription = Console.ReadLine().Trim();

            Console.Write("Enter movie length (> 0): ");
            movieLength = ReadDecimal();

            Console.Write("Enter Y/N if movie is owned: ");
            if (ReadYesNo() == true)
            {
                movieOwned = "Owned";
            } else
                movieOwned = "Don't Own";
        }

        private static void ListMovies()
        {
            if (!String.IsNullOrEmpty(movieName))
            {
                string msg = $"{movieName}\n{movieDescription}\nMovie Length = { movieLength} mins\nStatus = {movieOwned}\n";

                Console.WriteLine(msg);
            } else
                Console.WriteLine("No Movies Available");
        }

        static char GetInput()
        {
            while (true)
            {
                Console.WriteLine("".PadLeft(10), '-');
                Console.WriteLine("L)ist Movies");
                Console.WriteLine("A)dd Movies");
                Console.WriteLine("R)emove Movie");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();

                if (input != null && input.Length != 0)
                {

                    var letter = Char.ToUpper(input[0]);
                    if (letter == 'L')
                        return 'L';
                    else if (letter == 'A')
                        return 'A';
                    else if (letter == 'R')
                        return 'R';
                    else if (letter == 'Q')
                        return 'Q';
                }
                //Error
                Console.WriteLine("Please choose a valid option");
            }
        }
        static decimal ReadDecimal()
        {
            do
            {
                var input = Console.ReadLine();

                if (Decimal.TryParse(input, out decimal result))
                    return result;

                Console.WriteLine("Enter a valid length in mins");
            } while (true);
        }

        static bool ReadYesNo()
        {
            do
            {
                var input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    switch (Char.ToUpper(input[0]))
                    {
                        case 'Y':
                        return true;
                        case 'N':
                        return false;
                    }
                }

                Console.WriteLine("Enter either Y or N");

            } while (true);
        }

        static void RemoveMovie()
        {
            Console.WriteLine("Are you sure you want to delete the movie (Y/N)?");

            string input = Console.ReadLine();

            var letter = Char.ToUpper(input[0]);
            if (letter == 'Y')
            {
                movieName = null;
                movieLength = 0;
                movieDescription = null;
                movieOwned = null;
            }
        }

        static string movieName;
        static decimal movieLength;
        static string movieDescription;
        static string movieOwned;
    }
}
    

