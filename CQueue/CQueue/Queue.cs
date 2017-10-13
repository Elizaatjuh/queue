using System;

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
        if (rear < front) {
            return false;
        } else {
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