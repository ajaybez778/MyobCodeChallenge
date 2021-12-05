using System;
using System.Linq;

namespace MyobCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare varibles to get user name
            string userName = null;

            //Declare varibles to get user salary
            double userSalary;

            //Declare varibles to get user Gross Monthly Income
            double grossMonthlyIncome;

            //Declare varibles to get user Monthly Income Tax
            double monthlyIncomeTax;

            //Declare varibles to get user Net Monthly Income
            double netMonthlyIncome;

            // Display title
            Console.WriteLine("Myob Code Challenge \r");
            Console.WriteLine("------------------------\n");

            // Ask the user to enter the name and salary.
            Console.WriteLine("Please enter your Name and Salary: ");

            //Read User Input
            string userInput = Console.ReadLine();

            //Get the user salary by user input 
            userSalary = GetSalary(userInput);

            //Get the user name by user input
            userName = GetName(userSalary.ToString(), userInput);

            //Get user Gross Monthly Income
            grossMonthlyIncome = GetGrossMonthlyIncome(userSalary);

            // get user Monthly Income Tax
            monthlyIncomeTax = GetMonthlyIncomeTax(userSalary);

            //Get user Net Monthly Income
            netMonthlyIncome = GetNetMonthlyIncome(grossMonthlyIncome, monthlyIncomeTax);

            //Output User Salary Information
            Console.WriteLine("Monthly Payslip for: "+ userName);

            Console.WriteLine("Gross Monthly Income: " + "$" + grossMonthlyIncome.ToString());

            Console.WriteLine("Monthly Income Tax: " + "$" + monthlyIncomeTax.ToString());

            Console.WriteLine("Net Monthly Income: " + "$" + netMonthlyIncome.ToString());
        }

        //Function to get Salary
        private static double GetSalary(string input)
        {
            try
            {
                //Declare a double varible to validate User entered data.
                double validateDouble;

                // Declare empty value to return user Salary
                double salary;

                //Get Numbers from User Input
                salary = double.Parse(input.Where(x => Char.IsDigit(x)).ToArray());

                //Remove an leading zeros from user salary
                string removeLeadingZeros = salary.ToString().TrimStart('0');

                //Convert to Double
                salary = double.Parse(removeLeadingZeros);

                //Check if salary less than Zero
                if(salary < 0)
                {
                    Console.WriteLine("Salary Cannot be less than Zero");
                    Console.WriteLine("Please try again");
                    Environment.Exit(0);
                }

                //Return Salary
                return salary;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not a Valid Input, Please try again!");
                Console.WriteLine("GenerateMonthlyPayslip " + "\"Mary Song\"" + "60000");
                return 0;
            }
        }

        //Function to get UserName
        private static string GetName(string salary, string input)
        {
            try
            {
                //Remove generateMonthlyPaysLip from user Input
                string checkString = "GenerateMonthlyPayslip";

                string name = input.Replace(salary, "");

                //Get First word from Input
                String[] arr = name.Split(" ", 2);

                //if First word is GenerateMonthlyPayslip Replace it with empty string
                if (checkString.ToLower() == arr[0].ToLower())
                {
                    name = name.Replace(checkString, "");
                }

                //Return User Name
                return name.Trim('0');
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not a Valid Input, Please try again!");
                Console.WriteLine("GenerateMonthlyPayslip " + "\"Mary Song\"" + "60000");
                return null;
            }
        }

        //Function to Calculate Gross Monthly Income
        private static double GetGrossMonthlyIncome(double salary)
        {
            try
            {
                //Calculate and string String
                salary = salary / 12;
                return salary;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Calculating Gross Monthly Income");
                return 0;
            }
        }

        //Function to Calculate Gross Monthly Income
        private static double GetMonthlyIncomeTax(double salary)
        {
            try
            {
                //Declare empty value and return after calculation
                double monthlyIncome = 0;

                // if salary less than 20000
                if(salary <= 20000)
                {
                    monthlyIncome = salary * 0;
                }
                //if salary is less than 40001 and greater than 20000
                else if(salary >= 20001 && salary <= 40000)
                {
                    monthlyIncome = ((salary - 20000) * 0.1) / 12;
                }
                //if salary is less than 80001 and greater than 40000
                else if (salary >= 40001 && salary <= 80000)
                {
                    double threshold = salary - 20000;
                    monthlyIncome = ((20000 * 0)  + ((40000 - 20000) * 0.1) + ((salary - threshold) * 0.2)) / 12;
                }
                //if salary is less than 180001 and greater than 80000
                else if (salary >= 80001 && salary <= 180000)
                {
                    double threshold = salary - 40000;
                    monthlyIncome = ((20000 * 0) + ((40000 - 20000) * 0.1) + ((80000 - 40000) * 0.2) + ((salary - threshold) * 0.3)) / 12;
                }
                //if salary is greater than 180000
                else
                {
                    double threshold = salary - 80000;
                    monthlyIncome = ((20000 * 0) + ((40000 - 20000) * 0.1) + ((80000 - 40000) * 0.2) + ((180000 - 80000) * 0.3) + ((salary - threshold) * 0.4)) / 12;
                }

                //Remove Decimal points and Return User Monthly Income
                return Math.Round(monthlyIncome,2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Calculating Gross Monthly Income");
                return 0;
            }
        }

        //Function to Calculate Gross Monthly Income
        private static double GetNetMonthlyIncome(double grossMonthlyIncome, double monthlyIncomeTax)
        {
            try
            {
                //Return User Net Monthly Income
                return grossMonthlyIncome - monthlyIncomeTax;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Calculating Gross Monthly Income");
                return 0;
            }
        }
    }
}
