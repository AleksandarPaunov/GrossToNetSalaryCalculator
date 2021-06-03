using System;
using System.Collections.Generic;

namespace GrossToNetSalaryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal inputSalary = InputGrossSalaryValidator();
            CalculateGrossToNetAmount(inputSalary);


            Console.WriteLine();
            TotalTaxes(Taxes);

            
        }

        public static List<decimal> Taxes = new List<decimal>(); // Used to store the total taxes > 
        // In future can be created classes for customer(which will have a property of income tax and social tax ),
        // Tax class which income tax and social tax will inherit , also holding the total amount of tax in a dictionary with customer Id and tax total amount
        //Options are many depends on what reporting we are focussing on, individual tax reporting or just total tax to be paid.

        public static decimal InputGrossSalaryValidator() // Method for validating the input
        {
            decimal grossSalary;
            bool parsedSalary;
            do
            {
                Console.Clear();
                Console.WriteLine("Please enter gross salary (amount has to be greater or equal to 500).");
                parsedSalary = decimal.TryParse(Console.ReadLine(), out grossSalary);



            } while (!parsedSalary);

            if (grossSalary<500)
            {
                
                return InputGrossSalaryValidator();
            }

            return grossSalary;
        }

        public static void CalculateGrossToNetAmount(decimal grossSalary)
        {
            decimal netAmount;
            if (grossSalary<=1000)
            {
                netAmount = grossSalary;
                Console.WriteLine($"Net salary for the gross salary entered {grossSalary} is : {netAmount}");

            }

            decimal amountToBeTaxed = TaxableAmountCalculator(grossSalary);
            decimal incomeTax = IncomeTaxCalculator(amountToBeTaxed);
            Taxes.Add(incomeTax);
            decimal socialContributionTax = SocialContributionTaxCalculator(grossSalary,amountToBeTaxed);
            Taxes.Add(socialContributionTax);
            netAmount = grossSalary - (incomeTax + socialContributionTax);

            Console.WriteLine($"Your gross salary is : {grossSalary} " +
                $"\r\ndeducted with income tax of {incomeTax} and social contribution tax of " +$"{socialContributionTax} " +
                $"\r\nto lead to your net salary being: {netAmount}");









        } //Calculating gross to net amount

        public static decimal TaxableAmountCalculator(decimal netSalary)
        {
            netSalary = netSalary - 1000;
            return netSalary;
        } // Calculating the taxable amount 

        public static decimal IncomeTaxCalculator(decimal taxableAmount)
        {
            

            return (taxableAmount * 10)/100;


        } // Helper for income tax amount

        public static decimal SocialContributionTaxCalculator(decimal grossSalary,decimal taxableAmount)
        {
            if (grossSalary>3000)
            {
                grossSalary = 3000;
            }
            taxableAmount = TaxableAmountCalculator(grossSalary);
            return (taxableAmount * 15) / 100;
        } // Helper for social contribution tax

        public static void TotalTaxes (List<decimal>taxList)
        {
            decimal totalTaxes = 0;
            foreach (var tax in taxList)
            {
                totalTaxes += tax;
            }
            Console.WriteLine(totalTaxes);
        } //Calculate total taxes


    }
}
