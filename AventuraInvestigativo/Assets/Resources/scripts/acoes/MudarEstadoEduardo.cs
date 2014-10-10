using UnityEngine;
using System.Collections;
public class MudarEstadoEduardo : Acao{
	string personagem;
	GameController gm;
	Inventorio inventorio;
	int state;
	string item;
	public MudarEstadoEduardo(int state){
		this.personagem = personagem;
		this.state = state;
		Debug.Log ("Criando estado " + state);
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	public override bool Update(){
		Debug.Log ("Mudou estado eduardo: "+state);
		if (!gm.TemItem ("Chave") && !gm.TemItem ("Papel")) {
			gm.changeState("Eduardo", state);
		}else{
			gm.changeState("Eduardo", 3);
		}
		return true;
	}	
}