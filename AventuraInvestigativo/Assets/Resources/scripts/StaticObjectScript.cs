using UnityEngine;
using System.Collections;

public class StaticObjectScript : MonoBehaviour {
	//public int layer1 = 0;
	//private SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		Vector3 pos = this.gameObject.transform.position;
		pos.z = pos.y;
		this.gameObject.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
