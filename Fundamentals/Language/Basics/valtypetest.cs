using System;

enum RoomType {Economy, Business, Executive, Deluxe}

struct HotelRoom   // in c# struct is value type and class is reference type
{
	public int Number; // = 101; we can't declare like this b/c it's within struct which is value type.
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
		HotelRoom myroom; 
		myroom.Number = 101;
		myroom.Category = RoomType.Executive;
		myroom.Taken = false;

		myroom.Print();
		Console.WriteLine("Reserving roomno.101...");
		
		Reserve(myroom);

		myroom.Print();
	}
}

// in this example after reservation also the o/p shows room to be available which is not correct. now see next prg reftype.cs