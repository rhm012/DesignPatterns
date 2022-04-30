using System;

namespace Memento
{
    /// Memento Design Pattern
	/// I used the skeleton of the structal code from https://www.dofactory.com/net/memento-design-pattern and thats where I got description and General UML from
  

    public class Program
    {
		/// Main function that executes the code
		
        public static void Main(string[] args)
        {
            MTGCard m = new MTGCard();
            m.Name = "Queza, Augur of Agonies";
            m.Manacost = "1WUB";
            m.Price = 0.9;

            /// Stores the values into the memento
            Binder n = new Binder();
            n.Memento = m.SaveMemento();

            /// Changes the Originator

            m.Name = "Vivien on the Hunt";
            m.Manacost = "4GG";
            m.Price = 4.20;

			/// new binder
			Binder k = new Binder();
			k.Memento = m.SaveMemento();
            /// Restore the object

            m.RestoreMemento(n.Memento);
			
			/// restores the other object
			m.RestoreMemento(k.Memento);

        }
    }

    /// <summary>
    /// The 'Originator' class
    /// I did mtg cards cuz it was the first thing I saw on my desk

    public class MTGCard
    {
        string name;
        string manacost;
        double price;

        // Gets or sets name

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Console.WriteLine("Name:   " + name);
            }
        }

        // Gets or sets manacost

        public string Manacost
        {
            get { return manacost; }
            set
            {
                manacost = value;
                Console.WriteLine("Mana Cost:  " + manacost);
            }
        }

        // Gets or sets Price

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                Console.WriteLine("Price: " + price);
            }
        }

        // Stores memento

        public Memento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new Memento(name, manacost, price);
        }

        // Restores memento

        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            Name = memento.Name;
            Manacost = memento.Manacost;
            Price = memento.Price;
        }
    }

    /// <summary>
    /// The 'Memento' class
    /// /this was pretty straight forward from what I saw with the structal code. There is not many different ways to do this
	

    public class Memento
    {
        string name;
        string manacost;
        double price;

        // Constructor

        public Memento(string name, string manacost, double price)
        {
            this.name = name;
            this.manacost = manacost;
            this.price = price;
        }
		// getters and setters for name manacost and price
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Manacost
        {
            get { return manacost; }
            set { manacost = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }

    /// The 'Caretaker' class
    /// it just sets and returns the memento, I named it binder cuz you put your extra mtg cards in a binder

    public class Binder
    {
        Memento memento;

        public Memento Memento
        {
            set { memento = value; }
            get { return memento; }
        }
    }
}
