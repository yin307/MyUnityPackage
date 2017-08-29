using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MissionWraperUI : MonoBehaviour {

	public GameObject missionItemUIPrefab;
	public Transform missionHolder;
	public Sprite[] icons;
	// Use this for initialization
	void Start () {
		if (MissionDefine.missionActive.Contains ("LOGIN_10_DAY")) {
			DatePassHelper.processIfNewDay ("LastDayLogin", DatePassHelper.DateFormat.ddMMyyyy, () => {
				Mission.addDone (1, "LOGIN_10_DAY");
			}, null, true);
		}
		initMissions ();
	}
	
	void initMissions(){
		for(int i = 0; i < MissionDefine.missionActive.Count; i ++){
			GameObject newMissionItem = Instantiate (missionItemUIPrefab) as GameObject;
			newMissionItem.transform.SetParent (missionHolder, false);
			MissionItemUI missionItemUI = newMissionItem.GetComponent<MissionItemUI> ();
			missionItemUI.mission = Mission.make (MissionDefine.missionActive [i]);
			missionItemUI.setUI ();
			missionItemUI.icon.sprite = icons [i];
		}
	}
		
}
