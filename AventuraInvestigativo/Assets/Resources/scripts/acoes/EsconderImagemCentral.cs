using UnityEngine;
using System.Collections;
public class EsconderImagemCentral : Acao
{
	public EsconderImagemCentral()
	{
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	public override bool Update()
	{
		gm.hidebigimage ();
		return true;
	}
}
