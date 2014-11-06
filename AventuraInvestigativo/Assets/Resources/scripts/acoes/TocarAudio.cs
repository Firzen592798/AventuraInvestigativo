using UnityEngine;
using System.Collections;
public class TocarAudio : Acao{
	GameController gm;
	public TocarAudio(int num){
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	public override bool Update(){
		gm.PlayAudio();
		return true;
	}
}
