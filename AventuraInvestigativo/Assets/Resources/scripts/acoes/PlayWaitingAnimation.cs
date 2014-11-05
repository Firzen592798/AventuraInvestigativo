using UnityEngine;
using System.Collections;

public class PlayWaitingAnimation : Acao {

	bool enabled;

	public PlayWaitingAnimation() {
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));

		enabled = true;
	}

	public PlayWaitingAnimation(bool enable) {
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));

		enabled = enable;
	}

	public override bool Update() {
		PlayerController p = gm.getPlayer();
		p.make_wait(enabled);
		return true;
	}
}