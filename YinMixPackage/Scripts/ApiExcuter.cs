using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace YPackage
{
	public class ApiExcuter : MonoBehaviour
	{
		public IEnumerator myAction;
		public bool isDone;
		public float timeOut;

		public void onSuccess(string s){
			isDone = true;
			Destroy (gameObject);
		}
		public void onFail(string s){
			isDone = true;
			Destroy (gameObject);
		}
		public Action<string> onTimeOut;

		public void excute(){
			StartCoroutine (myAction);
			StartCoroutine (doTimeOut ());
		}

		IEnumerator doTimeOut(){
			yield return new WaitForSeconds (timeOut);
			if (!isDone) {
				if (onTimeOut != null) {
					onTimeOut ("");
				}
			}
		}
	}
}

