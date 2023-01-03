using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.name == "Player") {
			if (transform.name == "Gold Coin") {
				PlayerPrefs.SetInt("Gold Coins", PlayerPrefs.GetInt("Gold Coins") + 1);
			}else {
				PlayerPrefs.SetInt("Purple Coins", PlayerPrefs.GetInt("Purple Coins") + 1);
			}
			DestroyObject(this.gameObject);
		}
	}
}
