using System;

interface IPrintable
{
	void Print();
}

class SimpleEntity : IPrintable
{
	private int id;
	private static int count;

	static SimpleEntity()
	{
		Console.WriteLine("-- SimpleEntity type initialized in app-domain<{0}>", AppDomain.CurrentDomain.Id);
	}

	public SimpleEntity()
	{
		id = ++count;
		Console.WriteLine("-- SimpleEntity instance<{1}> initialized in app-domain<{0}>", AppDomain.CurrentDomain.Id, id);
	}

	public void Print()
	{
		Console.WriteLine("This is SimpleEntity instance<{1}> in app-domain<{0}>", AppDomain.CurrentDomain.Id, id);
	}

	~SimpleEntity()
	{
		Console.WriteLine("-- SimpleEntity instance<{1}> finalized in app-domain<{0}>", AppDomain.CurrentDomain.Id, id);
	}
}


static class Test
{
	public static void Action()
	{
		Console.WriteLine("--Acting in app-domain<{0}>({1})", AppDomain.CurrentDomain.Id, AppDomain.CurrentDomain.FriendlyName);
		IPrintable p = new SimpleEntity();
		p.Print();
	}

	public static void Main()
	{
		Action();
		Action();
		Action();

		AppDomain ad = AppDomain.CreateDomain("appdomtest1.second");
		ad.DoCallBack(Action);
		ad.DoCallBack(Action);
		AppDomain.Unload(ad);

		Console.WriteLine("Enter any key to exit...");
		Console.ReadLine();
	}
}