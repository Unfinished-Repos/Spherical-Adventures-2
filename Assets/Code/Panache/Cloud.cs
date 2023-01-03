using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
	float Speed;

	void Start () {
		Speed = Random.Range(4.0f, 6.0f);
	}

	void Update () {
		transform.Translate(Vector3.right * Time.deltaTime * Speed);
		if (transform.position.x >= 40 * transform.position.z) {
			DestroyObject(this.gameObject);
		}
	}
}
