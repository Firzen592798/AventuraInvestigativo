using UnityEngine;
using System.Collections;

public class MudarCena : Acao{

	public string goto_cene = "next";
	public string spawn_point = "spawn";
	
	public MudarCena(GameController gm, string goto_cene, string spawn){
		this.goto_cene = goto_cene;
		this.spawn_point = spawn;
		this.gm = gm;
	}
	
	public override bool Update(){
		gm.hideppbutton ();
		gm.TransiteScene(goto_cene, spawn_point);
		return true;
	}
}