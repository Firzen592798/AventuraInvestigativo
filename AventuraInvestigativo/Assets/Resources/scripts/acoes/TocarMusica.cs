using UnityEngine;
using System.Collections;
public class TocarMusica : Acao{

	int n;
	int t;
	public TocarMusica(GameController gm, int num,int tp){
		this.gm = gm;
		n = num;
		t = tp;
	}
	
	public override bool Update(){
		gm.playSound (n, t);
		return true;
	}
}

