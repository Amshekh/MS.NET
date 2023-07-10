partial class Interval
{
	private int minutes;
	private int seconds;

	public Interval(int m, int s)
	{
		minutes = m + s / 60;
		seconds = s % 60;
	}

	public int Minutes
	{
		get {return minutes;}
	}
	
	public int Seconds
	{
		get {return seconds;}
	}

	public virtual int GetTime()
	{
		return 60 * minutes + seconds;
	}

	public override string ToString()
	{
		if(seconds >= 10)
			return minutes + ":" + seconds;

		return minutes + ":0" + seconds;
	}

	public override int GetHashCode()
	{
		return 1000 * GetTime();
	}

	public override bool Equals(object other)
	{
		Interval that = (Interval) other;

		return this.GetTime() == that.GetTime();
	}
}


// patial class is helpful in taking particulat set of arguments and in this way you don't have to take all the required stuff and use all classes which may lead to heavy code size.














