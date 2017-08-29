using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class YApi : MonoBehaviour
{

	public static void POST(string url, 
		Dictionary<string, string> data = null, 
		Action<string> onSuccess = null, 
		Action<string> onFail = null, 
		float timeOut = 10, 
		Action<string> onTimeOut = null){

		YApi yApi = FindObjectOfType<YApi> ();
		if (yApi == null) {
			GameObject obj = new GameObject ("YApi");
			yApi = obj.AddComponent<YApi> ();
		}
		yApi.post (url, data, onSuccess, onFail);
	}

	public static void GET_SPRITE(string url, Action<Sprite> callBack){
		YApi yApi = FindObjectOfType<YApi> ();
		yApi.StartCoroutine (yApi.downloadPicture (url, callBack));
	}


	public void post(string url, 
		Dictionary<string, string> data = null, 
		Action<string> onSuccess = null, 
		Action<string> onFail = null, 
		float timeOut = 10, 
		Action<string> onTimeOut = null){
		StartCoroutine (postCoroutine (url, data, onSuccess, onFail));
	}

	IEnumerator postCoroutine(string url, 
		Dictionary<string, string> data, 
		Action<string> onSuccess = null,
		Action<string> onFail = null){

		WWWForm body = new WWWForm();

		if (data != null) {
			foreach (KeyValuePair<string,string> d in data) {
				body.AddField (d.Key, d.Value);
			}
		}
		UnityWebRequest request = UnityWebRequest.Post (url, body);
		yield return request.Send ();
		if (request.isError) {
			if (onFail != null) {
				onFail ("");
			}
		} else {
			if (onSuccess != null) {
				onSuccess (request.downloadHandler.text);
			}
		}
	}		

	IEnumerator downloadPicture(string url, Action<Sprite> callBack){
		//Debug.Log (FBData.user.profilePic);
		UnityWebRequest request = UnityWebRequest.GetTexture (url);	
		yield return request.Send ();

		if(request.isError) {
			Debug.Log(request.error);
		}
		else {
			Texture2D myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
			Rect rec = new Rect(0, 0, myTexture.width, myTexture.height);
			Sprite sprite = Sprite.Create(myTexture,rec,new Vector2(0,0),1);
			callBack (sprite);
		}

	}

}


