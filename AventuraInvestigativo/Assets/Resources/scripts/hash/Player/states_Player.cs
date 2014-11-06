using UnityEngine;
using System.Collections;

public class states_Player : DicionarioAcoes
{
	public states_Player() {
		setInitState(1);

		//********************************************
		//*****      Player - Estado 0      **********
		//********************************************
		state PlayerState0 = new state(0);
		
		//=================================
		//  Acoes Settings do estado 1
		//=================================
		PlayerState0.SettingActions.Add(new MudarControlePlayer(false));
		
		//FIM ESTADO 0
		AddStateTo(PlayerState0);

		//********************************************
		//*****      Player - Estado 1      **********
		//********************************************
		state PlayerState1 = new state(1);

		//=================================
		//  Acoes Settings do estado 1
		//=================================
		Acao playost = new TocarMusica (0,1);

		PlayerState1.SettingActions.Add (playost);
		PlayerState1.SettingActions.Add(new MudarControlePlayer(true));
		PlayerState1.SettingActions.Add(new PlayWaitingAnimation());

		//=================================
		//  Acoes OnInit do estado 1
		//=================================

		string[] testt = new string[1];
		testt [0] = "isso eh uma grande mochila";
		int[] testt2 = new int[1];
		testt2 [0] = 0;
		Acao mover0 = new MoverPersonagem("Player", "point1", true);
		Acao testeimagem = new MostrarImagemCentral (testt2, new Rect (0, 0, 400, 400), 0, 0, 35, testt, Color.black);
		Acao dialog0 = new MostrarDialogos(new DialogLine("Jane", "Mas que djabos eh isso!?!", 0, 0));
		Acao testeesconder = new EsconderImagemCentral ();
		Acao mover1 = new MoverPersonagem("Player", "initial_spot", true);
		Acao dialog1 = new MostrarDialogos(new DialogLine("Jane", "...", 0, 0));
		Acao dialog2 = new MostrarDialogos(new DialogLine ("Jane", "...!", 0, 0));

		ArrayList dialogoEduardo = new ArrayList ();
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Oi, Sinto que vou me arrepender em te-la convidado a passar este fim-de-semana na Mansão Christie. Você parece um tanto chateada.", 1, 1));
		dialogoEduardo.Add(new DialogLine ("Jane", "Não se incomode comigo, Hastings. Você sabe que meu temperamento não é dos mais sociáveis.", 0, 0));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Sim, sim... espero que se divirta, contudo.", 1,1));
		dialogoEduardo.Add(new DialogLine ("Jane", "O que me incomoda mais é essa sensação de isolamento... não que seja de todo ruim passar um fim-de-semana mais isolado... mas ouça essa chuva...", 0,0));
		dialogoEduardo.Add(new DialogLine ("Jane", "mesmo que qualquer um de nós precisasse ir lá fora por uma emergência sequer, não poderíamos de tão forte que cai a tempestade... ", 0,0));
		dialogoEduardo.Add(new DialogLine ("Jane", "estar tão longe de tudo e a este nível de encarceramento desperta meus sentimentos mais alertas.", 0,0));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Haha, não é necessário estar alerta na mansão Christie. É perfeitamente seguro... se não há como sair, não como entrar, ou seja: nenhum mal virá", 1,1));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "de fora.", 1, 1));
		dialogoEduardo.Add(new DialogLine ("Jane", "Não me entenda mal, Hastings... não tenho medo de que algo entre aqui... me sinto terrivelmente desconfortável estando preso com essas pessoas...", 0,0));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Os Christie? Eles são totalmente inofensivos pessoalmente... você deveria temê-los se fosse um empregado da empresa deles... estes sim sofrem em", 1,1));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "suas mãos...", 1, 1));
		dialogoEduardo.Add(new DialogLine ("Jane", "Nunca se sabe Hastings... acredito que é melhor ficarmos com olhos e ouvidos preparados... estou sentindo que a noite vai ser longa..", 0,0));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Sendo assim, vou tomar outra taça deste delicioso espumante enquanto a celebração não inicia de fato... Com licença, senhorita.", 1,1));
		dialogoEduardo.Add(new DialogLine ("Jane", "Ora, largue as formalidades Capitão...", 0,0));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Apenas uma cordialidade senhorita Terry... e para ser mais cordial vou te dar uma recomendação, aceitas?", 1,1));
		dialogoEduardo.Add(new DialogLine ("Jane", "Diga, ora.", 0,0));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Se você possui qualquer interesse em se sentir mais segura esta noite, recomendo que procure conhecer melhor os que estarão presentes nesta", 1,1));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "cerimônia...", 1, 1));
		dialogoEduardo.Add(new DialogLine ("Jane", "E como eu supostamente deveria fazer isto, Capitão?", 0,0));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Creio que um rápido reconhecimento do saguão deve bastar... Depois me encontre e diga o que você encontrou. Estarei próximo ao bar.", 1,1));


		PlayerState1.OnInitActions.Add(new Esperar(2));

		PlayerState1.OnInitActions.Add(mover0);

		PlayerState1.OnInitActions.Add(testeimagem);

		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation());
		PlayerState1.OnInitActions.Add(dialog0);
		PlayerState1.OnInitActions.Add(testeesconder);
		PlayerState1.OnInitActions.Add(new Esperar(2));

		PlayerState1.OnInitActions.Add(mover1);
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation());
		PlayerState1.OnInitActions.Add(dialog1);
		PlayerState1.OnInitActions.Add(new Esperar(2));

		PlayerState1.OnInitActions.Add(mover0);
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation());
		PlayerState1.OnInitActions.Add(dialog1);
		PlayerState1.OnInitActions.Add(new Esperar(2));

		PlayerState1.OnInitActions.Add(mover1);
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation());
		PlayerState1.OnInitActions.Add(dialog1);
		PlayerState1.OnInitActions.Add(new Esperar(2));
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation(false));
		PlayerState1.OnInitActions.Add(dialog2);

		PlayerState1.OnInitActions.Add(new MoverPersonagem("Eduardo", "point2", true));
		PlayerState1.OnInitActions.Add(new MostrarDialogos(dialogoEduardo));
		PlayerState1.OnInitActions.Add(new SalvarPosicaoGlobal("Eduardo"));
		PlayerState1.OnInitActions.Add(new MudarEstado("Player", 0));

		// FIM ESTADO 1
		AddStateTo(PlayerState1);

	}
}