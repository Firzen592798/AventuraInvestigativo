using UnityEngine;
using System.Collections;

public class states_Eduardo : DicionarioAcoes
{
	public states_Eduardo()
	{
		setInitState(-1);

		//********************************************
		//*****      Eduardo - Estado I      *********
		//********************************************
		state EduardoStateI = new state(-1);
		
		//=================================
		//  Acoes Settings do estado I
		//=================================
		EduardoStateI.SettingActions.Add(new SalvarPosicaoGlobal("Eduardo"));
		EduardoStateI.SettingActions.Add(new MudarEstado("Eduardo", 0));


		AddStateTo(EduardoStateI);

		//********************************************
		//*****      Eduardo - Estado 0      *********
		//********************************************
		state EduardoState0 = new state(0);

		//=================================
		//  Acoes OnExamine do estado 0
		//=================================
		ArrayList dEduardo_s0_e = new ArrayList ();
		dEduardo_s0_e.Add(new DialogLine ("Eduardo Hastings", "E então Jane, encontrou algo?", 1, 1));
		dEduardo_s0_e.Add(new DialogLine ("Jane", "Não... não estou com sorte", 0, 0));
		dEduardo_s0_e.Add(new DialogLine ("Eduardo Hastings", "Ora... não a conheci desistindo assim tão fácil. Continue... estou certo de que encontrará algo intrigante.", 1, 1));
		
		
		Acao eduardo_s0_a0_e = new MostrarDialogos (dEduardo_s0_e);
		EduardoState0.OnExamineAction.Add(eduardo_s0_a0_e);
		
		AddStateTo(EduardoState0);
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
		EduardoState1.OnExamineAction.Add(new MudarEstado("Eduardo",3,"(0 & 1)"));
		EduardoState1.OnExamineAction.Add (eduardo_s1_a0_e);
		
		AddStateTo(EduardoState1);
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
		EduardoState2.OnExamineAction.Add(new MudarEstado("Eduardo",3,"(0 & 1)"));
		EduardoState2.OnExamineAction.Add (eduardo_s2_a0_e);
		
		AddStateTo(EduardoState2);
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
		
		AddStateTo(EduardoState3);
		//acoesHashtable.Add ("Eduardo-3", EduardoState3);
	}
}