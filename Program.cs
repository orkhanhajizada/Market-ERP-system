﻿using System;
using MarketERP.Services;

namespace MarketERP
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }


        public static void MainMenu()
        {
            int selection = 0;

            do
            {
                Console.WriteLine("1. Məhsullar");
                Console.WriteLine("2. Satışlar");
                Console.WriteLine("3. Çıxış");

                Console.WriteLine("Please select your option");

                string selectionStr = Console.ReadLine();
                selection = int.Parse(selectionStr);


                switch (selection)
                {
                    case 1:
                        MenuServices.DisplayProductSubMenu();
                        break;
                    case 2:
                        MenuServices.DisplaySaleSubMenu();
                        break;
                    case 3:
                        Console.WriteLine("Good bye");
                        break;
                    default:
                        break;
                }

            } while (selection != 3);
        }
    }
}