using System;
using UnityEngine;
using UnityEngine.UI;

public class GameCenter : MonoBehaviour
{
	public Text message;
	public GameObject faded;
	public GameObject failHolder;
	public GameObject successHolder;

	public Button tryAgainBtn;

	public void saveData(){
		tryAgainBtn.onClick.RemoveAllListeners ();
		tryAgainBtn.onClick.AddListener (() => {
			Player.saveToServer (onSaveSuccess, onSaveFail);
		});
		message.text = "Processing ...";
		faded.SetActive (true);
		failHolder.SetActive (false);
		successHolder.SetActive (false);
		Player.saveToServer (onSaveSuccess, onSaveFail);
	}

	public void getData(){
		tryAgainBtn.onClick.RemoveAllListeners ();
		tryAgainBtn.onClick.AddListener (() => {
			Player.syncWithServer (onGetSuccess, onGetFail);
		});
		message.text = "Processing ...";
		faded.SetActive (true);
		failHolder.SetActive (false);
		successHolder.SetActive (false);
		Player.syncWithServer (onGetSuccess, onGetFail);
	}

	public void onSaveSuccess(string res){
		message.text = "Save data to cloud is successfully !";
		successHolder.SetActive (true);
		failHolder.SetActive (false);
	}
	public void onSaveFail(string res){
		message.text = "Save data to cloud has failled ! Please check your network and try again later.";
		successHolder.SetActive (false);
		failHolder.SetActive (true);
	}

	public void onGetSuccess(string res){
		message.text = "Sync data from cloud is successfully !";
		successHolder.SetActive (true);
		failHolder.SetActive (false);
	}
	public void onGetFail(string res){
		message.text = "Sync data from cloud has failled ! Please check your network and try again later.";
		successHolder.SetActive (false);
		failHolder.SetActive (true);
	}
}


