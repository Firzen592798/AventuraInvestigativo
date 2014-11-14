using UnityEngine;
using System.Collections;
public class MudarEstado : Acao{
	string personagem;
	int state;
	string condit;
	public MudarEstado(GameController gm, string personagem, int state){
		this.personagem = personagem;
		this.state = state;
		this.condit = null;
		this.gm = gm;
	}

	public MudarEstado(GameController gm, string personagem, int state, string condit)
	{
		this.personagem = personagem;
		this.state = state;
		this.condit = condit;
		this.gm = gm;
	}

	public override bool Update(){
		gm.changeState(personagem, state, condit);
		return true;
	}

}