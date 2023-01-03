using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Block : MonoBehaviour {
	int Speed = 3;
	bool Gravity_Status = false;

	void Start () {
		RaycastHit Hit;
		if (Physics.Raycast(transform.position, Vector3.down, out Hit, 1.0f)) {
			if (Hit.collider.gameObject.name == "Player") {
				Debug.Log("Player died");
				//Add death menu
			}
			//DestroyObject(Hit.collider.gameObject);
		}
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.name == "Player") {
			Gravity_Status = true;
		}
	}

	void Update () {
		if (Gravity_Status == true) {
			this.gameObject.GetComponent<Rigidbody>().useGravity = true;
		}
	}
}
