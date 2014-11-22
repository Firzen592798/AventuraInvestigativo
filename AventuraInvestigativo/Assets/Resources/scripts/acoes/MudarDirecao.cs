using UnityEngine;
using System.Collections;

public class MudarDirecao : Acao {
	private ObjectController NPC;
	private string personagem;
	private int dirX;
	private int dirY;

	/// <summary>
	/// <para>Horizontal:</para>
	/// <para>'L' ou 'l' = esquerda</para>
	/// <para>'R' ou 'r' = direita</para>
	/// <para>'N' ou 'n' = nulo</para>
	/// <para></para>
	/// <para>Vertical:</para>
	/// <para>'U' ou 'u' = cima</para>
	/// <para>'D' ou 'd' = baixo</para>
	/// <para>'N' ou 'n' = nulo</para>
	/// </summary>
	/// <param name="gm">Gm.</param>
	/// <param name="personagem">Personagem.</param>
	/// <param name="HorizontalDir">Horizontal dir.</param>
	/// <param name="VerticalDir">Vertical dir.</param>
	public MudarDirecao(GameController gm, string personagem, char HorizontalDir, char VerticalDir) {
		this.gm = gm;
		this.personagem = personagem;
		dirX = -2;
		dirY = -2;
		string hcod = HorizontalDir.ToString().ToUpper();
		if (hcod == "L") {
			dirX = -1;
		}
		else if (hcod == "R") {
			dirX = 1;
		}
		else if (hcod == "N") {
			dirX = 0;
		}

		string vcod = VerticalDir.ToString().ToUpper();
		if (vcod == "U") {
			dirY = 1;
		}
		else if (vcod == "D") {
			dirY = -1;
		}
		else if (vcod == "N") {
			dirY = 0;
		}
	}

	public override bool Update() {
		NPC = gm.getNPC(personagem);
		if ((dirX != -2)&&(dirY != -2)) {
			if ((dirX != 0)||(dirY != 0)) {
				NPC.changeDirection(dirX, dirY);
			}
		}
		return true;
	}
}