/* ------------------------
 * This is my first C# Script
 * 1:38 AM         12/24/2017
 * ------------------------*/

using UnityEngine;

public class Rotate_Cube : MonoBehaviour {
	void Start () {
		int Turn_Amount = Random.Range(1, 5); //Aqcuires turn amount
		transform.Rotate(0, (Turn_Amount * 90), 0); //Executes required turns
	}
}