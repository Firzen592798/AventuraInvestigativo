using UnityEngine;
using System.Collections;
public class MudarEstado : Acao{
	string personagem;
	GameController gm;
	int state;
	public MudarEstado(string personagem, int state){
		this.personagem = personagem;
		this.state = state;
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	public override bool Update(){
		gm.changeState(personagem, state);
		return true;
	}
	
	
}