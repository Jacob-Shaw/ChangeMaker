
using System.Collections.Generic;
using System;

class Result
{
    public static List<int> ChangeMaker(float price, List<float> payment)
    {
        //This is the total amount paid by the customer
        decimal paymentTotal = 0;

        //This is the amount of change that is due the customer
        decimal changeDue = 0;
        
        //These are the numbers of each type of coin to return to the customer
        int quartersChange = 0;
        int dimesChange = 0;
        int nickelsChange = 0;
        int penniesChange = 0;
        
        //This is a generics list to hold the change result to be returned 
        List<int> changeResult = new List<int>();

        decimal xPayment = 0;

        //Calculate the total of the payment
        foreach (var currency in payment)
        {
            //Add each currency tendered in the payment argument to the payment total
            xPayment = (decimal)currency;
            paymentTotal += xPayment;
        }

        
        //If the payment is equal to the price then there no change to be given
        if (paymentTotal == (decimal)price )
        {
            changeResult.Add(0);
            changeResult.Add(0);
            changeResult.Add(0);
            changeResult.Add(0);
            
            return changeResult;
        }
        
        //If the payment total is less than the price then return the amount in change
        if (paymentTotal < (decimal)price)
        {
            changeDue = paymentTotal;

            //Determine the number of coins to be given
            //Determine Quarters
            while (changeDue > 0.24M)
            {
                changeDue = changeDue - 0.25M;
                quartersChange++;
            }

            //Determine Dimes
            while (changeDue > 0.09M)
            {
                changeDue = changeDue - 0.10M;
                dimesChange++;
            }

            //Determine Nickels
            while (changeDue > 0.04M)
            {
                changeDue = changeDue - 0.05M;
                nickelsChange++;
            }

            //Determine Pennies
            while (changeDue > 0.00M)
            {
                changeDue = changeDue - 0.01M;
                penniesChange++;
            }

            //Add the number of each specific coin to the coin total/changeResult
            changeResult.Add(penniesChange);
            changeResult.Add(nickelsChange);
            changeResult.Add(dimesChange);
            changeResult.Add(quartersChange);
            
            return changeResult;
        }
        
        //If the amount tendered is not less than or equal to the price
        //  then this will determine the change after purchase

        //Calculate the amount of change due
        changeDue = paymentTotal - (decimal)price;

        while (changeDue > 0.24M )
        {
            changeDue = changeDue - 0.25M;
            quartersChange++;
        }

        while (changeDue > 0.09M )
        {
            changeDue = changeDue - 0.10M;
            dimesChange++;
        }

        while (changeDue > 0.04M ) 
        {
            changeDue = changeDue - 0.05M;
            nickelsChange++;
        }

        while (changeDue > 0.00M )
        {
            changeDue = changeDue - 0.01M;
            penniesChange++;
        }
        
        changeResult.Add(penniesChange);
        changeResult.Add(nickelsChange);
        changeResult.Add(dimesChange);
        changeResult.Add(quartersChange);
        
        return changeResult;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
       // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        
        float price = Convert.ToSingle(Console.ReadLine().Trim());
        
        int paymentCount = Convert.ToInt32(Console.ReadLine().Trim());
        
        List<float> payment = new List<float>();
        
        for (int i = 0; i<paymentCount; i++)
        {
            float paymentItem = Convert.ToSingle(Console.ReadLine().Trim());
            payment.Add(paymentItem);
        }

        List<int> result = Result.ChangeMaker(price, payment);
        
        Console.WriteLine(String.Join("\n", result));

        Console.ReadLine();
    }

}