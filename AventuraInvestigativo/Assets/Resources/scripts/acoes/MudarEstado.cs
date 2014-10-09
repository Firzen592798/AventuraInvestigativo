using UnityEngine;
using System.Collections;
public class MudarEstado : Acao{
	string personagem;
	GameController gm;
	public MudarEstado(string personagem, int state){
		this.personagem = personagem;
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	public override bool Update(){
		gm.changeState(personagem, 1);
		return true;
	}
	
	
}