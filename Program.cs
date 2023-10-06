//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
////[1,1,1,2,2,3]

using System;
using System.IO;
using Logic;

namespace FileManager1
{
    class Program
    {


        static void Main(string[] args)
        {
            FileManager test = new FileManager();
            Console.WriteLine("Текущая директория: " + FileManager.currentDirectory);

            while (true)
            {
                FileManager.PrintMenu();

                int choice = int.Parse(Console.ReadLine());
                FileManager.GoToChoise(choice);
            }
        }


    } 
}