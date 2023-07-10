using System;
using System.Dynamic;
using System.Reflection;

class EnglishGreeter
{
	public string Meet(string name, int age)
	{
		if(age < 25)
			return "Hi " + name;
		return "Hello " + name;
	}

	public string Leave(string name)
	{
		return "Bye " + name;
	}
}

class EchoProxy : DynamicObject
{
	private object original;
	
	public EchoProxy(object target)
	{
		original = target;
	}
	
	public override bool TryInvokeMember(InvokeMemberBinder method, object[] arguments, out object result)
	{
		Type t = original.GetType();
		
		try
		{
			Console.WriteLine(">> Invoking {0} method of class {1}", method.Name, t.Name);
			result = t.InvokeMember(method.Name, BindingFlags.InvokeMethod, null, original, arguments);
			return true;
		}
		catch(MissingMethodException)
		{
			result = null;
			return false;
		}
	}
}

static class Test
{
	public static void Main()
	{
		EnglishGreeter eg = new EnglishGreeter();
		dynamic ep = new EchoProxy(eg);
		
		Console.WriteLine(ep.Meet("Jack", 22));
		Console.WriteLine(ep.Leave("Jack"));
		//Console.WriteLine(ep.Kill("Jack"));
	}
}














