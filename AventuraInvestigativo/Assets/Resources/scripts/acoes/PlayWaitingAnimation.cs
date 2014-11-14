using UnityEngine;
using System.Collections;

public class PlayWaitingAnimation : Acao {

	bool enabled;

	public PlayWaitingAnimation(GameController gm) {

		this.gm = gm;
		enabled = true;
	}

	public PlayWaitingAnimation(GameController gm, bool enable) {
		this.gm = gm;

		enabled = enable;
	}

	public override bool Update() {
		PlayerController p = gm.getPlayer();
		p.make_wait(enabled);
		return true;
	}
}