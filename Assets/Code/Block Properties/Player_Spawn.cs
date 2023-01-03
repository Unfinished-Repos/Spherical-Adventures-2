using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Spawn : MonoBehaviour {
	public GameObject Player;
	public GameObject Level_Text;
	GameObject Spawn;
	UnityEngine.UI.Text Level;

	void Start () {
		Spawn = Instantiate(Player,  transform.position, Quaternion.identity);
		Spawn.name = "Player";
		if (SceneManager.GetActiveScene().name != "MainMenu") {
			Spawn = Instantiate(Level_Text,  transform.position, Quaternion.identity);
			Spawn.name = "Level Text";
			Spawn.transform.Translate(Vector3.left * .45f);
			Spawn.GetComponent<TextMesh>().text = "Level " + PlayerPrefs.GetInt("World#") + "-" + PlayerPrefs.GetInt("Level#");
		}
		DestroyObject(this.gameObject);
	}
}