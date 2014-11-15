using UnityEngine;
using System.Collections;
public class TocarAudio : Acao{
	public TocarAudio(GameController gm){
		this.gm = gm;
	}
	
	public override bool Update(){
		gm.PlayAudio();
		return true;
	}
}
