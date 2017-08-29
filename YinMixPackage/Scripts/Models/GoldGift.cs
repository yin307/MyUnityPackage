using System;


public class GoldGift : Gift
{
	public GoldGift ()
	{
	}
	public GoldGift (int amount) : base("Gold", "GOLD", amount)
	{
		
	}
	public override void reward ()
	{
		base.reward ();
	}
}


