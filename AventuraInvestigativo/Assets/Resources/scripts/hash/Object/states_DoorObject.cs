using UnityEngine;
using System.Collections;

public class states_DoorObject: DicionarioAcoes
{
	public states_DoorObject ()
	{
		setInitState(0);

		//============================
		//% Estado 0 da Porta
		//============================
		state DoorState0 = new state(0);

		//=================================
		//  Acoes Settings do estado 0
		//=================================
		DoorState0.SettingActions.Add(new SalvarPosicaoGlobal("Porta"));

		//**********************************************
		//*******  Acoes OnExamine do estado 0 do papel
		//**********************************************
		
		DialogLine dialogDoor = new DialogLine ("Porta", "Voce nao pode entrar aqui ainda, voce ainda tem coisas para fazer", -1);
		//ArrayList dialogosDoor = new ArrayList();
		//dialogosDoor.Add (dialogDoor);
		Acao mostrarDialogoDoor = new  MostrarDialogos(dialogDoor);
		DoorState0.OnExamineAction.Add(mostrarDialogoDoor);
		AddStateTo(DoorState0);
		
		//============================
		//% Estado 1 da Porta
		//============================
		
		state DoorState1 = new state(1);
		
		//**********************************************
		//*******  Acoes OnExamine do estado 0 do papel
		//**********************************************
		
		Acao mudarCenaPorta = new MudarCena("Creditos", "transitor3");
		DoorState1.OnExamineAction.Add(mudarCenaPorta);
		AddStateTo(DoorState1);
		//acoesHashtable.Add("Papel-0", PapelState0);

	}
}
