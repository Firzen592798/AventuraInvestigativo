using UnityEngine;
using System.Collections;
public class DicionarioAcoes {

	private Hashtable acoesHashtable = new Hashtable();
	public DicionarioAcoes() {
		//============================
		//% Estado 0 de Dark Megaman %
		//============================
		state EduardoState0 = new state();
		
		//**********************************************
		//*******  Acoes OnExamine do estado 0  ********
		//**********************************************
		ArrayList dEduardo_s0 = new ArrayList ();
		dEduardo_s0.Add(new DialogLine ("Capitão Eduardo Hastings", "Oi", "Sinto que vou me arrepender em te-la convidado a passar este fim-de-semana na Mansão Christie. Você parece um tanto chateada"));
		dEduardo_s0.Add(new DialogLine ("Jane", "Testando o dialogo", "Não se incomode comigo, Hastings. Você sabe que meu temperamento não é dos mais sociáveis."));
		/*dEduardo_s0.Add(new DialogLine ("Capitão Eduardo Hastings", "Sim, sim... espero que se divirta, contudo.", ""));
		dEduardo_s0.Add(new DialogLine ("Jane", "O que me incomoda mais é essa sensação de isolamento... não que seja de todo ruim passar um fim-de-semana mais isolado... mas ouça essa chuva...", ""));
		dEduardo_s0.Add(new DialogLine ("Jane", " mesmo que qualquer um de nós precisasse ir lá fora por uma emergência sequer, não poderíamos de tão forte que cai a tempestade... ", ""));
		dEduardo_s0.Add(new DialogLine ("Jane", "estar tão longe de tudo e a este nível de encarceramento desperta meus sentimentos mais alertas.", ""));
		dEduardo_s0.Add(new DialogLine ("Capitão Eduardo Hastings", "Haha, não é necessário estar alerta na mansão Christie. É perfeitamente seguro... se não há como sair, não como entrar, ou seja: nenhum mal virá de fora.", ""));
		dEduardo_s0.Add(new DialogLine ("Jane", "Não me entenda mal, Hastings... não tenho medo de que algo entre aqui... me sinto terrivelmente desconfortável estando preso com essas pessoas...", ""));
		dEduardo_s0.Add(new DialogLine ("Capitão Eduardo Hastings", "Os Christie? Eles são totalmente inofensivos pessoalmente... você deveria temê-los se fosse um empregado da empresa deles... estes sim sofrem em suas mãos...", ""));
		dEduardo_s0.Add(new DialogLine ("Jane", "Nunca se sabe Hastings... acredito que é melhor ficarmos com olhos e ouvidos preparados... estou sentindo que a noite vai ser longa..", ""));
		dEduardo_s0.Add(new DialogLine ("Capitão Eduardo Hastings", "Sendo assim, vou tomar outra taça deste delicioso espumante enquanto a celebração não inicia de fato... Com licença, senhorita.", ""));
		dEduardo_s0.Add(new DialogLine ("Jane", "Ora, largue as formalidades Capitão...", ""));
		dEduardo_s0.Add(new DialogLine ("Capitao Eduardo Hastings", "Apenas uma cordialidade senhorita Terry... e para ser mais cordial vou te dar uma recomendação, aceitas?", ""));
		dEduardo_s0.Add(new DialogLine ("Jane", "Diga, ora.", ""));
		dEduardo_s0.Add(new DialogLine ("Capitão Eduardo Hastings", "Se você possui qualquer interesse em se sentir mais segura esta noite, recomendo que procure conhecer melhor os que estarão presentes nesta cerimônia...", ""));
		dEduardo_s0.Add(new DialogLine ("Jane", "E como eu supostamente deveria fazer isto, Capitão?", ""));
		dEduardo_s0.Add(new DialogLine ("Capitão Eduardo Hastings", "Creio que um rápido reconhecimento do saguão deve bastar... Depois me encontre e diga o que você encontrou. Estarei próximo ao bar.", ""));
		*/Acao eduardo_s0_a0 = new MostrarDialogos(dEduardo_s0);
		ArrayList dEduardo_s0_e = new ArrayList ();
		dEduardo_s0_e.Add(new DialogLine ("Capitao Eduardo Hastings", "E então Jane, encontrou algo?", ""));
		dEduardo_s0_e.Add(new DialogLine ("Jane", "Não... não estou com sorte", ""));
		dEduardo_s0_e.Add(new DialogLine ("Capitao Eduardo Hastings", "Ora... não a conheci desistindo assim tão fácil. Continue... estou certo de que encontrará algo intrigante.", ""));


		Acao eduardo_s0_a0_e = new MostrarDialogos (dEduardo_s0_e);
		EduardoState0.OnInitActions.Add(eduardo_s0_a0);
		EduardoState0.OnExamineAction.Add(eduardo_s0_a0_e);

		acoesHashtable.Add ("Eduardo-0", EduardoState0);

		//============================
		//% Estado 1 de Eduardo
		//============================
		state EduardoState1 = new state();
		ArrayList dEduardo_s1 = new ArrayList ();
		dEduardo_s1.Add(new DialogLine ("Capitao Eduardo Hastings", "E então Jane, encontrou algo?", ""));
		dEduardo_s1.Add(new DialogLine ("Jane", "Sim, esta chave estava embaixo do tapete num canto escuro do saguão.", ""));
		dEduardo_s1.Add(new DialogLine ("Capitão Eduardo Hastings", "Hum, parece ser uma chave GORJA, daquelas que abrem qualquer porta de fechadura simples...", ""));
		dEduardo_s1.Add(new DialogLine ("Capitão Eduardo Hastings", "pode ser muito útil, esta casa é bem velha e talvez você encontre uma porta ou outra que possa  ser aberta com esta chave.", ""));
		Acao eduardo_s1_a0_e = new MostrarDialogos (dEduardo_s1);
		EduardoState1.OnExamineAction.Add (eduardo_s1_a0_e);
		acoesHashtable.Add ("Eduardo-1", EduardoState1);

		//============================
		//% Estado 2 de Eduardo
		//============================
		state EduardoState2 = new state();
		ArrayList dEduardo_s2 = new ArrayList ();
		dEduardo_s2.Add(new DialogLine ("Capitao Eduardo Hastings", "E então Jane, encontrou algo?", ""));
		dEduardo_s2.Add(new DialogLine ("Jane", "Sim, veja: encontrei este pedaço de papel com algumas palavras riscadas.", ""));
		dEduardo_s2.Add(new DialogLine ("Capitão Eduardo Hastings", "Hum... curioso... o nome parece ter sido escrito à caneta... ", ""));
		dEduardo_s2.Add(new DialogLine ("Capitão Eduardo Hastings", "mas os rabiscos rudes que foram feitos por cima foram feitos à lápis... nada que uma borracha não resolva, acredito.", ""));
		Acao eduardo_s2_a0_e = new MostrarDialogos (dEduardo_s2);
		EduardoState2.OnExamineAction.Add (eduardo_s2_a0_e);
		acoesHashtable.Add ("Eduardo-2", EduardoState2);

		//============================
		//% Estado 3 de Eduardo
		//============================
		state EduardoState3 = new state();
		ArrayList dEduardo_s3 = new ArrayList ();
		dEduardo_s3.Add(new DialogLine ("Capitao Eduardo Hastings", "E então Jane, encontrou algo?", ""));
		dEduardo_s3.Add(new DialogLine ("Jane", "Não imaginei que minha busca fosse ser tão fortuita, veja o que encontrei.", ""));
		dEduardo_s3.Add(new DialogLine ("Capitão Eduardo Hastings", "Hum, você parece estar com sorte...", ""));
		dEduardo_s3.Add(new DialogLine ("Jane", "Esta chave estava embaixo do tapete num canto escuro do saguão.", ""));

		dEduardo_s3.Add(new DialogLine ("Capitão Eduardo Hastings", "Hum, parece ser uma chave GORJA, daquelas que abrem qualquer porta de fechadura simples...", ""));
		dEduardo_s3.Add(new DialogLine ("Capitão Eduardo Hastings", " pode ser muito útil, esta casa é bem velha e talvez você encontre uma porta ou outra que possa ser aberta com esta chave...", ""));
		dEduardo_s3.Add(new DialogLine ("Capitão Eduardo Hastings", "o que mais você encontrou?", ""));
		dEduardo_s3.Add(new DialogLine ("Jane", "Também encontrei este pedaço de papel com algumas palavras riscadas.", ""));
		dEduardo_s3.Add(new DialogLine ("Capitão Eduardo Hastings", "Hum... curioso... o nome parece ter sido escrito à caneta... mas os rabiscos rudes ", ""));
		dEduardo_s3.Add(new DialogLine ("Capitão Eduardo Hastings", "que foram feitos por cima foram feitos à lápis... nada que uma borracha não resolva, acredito.", ""));


		Acao eduardo_s3_a0_e = new MostrarDialogos (dEduardo_s3);
		EduardoState3.OnExamineAction.Add (eduardo_s3_a0_e);
		acoesHashtable.Add ("Eduardo-3", EduardoState3);




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
		TapeteState0.OnExamineAction.Add(new MudarEstadoEduardo(1));
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
		PapelState0.OnExamineAction.Add(new MudarEstadoEduardo(2));

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