//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
public class HabilitarMenu : Acao{

	bool hab;
	public HabilitarMenu(GameController gm, bool hab){
		this.gm = gm;
		this.hab = hab;
	}
	
	public override bool Update(){
		gm.GameInterface.ShowingQuickMenuGUI = hab;
		//gm.show_menu_GUI = hab;
		return true;
	}
}