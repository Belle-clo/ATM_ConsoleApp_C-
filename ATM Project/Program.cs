using System;
using System.Collections.Generic;
using System.Linq;

public class CardHolder
{
        string cardNum;
        int pin;
        string FirstName;
        string LastName;
        double balance;

          //constructors
           public CardHolder(string cardNum,int pin,string FirstName, string LastName,double balance)
           {
              this.cardNum = cardNum;
              this.pin = pin;
              this.FirstName = FirstName;
              this.LastName = LastName;
              this.balance = balance;
           }


          public string getNum()
          {
              return cardNum;
          }



          public int getPin()
          {
             return pin;
          }


          public string getlastName()
          {
              return LastName;
          }


        public string getfirstName()
        {
             return FirstName;
        }


        public double getBalance()
        {
           return balance;
        }


         //setters
          
       public void setNum(string newCardNum)
       {
        cardNum = newCardNum;
       }


    public void setPin(int newPin)
    {
        pin = newPin;
    }


    public void setFirstName(string newFirstName)
    {
       FirstName = newFirstName;
    }


    public void setLastName(string newLastName)
    {
        LastName = newLastName;
    }


    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }


    //main method to run the atm

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
        }

        //method to handle deposits

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine();
            Console.Write("How much R would you like to deposit?:\t");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine();
            Console.WriteLine("Your new balance is \t" + currentUser.getBalance());
            Console.WriteLine();

        }

        //method to handle witdrawals

        void withdraw(CardHolder currentUser)
        {
           
            Console.Write("How much R would you like to withdraw?:\t");           
            double withdrawal = double.Parse(Console.ReadLine());
            Console.WriteLine();
            //Check if the user has enough money

            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you. Bye! :)");
            }
        }

        //method to check current balance

        void balance(CardHolder currentUser)
        {
            Console.WriteLine(" Your Current Balance is: \t " + currentUser.getBalance());
        }

        //Card holder list
        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("4900650106362051", 3449, "Tevita", "Janik", 848.00));
        cardHolders.Add(new CardHolder("4555375847669808", 9530, "Akari", " Hearne", 316.60));
        cardHolders.Add(new CardHolder("4636129655499284", 9246, "Ellamae", "Proulx", 213.80));
        cardHolders.Add(new CardHolder("4903716440916568", 1378, "Melia ", " Bronson", 570.15));
        cardHolders.Add(new CardHolder("4518864475226771", 9969, "Amerika", " Viveros", 838.66));


        //prompt user
        Console.WriteLine("Welcome to my ATM");
        Console.WriteLine();
        Console.Write("Please enter your debit card:\t");
        string debitCardNum = " ";
        CardHolder currentUser;
       

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against our list
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }



        Console.Write("Please enter your pin:\t");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //check against our list
               
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Pin. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect Pin. Please try again");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Welcome \t" + currentUser.getfirstName() + "\t :)");
        int option = 0;

        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            { }
             if(option == 1)
             {

                deposit(currentUser);
             }
             else if(option == 2)
             {
                withdraw(currentUser);
             }
            else if (option == 3)
            {
                balance(currentUser);
            }
             else if(option == 4)
            {
                break;
            }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");

    }

}

