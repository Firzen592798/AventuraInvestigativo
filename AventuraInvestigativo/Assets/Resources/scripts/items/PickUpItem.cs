﻿using UnityEngine;
using System.Collections;
public class PickUpItem : MonoBehaviour {
	public string nome;
	GameController gm;
	public Sprite sprite;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			gm.PegarItem(nome, sprite);
			//gm.SendMessage("PegarItem", nome);
			Destroy(gameObject);
			Debug.Log("Colidiu");
		}
	}

}
