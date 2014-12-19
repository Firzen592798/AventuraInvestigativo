using UnityEngine;
using System.Collections;
public class PickUpItem : MonoBehaviour {
	public string nome;
	GameController gm;
	public string spritepath;
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
			gm.AddItem(nome, spritepath);
			//gm.SendMessage("PegarItem", nome);
			Destroy(gameObject);
			Debug.Log("Colidiu");
		}
	}

}
