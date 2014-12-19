using UnityEngine;
using System.Collections;

public class AtivarEvento : Acao
{
	int n;

	public AtivarEvento(GameController gm, int ev_num)
	{
		n = ev_num;
		this.gm = gm;
	}

	public override bool Update()
	{
		gm.activateEvent(n);
		return true;
	}
}

