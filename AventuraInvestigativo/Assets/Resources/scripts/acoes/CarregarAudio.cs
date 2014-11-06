using UnityEngine;
using System.Collections;
public class CarregarAudio : Acao{
	GameController gm;
	int n;
	public CarregarAudio(int num){
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		n = num;
	}
	
	public override bool Update(){
		gm.LoadAudio (n);
		return true;
	}
}

