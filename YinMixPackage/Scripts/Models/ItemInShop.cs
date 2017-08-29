using System;


public class ItemInShop : Item
{
	public int price;

	public ItemInShop ()
	{
	}

	public static ItemInShop make(string code){
		return ItemDefine.itemInShopDefault[code];
	}

}


