using UnityEngine;
using System.Collections;

public class FadeInScreen : Acao{

	public FadeInScreen()
	{
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	public override bool Update()
	{
		return gm.FadeToClear ();
	}
}