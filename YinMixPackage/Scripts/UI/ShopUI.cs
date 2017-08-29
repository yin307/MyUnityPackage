using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using LitJson;

public class ShopUI : MonoBehaviour
{
	private static int gold;

	public static int Gold {
		get {
			return gold;
		}
		set {
			gold = value;
			//Debug.Log (gold);
		}
	}

	public UnityEvent onBuySuccess;
	public UnityEvent onBuyFail;
	public GameObject shopItemUIPrefab;
	public Transform shopItemHolder;
	bool inited;


	void Start(){
		//initItem ();
		//Gold = Gold - 10;
	}

	void initItem(){
		for (int i = 0; i < ItemDefine.itemCodeToBuy.Length; i++) {
			ItemInShop itemInShop = ItemInShop.make (ItemDefine.itemCodeToBuy [i]);
			GameObject newShopItemUI = Instantiate (shopItemUIPrefab) as GameObject;
			newShopItemUI.transform.SetParent (shopItemHolder, false);
			newShopItemUI.transform.localScale = new Vector3 (1, 1, 1);
			ShopItemUI shopItemUI = newShopItemUI.GetComponent<ShopItemUI> ();
			shopItemUI.item = itemInShop;
			shopItemUI.setUI (this);
		}

	}

	public void onBuy(ItemInShop item, int amount){
		int totalCost = item.price * amount;
		if (totalCost > gold) {
			if (onBuyFail != null) {
				onBuyFail.Invoke ();
			}
			return;
		}

		Gold = Gold - totalCost;
		ItemInBag.addAmount (amount, item.code);
		if (onBuySuccess != null) {
			onBuySuccess.Invoke ();
		}
	}

}


