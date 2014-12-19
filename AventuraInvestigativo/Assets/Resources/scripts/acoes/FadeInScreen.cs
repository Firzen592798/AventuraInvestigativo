using UnityEngine;
using System.Collections;

public class FadeInScreen : Acao{

	public FadeInScreen(GameController gm)
	{
		this.gm = gm;
	}

	public override bool Update()
	{
		return gm.GameInterface.FadeToClear ();
	}
}