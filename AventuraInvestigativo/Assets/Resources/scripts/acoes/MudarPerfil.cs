using UnityEngine;
using System.Collections;
public class MudarPerfil : Acao{
	Profile prof;
	int whonum;
	
	public MudarPerfil(GameController gm, int whonum, Profile prof){
		this.gm = gm;
		this.whonum = whonum;
		this.prof = prof;
	}

	public override bool Update(){
		gm.SetProfile(whonum,prof);
		return true;
	}	
	
}