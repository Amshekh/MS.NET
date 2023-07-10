using System;

enum RoomType {Economy, Business, Executive, Deluxe}

class HotelRoom   // in c# struct is value type and class is reference type
{
	public int Number = 101; // here we can declare like this b/c it's within class which is reference type.
	public RoomType Category;
	public bool Taken;

	public void Print()
	{
		string status = Taken ? "Occupied" : "Available";
		Console.WriteLine("Room {0} is of {1} class and is currently {2}.", Number, Category, status); // notice the print advantage.
	}
}

static class Test
{
	
	private static void Reserve(HotelRoom room)
	{
		if(room.Taken == false)
			room.Taken = true;
	}

	public static void Main()
	{
		HotelRoom myroom = new HotelRoom(); // new operator is used b/c in this eg. we use class and class is reference type in c#.
		myroom.Number = 101;
		myroom.Category = RoomType.Executive;
		myroom.Taken = false;

		myroom.Print();
		Console.WriteLine("Reserving roomno.101...");
		
		Reserve(myroom);

		myroom.Print();
	}
}

// in this example after reservation the o/p works properly.