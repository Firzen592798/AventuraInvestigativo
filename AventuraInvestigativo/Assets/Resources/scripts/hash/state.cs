using System.Collections;
using UnityEngine;

public class state {
	public int id;
	public ArrayList SettingActions;
	public ArrayList OnInitActions;
	public ArrayList OnExamineAction;
	public Vector3 ObjectPos;
	
	public state (int state_num) {
		id = state_num;
		SettingActions = new ArrayList();
		OnInitActions = new ArrayList();
		OnExamineAction = new ArrayList();
	}
	public void setPos (Vector3 pos)
	{
		ObjectPos = pos;
	}
}