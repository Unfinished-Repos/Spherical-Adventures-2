using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Map_Generator : MonoBehaviour {
	//All the fucking text stuff
	StreamReader Levell;
	StreamReader Level2;
	TextAsset Level_Text;

	//Regular vars
	int i  = 0;
	int Total_Lines;

	[Header("Blocks")]
	public GameObject Dirt_Grass;
	public GameObject Coin_Gold;
	public GameObject Coin_Purple;
	public GameObject Player_Spawn;
	public GameObject Falling_Block;

	[Space]

	[Header("Clouds")] //Make them more efficient
	public GameObject Cloud1;
	public GameObject Cloud2;
	public GameObject Cloud3;
	public GameObject Cloud4;
	public GameObject Cloud5;
	public GameObject Cloud6;
	public GameObject Cloud7;
	public GameObject Cloud8;

	void Start () {
		PlayerPrefs.SetInt("Gold Coins Total", 0);
		PlayerPrefs.SetInt("Purple Coins Total", 0);
		Level_Text = Resources.Load<TextAsset>("Level " + PlayerPrefs.GetInt("World#") + "-" + PlayerPrefs.GetInt("Level#"));
		Levell = new StreamReader(new MemoryStream(Level_Text.bytes));
		Level2 = new StreamReader(new MemoryStream(Level_Text.bytes));
		while (Levell.ReadLine() != null) {
			i++;
		}
		Total_Lines = i;
		Levell.Close();
		for (i = 1; i <= Total_Lines; i++) {
			string Line_Current = Level2.ReadLine();
			for (int a = 1; a <= Line_Current.Length; a++) {
				switch (Line_Current[a-1].ToString()) {
				case "B":
					GameObject Creation = Instantiate(Dirt_Grass,  new Vector3(a, 0 - i, 0), Quaternion.Euler(0, 0, 0));
					Creation.name = "Grass Dirt";
					break;
				case "O":
					Creation = Instantiate(Coin_Gold,  new Vector3(a, 0 - i, 0), Quaternion.Euler(0, 0, 0));
					Creation.name = "Gold Coin";
					PlayerPrefs.SetInt("Gold Coins Total", PlayerPrefs.GetInt("Gold Coins Total") + 1);
					break;
				case "P":
					Creation = Instantiate(Coin_Purple,  new Vector3(a, 0 - i, 0), Quaternion.Euler(0, 0, 0));
					Creation.name = "Purple Coin";
					PlayerPrefs.SetInt("Purple Coins Total", PlayerPrefs.GetInt("Purple Coins Total") + 1);
					break;
				case "S":
					Creation = Instantiate(Player_Spawn,  new Vector3(a, 0 - i, 0), Quaternion.Euler(0, 0, 0));
					Creation.name = "Player Spawner";
					break;
				case "F":
					Creation = Instantiate(Falling_Block,  new Vector3(a, 0 - i, 0), Quaternion.Euler(0, 0, 0));
					Creation.name = "Falling Block";	
					break;
				case " ":
					break;
				default:
					Debug.Log("ERROR: LEVEL CHARACTER");
					break;
				}
			}
		}
		Level2.Close();
	}

	void Update () { 
		if (Random.Range(1, 600) == 69) { //Le clouts (Make more frequent?)
			switch (Random.Range(1, 9)) { //More clouds in future?
				case 1:
					Instantiate(Cloud1,  new Vector3(-150, Random.Range(20f, 50f), Random.Range(150f, 50f)), Quaternion.Euler(0, 0, 0));
					break;
				case 2:
					Instantiate(Cloud2,  new Vector3(-150, Random.Range(20f, 50f), Random.Range(150f, 50f)), Quaternion.Euler(0, 0, 0));
					break;
				case 3:
					Instantiate(Cloud3,  new Vector3(-150, Random.Range(20f, 50f), Random.Range(150f, 50f)), Quaternion.Euler(0, 0, 0));
					break;
				case 4:
					Instantiate(Cloud4,  new Vector3(-150, Random.Range(20f, 50f), Random.Range(150f, 50f)), Quaternion.Euler(0, 0, 0));
					break;
				case 5:
					Instantiate(Cloud5,  new Vector3(-150, Random.Range(20f, 50f), Random.Range(150f, 50f)), Quaternion.Euler(0, 0, 0));
					break;
				case 6:
					Instantiate(Cloud6,  new Vector3(-150, Random.Range(20f, 50f), Random.Range(150f, 50f)), Quaternion.Euler(0, 0, 0));
					break;
				case 7:
					Instantiate(Cloud7,  new Vector3(-150, Random.Range(20f, 50f), Random.Range(150f, 50f)), Quaternion.Euler(0, 0, 0));
					break;
				case 8:
					Instantiate(Cloud8,  new Vector3(-150, Random.Range(20f, 50f), Random.Range(150f, 50f)), Quaternion.Euler(0, 0, 0));
					break;
			}
		}
	}
}