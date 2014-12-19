using UnityEngine;
using System.Collections;

public class FadeOutScreen : Acao{
	
	public FadeOutScreen(GameController gm)
	{
		this.gm = gm;
	}
	
	public override bool Update()
	{
		return gm.GameInterface.FadeToBlack ();
	}
}
