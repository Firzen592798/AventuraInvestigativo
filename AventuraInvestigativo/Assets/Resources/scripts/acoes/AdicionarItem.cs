using UnityEngine;
using System.Collections;
public class AdicionarItem : Acao{
	string item;
	string spritepath;
	GameController gm;

	public AdicionarItem(string item, string spritepath){
		this.item = item;
		this.spritepath = spritepath;
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	public override bool Update(){
		gm.PegarItem(item, Resources.Load<Sprite>(spritepath));
		return true;
	}
	
	
}