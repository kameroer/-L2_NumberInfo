﻿using System;
using System.Collections.Generic;
///-----------------------------------------------------------------------------
///   Namespace:    L2_NumberInfo
///   Description:  Input a number to get some information about it
///   Author:       Derek Wolters                
///   Date:         3.28.17
///   Revision History:
///   Name:           Date:        Description:
///-----------------------------------------------------------------------------

namespace L2_NumberInfo
{
    class L2_NumberInfo
    {
        static void Main(string[] args)
        {
            //initialize variables
            int num = 0;
            string name = "";
            string reply = "";
            bool keepGoing = true;
            List<string> outputs = new List<string> { };

            Console.WriteLine("This program will give information based on a " +
                "provided number");

            //get user's name
            name = getName();

            while (keepGoing)
            {
                //get user input
                num = getInput(outputs);

                //calculate information
                reply = getNumInfo(num, name, outputs);

                //display information
                Console.WriteLine(reply);

                //exit program               
                if (exitProgram()) break;
            }
        }

        //get the user's name
        static string getName()
        {
            string name = "";

            Console.WriteLine("What is your first name?");
            name = Console.ReadLine();
            Console.WriteLine("Hello " + name + ". It's nice to meet you!");

            return name;
        }

        //get the user's number
        static int getInput(List<string> list)
        {
            string input = "";
            int temp;
            
            Console.WriteLine("Enter a number between 1 and 100 or type " +
                                "print to see a list of the previous entries:");
            input = Console.ReadLine();

            if (input.Contains("print"))
            {
                foreach (string entry in list)
                {
                    Console.WriteLine(entry);               
                }
                return getInput(list);
            }
            else if (!int.TryParse(input, out temp))
            {
                //check that input is an integer & ask for reentry if not
                Console.WriteLine("Input should be a whole number. " +
                    "Try again.");
                return getInput(list);
            }
            else if (temp > 100 || temp < 1)
            {
                //check that input is withing range & ask for reentry if not
                Console.WriteLine("Input should be greater than 1 or less " +
                     " than 100. Try again.");
                return getInput(list);
            }
            else { return temp; }          
            
        }

        //find info based on the user's input
        static String getNumInfo(int num, string name, List<string> outputs)
        {
            string result = "";

            if (num % 2 != 0)
            {
                result = name + ", " + num + " is an odd number.";

            }
            else if (num <= 25 && num >= 2)
            {
                result = name + ", " + num + " is even and less than 25.";
            }
            else if (num % 2 == 0 && num <= 60 && num >= 25)
            {
                result = name + ", " + num + " is an even number.";
            }
            else if (num % 2 == 0 && num > 60)
            {
                result = name + ", " + num + " is an even number.";
            }
            else if (num % 2 != 0 && num > 60)
            {
                result = name + ", " + num + " is an odd number."; 
            }
            outputs.Add(result);
            return result;
        }
        
        //exit the program when the user wants to
        static Boolean exitProgram()
        {
            string xitChoice = "";

            Console.WriteLine("Do you want to continue? Enter Y or N.");

            xitChoice = Console.ReadLine().ToUpper();

            while (xitChoice != "N" && xitChoice != "Y")
            {
                Console.WriteLine("Not a vaid answer. Do you want to " +
                    "continue? Enter Y or N.");
                xitChoice = Console.ReadLine().ToUpper();
            }

            return xitChoice == "N" ? true : false;
        }
    }
}
