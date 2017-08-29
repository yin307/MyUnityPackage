using System;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelper
{
	public static T getObjectFromPref<T>(string key){
		try{
			T res = JsonMapper.ToObject<T>(PlayerPrefs.GetString(key));
			return res;
		}catch(Exception ex){
			throw new Exception(ex.Message);
		}
			
		return default(T);
	}

	public static string toJson(object obj){
		return JsonMapper.ToJson (obj);
	}		

}


