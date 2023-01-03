using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class User_Interface : MonoBehaviour {
	[Header("Regular Interface")]
	public UnityEngine.UI.Text Gold_Coin;
	public UnityEngine.UI.Text Purple_Coin;
	public UnityEngine.UI.Text Time_Text;
	public GameObject Pause_Button;

	[Space]

	[Header("Pause Menu")]
	public GameObject Pause_Menu;
	public UnityEngine.UI.Text Pause_Fastest_Time_Text;

	[Space]

	[Header("End Menu")]
	public GameObject End_Menu;
	public UnityEngine.UI.Text End_Fastest_Time_Text;
	public UnityEngine.UI.Text Finished_Time_Text;
	public UnityEngine.UI.Text Score_Text;
	public UnityEngine.UI.Text Grade_Text;
	//Game master stuff
	bool Game_Already_won = false;

	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Time_Check();
	}

	void Update () {
		Gold_Coin.text = PlayerPrefs.GetInt("Gold Coins") + "/" + PlayerPrefs.GetInt("Gold Coins Total");
		Purple_Coin.text = PlayerPrefs.GetInt("Purple Coins") + "/" + PlayerPrefs.GetInt("Purple Coins Total");
		Time_Text.text = (Mathf.Round(Time.timeSinceLevelLoad * 1000) / 1000).ToString();

		if (PlayerPrefs.GetString("Level Completed") == "true" && Game_Already_won == false) {
			Time_Check();
			End_Menu.SetActive(true);
			StartCoroutine(Quantum_Fractal());
			Game_Already_won = true;
			Time.timeScale = 0;
		}
	}

	void Time_Check () {
		Finished_Time_Text.text = " Finished Time: " + (Mathf.Round(PlayerPrefs.GetFloat("Current Time") * 1000) / 1000).ToString();

		if (PlayerPrefs.GetFloat("Best Time " + PlayerPrefs.GetInt("World#") + "-" + PlayerPrefs.GetInt("Level#")) != 0) {
			Pause_Fastest_Time_Text.text = " Fastest Time: " + (Mathf.Round(PlayerPrefs.GetFloat("Best Time " + PlayerPrefs.GetInt("World#") + "-" + PlayerPrefs.GetInt("Level#")) * 1000) / 1000);
			End_Fastest_Time_Text.text = Pause_Fastest_Time_Text.text;
		}else {
			Pause_Fastest_Time_Text.text = " Fastest Time: N/A";
			End_Fastest_Time_Text.text = Pause_Fastest_Time_Text.text;
		}
	}

	IEnumerator Quantum_Fractal () { //That would make a good band name
		float Score = Mathf.Round(1000 - (PlayerPrefs.GetFloat("Current Time") * 5) + (PlayerPrefs.GetInt("Gold Coins") * 50) + (PlayerPrefs.GetInt("Purple Coins") * 200));
		for (float Loading_Score = 30; Loading_Score < Score; Loading_Score += Score / Loading_Score) {
			Score_Text.text = " Score: " + Mathf.Round(Loading_Score).ToString();
			yield return 0;
			if (Input.GetMouseButtonDown(0)) {
				break;
			}
		}
		Score_Text.text = " Score: " + Score.ToString();
		if (Score > 1500) {
			Grade_Text.text = "A+++";
		}else if (Score > 1250) {
			Grade_Text.text = "A++";
		}else if (Score > 1000) {
			Grade_Text.text = "A+";
		}else if (Score > 950) {
			Grade_Text.text = "A";
		}else if (Score > 900) {
			Grade_Text.text = "A-";
		}else if (Score > 850) {
			Grade_Text.text = "B+";
		}else if (Score > 800) {
			Grade_Text.text = "B-";
		}else if (Score > 750) {
			Grade_Text.text = "C+";
		}else if (Score > 700) {
			Grade_Text.text = "C";
		}else if (Score > 650) {
			Grade_Text.text = "C-";
		}else if (Score > 600) {
			Grade_Text.text = "D+";
		}else if (Score > 550) {
			Grade_Text.text = "D";
		}else if (Score > 500) {
			Grade_Text.text = "D-";
		}
	}

	//Shared buttons
	public void Exit () {
		Time.timeScale = 1;
		Application.LoadLevel("MainMenu");
	}

	public void Sound () {
		//Sound related stuff
	}

	//Pause related code
	public void Pause () {
		Pause_Button.SetActive(false);
		Pause_Menu.SetActive(true);
		Time.timeScale = 0;
	}

	public void Pause_Restart () {
		Next();
	}

	public void Resume () {
		Pause_Menu.SetActive(false);
		Pause_Button.SetActive(true);
		Time.timeScale = 1;
	}

	//End menu related code
	public void End_Restart () {
		if (PlayerPrefs.GetInt("World#") == 1 && PlayerPrefs.GetInt("Level#") == 1) {
			PlayerPrefs.SetInt("Level#", 8);
			PlayerPrefs.SetInt("World#", 0);
		}else if (PlayerPrefs.GetInt("World#") == 0 && PlayerPrefs.GetInt("Level#") == 1) {
			PlayerPrefs.SetInt("Level#", 5);
			PlayerPrefs.SetInt("World#", 1);
		}else if (PlayerPrefs.GetInt("Level#") <= 8) {
			PlayerPrefs.SetInt("Level#", PlayerPrefs.GetInt("Level#") - 1);
		}
		Next();
	}

	public void Next () {
		Time.timeScale = 1;
		Application.LoadLevel("God");
	}
}