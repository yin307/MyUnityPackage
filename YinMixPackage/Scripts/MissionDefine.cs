using System;
using System.Collections;
using System.Collections.Generic;

public class MissionDefine
{
	public static Dictionary<string, Mission> defaultMission = new Dictionary<string, Mission> () {
		{ "DESTROY_1000_BALL", mission1 () },
		{ "GIFT_10_HEART",mission2 () },
		{ "LOGIN_10_TIME",mission3 () },
		{ "REACH_LVL_15",mission4 () },
		{ "COMPLETE_LVL_15_3STAR", mission5 () },
		{ "COLLECT_100_STAR",mission6 () },
		{ "CONNECT_FB",mission7 () },
		{ "USE_50_MUSHROOM",mission8 () },
		{ "INVITE_1_FRIEND",mission9 () },
		{ "POP_100_BLUE_BUBBLE",mission10 () },
		{ "USE_20_DRAGON",mission11 () },
		{ "USE_50_AIM", mission12 () }
	};

	public static List<string> missionActive = new List<string>(){
		"DESTROY_1000_BALL", 
		//"GIFT_10_HEART",
		"LOGIN_10_DAY",
		"REACH_LVL_15",
		"COMPLETE_LVL_15_3STAR",
		"COLLECT_100_STAR",
		"CONNECT_FB",
		"USE_50_MUSHROOM",
		//"INVITE_1_FRIEND",
		"POP_100_BLUE_BUBBLE",
		"USE_20_DRAGON",
		"USE_50_AIM"
	};

	public static Mission mission1(){
		Mission mission = new Mission ();
		mission.code = "DESTROY_1000_BALL";
		mission.description = "Pop 1000 bubbles";
		mission.name = "Pop 1000 bubbles";
		mission.mustDone = 10000;
		mission.setGift (new List<Gift> (){ 
			new GoldGift(100)
		});

		return mission;
	}

	public static Mission mission2(){
		Mission mission = new Mission ();
		mission.code = "GIFT_10_HEART";
		mission.description = "Gift 10 heart for friends";
		mission.name = "Gift 10 heart for friends";
		mission.mustDone = 10;
		mission.setGift (new List<Gift> (){ 
			new GoldGift(110)
		});

		return mission;
	}

	public static Mission mission3(){
		Mission mission = new Mission ();
		mission.code = "LOGIN_10_DAY";
		mission.description = "Login 10 days in arow";
		mission.name = "Login 10 days in arow";
		mission.mustDone = 10;
		mission.setGift (new List<Gift> (){ 
			new GoldGift(120)
		});

		return mission;
	}
	public static Mission mission4(){
		Mission mission = new Mission ();
		mission.code = "REACH_LVL_15";
		mission.description = "Reach to level 10";
		mission.name = "Reach to level 10";
		mission.mustDone = 10;
		mission.setGift (new List<Gift> (){ 
			new GoldGift(130)
		});

		return mission;
	}

	public static Mission mission5(){
		Mission mission = new Mission ();
		mission.code = "COMPLETE_LVL_15_3STAR";
		mission.description = "Complete level 15 with 3 starts";
		mission.name = "Complete level 15 with 3 starts";
		mission.mustDone = 1;
		mission.setGift (new List<Gift> (){ 
			new GoldGift(140)
		});

		return mission;
	}

	public static Mission mission6(){
		Mission mission = new Mission ();
		mission.code = "COLLECT_100_STAR";
		mission.description = "Collect 100 stars";
		mission.name = "Collect 100 stars";
		mission.mustDone = 100;
		mission.setGift (new List<Gift> (){ 
			new GoldGift(150)
		});

		return mission;
	}

	public static Mission mission7(){
		Mission mission = new Mission ();
		mission.code = "CONNECT_FB";
		mission.description = "Connect to Facebook";
		mission.name = "Connect to Facebook";
		mission.mustDone = 1;
		mission.setGift (new List<Gift> (){ 
			new GoldGift(160)
		});

		return mission;
	}

	public static Mission mission8(){
		Mission mission = new Mission ();
		mission.code = "USE_50_MUSHROOM";
		mission.description = "Use 50 mushrooms";
		mission.name = "Use 50 mushrooms";
		mission.mustDone = 50;
		mission.setGift (new List<Gift> (){ 
			new GoldGift(170)
		});

		return mission;
	}

	public static Mission mission9(){
		Mission mission = new Mission ();
		mission.code = "INVITE_1_FRIEND";
		mission.description = "Invite a firend play with you";
		mission.name = "Invite a firend play with you";
		mission.mustDone = 1;
		mission.setGift (new List<Gift> (){ 
			new GoldGift(180)
		});

		return mission;
	}

	public static Mission mission10(){
		Mission mission = new Mission ();
		mission.code = "POP_100_BLUE_BUBBLE";
		mission.description = "Pop 100 blue bubbles";
		mission.name = "Pop 100 blue bubbles";
		mission.mustDone = 100;
		mission.setGift (new List<Gift> (){ 
			new GoldGift(190)
		});

		return mission;
	}

	public static Mission mission11(){
		Mission mission = new Mission ();
		mission.code = "USE_20_DRAGON";
		mission.description = "Use 20 dragon bubble";
		mission.name = "Use 20 dragon bubble";
		mission.mustDone = 20;
		mission.setGift (new List<Gift> (){ 
			new GoldGift(200)
		});

		return mission;
	}
	public static Mission mission12(){
		Mission mission = new Mission ();
		mission.code = "USE_50_AIM";
		mission.description = "Use 50 times aim powerup";
		mission.name = "Use 50 times aim powerup";
		mission.mustDone = 50;
		mission.setGift (new List<Gift> (){ 
			new GoldGift(210)
		});

		return mission;
	}


}


