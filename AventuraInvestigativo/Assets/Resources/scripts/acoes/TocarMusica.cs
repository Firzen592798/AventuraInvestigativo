using UnityEngine;
using System.Collections;
public class TocarMusica : Acao{
	GameController gm;
	int n;
	int t;
	public TocarMusica(int num,int tp){
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		n = num;
		t = tp;
	}
	
	public override bool Update(){
		gm.playSound (n, t);
		return true;
	}
}

