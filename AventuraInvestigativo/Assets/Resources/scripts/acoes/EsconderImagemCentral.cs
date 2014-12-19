using UnityEngine;
using System.Collections;
public class EsconderImagemCentral : Acao
{
	public EsconderImagemCentral(GameController gm)
	{
		this.gm = gm;
	}
	public override bool Update()
	{
		gm.GameInterface.hidebigimage ();
		return true;
	}
}
