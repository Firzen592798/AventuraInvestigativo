using UnityEngine;
using System.Collections;
public class MudarEstado : Acao{
	string personagem;
	int state;
	string condit;
	public MudarEstado(string personagem, int state){
		this.personagem = personagem;
		this.state = state;
		this.condit = null;
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	public MudarEstado(string personagem, int state, string condit)
	{
		this.personagem = personagem;
		this.state = state;
		this.condit = condit;
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	public override bool Update(){
		gm.changeState(personagem, state, condit);
		return true;
	}

}