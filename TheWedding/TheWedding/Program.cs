using System;
using TheWedding.Models;

namespace TheWedding
{

    class Program
    {
        static void Main(string[] args)
        {
            MarriedPerson bride;
            MarriedPerson groom;
            CreateMarriedCouple(out bride, out groom);

            Godparent godmother;
            Godparent godfather;
            CreateGodparents(out godmother, out godfather);

            Guest[] guests = CreateGuests();

            Wedding wedding = new Wedding(bride, groom, godmother, godfather, guests);

            DisplayWhetherTheWeddingWasSuccessfulOrNot(wedding);
                       
            Console.ReadKey();
        }

        private static void DisplayWhetherTheWeddingWasSuccessfulOrNot(Wedding wedding)
        {
            if (wedding.isSuccessful())
            {
                Console.WriteLine("Congratulations! The wedding was successful.");
            }
            else
            {
                Console.WriteLine("The wedding was not successful.");
            }
        }

        private static Guest[] CreateGuests()
        {
            int numberOfGuests = GetNumberOfGuests();

            Guest[] guests = new Guest[numberOfGuests];

            for (int i = 0; i < guests.Length; i++)
            {
                int index = i;
                guests[i] = CreateGuest(index);
            }

            return guests;
        }

        private static int GetNumberOfGuests()
        {
            Console.Write("Please enter the number of guests: ");
            int numberOfGuests;
            while (!int.TryParse(Console.ReadLine(), out numberOfGuests))
            {
                Console.WriteLine();
                Console.Write("Please enter the number of guests: ");
            }

            Console.WriteLine();

            return numberOfGuests;
        }

        private static Guest CreateGuest(int index)
        {
            Console.WriteLine($"Guest {index + 1}");

            Console.Write("Please enter the first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter the last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter the amount of monetary gift: ");
            int monetaryGift;
            while (!int.TryParse(Console.ReadLine(), out monetaryGift))
            {
                Console.WriteLine();
                Console.Write("Please enter the amount of monetary gift: ");
            }
            Console.WriteLine();

            Guest guest = new Guest(firstName, lastName, monetaryGift);
             
            return guest;
        }

        private static void CreateGodparents(out Godparent godmother, out Godparent godfather)
        {
            godmother = CreateAGodparent(true);
            godfather = CreateAGodparent(false);
            return;
        }

        private static Godparent CreateAGodparent(bool isGodmother)
        {
            string godmotherOrGodfather = isGodmother ? "Godmother:" : "Godfather:";
            Console.WriteLine($"{godmotherOrGodfather}");

            Console.Write("Please enter the first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter the last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter the amount of monetary gift(common sum): ");
            int monetaryGift;
            while (!int.TryParse(Console.ReadLine(), out monetaryGift))
            {
                Console.WriteLine();
                Console.Write("Please enter the amount of monetary gift: ");
            }
            Console.WriteLine();

            Godparent godparent = new Godparent(firstName, lastName, monetaryGift); 

            return godparent;
        }

        private static void CreateMarriedCouple(out MarriedPerson bride, out MarriedPerson groom)
        {
            bride = CreateAMarriedPerson(true);
            groom = CreateAMarriedPerson(false);
            return;
        }

        private static MarriedPerson CreateAMarriedPerson(bool isBride)
        {
            string brideOrGroom = isBride ? "Bride:" : "Groom:";

            Console.WriteLine($"{brideOrGroom}");

            Console.Write("Please enter the first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter the last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter the expected amount from godparents: ");
            int expectedAmountFromGodparents;
            while (!int.TryParse(Console.ReadLine(), out expectedAmountFromGodparents))
            {
                Console.WriteLine();
                Console.Write("Please enter the expected amount from godparents: ");
            }
            Console.WriteLine();

            Console.Write("Please enter the expected amount from guests: ");
            int expectedAmountFromGuests;
            while (!int.TryParse(Console.ReadLine(), out expectedAmountFromGuests))
            {
                Console.WriteLine();
                Console.Write("Please enter the expected amount from guests: ");
            }
            Console.WriteLine();

            MarriedPerson marriedPerson = new MarriedPerson(firstName, lastName, expectedAmountFromGodparents, expectedAmountFromGuests);
            
            return marriedPerson;
        }
}   }
