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

// Interface voor een wachtrij met elementen van type E
public interface IQueue<E>
{
	// Test of de wachtrij leeg is
	bool Empty();

	// Voeg een nieuw element toe aan het einde van de wachtrij
	void Add(E item);

	// Geef het element aan het begin van de wachtrij terug zonder deze te verwijderen
	E Peek();

	// Verwijder het element aan het begin van de wachtrij en geef deze terug
	E Poll();
}

class EQueue<E> : IQueue<E>
{
	E[] Queue;
	int front = 0, rear = -1;

	public EQueue(int length)
	{
		Queue = new E[length];
	}

	public bool Empty()
	{
		if (rear < front)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public void Add(E item)
	{
		rear++;
		Queue[rear] = item;
	}

	public E Peek()
	{
		return Queue[front];
	}

	public E Poll()
	{
		E item = Queue[front];
		front++;
		return item;
	}

	public void Debug()
	{
		for (int i = 0; i < Queue.Length; i++)
		{
			Console.WriteLine("Queue item [" + i + "] = " + Queue[i]);
		}
	}
}