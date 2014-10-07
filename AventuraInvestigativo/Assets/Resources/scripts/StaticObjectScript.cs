using UnityEngine;
using System.Collections;

public class StaticObjectScript : MonoBehaviour {
	public int layer1 = 0;
	private SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (sprite)
			sprite.sortingOrder = layer1;
	}
}
