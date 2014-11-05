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
		Acao playost = new TocarMusica (1);

		PlayerState1.SettingActions.Add (playost);
		PlayerState1.SettingActions.Add(new MudarControlePlayer(true));
		PlayerState1.SettingActions.Add(new PlayWaitingAnimation());

		//=================================
		//  Acoes OnInit do estado 1
		//=================================


		Acao mover0 = new MoverPersonagem("Player", "point1", true);
		Acao dialog0 = new MostrarDialogos(new DialogLine("Jane", "...", 0, 0));
		Acao mover1 = new MoverPersonagem("Player", "initial_spot", true);
		Acao dialog1 = new MostrarDialogos(new DialogLine("Jane", "...!", 0, 0));


		PlayerState1.OnInitActions.Add(new Esperar(2));

		PlayerState1.OnInitActions.Add(mover0);
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation());
		PlayerState1.OnInitActions.Add(dialog0);
		PlayerState1.OnInitActions.Add(new Esperar(2));

		PlayerState1.OnInitActions.Add(mover1);
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation());
		PlayerState1.OnInitActions.Add(dialog0);
		PlayerState1.OnInitActions.Add(new Esperar(2));

		PlayerState1.OnInitActions.Add(mover0);
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation());
		PlayerState1.OnInitActions.Add(dialog0);
		PlayerState1.OnInitActions.Add(new Esperar(2));

		PlayerState1.OnInitActions.Add(mover1);
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation());
		PlayerState1.OnInitActions.Add(dialog0);
		PlayerState1.OnInitActions.Add(new Esperar(2));
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation(false));
		PlayerState1.OnInitActions.Add(dialog1);

		PlayerState1.OnInitActions.Add(new MudarEstado("Eduardo", 0));

		// FIM ESTADO 1
		AddStateTo(PlayerState1);

	}
}