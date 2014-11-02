using UnityEngine;
using System.Collections;

public class states_PaperObject : DicionarioAcoes
{
	public states_PaperObject()
	{
		//********************************************
		//*****      Papel - Estado 0       **********
		//********************************************
		state PapelState0 = new state(0);
		
		//=================================
		//  Acoes OnExamine do estado 0
		//=================================
		DialogLine papelDialog = new DialogLine ("Papel", "Voce achou um papel!", -1);
		ArrayList dialogosPapel = new ArrayList();
		dialogosPapel.Add (papelDialog);
		Acao mostrarDialogoPapel = new  MostrarDialogos(dialogosPapel);
		//PapelState0.OnExamineAction.Add(new MudarEstadoEduardo(2));
		PapelState0.OnExamineAction.Add(mostrarDialogoPapel);
		PapelState0.OnExamineAction.Add (new AtivarEvento (1));
		PapelState0.OnExamineAction.Add (new MudarEstado ("Eduardo", 2, "(1 & !0)"));
		PapelState0.OnExamineAction.Add(new AdicionarItem("Papel", "sprites/Paper item", true));
		
		AddStateTo(PapelState0);
		//acoesHashtable.Add("Papel-0", PapelState0);
	}
}