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
			//ObjectController npcController = (ObjectController)go.GetComponent (typeof(ObjectController));
			gm.hideppbutton ();
			ObjectController.Destroy (go);

		}
		return true;
	}
	
	
}