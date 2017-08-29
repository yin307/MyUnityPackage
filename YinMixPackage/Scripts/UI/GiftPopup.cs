using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using System.Collections;
using System.Collections.Generic;

public class GiftPopup : MonoBehaviour
{
	public Gift gift;
	public Text amount;
	public Image giftIcon;
	public Button getReward;
	public UnityEvent onReward;

	public Sprite[] iconSprites;
	public List<string> codeOfSprite;

	public void setUI(){
		amount.text = gift.amount + "";
		getReward.onClick.RemoveAllListeners ();
		giftIcon.sprite = iconSprites [codeOfSprite.IndexOf (gift.code)];
		getReward.onClick.AddListener (() => {			
			gift.reward();
			if(onReward != null){				
				onReward.Invoke();
			}
		});
	}

	public static void open(Gift gift){
		GiftPopup  giftPopup = GameObject.Find ("GiftPopup").GetComponent<GiftPopup>();
		if (giftPopup == null) {
			return;
		}
		giftPopup.gift = gift;
		giftPopup.setUI ();
		giftPopup.gameObject.SetActive (true);
	}
}


