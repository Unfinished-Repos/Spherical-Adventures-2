using UnityEngine;

public class Camera_Movement : MonoBehaviour {
	GameObject Player;
	float Change_y;
	float Change_x;

	void Update () { //  Make more smoooth
		if (Player != null) {
			Change_y = (Player.transform.position.y + 1 - transform.position.y) / 2;
			Change_x = (Player.transform.position.x - transform.position.x) / 2;
			transform.position += new Vector3(Change_x, Change_y, 0);
		}else {
			Player = GameObject.Find("Player");
			transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1, -10);
		}
	}
}