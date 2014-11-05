using UnityEngine;
using System.Collections;
public class TocarMusica : Acao{
	GameController gm;
	int n;
	public TocarMusica(int num){
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		n = num;
	}
	
	public override bool Update(){
		gm.playSound (n);
		return true;
	}
}

