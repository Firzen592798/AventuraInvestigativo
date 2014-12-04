using UnityEngine;
using System.Collections;

public class InicializarPosicaoGlobal : Acao {
	string npcNome;
	Vector3 position;
	int scene;
	
	public InicializarPosicaoGlobal(GameController gm, string personagem) {
		this.gm = gm;
		npcNome = personagem;
	}

	public override bool Update() {
		PositionGlobal gpos = gm.getGlobalPosition(npcNome);
		Debug.Log("gpos.initialized ="+gpos.initialized);
		if (!gpos.initialized) {
			gm.setGlobalPosition(npcNome);
		}
		return true;
	}
}