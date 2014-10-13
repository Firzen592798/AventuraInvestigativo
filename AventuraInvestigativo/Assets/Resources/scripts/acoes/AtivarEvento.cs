using UnityEngine;
using System.Collections;

public class AtivarEvento : Acao
{
	int n;
	public AtivarEvento(int ev_num)
	{
		n = ev_num;
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	public override bool Update()
	{
		gm.activateEvent (n);
		return true;
	}
}

