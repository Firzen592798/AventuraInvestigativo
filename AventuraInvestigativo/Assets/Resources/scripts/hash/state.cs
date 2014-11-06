using System.Collections;
using UnityEngine;

public class state {
	public int id;
	public ArrayList SettingActions;
	public ArrayList OnInitActions;
	public ArrayList OnExamineAction;
	
	public state (int state_num) {
		id = state_num;
		SettingActions = new ArrayList();
		OnInitActions = new ArrayList();
		OnExamineAction = new ArrayList();
	}
}