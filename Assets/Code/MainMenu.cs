using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	[Header("Main Interface")]
	public UnityEngine.UI.Button Play_Button;
	public UnityEngine.UI.Button Settings_Button;
	public UnityEngine.UI.Button Level_Select_Button;
	public UnityEngine.UI.Button Customize_Button;
	public UnityEngine.UI.Button Credits_Button;
	public UnityEngine.UI.Button Achievements_Button;
	public UnityEngine.UI.Text Play_Text;

	[Space]

	[Header("Other")]
	public GameObject Camera;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("Level#") == 0) {
			PlayerPrefs.SetInt("Level#", 1);
			Play_Text.text = "Start";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play () {
		Application.LoadLevel("God");
	}

	public void Settings () {
		StartCoroutine(Settings_Content());
	}

	IEnumerator Settings_Content () {
		for (float Camera_Position = -4; Camera_Position < 3.5f; Camera_Position += .1f) {
			Camera.transform.position = new Vector3 (12.5f, Camera_Position, -10);
			Play_Button.transform.position = new Vector3(Play_Button.transform.position.x, Play_Button.transform.position.y - 7.5f, Play_Button.transform.position.z);
			Settings_Button.transform.position = new Vector3(Settings_Button.transform.position.x, Settings_Button.transform.position.y - 7.5f, Settings_Button.transform.position.z);
			Level_Select_Button.transform.position = new Vector3(Level_Select_Button.transform.position.x, Level_Select_Button.transform.position.y - 7.5f, Level_Select_Button.transform.position.z);
			Customize_Button.transform.position = new Vector3(Customize_Button.transform.position.x, Customize_Button.transform.position.y - 7.5f, Customize_Button.transform.position.z);
			Credits_Button.transform.position = new Vector3(Credits_Button.transform.position.x, Credits_Button.transform.position.y - 7.5f, Credits_Button.transform.position.z);
			Achievements_Button.transform.position = new Vector3(Achievements_Button.transform.position.x, Achievements_Button.transform.position.y - 7.5f, Achievements_Button.transform.position.z);
			yield return 0;
			if (Input.GetMouseButtonDown(0)) {
				break;
			}
		}
		Camera.transform.position = new Vector3(12.5f, 3.5f, -10);
	}
}