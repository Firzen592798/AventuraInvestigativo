using UnityEngine;
using System.Collections;
public class DicionarioAcoes {

	private Hashtable acoesHashtable = new Hashtable();
	public DicionarioAcoes() {


		//============================
		//% Estado 0 de Eduardo      %
		//============================
		state EduardoState0 = new state();

		//**********************************************
		//*******  Acoes OnInit do estado 0  ***********
		//**********************************************
		Acao a = new MoverPersonagem("Eduardo", new Vector3(0f,0f,0f), true);
		EduardoState0.OnInitActions.Add(a);

		// fim acoes de Eduardo
		acoesHashtable.Add("Eduardo-0", EduardoState0);

		//###############################################################################################

		//============================
		//% Estado 0 de Dark Megaman %
		//============================
		state DarkMegamanState0 = new state();

		//**********************************************
		//*******  Acoes OnExamine do estado 0  ********
		//**********************************************
		DialogLine d1 = new DialogLine ("Dark Megaman", "Oi", "");
		DialogLine d2 = new DialogLine ("Dark Megaman", "Testando o dialogo", "");
		DialogLine d3 = new DialogLine ("Dark Megaman", "Victor Hugo", "");
		DialogLine d4 = new DialogLine ("Dark Megaman", "Gin", "");
		ArrayList dialogos = new ArrayList ();
		dialogos.Add (d1);
		dialogos.Add (d2);
		dialogos.Add (d3);
		dialogos.Add (d4);
		Acao a1 = new MostrarDialogos(dialogos);
		ArrayList escolhas = new ArrayList ();
		escolhas.Add (new Escolha ("Mudar o estado", 1));
		escolhas.Add (new Escolha ("Sai pra la", 2));
		escolhas.Add (new Escolha ("Fazer nada", 0));
		Acao a2 = new MostrarEscolhas(new DialogLine("Dark Megaman", "O que voce deseja?", ""), escolhas);

	//	ArrayList acoesDarkMegamanEstadoZero = new ArrayList();
	//	acoesDarkMegamanEstadoZero.Add (a1);
	//	acoesDarkMegamanEstadoZero.Add (a2);
	//	acoesHashtable.Add("Dark Megaman-0", acoesDarkMegamanEstadoZero);


		DarkMegamanState0.OnExamineAction.Add(a1);
		DarkMegamanState0.OnExamineAction.Add(a2);

		//**********************************************
		//********  Acoes OnInit do estado 0  **********
		//**********************************************
		DialogLine d5 = new DialogLine("Dark Megaman", "E ae! Esse eh um dialogo gerado assim que\nvc entrou nesse quarto!", "");
		DialogLine d6 = new DialogLine("Dark Megaman", "Aproveite esse teste inutil", "");
		DialogLine d7 = new DialogLine("Dark Megaman", "HUAHUAHUAHUAHUA", "");
		DialogLine d8 = new DialogLine("Dark Megaman", "GOTY!", "");

		ArrayList dialogos1 = new ArrayList();
		dialogos1.Clear();
		dialogos1.Add(d5);
		dialogos1.Add(d6);
		dialogos1.Add(d7);
		dialogos1.Add(d8);
		Acao a3 = new MostrarDialogos(dialogos1);

		DarkMegamanState0.OnInitActions.Add(a3);

		// fim estado 0 do Dark Megaman
		acoesHashtable.Add("Dark Megaman-0", DarkMegamanState0);

		//####################################################################################################

		//============================
		//% Estado 1 de Dark Megaman %
		//============================
		state DarkMegamanState1 = new state();

		//**********************************************
		//*******  Acoes OnExamine do estado 1  ********
		//**********************************************

		DialogLine d1e1 = new DialogLine ("Dark Megaman", "Mudando o estado", "");
		DialogLine d2e1 = new DialogLine ("Dark Megaman", "Testando o novo dialogo", "");
		ArrayList dialogos2 = new ArrayList();
		dialogos2.Add (d1e1);
		dialogos2.Add (d2e1);
		Acao a1e1 = new  MostrarDialogos(dialogos2);
		DarkMegamanState1.OnExamineAction.Add(a1e1);
		acoesHashtable.Add("Dark Megaman-1", DarkMegamanState1);

		// fim estado 1 do Dark Megaman
		//####################################################################################################
		
		//============================
		//% Estado 2 de Dark Megaman %
		//============================
		state DarkMegamanState2 = new state();
		
		//**********************************************
		//*******  Acoes OnExamine do estado 2  ********
		//**********************************************


		//**********************************************
		//*******  Acoes OnInit do estado 2  ********
		//**********************************************

		//Acao acaoMover = new MoverPersonagem();
		//ArrayList acoesDarkMegamanEstadoDois = new ArrayList();
		//acoesDarkMegamanEstadoDois.Add (acaoMover);
		//DarkMegamanState2.OnInitActions.Add(acaoMover);
		//acoesHashtable.Add("Dark Megaman-2", DarkMegamanState2);

		//============================
		//% Estado 0 de Tapete
		//============================
		state TapeteState0 = new state();
		
		//**********************************************
		//*******  Acoes OnExamine do estado 0 do tapete
		//**********************************************
		
		DialogLine tapete1 = new DialogLine ("Tapete", "Voce achou uma chave secreta", "");
		DialogLine tapete2 = new DialogLine ("Dark Megaman", "A chave foi adicionada no seu inventorio", "");
		ArrayList dialogosTapete = new ArrayList();
		dialogosTapete.Add (tapete1);
		dialogosTapete.Add (tapete2);
		Acao mostrarDialogoTapete = new  MostrarDialogos(dialogosTapete);
		TapeteState0.OnExamineAction.Add(mostrarDialogoTapete);
		TapeteState0.OnExamineAction.Add(new AdicionarItem("Chave", "sprites/chave", false));
		TapeteState0.OnExamineAction.Add(new MudarEstado("Tapete", 1));
		acoesHashtable.Add("Tapete-0", TapeteState0);

		//============================
		//% Estado 1 do Tapete
		//============================

		state TapeteState1 = new state();

		//**********************************************
		//*******  Acoes OnExamine do estado 1 do tapete
		//**********************************************
		
		DialogLine tapetevazio = new DialogLine ("Tapete", "Nao ha nada aqui", "");
		ArrayList dialogosTapeteVazio = new ArrayList();
		dialogosTapeteVazio.Add (tapetevazio);

		Acao mostrarDialogoTapeteVazio = new  MostrarDialogos(dialogosTapeteVazio);
		TapeteState1.OnExamineAction.Add(mostrarDialogoTapeteVazio);
		acoesHashtable.Add("Tapete-1", TapeteState1);
	
		
		//============================
		//% Estado 0 do Papel
		//============================
		
		state PapelState0 = new state();
		
		//**********************************************
		//*******  Acoes OnExamine do estado 0 do papel
		//**********************************************
		
		DialogLine papelDialog = new DialogLine ("Papel", "Voce achou um papel!", "");
		ArrayList dialogosPapel = new ArrayList();
		dialogosPapel.Add (papelDialog);
		Acao mostrarDialogoPapel = new  MostrarDialogos(dialogosPapel);
		PapelState0.OnExamineAction.Add(mostrarDialogoPapel);
		PapelState0.OnExamineAction.Add(new AdicionarItem("Papel", "sprites/papel", true));
		acoesHashtable.Add("Papel-0", PapelState0);
		//TapeteState0.OnExamineAction.Add(new MudarEstado("Tapete", 1));
		//acoesHashtable.Add("Tapete-0", TapeteState0);

	}
	
	public state getStatePersonagem(string personagem, int estado){
		return (state)acoesHashtable[personagem + "-" + estado];
	}
}

public class state {
	public ArrayList SettingActions;
	public ArrayList OnInitActions;
	public ArrayList OnExamineAction;

	public state () {
		SettingActions = new ArrayList();
		OnInitActions = new ArrayList();
		OnExamineAction = new ArrayList();
	}
}