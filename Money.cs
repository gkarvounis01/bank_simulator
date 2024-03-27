using Intuit.Ipp.Data;
using Intuit.Ipp.Exception;
using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Xml.Serialization;

namespace Trapeza
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
            AccountList.Add(new Account("Georgios Karvounis", 123456789, 0123, 5000.0));
            AccountList.Add(new Account("Konstantinta Betchava", 987654321, 6666, 20.0));
            AccountList.Add(new Account("Dimitris Oupas", 111111111, 1111, 100.0));
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
                    Console.Write("1.Ανάληψη\n" +
                                    "2.Κατάθεση\n" +
                                    "3.Eρώτηση Υπολοίπου\n" +
                                    "4.Έξοδος\n");

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
                    Console.Write("Εισάγετε το ΑΦΜ: ");
                    int afm = Convert.ToInt32(Console.ReadLine());
                    login_account.SetAfm(afm);

                    Console.Write("Εισάγετε το Pin: ");
                    int pin = Convert.ToInt32(Console.ReadLine());
                    login_account.SetPin(pin);

                    for (int i = 0; i < AccountList.Count; i++)
                    {
                        if (login_account.GetAfm() == AccountList[i].GetAfm() && login_account.GetPin() == AccountList[i].GetPin())
                        {
                            flag = true;
                            num = i;
                            break;
                        }
                    }

                    if (flag == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Λάθος ΑΦΜ ή Pin!");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Επιτυχής σύνδεση!");
                    }
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Εισάγετε το ποσό για ανάληψη: ");
                        double temp_withdrawl = Convert.ToDouble(Console.ReadLine());
                        AccountList[num].withdraw(temp_withdrawl);
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Εισάγετε το ποσό για κατάθεση: ");
                        double temp_deposit = Convert.ToDouble(Console.ReadLine());
                        AccountList[num].deposit(temp_deposit);
                        break;

                    case 3:
                        AccountList[num].print();
                        break;

                    case 4:
                        Console.WriteLine("Έξοδος απο το σύστημα... Παρακαλώ περιμένετε");
                        Thread.Sleep(milliseconds);
                        Console.Clear();
                        Console.WriteLine("Η έξοδος πραγματοποιήθηκε με επιτυχία.");
                        break;
                }
            }while (choice < 4  && choice > 0);

        }
    }
}