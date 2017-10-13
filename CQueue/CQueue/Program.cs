using System;

namespace CQueue
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Write("Aantal wachtwoorden invoeren:");
            int passwords = int.Parse(Console.ReadLine());
            for (int i = 0; i < passwords; i++)
            {
                Console.Write("Voer wachtwoord in:");
                string readpassword = Console.ReadLine();
                char[] password = readpassword.ToCharArray();
                EQueue<char> passwordQueue = new EQueue<char>(password.Length);

                // add items to queue
                for (int j = 0; j < password.Length; j++)
                {
                    passwordQueue.Add(password[j]);
                }

                // debugging
                passwordQueue.Debug();

                // loop through queue
                for (int j = 0; j < password.Length; j++)
                {
                    char queueItem = passwordQueue.Poll();

                    Console.Write(queueItem + " - ");

                    switch(password[j])
                    {
                        case '-':
                            // functie backspace;
                            Console.WriteLine("functie backspace");
                            break;
                        case '<':
                            // functie cursor naar links
                            Console.WriteLine("functie cursor naar links");
                            break;
                        case '>':
                            // functie cursor naar rechts
                            Console.WriteLine("functie cursor naar rechts");
                            break;
                        default:
                            // functie voeg character toe
                            Console.WriteLine("functie voeg character toe");
                            break;
                    }
                }
            }
        }
    }
}