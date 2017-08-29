using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionNotifiCounter : MonoBehaviour {
	public GameObject holder;
	public Text counter;

	// Use this for initialization
	void Start () {
		setUI ();
	}

	public void setUI(){
		int numberMissionCanReward = Mission.getNumberMissionCanReward ();
		if (numberMissionCanReward == 0) {
			holder.SetActive (false);
			return;
		}

		holder.SetActive (true);
		counter.text = numberMissionCanReward + "";
	}

	public static void refresh(){
		MissionNotifiCounter missionNotifiCounter = FindObjectOfType<MissionNotifiCounter> ();
		if (missionNotifiCounter != null) {
			missionNotifiCounter.setUI ();
		}
	}
}
