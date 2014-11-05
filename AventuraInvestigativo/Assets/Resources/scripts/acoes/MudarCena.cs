using UnityEngine;
using System.Collections;

public class MudarCena : Acao{

	public string goto_cene = "next";
	public string spawn_point = "spawn";
	GameController gm;
	
	public MudarCena(string goto_cene, string spawn){
		this.goto_cene = goto_cene;
		this.spawn_point = spawn;
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	public override bool Update(){
		gm.hideppbutton ();
		gm.TransiteScene(goto_cene, spawn_point);
		return true;
	}
}