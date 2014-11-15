using UnityEngine;
using System.Collections;

public class DesativarEvento : Acao
{
	int n;
	public DesativarEvento(GameController gm, int ev_num)
	{
		n = ev_num;
		this.gm = gm;
	}
	
	public override bool Update()
	{
		gm.deactivateEvent(n);
		return true;
	}
}