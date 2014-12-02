//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
public class TornarExaminavel : Acao{
	private string npcNome;
	private bool examinable;

	public TornarExaminavel(GameController gm, string npc, bool examinable)
	{
		this.gm = gm;
		npcNome = npc;
		this.examinable = examinable;
	}
	
	public override bool Update() {
		gm.setExaminable (npcNome, examinable);
		return true;
	}
	
	
}