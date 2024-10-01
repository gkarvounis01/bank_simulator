using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bank
{
    internal class Money
    {
        static void Main(string[] args)
        {
            //delay time 2 seconds
            int milliseconds = 2000;

            //Create list
            List<Account> AccountList = new List<Account>();

            //Add to list
            AccountList.Add(new Account("Jack Reach", 123456789, 0123, 5000.0));
            AccountList.Add(new Account("Janet Bet", 987654321, 6666, 20.0));
            AccountList.Add(new Account("Carol Ober", 111111111, 1111, 100.0));
            AccountList.Add(new Account("Jane doe", 555566666, 5566, 555.0));
            AccountList.Add(new Account("John Doe", 222222222, 2222, 222222));

            //Create account with login information to compare with accounts in list
            Account login_account = new Account();

            //Menu variable
            int choice = 0;

            //login account number in list
            int num = 0;

            //Flag for login status
            bool flag = false;
            do
            {
                do
                {
                    //Main menu
                    Console.Write("1.Withdrawal\n" +
                                  "2.Deposit\n" +
                                  "3.Balance\n" +
                                  "4.Exit\n");

                    choice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    if (choice == 4)
                    {
                        flag = true;
                    }

                } while (choice > 4 || choice < 1);

                while (flag == false)
                {
                    //Login
                    Console.Write("Enter your Taxpayer Identification Number: ");
                    int tin = Convert.ToInt32(Console.ReadLine());
                    login_account.SetTin(tin);

                    Console.Write("Enter your Pin: ");
                    int pin = Convert.ToInt32(Console.ReadLine());
                    login_account.SetPin(pin);

                    for (int i = 0; i < AccountList.Count; i++)
                    {
                        if (login_account.GetTin() == AccountList[i].GetTin() && login_account.GetPin() == AccountList[i].GetPin())
                        {
                            flag = true;
                            num = i;
                            break;
                        }
                    }

                    if (flag == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong Taxpayer Identification Number or PIN!");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Successful login!");
                    }
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter amount for withdrawal: ");
                        double temp_withdrawl = Convert.ToDouble(Console.ReadLine());
                        AccountList[num].withdraw(temp_withdrawl);
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Enter amount for deposit: ");
                        double temp_deposit = Convert.ToDouble(Console.ReadLine());
                        AccountList[num].deposit(temp_deposit);
                        break;

                    case 3:
                        AccountList[num].print();
                        break;

                    case 4:
                        Console.WriteLine("Logging out... Please wait");
                        Thread.Sleep(milliseconds);
                        Console.Clear();
                        Console.WriteLine("Exiting...");
                        Thread.Sleep(milliseconds);
                        break;
                }
            }while (choice < 4  && choice > 0);

        }
    }
}