using UnityEngine;
using System.Collections;
public class AdicionarItem : Acao{
	string item;
	string spritepath;
	bool destroy;
	GameController gm;

	public AdicionarItem(GameController gm, string item, string spritepath, bool destroy){
		this.gm = gm;
		this.item = item;
		this.spritepath = spritepath;
		this.destroy = destroy;
	}
	
	public override bool Update(){
		//gm.PegarItem(item, Resources.Load<Sprite>(spritepath));
		gm.PegarItem(item, spritepath);
		if(destroy){
			GameObject go = GameObject.FindGameObjectWithTag (item);
			//ObjectController npcController = (ObjectController)go.GetComponent (typeof(ObjectController));
			gm.hideppbutton ();
			ObjectController.Destroy (go);

		}
		return true;
	}
	
	
}