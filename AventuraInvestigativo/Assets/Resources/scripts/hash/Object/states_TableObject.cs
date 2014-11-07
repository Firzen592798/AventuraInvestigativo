using UnityEngine;
using System.Collections;

public class states_TableObject: DicionarioAcoes
{
	public states_TableObject ()
	{
		setInitState(0);
		
		//********************************************
		//*****      Tapete - Estado 0       *********
		//********************************************
		state TapeteState0 = new state(0);
		
		//=================================
		//  Acoes Settings do estado 0
		//=================================
		TapeteState0.SettingActions.Add(new SalvarPosicaoGlobal("Mesa"));
		
		//=================================
		//  Acoes OnExamine do estado 0
		//=================================
		DialogLine tapete1 = new DialogLine ("Mesa", "Voce achou um papel secreto", -1);
		DialogLine tapete2 = new DialogLine ("Mesa", "O papel foi adicionado no seu inventorio", -1);
		ArrayList dialogosTapete = new ArrayList();
		dialogosTapete.Add (tapete1);
		dialogosTapete.Add (tapete2);
		Acao mostrarDialogoTapete = new  MostrarDialogos(dialogosTapete);
		TapeteState0.OnExamineAction.Add(mostrarDialogoTapete);
		//TapeteState0.OnExamineAction.Add(new MudarEstadoEduardo(1));
		TapeteState0.OnExamineAction.Add(new AdicionarItem("Papel", "sprites/Paper item", false));
		TapeteState0.OnExamineAction.Add(new AtivarEvento(1));
		TapeteState0.OnExamineAction.Add(new MudarEstado("Eduardo",2,"(!0 & 1)"));
		TapeteState0.OnExamineAction.Add(new MudarEstado("Mesa", 1));
		
		AddStateTo(TapeteState0);
		//acoesHashtable.Add("Tapete-0", TapeteState0);
		
		//********************************************
		//*****      Tapete - Estado 1       *********
		//********************************************
		state TapeteState1 = new state(1);
		
		//=================================
		//  Acoes OnExamine do estado 1
		//=================================
		DialogLine dialogoTapeteVazio = new DialogLine ("Mesa", "Nao ha nada aqui", -1);
		//ArrayList dialogosTapeteVazio = new ArrayList();
		//dialogosTapeteVazio.Add (tapetevazio);
		
		Acao mostrarDialogoTapeteVazio = new MostrarDialogos(dialogoTapeteVazio);
		TapeteState1.OnExamineAction.Add(mostrarDialogoTapeteVazio);
		
		AddStateTo(TapeteState1);
		//acoesHashtable.Add("Tapete-1", TapeteState1);
	}
}

