using UnityEngine;
using System.Collections;

public class DesativarEvento : Acao
{
	int n;
	public DesativarEvento(int ev_num)
	{
		n = ev_num;
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	public override bool Update()
	{
		gm.deactivateEvent(n);
		return true;
	}
}