using UnityEngine;
using System.Collections;

public class SalvarPosicaoGlobal : Acao {
	string npcNome;
	Vector3 position;
	int scene;
	
	public SalvarPosicaoGlobal(GameController gm, string personagem) {
		this.gm = gm;
		npcNome = personagem;
		position = new Vector3();
		scene = -1;
	}

	public SalvarPosicaoGlobal(GameController gm, string personagem, Vector3 pos, int scene_index) {
		this.gm = gm;
		npcNome = personagem;
		position = pos;
		scene = scene_index;
	}

	public override bool Update () {
		if (scene == -1) {
			gm.setGlobalPosition(npcNome);
		}
		else {
			position.z = position.y;
			gm.setGlobalPosition(npcNome, position, scene);
		}
		return true;
	}
}