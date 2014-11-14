using UnityEngine;
using System.Collections;
public class CarregarAudio : Acao{
	int n;
	public CarregarAudio(GameController gm, int num){
		this.gm = gm;
		n = num;
	}
	
	public override bool Update(){
		gm.LoadAudio (n);
		return true;
	}
}

