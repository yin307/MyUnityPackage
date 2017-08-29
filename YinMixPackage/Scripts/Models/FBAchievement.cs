using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace YPackage
{
	public class FBAchievement
	{
		public Achievement achievement;
		public User user;

		public FBAchievement(){
			achievement = new Achievement ();
			user = new User ();
		}

		public static void getListFriendsAchievements(string rangeFriends, string ach_id, int limit, Action<string> onSuccess, Action<string> onFail){
			Dictionary<string, string> data = new Dictionary<string, string> ();
			data.Add ("game_id", "bunnypop");
			data.Add ("ach_id", ach_id);
			data.Add ("limit", limit.ToString ());
			data.Add ("range_friends", rangeFriends);
			YApi.POST ("http://ads.haanhmedia.com/getListFriendsByAch.php", data, onSuccess, onFail);
		}

		public static void pushAchievements(string user_code, int score, string ach_id, Action<string> onSuccess, Action<string> onFail){
			Dictionary<string, string> data = new Dictionary<string, string> ();
			data.Add ("game_id", "bunnypop");
			data.Add ("ach_id", ach_id);
			data.Add ("score", score.ToString ());
			data.Add ("user_code", user_code);
			Debug.Log ("Start push");
			YApi.POST ("http://ads.haanhmedia.com/saveAchievement.php", data, onSuccess, onFail);
		}
	}
}

