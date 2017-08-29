using System;

public class Gift : IGift
{
	public string name;
	public string code;
	public int amount;

	public virtual void reward(){
		
	}

	public Gift ()
	{
	}

	public Gift (string name, string code, int amount)
	{
		this.name = name;
		this.code = code;
		this.amount = amount;
	}
}


