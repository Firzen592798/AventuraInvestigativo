using UnityEngine;
using System.Collections;

public class states_Player : DicionarioAcoes
{
	public states_Player() {
		setAState(1);

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
		Acao dialog2 = new MostrarDialogos (new DialogLine ("Jane", "...!", 0, 0));


		PlayerState1.OnInitActions.Add(new Esperar(2));

		PlayerState1.OnInitActions.Add(mover0);

		PlayerState1.OnInitActions.Add (testeimagem);

		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation());
		PlayerState1.OnInitActions.Add(dialog0);
		PlayerState1.OnInitActions.Add (testeesconder);
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

		PlayerState1.OnInitActions.Add(new MudarEstado("Eduardo", 0));

		// FIM ESTADO 1
		AddStateTo(PlayerState1);

	}
}