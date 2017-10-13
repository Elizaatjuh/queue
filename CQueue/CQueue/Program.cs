using System;
using System.Collections;
using System.Collections.Generic;

namespace CQueue
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int passwords = int.Parse(Console.ReadLine());
            string[] passwordsArray = new string[passwords];

			for (int i = 0; i < passwords; i++)
			{
				string readpassword = Console.ReadLine();
                passwordsArray[i] = readpassword;
			}
                
            for (int i = 0; i < passwords; i++)
            {
                char[] password = passwordsArray[i].ToCharArray();
                EQueue<char> passwordQueue = new EQueue<char>(password.Length);

                // add items to queue
                for (int j = 0; j < password.Length; j++)
                {
                    passwordQueue.Add(password[j]);
                }

                List<char> realpassword = new List<char>();
                int index = 0;

                // loop through queue
                for (int j = 0; j < password.Length; j++)
                {
                    char queueItem = passwordQueue.Poll();
                    switch(password[j])
                    {
                        case '-':
                            // functie backspace
                            index--;
                            realpassword.RemoveAt(index);
                            break;
                        case '<':
                            // functie cursor naar links
                            if (index > 0) { index--; }
                            break;
                        case '>':
                            // functie cursor naar rechts
                            index++;
                            break;
                        default:
                            // functie voeg character toe
                            realpassword.Insert(index, queueItem);
                            index++;
                            break;
                    }
                }

                Console.WriteLine(string.Join("", realpassword.ToArray()));
            }
        }
    }
}