using UnityEngine;
using System.Collections;

public class SalvarPosicaoGlobal : Acao {

	string npcNome;
	public SalvarPosicaoGlobal(GameController gm, string personagem) {
		this.gm = gm;
		npcNome = personagem;
	}

	public SalvarPosicaoGlobal(GameController gm, string personagem, Vector3 pos, int scene_index) {
		this.gm = gm;
		npcNome = personagem;
		//TODO
	}

	public override bool Update () {
		gm.setGlobalPosition(npcNome);
		return true;
	}
}