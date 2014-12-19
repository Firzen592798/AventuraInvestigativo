using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		if (g == null) {
			g = Instantiate(Resources.Load("prefab/GameManager", typeof(GameObject))) as GameObject;
			g.name = "GameManager";
		}
		GetComponent<Intro>().enabled = false;
	}
}
