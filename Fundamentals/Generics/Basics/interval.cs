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
		get{return minutes;}
	}

	public int Seconds
	{
		get{return seconds;}
	}

	public virtual int GetTime()
	{
		return 60 * minutes + seconds;
	}

	public override string ToString()
	{
		return minutes + ":" + seconds;
	}

	public override int GetHashCode()
	{
		return 1000 * GetTime();
	}

	public override bool Equals(object other)
	{
		if(other is Interval)
		{
			Interval that = (Interval) other;
			return this.GetTime() == that.GetTime();
		}

		return false;
	}
}

partial class BigInterval : Interval
{
	private int hours;

	public BigInterval(int h, int m, int s) : base((m + s / 60) % 60, s % 60)
	{
		hours = h + (m + s / 60) / 60;
	}

	public int Hours
	{
		get{return hours;}
	}

	public override int GetTime()
	{
		return 3600 * hours + base.GetTime();
	}

	public override string ToString()
	{
		return hours + ":" + base.ToString();
	}
	
}












































