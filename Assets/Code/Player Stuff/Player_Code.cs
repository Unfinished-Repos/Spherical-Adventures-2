using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Code : MonoBehaviour {
	[Range(5,50)]
	public int Speed = 5; // Increase?
	float Gravity = -9.81f;
	float Velocity_y;
	int Jumps;
	bool Jumping;
	float Pre_Frame_Pos = 0;
	RaycastHit Vertical_Hit;
	RaycastHit Horizontal_Hit;

	void Update () {
		if (Physics.Raycast(transform.position, Vector3.down, out Vertical_Hit, .41f) && Jumping != true) { //Checking if touching ground
			Jumps = 2;
		}
		if (transform.position.y < Pre_Frame_Pos) {
			Jumping = false;
		}

		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) {
			if (Input.GetKey(KeyCode.LeftArrow) == true) { // Add phone rotation
				if (Physics.Raycast(transform.position, Vector3.left, out Horizontal_Hit, .4f)) {
					//Zero horizontal velocity
				}else {
					transform.Translate(Vector3.left * Time.deltaTime * Speed);
				}
			}
			if (Input.GetKey(KeyCode.RightArrow) == true) {
				if (Physics.Raycast(transform.position, Vector3.right, out Horizontal_Hit, .4f)) {
					//Zero horizontal velocity
				}else {
					transform.Translate(Vector3.right * Time.deltaTime * Speed);
				}
			}

			if (Application.platform == RuntimePlatform.WindowsEditor) { //DEV CHEATS (FIX WORLD AND LEVEL SHIFTING TO CHECK)
				if (Input.GetKey(KeyCode.R) == true) { //Reset level
					Time.timeScale = 1;
					Application.LoadLevel("God");
				}
				if (Input.GetKey(KeyCode.Z) == true) { //Set level to first one
					Time.timeScale = 1;
					PlayerPrefs.SetInt("Level#", 1);
					PlayerPrefs.SetInt("World#", 0);
					Application.LoadLevel("God");
				}
				if (Input.GetKey(KeyCode.L) == true) { //Shift level up by 1
					Time.timeScale = 1;
					PlayerPrefs.SetInt("Level#", PlayerPrefs.GetInt("Level#") + 1);
					Application.LoadLevel("God");
				}else if (Input.GetKey(KeyCode.J) == true) { //Shift level down by 1
					Time.timeScale = 1;
					PlayerPrefs.SetInt("Level#", PlayerPrefs.GetInt("Level#") - 1);
					Application.LoadLevel("God");
				}
				if (Input.GetKey(KeyCode.I) == true) { //Shift world up by 1
					Time.timeScale = 1;
					PlayerPrefs.SetInt("World#", PlayerPrefs.GetInt("World#") + 1);
					Application.LoadLevel("God");
				}else if (Input.GetKey(KeyCode.K) == true) { //Shift world down by 1
					Time.timeScale = 1;
					PlayerPrefs.SetInt("World#", PlayerPrefs.GetInt("World#") - 1);
					Application.LoadLevel("God");
				}
			}
		}else if (Application.platform == RuntimePlatform.Android) {;
			if (Input.acceleration.x > 0) {
				if (Physics.Raycast(transform.position, Vector3.right, out Horizontal_Hit, .4f)) {
					//Zero horizontal velocity
				}else {
					GetComponent<Rigidbody>().velocity = new Vector3(Input.acceleration.x * Speed, 0, 0);
				}
			}else if (Input.acceleration.x < 0) {
				if (Physics.Raycast(transform.position, Vector3.left, out Horizontal_Hit, .4f)) {
					//Zero horizontal velocity
				}else {
					GetComponent<Rigidbody>().velocity = new Vector3(Input.acceleration.x * Speed, 0, 0);
				}
			}
		}

		if (Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.W) == true || Input.GetMouseButtonDown(0)) {
			if (Jumping == false && Jumps > 0) {
				GetComponent<Rigidbody>().velocity = Vector3.up * Speed; //WHY DOES THIS NOT FUCKING WORK FOR ANDROID!!!?!?!?
				Jumping = true;
				Jumps--;
			}
		}
		Pre_Frame_Pos = transform.position.y;
	}
}