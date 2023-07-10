using System;

enum RoomType {Economy=1, Business, Executive, Deluxe} // enum is integer type; bydefault it takes from 0; here we are taking roomtype as 1, business =2 and so on.

struct HotelRoom
{
	public int Number;
	public RoomType Category;
	public bool Taken;
	
	public void Print()
	{
		string status = Taken ? "Occupied" : "Available";
		Console.WriteLine("Room {0} is of {1} class and is currently {2}.", Number, Category, status);
	}
}

static class Test
{

	private unsafe static void Reserve(HotelRoom* room) // as we see use of pointer compiler will generate warning so we use unsafe
	{
		if(room->Taken == false)		
			room->Taken = true;
	}

	public unsafe static void Main()
	{
		HotelRoom myroom = new HotelRoom();
		myroom.Number = 101;
		myroom.Category = RoomType.Economy;

		myroom.Print();
		Console.WriteLine("Reserving myroom...");
		
		Reserve(&myroom); // notice: use of addr. operator
		
		myroom.Print();
	}
}



// in this we have right o/p compared to valtypetest.(see o/p).










