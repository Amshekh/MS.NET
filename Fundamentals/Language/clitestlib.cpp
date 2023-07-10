#using <mscorlib.dll>

namespace Greeting
{
	using namespace System;

	public ref class Greeter
	{
	public:
		String^Greet(String^ name, int age)
		{
			if(age < 18)
				return "Hi " + name;

			return "Hello " + name;
		}
	};
}