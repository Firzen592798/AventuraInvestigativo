using UnityEngine;
using System.Collections;

public class states_DoorObject: DicionarioAcoes
{
	protected GameController gm;
	protected GameObject g;
	public states_DoorObject ()
	{
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		setInitState(0);

		//============================
		//% Estado 0 da Porta
		//============================
		state DoorState0 = new state(0);

		//=================================
		//  Acoes Settings do estado 0
		//=================================
		DoorState0.SettingActions.Add(new InicializarPosicaoGlobal(gm, "Porta"));

		//**********************************************
		//*******  Acoes OnExamine do estado 0 do papel
		//**********************************************
		
		DialogLine dialogDoor = new DialogLine ("Porta", "Voce nao pode entrar aqui ainda, voce ainda tem coisas para fazer", -1);
		//ArrayList dialogosDoor = new ArrayList();
		//dialogosDoor.Add (dialogDoor);
		Conversa c0 = new Conversa ("Porta", dialogDoor);
		Acao mostrarDialogoDoor = new  MostrarDialogos(gm, c0);

		DoorState0.OnExamineAction.Add(mostrarDialogoDoor);
		AddStateTo(DoorState0);
		
		//============================
		//% Estado 1 da Porta
		//============================
		
		state DoorState1 = new state(1);
		
		//**********************************************
		//*******  Acoes OnExamine do estado 0 do papel
		//**********************************************
		
		Acao mudarCenaPorta = new MudarCena(gm, "Creditos", "transitor3");
		DoorState1.OnExamineAction.Add (new CarregarAudio (gm, 11));
		DoorState1.OnExamineAction.Add (new TocarAudio (gm));
		DoorState1.OnExamineAction.Add(mudarCenaPorta);
		AddStateTo(DoorState1);
		//acoesHashtable.Add("Papel-0", PapelState0);

	}
}
