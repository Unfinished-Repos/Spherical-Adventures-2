using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Game_Master : MonoBehaviour {
	bool Game_Already_won = false;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("Gold Coins", 0);
		PlayerPrefs.SetInt("Purple Coins", 0);
		PlayerPrefs.SetString("Level Completed", "false");
	}

	// Update is called once per frame
	void Update () {
		if (Resources.Load<TextAsset>("Level " + PlayerPrefs.GetInt("World#") + "-" + PlayerPrefs.GetInt("Level#")) == null) {
			PlayerPrefs.SetInt("Level#", 1);
			PlayerPrefs.SetInt("World#", 0);
			Application.LoadLevel("God");
		}
		
		if (PlayerPrefs.GetInt("Gold Coins") == PlayerPrefs.GetInt("Gold Coins Total") && PlayerPrefs.GetString("Level Completed") != "true" && Game_Already_won == false) {
			PlayerPrefs.SetInt("Level#", PlayerPrefs.GetInt("Level#") + 1);
			if (Resources.Load<TextAsset>("Level " + PlayerPrefs.GetInt("World#") + "-" + PlayerPrefs.GetInt("Level#")) == null) {
				PlayerPrefs.SetInt("Level#", 1);
				PlayerPrefs.SetInt("World#", PlayerPrefs.GetInt("World#") + 1);
				if (Resources.Load<TextAsset>("Level " + PlayerPrefs.GetInt("World#") + "-" + PlayerPrefs.GetInt("Level#")) == null) {
					PlayerPrefs.SetInt("Level#", 1);
					PlayerPrefs.SetInt("World#", 0);
				}
			}
			PlayerPrefs.SetFloat("Current Time", Time.timeSinceLevelLoad);
			if (PlayerPrefs.GetFloat("Best Time " + PlayerPrefs.GetInt("World#") + "-" + PlayerPrefs.GetInt("Level#")) == 0 || PlayerPrefs.GetFloat("Best Time " + PlayerPrefs.GetInt("World#") + "-" + PlayerPrefs.GetInt("Level#")) > PlayerPrefs.GetFloat("Current Time")) {
				PlayerPrefs.SetFloat("Best Time " + PlayerPrefs.GetInt("World#") + "-" + PlayerPrefs.GetInt("Level#"), PlayerPrefs.GetFloat("Current Time"));
			}
			PlayerPrefs.SetString("Level Completed", "true");
			Game_Already_won = true;
		}
	}
}
