using System;
using UnityEngine;
using UnityEngine.UI;

public class MissionItemUI : MonoBehaviour
{
	public Text name;
	public Text amountGift;
	public Button getRewardBtn;
	public Mission mission;
	public Image progressBar;
	public Text progressText;
	public Image icon;

	public void setUI(){
		name.text = mission.getName ();
		amountGift.text = "x" + mission.getGift() [0].amount + "";
		progressText.text = mission.getProgress ();
		progressBar.fillAmount = mission.getProgressValue ();

		if (mission.isCanGetReward ()) {
			getRewardBtn.enabled = true;
		} else {
			getRewardBtn.enabled = false;
		}	
	}

	public void getReward(){
		RewardIcon reward = MenuManager.Instance.RewardPopup.GetComponent<RewardIcon> ();
		reward.SetIconSprite (0);
		reward.gameObject.SetActive (true);
		InitScriptName.InitScript.Instance.AddGems (mission.getGift()[0].amount);
		mission.rewarded = true;
		setUI ();
	}

}


