using UnityEngine;
using System.Collections;
public class DicionarioAcoes {

	private Hashtable acoesHashtable = new Hashtable();
	public DicionarioAcoes() {
		//********************************************
		//*****      Eduardo - Estado 0      *********
		//********************************************
		state EduardoState0 = new state(0);

		//=================================
		//  Acoes OnInit do estado 0
		//=================================
		Acao move = new MoverPersonagem("Eduardo", Vector3.zero, true);

		ArrayList dEduardo_s0 = new ArrayList ();
		dEduardo_s0.Add (new DialogLine ("", "Para passar o texto ou interagir aperte a tecla Z.", 0, 0)); 
		dEduardo_s0.Add (new DialogLine ("", "Para acessar o menu clique com o botão direito do mouse.", 0, 0)); 
		dEduardo_s0.Add(new DialogLine ("Eduardo Hastings", "Oi, Sinto que vou me arrepender em te-la convidado a passar este fim-de-semana na Mansão Christie. Você parece um tanto chateada.", 1, 1));
		dEduardo_s0.Add(new DialogLine ("Jane", "Não se incomode comigo, Hastings. Você sabe que meu temperamento não é dos mais sociáveis.", 0, 0));
		dEduardo_s0.Add(new DialogLine ("Eduardo Hastings", "Sim, sim... espero que se divirta, contudo.", 1,1));
		dEduardo_s0.Add(new DialogLine ("Jane", "O que me incomoda mais é essa sensação de isolamento... não que seja de todo ruim passar um fim-de-semana mais isolado... mas ouça essa chuva...", 0,0));
		dEduardo_s0.Add(new DialogLine ("Jane", " mesmo que qualquer um de nós precisasse ir lá fora por uma emergência sequer, não poderíamos de tão forte que cai a tempestade... ", 0,0));
		dEduardo_s0.Add(new DialogLine ("Jane", "estar tão longe de tudo e a este nível de encarceramento desperta meus sentimentos mais alertas.", 0,0));
		dEduardo_s0.Add(new DialogLine ("Eduardo Hastings", "Haha, não é necessário estar alerta na mansão Christie. É perfeitamente seguro... se não há como sair, não como entrar, ou seja: nenhum mal virá de fora.", 1,1));
		dEduardo_s0.Add(new DialogLine ("Jane", "Não me entenda mal, Hastings... não tenho medo de que algo entre aqui... me sinto terrivelmente desconfortável estando preso com essas pessoas...", 0,0));
		dEduardo_s0.Add(new DialogLine ("Eduardo Hastings", "Os Christie? Eles são totalmente inofensivos pessoalmente... você deveria temê-los se fosse um empregado da empresa deles... estes sim sofrem em suas mãos...", 1,1));
		dEduardo_s0.Add(new DialogLine ("Jane", "Nunca se sabe Hastings... acredito que é melhor ficarmos com olhos e ouvidos preparados... estou sentindo que a noite vai ser longa..", 0,0));
		dEduardo_s0.Add(new DialogLine ("Eduardo Hastings", "Sendo assim, vou tomar outra taça deste delicioso espumante enquanto a celebração não inicia de fato... Com licença, senhorita.", 1,1));
		dEduardo_s0.Add(new DialogLine ("Jane", "Ora, largue as formalidades Capitão...", 0,0));
		dEduardo_s0.Add(new DialogLine ("Eduardo Hastings", "Apenas uma cordialidade senhorita Terry... e para ser mais cordial vou te dar uma recomendação, aceitas?", 1,1));
		dEduardo_s0.Add(new DialogLine ("Jane", "Diga, ora.", 0,0));
		dEduardo_s0.Add(new DialogLine ("Eduardo Hastings", "Se você possui qualquer interesse em se sentir mais segura esta noite, recomendo que procure conhecer melhor os que estarão presentes nesta cerimônia...", 1,1));
		dEduardo_s0.Add(new DialogLine ("Jane", "E como eu supostamente deveria fazer isto, Capitão?", 0,0));
		dEduardo_s0.Add(new DialogLine ("Eduardo Hastings", "Creio que um rápido reconhecimento do saguão deve bastar... Depois me encontre e diga o que você encontrou. Estarei próximo ao bar.", 1,1));

		Acao eduardo_s0_a0 = new MostrarDialogos(dEduardo_s0);

		EduardoState0.OnInitActions.Add(move);
		EduardoState0.OnInitActions.Add(eduardo_s0_a0);

		//=================================
		//  Acoes OnExamine do estado 0
		//=================================
		ArrayList dEduardo_s0_e = new ArrayList ();
		dEduardo_s0_e.Add(new DialogLine ("Eduardo Hastings", "E então Jane, encontrou algo?", 1, 1));
		dEduardo_s0_e.Add(new DialogLine ("Jane", "Não... não estou com sorte", 0, 0));
		dEduardo_s0_e.Add(new DialogLine ("Eduardo Hastings", "Ora... não a conheci desistindo assim tão fácil. Continue... estou certo de que encontrará algo intrigante.", 1, 1));


		Acao eduardo_s0_a0_e = new MostrarDialogos (dEduardo_s0_e);
		EduardoState0.OnExamineAction.Add(eduardo_s0_a0_e);

		AddStateTo("Eduardo", EduardoState0);
		//acoesHashtable.Add ("Eduardo-0", EduardoState0);


		//********************************************
		//*****      Eduardo - Estado 1       ********
		//********************************************
		state EduardoState1 = new state(1);

		//=================================
		//  Acoes OnExamine do estado 1
		//=================================
		ArrayList dEduardo_s1 = new ArrayList ();
		dEduardo_s1.Add(new DialogLine ("Eduardo Hastings", "E então Jane, encontrou algo?", 1, 1));
		dEduardo_s1.Add(new DialogLine ("Jane", "Sim, esta chave estava embaixo do tapete num canto escuro do saguão.", 0,0));
		dEduardo_s1.Add(new DialogLine ("Eduardo Hastings", "Hum, parece ser uma chave GORJA, daquelas que abrem qualquer porta de fechadura simples...", 1, 1));
		dEduardo_s1.Add(new DialogLine ("Eduardo Hastings", "pode ser muito útil, esta casa é bem velha e talvez você encontre uma porta ou outra que possa  ser aberta com esta chave.", 1, 1));
		Acao eduardo_s1_a0_e = new MostrarDialogos (dEduardo_s1);
		EduardoState1.OnExamineAction.Add(new MudarEstado("Eduardo",3,"0 1 &"));
		EduardoState1.OnExamineAction.Add (eduardo_s1_a0_e);

		AddStateTo("Eduardo", EduardoState1);
		//acoesHashtable.Add ("Eduardo-1", EduardoState1);

		//********************************************
		//*****      Eduardo - Estado 2       ********
		//********************************************
		state EduardoState2 = new state(2);
		ArrayList dEduardo_s2 = new ArrayList ();
		dEduardo_s2.Add(new DialogLine ("Eduardo Hastings", "E então Jane, encontrou algo?", 1, 1));
		dEduardo_s2.Add(new DialogLine ("Jane", "Sim, veja: encontrei este pedaço de papel com algumas palavras riscadas.", 0, 0));
		dEduardo_s2.Add(new DialogLine ("Eduardo Hastings", "Hum... curioso... o nome parece ter sido escrito à caneta... ", 1, 1));
		dEduardo_s2.Add(new DialogLine ("Eduardo Hastings", "mas os rabiscos rudes que foram feitos por cima foram feitos à lápis... nada que uma borracha não resolva, acredito.", 1, 1));
		Acao eduardo_s2_a0_e = new MostrarDialogos (dEduardo_s2);
		EduardoState2.OnExamineAction.Add(new MudarEstado("Eduardo",3,"0 1 &"));
		EduardoState2.OnExamineAction.Add (eduardo_s2_a0_e);

		AddStateTo("Eduardo", EduardoState2);
		//acoesHashtable.Add ("Eduardo-2", EduardoState2);

		//********************************************
		//*****      Eduardo - Estado 3      *********
		//********************************************
		state EduardoState3 = new state(3);
		ArrayList dEduardo_s3 = new ArrayList ();
		dEduardo_s3.Add(new DialogLine ("Eduardo Hastings", "E então Jane, encontrou algo?", 1,1));
		dEduardo_s3.Add(new DialogLine ("Jane", "Não imaginei que minha busca fosse ser tão fortuita, veja o que encontrei.", 0, 0));
		dEduardo_s3.Add(new DialogLine ("Eduardo Hastings", "Hum, você parece estar com sorte...", 1, 1));
		dEduardo_s3.Add(new DialogLine ("Jane", "Esta chave estava embaixo do tapete num canto escuro do saguão.", 0, 0));

		dEduardo_s3.Add(new DialogLine ("Eduardo Hastings", "Hum, parece ser uma chave GORJA, daquelas que abrem qualquer porta de fechadura simples...", 1, 1));
		dEduardo_s3.Add(new DialogLine ("Capitão Eduardo Hastings", " pode ser muito útil, esta casa é bem velha e talvez você encontre uma porta ou outra que possa ser aberta com esta chave...", 1, 1));
		dEduardo_s3.Add(new DialogLine ("Eduardo Hastings", "o que mais você encontrou?", 1, 1));
		dEduardo_s3.Add(new DialogLine ("Jane", "Também encontrei este pedaço de papel com algumas palavras riscadas.", 0, 0));
		dEduardo_s3.Add(new DialogLine ("Eduardo Hastings", "Hum... curioso... o nome parece ter sido escrito à caneta... mas os rabiscos rudes ", 1, 1));
		dEduardo_s3.Add(new DialogLine ("Eduardo Hastings", "que foram feitos por cima foram feitos à lápis... nada que uma borracha não resolva, acredito.", 1 ,1));


		Acao eduardo_s3_a0_e = new MostrarDialogos (dEduardo_s3);
		EduardoState3.OnExamineAction.Add (eduardo_s3_a0_e);

		Acao mudarEstadoPorta = new MudarEstado ("Porta", 1);
		EduardoState3.OnExamineAction.Add (mudarEstadoPorta);

		AddStateTo("Eduardo", EduardoState3);
		//acoesHashtable.Add ("Eduardo-3", EduardoState3);


		//********************************************
		//*****      Tapete - Estado 0       *********
		//********************************************
		state TapeteState0 = new state(0);
		
		//=================================
		//  Acoes OnExamine do estado 0
		//=================================
		DialogLine tapete1 = new DialogLine ("Tapete", "Voce achou uma chave secreta", -1);
		DialogLine tapete2 = new DialogLine ("Tapete", "A chave foi adicionada no seu inventorio", -1);
		ArrayList dialogosTapete = new ArrayList();
		dialogosTapete.Add (tapete1);
		dialogosTapete.Add (tapete2);
		Acao mostrarDialogoTapete = new  MostrarDialogos(dialogosTapete);
		TapeteState0.OnExamineAction.Add(mostrarDialogoTapete);
		//TapeteState0.OnExamineAction.Add(new MudarEstadoEduardo(1));
		TapeteState0.OnExamineAction.Add(new AdicionarItem("Chave", "sprites/Key item", false));
		TapeteState0.OnExamineAction.Add(new AtivarEvento(0));
		TapeteState0.OnExamineAction.Add(new MudarEstado("Eduardo",1,"0 1 ! &"));
		TapeteState0.OnExamineAction.Add(new MudarEstado("Tapete", 1));

		AddStateTo("Tapete", TapeteState0);
		//acoesHashtable.Add("Tapete-0", TapeteState0);

		//********************************************
		//*****      Tapete - Estado 1       *********
		//********************************************
		state TapeteState1 = new state(1);

		//=================================
		//  Acoes OnExamine do estado 1
		//=================================
		DialogLine tapetevazio = new DialogLine ("Tapete", "Nao ha nada aqui", -1);
		ArrayList dialogosTapeteVazio = new ArrayList();
		dialogosTapeteVazio.Add (tapetevazio);

		Acao mostrarDialogoTapeteVazio = new  MostrarDialogos(dialogosTapeteVazio);
		TapeteState1.OnExamineAction.Add(mostrarDialogoTapeteVazio);

		AddStateTo("Tapete", TapeteState1);
		//acoesHashtable.Add("Tapete-1", TapeteState1);
	
		
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
		PapelState0.OnExamineAction.Add (new MudarEstado ("Eduardo", 2, "1 0 ! &"));
		PapelState0.OnExamineAction.Add(new AdicionarItem("Papel", "sprites/Paper item", true));

		AddStateTo("Papel", PapelState0);
		//acoesHashtable.Add("Papel-0", PapelState0);


		//============================
		//% Estado 0 da Porta
		//============================
		
		state DoorState0 = new state(0);
		
		//**********************************************
		//*******  Acoes OnExamine do estado 0 do papel
		//**********************************************
		
		DialogLine dialogDoor = new DialogLine ("Porta", "Voce nao pode entrar aqui ainda, voce ainda tem coisas para fazer", -1);
		ArrayList dialogosDoor = new ArrayList();
		dialogosDoor.Add (dialogDoor);
		Acao mostrarDialogoDoor = new  MostrarDialogos(dialogosDoor);
		DoorState0.OnExamineAction.Add(mostrarDialogoDoor);
		AddStateTo("Porta", DoorState0);

		//============================
		//% Estado 1 da Porta
		//============================
		
		state DoorState1 = new state(1);
		
		//**********************************************
		//*******  Acoes OnExamine do estado 0 do papel
		//**********************************************

		Acao mudarCenaPorta = new  MudarCena("Cena2", "transitor2");
		DoorState1.OnExamineAction.Add(mudarCenaPorta);
		AddStateTo("Porta", DoorState1);
		//acoesHashtable.Add("Papel-0", PapelState0);


	}
	
	public state getStatePersonagem(string personagem, int estado){
		return (state)acoesHashtable[personagem + "-" + estado];
	}

	void AddStateTo(string personagem, state estado) {
		acoesHashtable.Add(personagem+"-"+estado.id, estado);
	}
}

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