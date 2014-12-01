using UnityEngine;
using System.Collections;

public class states_TableObject: DicionarioAcoes
{
	protected GameController gm;
	protected GameObject g;
	public states_TableObject ()
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
		TapeteState0.SettingActions.Add(new SalvarPosicaoGlobal(gm, "Mesa"));
		
		//=================================
		//  Acoes OnExamine do estado 0
		//=================================
		DialogLine tapete1 = new DialogLine ("Mesa", "Voce achou um papel secreto", -1);
		DialogLine tapete2 = new DialogLine ("Mesa", "O papel foi adicionado no seu inventorio", -1);
		ArrayList dialogosTapete = new ArrayList();
		dialogosTapete.Add (tapete1);
		dialogosTapete.Add (tapete2);
		Conversa c0 = new Conversa ("Dialogo da mesa", dialogosTapete);
		Acao mostrarDialogoTapete = new  MostrarDialogos(gm, c0);
		TapeteState0.OnExamineAction.Add(mostrarDialogoTapete);
		//TapeteState0.OnExamineAction.Add(new MudarEstadoEduardo(1));
		TapeteState0.OnExamineAction.Add(new AdicionarItem(gm, "Papel", "sprites/Paper item", false));
		TapeteState0.OnExamineAction.Add(new AtivarEvento(gm, 1));
		TapeteState0.OnExamineAction.Add(new MudarEstado(gm, "Eduardo",2,"(!0 & 1)"));
		TapeteState0.OnExamineAction.Add(new MudarEstado(gm, "Mesa", 1));
		
		AddStateTo(TapeteState0);
		//acoesHashtable.Add("Tapete-0", TapeteState0);
		
		//********************************************
		//*****      Tapete - Estado 1       *********
		//********************************************
		state TapeteState1 = new state(1);

		TapeteState1.OnInitActions.Add (new TornarExaminavel (gm, "Mesa", false));
		//=================================
		//  Acoes OnExamine do estado 1
		//=================================
		DialogLine dialogoTapeteVazio = new DialogLine ("Mesa", "Nao ha nada aqui", -1);
		//ArrayList dialogosTapeteVazio = new ArrayList();
		//dialogosTapeteVazio.Add (tapetevazio);
		Conversa c1 = new Conversa ("Dialogo tapete vazio", dialogoTapeteVazio);
		Acao mostrarDialogoTapeteVazio = new MostrarDialogos(gm, c1);
		TapeteState1.OnExamineAction.Add(mostrarDialogoTapeteVazio);
		
		AddStateTo(TapeteState1);
		//acoesHashtable.Add("Tapete-1", TapeteState1);
	}
}

