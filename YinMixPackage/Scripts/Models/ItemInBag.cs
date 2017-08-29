using System;
using UnityEngine;
using LitJson;

public class ItemInBag : Item
{
	public int amountHave;

	public ItemInBag ()
	{
		
	}

	public ItemInBag(string code){

	}

	public void use(Action callBack){
		if (amountHave < 1) {
			throw new Exception ("NOT_ENOGH");
		}
		if (callBack != null) {
			callBack.Invoke ();
		}
		amountHave--;
		save ();
	}

	public void save(){
		string jsonData = JsonMapper.ToJson (this);
		PlayerPrefs.SetString (code, jsonData);
	}

	public static ItemInBag make(string code){
		try{
			ItemInBag mission = JsonHelper.getObjectFromPref<ItemInBag>(code);
			return mission;
		}catch(Exception ex){

		}
		return ItemDefine.itemInBagDefault [code];
	}

	public static void addAmount(int value, string code){
		ItemInBag itemInBag = new ItemInBag (code);
		itemInBag.amountHave += value;
		itemInBag.save ();
	}
}


