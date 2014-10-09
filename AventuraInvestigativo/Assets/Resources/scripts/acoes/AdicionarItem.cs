using UnityEngine;
using System.Collections;
public class AdicionarItem : Acao{
	string item;
	string spritepath;
	bool destroy;
	GameController gm;

	public AdicionarItem(string item, string spritepath, bool destroy){
		this.item = item;
		this.spritepath = spritepath;
		this.destroy = destroy;
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	public override bool Update(){
		gm.PegarItem(item, Resources.Load<Sprite>(spritepath));
		if(destroy){
			GameObject go = GameObject.FindGameObjectWithTag (item);
			NPCController2 npcController = (NPCController2)go.GetComponent (typeof(NPCController2));
			NPCController2.Destroy (go);
		}
		return true;
	}
	
	
}