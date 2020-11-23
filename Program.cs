using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.IO;

namespace VacationBudgetPlanner
{
    class Program
    {


        static void Main(string[] args)
        {

            //Password checker
            int pwTry = 0;
            while (pwTry < 3)
            {
                Console.Write("Input a password: ");
                string password = Console.ReadLine();

                if (password == "abc@123" || password == "ABC@123")
                {
                    Console.WriteLine("Welcome!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Something went wrong.. please try again. {pwTry +1} of 3 attempts tried.");
                    pwTry++;
                    if (pwTry == 3)
                    {
                        Console.WriteLine("Max attempts tried. Program will now close.");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                }

            }

            //Currency API - Work in progress

            string getCurrencyRates = String.Format("http://data.fixer.io/api/latest?access_key=a1cb0cc0c87a0dc2f70f5e79a5897e6f&format=1");
            WebRequest requestObjectGet = WebRequest.Create(getCurrencyRates);
            requestObjectGet.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjectGet.GetResponse();

            string getCurrencyRatesStringResults = null;
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                getCurrencyRatesStringResults = sr.ReadToEnd();
                sr.Close();
            }

            const int minutesInHour = 60;
            const int minutesInDay = 1440;
            const int hoursInDay = 24;
            const int daysInWeek = 7;


            // Prints welcome message to user
            Console.WriteLine($"Welcome to the Vacation Budget Planner!");

            //Asks user for their name and saves it as a string variable
            Console.WriteLine($"Please enter your name:");
            string userName = Console.ReadLine();

            bool retryApplication = true;
            while (retryApplication)
            {
                //Welcome message and travel option 
                bool travelExit = true;
                while (travelExit)
                {
                    Console.WriteLine($"Welcome {userName}! Please enter the country you want go to? \n(1) Mexico \n(2) Jamaica");
                    int selectedCountry = Int32.Parse(Console.ReadLine());

                    switch (selectedCountry)
                    {
                        case 1:
                            travelExit = false;
                            Console.WriteLine($"Great, Mexico sounds like an amazing trip!");
                            Console.WriteLine("**********************");

                            //Asks how many days the user wants to stay then converts into hours and minutes
                            Console.WriteLine("How many days do you want to stay in Mexico?");
                            int daysToStayMexico = Int32.Parse(Console.ReadLine());
                            //Console.WriteLine(daysToStayMexico); //test

                            int hoursToStayMexico = daysToStayMexico * hoursInDay;
                            //Console.WriteLine(hoursToStayMexico); //test

                            int minutesToStayMexico = hoursToStayMexico * minutesInHour;
                            //Console.WriteLine(minutesToStayMexico); //test

                            Console.WriteLine($"You have selected to stay {daysToStayMexico} days which is {hoursToStayMexico} hours or {minutesToStayMexico} minutes.\n");

                            //Asks how much spending money they will bring
                            Console.WriteLine("How much spending money (USD) would you like to take?");
                            double usdSpendingMoneyMexico = Double.Parse(Console.ReadLine());

                            //Calculates amount user can spend per day
                            double spendingPerDayMexico = (usdSpendingMoneyMexico / daysToStayMexico);
                            Console.WriteLine($"You have budgeted to spend {spendingPerDayMexico.ToString("C")} per day.");

                            //Converts to USD to Mexican Pesos. Currently 1 : 20.37 as of 11/15/2020
                            //TODO: Find a way to create an API to fetch the current exchange rate.
                            double pesoSpendingMoney = usdSpendingMoneyMexico * 20.37;

                            //Calculates spending money per day in Mexican Pesos and displays this to the user
                            double dailyPesoSpendingMoney = pesoSpendingMoney / daysToStayMexico;
                            Console.WriteLine("The amount of Mexican Pesos you can spend per day is " + dailyPesoSpendingMoney.ToString("C") + ".\n");
                            Console.WriteLine("***********USD Breakdown***********");


                            //Informs the user how much they plan to spend in USD per day
                            Console.WriteLine($"Your spending budget is {usdSpendingMoneyMexico.ToString("C")} USD total during your stay. \nYou will be staying {daysToStayMexico} days. \nYour daily budget is {spendingPerDayMexico.ToString("C")} USD.\n");
                            Console.WriteLine("***********Mexican Peso Breakdown***********");

                            //Informs the user how much they plan to spend in Mexican Pesos per day
                            Console.WriteLine($"Your spending budget is {pesoSpendingMoney.ToString("C")} Pesos total during your stay. \nYou will be staying {daysToStayMexico} days. \nYour daily budget is {dailyPesoSpendingMoney.ToString("C")} Pesos.");
                            Console.WriteLine("**********************");
                            Console.WriteLine($"{userName} please enjoy your trip to Mexico. We hope you make many wonderful memories. \n");
                            break;

                        case 2:
                            travelExit = false;
                            Console.WriteLine($"Great, Jamaica sounds like an amazing trip!");
                            Console.WriteLine("**********************");

                            //Asks how many days the user wants to stay then converts into hours and minutes
                            Console.WriteLine("How many days do you want to stay in Jamaica?");
                            int daysToStayJamaica = Int32.Parse(Console.ReadLine());
                            //Console.WriteLine(daysToStayJamaica); //test

                            int hoursToStayJamaica = daysToStayJamaica * hoursInDay;
                            //Console.WriteLine(hoursToStayJamaica; //test

                            int minutesToStayJamaica = hoursToStayJamaica * minutesInHour;
                            //Console.WriteLine(minutesToStayJamaica); //test

                            Console.WriteLine($"You have selected to stay {daysToStayJamaica} days which is {hoursToStayJamaica} hours or {minutesToStayJamaica} minutes.\n");

                            //Asks how much spending money they will bring
                            Console.WriteLine("How much spending money (USD) would you like to take?");
                            double usdSpendingMoneyJamaica = Double.Parse(Console.ReadLine());

                            //Calculates amount of USD user can spend per day
                            double usdSpendingPerDayJamaica = (usdSpendingMoneyJamaica / daysToStayJamaica);
                            Console.WriteLine($"You have budgeted to spend is {usdSpendingPerDayJamaica.ToString("C")} USD per day.");

                            //Converts to USD to Jamaican dollar. Currently 1 : 148.14 as of 11/15/2020
                            //TODO: Find a way to create an API to fetch the current exchange rate.
                            double jamaicanSpendingMoney = usdSpendingMoneyJamaica * 148.14;

                            //Calculates spending money per day in Jamaican dollars and displays this to the user
                            double dailyJamaicanSpendingMoney = jamaicanSpendingMoney / daysToStayJamaica;
                            Console.WriteLine("The amount of Jamaican dollars you can spend per day is " + dailyJamaicanSpendingMoney.ToString("C") + ".\n");
                            Console.WriteLine("***********USD Breakdown***********");

                            //Informs the user how much they plan to spend in USD per day
                            Console.WriteLine($"Your spending budget is {usdSpendingMoneyJamaica.ToString("C")} USD total during your stay. \nYou will be staying {daysToStayJamaica} days. \nYour daily budget is {usdSpendingPerDayJamaica.ToString("C")} USD.\n");
                            Console.WriteLine("***********Jamaican Dollar Breakdown***********");

                            //Informs the user how much they plan to spend in Jamaican dollars per day
                            Console.WriteLine($"Your spending budget is {jamaicanSpendingMoney.ToString("C")} Jamaican dollars total during your stay. \nYou will be staying {daysToStayJamaica} days. \nYour daily budget is {dailyJamaicanSpendingMoney.ToString("C")} Jamaican dollars.");
                            Console.WriteLine("**********************");
                            Console.WriteLine($"{userName} please enjoy your trip to Jamaica. We hope you make many wonderful memories. \n");
                            break;

                        default:
                            travelExit = true;
                            Console.WriteLine("You did not select a valid option. Please select 1 or 2 and try again.");
                            break;
                    }
                    if (!travelExit)
                        try
                        {
                            Console.WriteLine("Would you like to go through the vacation planner again? \n(1) Yes \n(2) No");
                            int retryOption = Int16.Parse(Console.ReadLine());
                            if (retryOption.Equals(1))
                            {
                                retryApplication = true;
                            }
                            else
                            {
                                Environment.Exit(0);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                }
            }
        }
    }
}
