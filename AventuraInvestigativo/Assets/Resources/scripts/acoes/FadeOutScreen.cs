using UnityEngine;
using System.Collections;

public class FadeOutScreen : Acao{
	
	public FadeOutScreen()
	{
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	public override bool Update()
	{
		return gm.FadeToBlack ();
	}
}
