//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
public class HabilitarMenu : Acao{
	GameController gm;
	bool hab;
	public HabilitarMenu(GameController gm, bool hab){
		this.gm = gm;
		this.hab = hab;
	}
	
	public override bool Update(){
		gm.show_menu_GUI = hab;
		return true;
	}
}