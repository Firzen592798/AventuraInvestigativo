using UnityEngine;
using System.Collections;

public class states_CarpetObject: DicionarioAcoes
{
	protected GameController gm;
	protected GameObject g;
	public states_CarpetObject ()
	{
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		setInitState(0);

		//********************************************
		//*****      Tapete - Estado 0       *********
		//********************************************
		state TapeteState0 = new state(0);

		//=================================
		//  Acoes Settings do estado 0
		//=================================
		TapeteState0.SettingActions.Add(new SalvarPosicaoGlobal(gm, "Tapete"));

		//=================================
		//  Acoes OnExamine do estado 0
		//=================================
		DialogLine tapete1 = new DialogLine ("Voce achou uma chave secreta", -1);
		DialogLine tapete2 = new DialogLine ("A chave foi adicionada no seu inventorio", -1);
		ArrayList dialogosTapete = new ArrayList();
		dialogosTapete.Add (tapete1);
		dialogosTapete.Add (tapete2);
		Acao mostrarDialogoTapete = new  MostrarDialogos(gm, dialogosTapete);
		TapeteState0.OnExamineAction.Add(mostrarDialogoTapete);
		//TapeteState0.OnExamineAction.Add(new MudarEstadoEduardo(1));
		TapeteState0.OnExamineAction.Add(new AdicionarItem(gm, "Chave", "sprites/Key item", false));
		TapeteState0.OnExamineAction.Add(new AtivarEvento(gm, 0));
		TapeteState0.OnExamineAction.Add(new MudarEstado(gm, "Eduardo",1,"(0 & !1)"));
		TapeteState0.OnExamineAction.Add(new MudarEstado(gm, "Tapete", 1));
		
		AddStateTo(TapeteState0);
		//acoesHashtable.Add("Tapete-0", TapeteState0);
		
		//********************************************
		//*****      Tapete - Estado 1       *********
		//********************************************
		state TapeteState1 = new state(1);
		
		//=================================
		//  Acoes OnExamine do estado 1
		//=================================
		DialogLine dialogoTapeteVazio = new DialogLine ("Nao ha nada aqui", -1);
		//ArrayList dialogosTapeteVazio = new ArrayList();
		//dialogosTapeteVazio.Add (tapetevazio);
		
		Acao mostrarDialogoTapeteVazio = new MostrarDialogos(gm, dialogoTapeteVazio);
		TapeteState1.OnExamineAction.Add(mostrarDialogoTapeteVazio);
		
		AddStateTo(TapeteState1);
		//acoesHashtable.Add("Tapete-1", TapeteState1);
	}
}

