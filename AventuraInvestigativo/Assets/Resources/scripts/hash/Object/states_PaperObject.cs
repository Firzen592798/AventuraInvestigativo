using UnityEngine;
using System.Collections;

public class states_PaperObject : DicionarioAcoes
{
	protected GameController gm;
	protected GameObject g;
	public states_PaperObject()
	{
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		setInitState(0);

		//********************************************
		//*****      Papel - Estado 0       **********
		//********************************************
		state PapelState0 = new state(0);

		//=================================
		//  Acoes Settings do estado 0
		//=================================
		PapelState0.SettingActions.Add(new SalvarPosicaoGlobal(gm, "Papel"));

		//=================================
		//  Acoes OnExamine do estado 0
		//=================================
		DialogLine papelDialog = new DialogLine("Papel", "Voce achou um papel!", -1);
		//ArrayList dialogosPapel = new ArrayList();
		//dialogosPapel.Add (papelDialog);
		Conversa c0 = new Conversa ("Papel", papelDialog);
		Acao mostrarDialogoPapel = new  MostrarDialogos(gm, c0);

		PapelState0.OnExamineAction.Add(mostrarDialogoPapel);
		PapelState0.OnExamineAction.Add(new AtivarEvento (gm, 1));
		PapelState0.OnExamineAction.Add(new MudarEstado (gm, "Eduardo", 2, "(1 & !0)"));
		PapelState0.OnExamineAction.Add(new AdicionarItem(gm, "Papel", "sprites/Paper item", true));
		
		AddStateTo(PapelState0);
		//acoesHashtable.Add("Papel-0", PapelState0);
	}
}