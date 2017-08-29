using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class Mission : IMission
{
	public string name;
	public string code;
	public string description;
	public int done;
	public int mustDone;
	List<Gift> gifts;
	public bool rewarded;

	public void reward(){
		if (!rewarded) {
			rewarded = true;
			foreach (Gift gift in gifts) {
				gift.reward ();
			}
			save ();
		} else {
			throw new Exception ("NOT_SUCCESS");
		}
	}
	public void addDone(int value){
		done += value;
		save ();
	}

	public List<Gift> getGift(){
		return gifts;
	}

	public void setGift(List<Gift> gifts){
		this.gifts = gifts;
	}

	public bool isDone(){
		return done >= mustDone;
	}

	public bool isCanGetReward(){
		return isDone () && !rewarded;
	}

	public string getProgress(){
		return done + "/" + mustDone;
	}

	public float getProgressValue(){
		return (float)(done) / (float)(mustDone) + 0f;
	}

	public string getName(){
		return name;
	}

	public Mission ()
	{
		
	}
		
	public Mission(string code){
		
	}

	public void save(){
		PlayerPrefs.SetString (code, JsonHelper.toJson (this));
	}

	public static Mission make(string code){
		try{
			Mission mission = JsonHelper.getObjectFromPref<Mission>(code);
			mission.gifts = MissionDefine.defaultMission [code].gifts;
			return mission;
		}catch(Exception ex){
			
		}
		return MissionDefine.defaultMission [code];
	}

	public static void addDone(int value, string code){
		Mission mission = Mission.make (code);
		mission.addDone (value);
	}

	public static int getNumberMissionCanReward(){
		int counter = 0;
		for (int i = 0; i < MissionDefine.missionActive.Count; i++) {
			Mission mission = Mission.make (MissionDefine.missionActive [i]);
			if (mission.isCanGetReward ()) {
				counter++;
			}
		}
		return counter;
	}
}


