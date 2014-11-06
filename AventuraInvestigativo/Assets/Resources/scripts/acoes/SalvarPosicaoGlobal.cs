using UnityEngine;
using System.Collections;

public class SalvarPosicaoGlobal : Acao {

	string npcNome;

	public SalvarPosicaoGlobal(string personagem) {
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		npcNome = personagem;
	}

	public SalvarPosicaoGlobal(string personagem, Vector3 pos, int scene_index) {
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		npcNome = personagem;
		//TODO
	}

	public override bool Update () {
		gm.setGlobalPosition(npcNome);
		return true;
	}
}