using UnityEngine;

public class Dirt_Spawner : MonoBehaviour {
	public GameObject Dirt;
	// Use this for initialization
	void Start () {
		RaycastHit Hit;
		if (Physics.Raycast(transform.position, Vector3.up, out Hit, 1)) {
			if (Hit.collider.gameObject.name == "Grass Dirt" || Hit.collider.gameObject.name == "Dirt") {
				GameObject Creation = Instantiate(Dirt,  transform.position, Quaternion.identity);
				Creation.name = "Dirt";
				DestroyObject(this.gameObject);
			}
		}
	}
}
