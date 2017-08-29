using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour{	
	public ShopUI shopUI;	
	public Text name;
	public Text amount;
	public Text price;
	public Button buy;
	public ItemInShop item;

	public void setUI(ShopUI shopUI){
		this.shopUI = shopUI;
		name.text = item.getName ();
		price.text = item.price + "";
	}

	public void onBuy(){
		shopUI.onBuy(item, int.Parse(amount.text));
	}
}


