using System;


public class Item : IItem
{
	public string code;
	public string name;
	public string description;


	public Item ()
	{
	}		
		
	public Item(string code){
		
	}


	public string getName(){
		return name;
	}

	public string getDescription(){
		return description;
	}		
}


