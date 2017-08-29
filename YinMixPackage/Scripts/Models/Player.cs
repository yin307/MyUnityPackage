using System;
using UnityEngine;
using LitJson;
using System.Collections;
using System.Collections.Generic;

public class Player
{
	public int[] unlockCharacter;
	public int selectedCharacter;
	public int gems;
	public int life;
	public Player ()
	{
		unlockCharacter = new int[]{ 1, 0, 0, 0, 0, 0 };
		gems = LevelEditorBase.THIS.FirstGems;
		life = LevelEditorBase.THIS.CapOfLife;
	}

	public static Player makePlayer(){
		Player player = new Player ();
		if (PlayerPrefs.HasKey ("PLAYER")) {
			player = LitJson.JsonMapper.ToObject<Player> (PlayerPrefs.GetString ("PLAYER"));
		}
		return player;
	}

	public void save(){
		PlayerPrefs.SetString ("PLAYER", LitJson.JsonMapper.ToJson (this));
	}
	public static void setGems(int value){
		Player player = Player.makePlayer ();
		player.gems = value;
		player.save ();
	}

	public static int getGems(){
		return Player.makePlayer ().gems;
	}

	public static void setLife(int value){
		Player player = Player.makePlayer ();
		player.life = value;
		player.save ();
	}

	public static int getLife(){
		return Player.makePlayer ().life;
	}

	public static void saveToServer(Action<string> onSuccess, Action<string> onFail){
		Player player = Player.makePlayer ();
		string jsonString = JsonMapper.ToJson (player);
		Dictionary<string, string> data = new Dictionary<string, string> ();
		data.Add ("game_id", "bunnypop");
		data.Add ("device_id", SystemInfo.deviceUniqueIdentifier);
		data.Add ("dataSave", jsonString);
		YApi.POST ("http://ads.haanhmedia.com/city_run/saveData.php", data, onSuccess, onFail);
	}
	public static void syncWithServer(Action<string> onSuccess, Action<string> onFail){
		Dictionary<string, string> data = new Dictionary<string, string> ();
		data.Add ("game_id", "bunnypop");
		data.Add ("device_id", SystemInfo.deviceUniqueIdentifier);
		YApi.POST ("http://ads.haanhmedia.com/city_run/getData.php", data, (result) => {
			try{
				Player player = JsonMapper.ToObject<Player>(result);
				player.save();
				InitScriptName.InitScript.Gems = player.gems;
				InitScriptName.InitScript.Lifes = player.life;
				if(onSuccess != null){
					onSuccess("");
				}
			}catch(Exception ex){
				Debug.Log(ex.Message);
				if(onFail != null)	{
					onFail("");
				}
			}

		},onFail);
	}
}



