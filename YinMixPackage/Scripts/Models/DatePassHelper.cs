using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DatePassHelper : MonoBehaviour
{
	public enum DateFormat
	{
		ddMMyyyy,
		ddMMyyyyhhmmss,
		hhmmss,
	}

	public static Dictionary<DateFormat, string> DateFormatString = new Dictionary<DateFormat, string>(){
		{DateFormat.ddMMyyyy, "dd-MM-yyyy"},
		{DateFormat.ddMMyyyyhhmmss, "dd-MM-yyyy HH:mm:ss"},
		{DateFormat.hhmmss, "HH:mm:ss"},
	};		
		
	public static string getNowString (DateFormat format)
	{
		DateTime now = DateTime.Now;
		if (format == DateFormat.ddMMyyyy) {
			return now.Day.ToString () + "-" + now.Month.ToString () + "-" + now.Year.ToString ();
		}
		if (format == DateFormat.ddMMyyyyhhmmss) {
			return now.Day.ToString () + "-" + now.Month.ToString () + "-" + now.Year.ToString () + " " + now.Hour.ToString() + ":" + now.Minute.ToString() + ":" + now.Second.ToString();
		}
		if (format == DateFormat.hhmmss) {
			return now.Hour.ToString() + ":" + now.Minute.ToString() + ":" + now.Second.ToString();
		}
		return "";
	}

	public static string getDateStringFromPref(string code){
		return PlayerPrefs.GetString (code);
	}

	public static void saveNowToPref(string code, DateFormat format){
		PlayerPrefs.SetString (code, getNowString (format));
	}

	public static bool comparePrefWithNow(string code, DateFormat format){
		return getDateStringFromPref (code).Equals (getNowString (format));
	}

	public static void processIfNewDay(string code, DateFormat format, Action onTrue = null, Action onFalse = null, bool overWriteDate = true){
		if (getDateStringFromPref (code).Equals ("")) {
			if (onTrue != null) {
				onTrue ();
			}
			if (overWriteDate) {
				saveNowToPref (code, format);
			}
			return;
		}

		if (getDateStringFromPref (code).Equals (getNowString (format))) {
			if (onFalse != null) {
				onFalse ();
			}
		} else {
			if (onTrue != null) {
				onTrue ();
			}
			if (overWriteDate) {
				saveNowToPref (code, format);
			}
			return;
		}
	}

	public static DateTime getDateTimeFromPref(string code, DateFormat format){
		try{
			string formatString = DateFormatString[format];
			return DateTime.ParseExact(getDateStringFromPref(code), formatString, null);

		}catch(Exception ex){
			Debug.LogError (ex.Message);
		}

		return DateTime.Now;
	}

	public static int getDayPassed(string code){
		if (getDateStringFromPref (code).Equals ("")) {
			return 0;
		}

		DateTime lasTime = getDateTimeFromPref (code, DateFormat.ddMMyyyy);
		DateTime now = DateTime.Now;
		return (int)(now - lasTime).TotalDays;
	}

	public static int getHourPassed(string code){
		if (getDateStringFromPref (code).Equals ("")) {
			return 0;
		}

		DateTime lasTime = getDateTimeFromPref (code, DateFormat.ddMMyyyyhhmmss);
		DateTime now = DateTime.Now;
		return (int)(now - lasTime).TotalHours;
	}

	public static int getMinutePassed(string code){
		if (getDateStringFromPref (code).Equals ("")) {
			return 0;
		}

		DateTime lasTime = getDateTimeFromPref (code, DateFormat.ddMMyyyyhhmmss);
		DateTime now = DateTime.Now;
		return (int)(now - lasTime).TotalMinutes;
	}

	public static void startCountDownSec(int start, int end = 0, Action<int> onUpdate = null, Action onFnish = null){
		DatePassHelper datePassHelper = FindObjectOfType<DatePassHelper> ();
		if (datePassHelper == null) {
			GameObject obj = new GameObject ("DatePassHelper");
			obj.AddComponent<DatePassHelper> ();
			datePassHelper = obj.GetComponent<DatePassHelper> ();
		}

		datePassHelper.callCountDownSec (start, end, onUpdate, onFnish);
	}

	public void callCountDownSec(int start, int end = 0, Action<int> onUpdate = null, Action onFinish = null){
		StartCoroutine (countDownSec (start, end, onUpdate, onFinish));
	}

	public IEnumerator countDownSec(int start, int end = 0, Action<int> onUpdate = null, Action onFinish = null){
		int startTime = start;
		while (true) {
			if (startTime != end) {
				yield return new WaitForSeconds (1);
				startTime--;
				if (onUpdate != null) {
					onUpdate (startTime);
				}
			} else {
				if (onFinish != null) {
					onFinish ();
				}
				break;
			}
		}
	}

	public static string splitSecondToString(int value){
		int hour = value / 60 / 60;
		int minute = (value - hour * 60 * 60) / 60;
		int second = value - hour * 60 * 60 - minute * 60;
		string hourStr = hour + "";
		string minuteStr = minute + "";
		string secondStr = second + "";
		if (hour < 10) {
			hourStr = "0" + hourStr;
		}
		if (minute < 10) {
			minuteStr = "0" + minuteStr;
		}
		if (second < 10) {
			secondStr = "0" + secondStr;
		}

		if (hour > 0) {

			return hourStr + ":" + minuteStr + ":" + secondStr;
		}

		return minuteStr + ":" + secondStr;
	}
}


