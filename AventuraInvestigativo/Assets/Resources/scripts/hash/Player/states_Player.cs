using UnityEngine;
using System.Collections;

public class states_Player : DicionarioAcoes
{
	GameController gm;
	public states_Player() {
		setInitState(1);
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		//********************************************
		//*****      Player - Estado 0      **********
		//********************************************
		state PlayerState0 = new state(0);
		
		//=================================
		//  Acoes Settings do estado 0
		//=================================
		PlayerState0.SettingActions.Add(new MudarControlePlayer(gm, false));
		
		//FIM ESTADO 0
		AddStateTo(PlayerState0);

		//********************************************
		//*****      Player - Estado 1      **********
		//********************************************
		state PlayerState1 = new state(1);

		//=================================
		//  Acoes Settings do estado 1
		//=================================
		//Acao playost = new TocarMusica (0,1);

		//PlayerState1.SettingActions.Add(playost);
		PlayerState1.SettingActions.Add(new MudarControlePlayer(gm, true));
		//PlayerState1.SettingActions.Add(new PlayWaitingAnimation());

		//=================================
		//  Acoes OnInit do estado 1
		//=================================

		string[] textos0 = new string[1];
		textos0 [0] = "4 de março \n15:00h";
		int[] imgs0 = new int[1] {-1};

		string[] textos1 = new string[3];
		textos1[0] = "Para passar textos ou interagir com os objetos do cenário pressione Z.";
		textos1[1] = "Para mover o personagem use as setas do teclado.";
		textos1[2] = "Para acessar o menu clique com o botao direito do mouse";
		int[] imgs1 = new int[3] {-1,-1,-1};

		string[] textos2 = new string[6];
		textos2 [0] = "Cheguei hoje pela manhã na Mansão Christie a convite de meu amigo, o Capitão Eduardo Hastings.";
		textos2 [1] = "Hastings estava me devendo um favor como este já que no último inverno salvei sua vida mais de uma vez, enquanto juntos buscávamos respostas para o Caso do Maníaco do Circo. Aquela época foi um tanto intensa, todos vocês que acompanham o blog sabem o que aconteceu. O assassino foi pego, apesar das consequências e de todo o mal que ele causou às pobres crianças.";
		textos2 [2] = "Não convém relembrar fantasmas tão soturnos agora. O capitão acertou em cheio me convidando para passar este fim-de semana na Mansão Christie, era exatamente o que eu estava precisando depois de tantos anos sem tirar uma folga sequer. O trabalho de consultoria em investigações particulares pode ser um tanto exaustivo se você é um dos únicos profissionais ainda na ativa.";
		textos2 [3] = "Mesmo estando me sentindo aliviada e de reconhecer que a Mansão Christie é um lugar um tanto isolado e calmo para quem quer descansar por alguns dias, não devo deixar de comentar que me sinto um bocado incomodada com o fato de que eu e Hastings somos os únicos hóspedes aqui instalados neste fim de semana que não fazem parte da família Christie.";
		textos2 [4] = "A profissão de Capitão de Polícia nesta pequena cidade dá a Hastings determinados privilégios um tanto antiéticos, como ser amigo de uma família que controla maior parte das ofertas de emprego da região através da empresa Christie e Filhos S.A.. Talvez meu incômodo seja apenas receio em estar atrapalhando algo. Parece que os principais membros da família Christie estão reunidos na Mansão para celebrar uma ocasião especial. Não faço ideia do que se trata, mas não levará muito tempo até que eu descubra qualquer coisa.";
		textos2 [5] = "Esta é minha última postagem desta semana. Talvez estejam estranhando ler algo neste blog que não envolva assassinatos ou desaparecimentos, mas eu estava realmente precisando de alguns dias de descanso. Voltarei a postar por aqui amanhã mesmo com uma cobertura provavelmente muito chata sobre como eu passei o dia deitada em uma rede. \n \n Desejando Mistérios \n JANE MISS TERRY";
		int[] imgs2 = new int[6] {0,0,0,0,0,0};

		string[] textos3 = new string[2];
		textos3 [0] = "5 de março\n8:20h";
		textos3 [1] = "5 de março\n8:21h";
		int[] imgs3 = new int[2] {-1,-1};

		string[] textos4 = new string[2];
		textos4 [0] = "Bom dia! Na última postagem avisei que quando aparecesse por aqui de novo seria para contar sobre as calmarias do meu fim de semana de descanso na Mansão Christie...";
		textos4 [1] = "Sinto que todos vocês ficariam desapontados se eu voltasse com qualquer história que não envolvesse algo mais animador e eletrizante. Pois bem... espero que acreditem nas minhas próximas palavras nas quais tentarei descrever com minúcias as situações mais impossíveis e inesperados que de fato aconteceram nesta última noite. Deixe-me convidá-los, assim como eu fui convidada, para esta...";
		int[] imgs4 = new int[2] {0,0};

		string[] textos5 = new string[1] {""};
		int[] imgs5 = new int[1] {1};

		// Cena 1

		PlayerState1.OnInitActions.Add (new TocarMusica(gm, 1,0));
		PlayerState1.OnInitActions.Add (new Esperar (gm, 2));
		PlayerState1.OnInitActions.Add (new MostrarImagemCentral (gm, imgs1,1f,1f,0f,0.3f,0.1f,textos1,Color.white,TextAnchor.UpperCenter,new double[3] {0.1,0.1,0.1}));
		PlayerState1.OnInitActions.Add (new MostrarImagemCentral (gm, imgs0, 1f, 1f, 0f, 0.4f, 0.15f, textos0, Color.white,TextAnchor.UpperCenter,new double[1] {0.1}));
		PlayerState1.OnInitActions.Add (new FadeInScreen (gm));
		PlayerState1.OnInitActions.Add (new EsconderImagemCentral (gm));
		PlayerState1.OnInitActions.Add (new MoverPersonagem (gm, "Player", "initial_spot2", false));
		PlayerState1.OnInitActions.Add (new MoverPersonagem (gm, "Player", "initial_spot3",true));
		PlayerState1.OnInitActions.Add (new CarregarAudio (gm, 2));
		PlayerState1.OnInitActions.Add (new TocarAudio (gm));
		PlayerState1.OnInitActions.Add (new Esperar (gm, 1));
		PlayerState1.OnInitActions.Add (new MostrarImagemCentral (gm, imgs2, 0.9f, 0.8f, 0f, 0.2f, 0.04f, textos2, Color.black,TextAnchor.UpperLeft,new double[6] {0.1,0.1,0.1,0.1,0.1,0.1}));
		PlayerState1.OnInitActions.Add (new EsconderImagemCentral (gm));
		PlayerState1.OnInitActions.Add (new FadeOutScreen (gm));
		PlayerState1.OnInitActions.Add (new Esperar (gm, 4));
		//Cena 2
		PlayerState1.OnInitActions.Add (new TocarMusica(gm, 2,0));
		PlayerState1.OnInitActions.Add (new MostrarImagemCentral (gm, imgs3, 1f, 1f, 0f, 0.4f, 0.15f, textos3, Color.white,TextAnchor.UpperCenter,new double[2] {0.1,0.1}));
		PlayerState1.OnInitActions.Add (new FadeInScreen (gm));
		PlayerState1.OnInitActions.Add (new EsconderImagemCentral (gm));
		PlayerState1.OnInitActions.Add (new MostrarImagemCentral (gm, imgs4, 0.9f, 0.8f, 0f, 0.2f, 0.04f, textos4, Color.black,TextAnchor.UpperLeft,new double[2] {0.1,0.1}));
		PlayerState1.OnInitActions.Add (new EsconderImagemCentral (gm));
		PlayerState1.OnInitActions.Add (new FadeOutScreen (gm));
		PlayerState1.OnInitActions.Add (new Esperar (gm, 1));
		PlayerState1.OnInitActions.Add (new CarregarAudio (gm, 3));
		PlayerState1.OnInitActions.Add (new TocarAudio (gm));
		PlayerState1.OnInitActions.Add (new MostrarImagemCentral (gm, imgs5, 1f, 1f, 0f, 0f, 0f, textos5, Color.clear,TextAnchor.UpperLeft,new double[1] {0.1}));
		PlayerState1.OnInitActions.Add (new EsconderImagemCentral (gm));
		//Cena 3
		PlayerState1.OnInitActions.Add (new MudarCena (gm, "CenaSalao", "SpawnJane"));
		PlayerState1.OnInitActions.Add (new TocarMusica(gm, 3,0));
		PlayerState1.OnInitActions.Add (new TocarMusica(gm, 0,1));
		PlayerState1.OnInitActions.Add (new FadeInScreen (gm));






		Acao mover0 = new MoverPersonagem(gm, "Player", "MoveJane1", true);
		Acao mover1 = new MoverPersonagem(gm, "Player", "SpawnJane", true);
		Acao dialog1 = new MostrarDialogos(gm, new DialogLine("Jane", "...", 0, 0));
		Acao dialog2 = new MostrarDialogos(gm, new DialogLine ("Jane", "...!", 0, 0));

		ArrayList dialogoEduardo = new ArrayList ();
		dialogoEduardo.Add(new DialogLine ("Jane", "TESTE!", 0, 0));
		/*

		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Sinto que vou me arrepender em tê-la convidado a passar este fim-desemana na Mansão Christie. Você parece um tanto chateada.", 1, 1));
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
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Apenas uma cordialidade senhorita Terry... e para ser mais cordial vou te oferecer uma proposta, aceitas?", 1,1));
		dialogoEduardo.Add(new DialogLine ("Jane", "Ora, diga Capitão.", 0,0));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Os Christie são de fato, inofensivos... poderosos para os que não os conhecem bem, mas pessoas terrivelmente inseguras no fundo... Mesmo ", 1,1));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "assim, te trouxe aqui apenas para agradecer por ter me tirado daquelas situações arriscadas em que meti na época que investigávamos o ", 1, 1));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "caso do Maníaco do Circo. Não te trouxe para que se sentisse tão incomodada ao redor de pessoas que não conhece bem", 1, 1));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "durante todo um fim-de-semana... Se a chuva melhorar até amanhecer podemos ir embora se quiser...", 1, 1));
		dialogoEduardo.Add(new DialogLine ("Jane", "Relaxe, capitão. Estou precisando socializar um pouco realmente. É só um fim de semana, não é possível que estas pessoas sejam tão insuportáveis Só preciso", 0,0));
		dialogoEduardo.Add(new DialogLine ("Jane", "que você me explique o que tanto eles estão comemorando nesta ocasião, para que fique mais fácil de interagir caso alguém puxe assunto.", 0,0));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Eu não estou bem certo... o senhor Joseph Christie me convidou apenas por gentileza e disse que eu trouxesse quem eu quisesse. ", 1,1));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Somos muito amigos desde que eles se mudaram para esta cidadezinha e instalaram a Christie e Filhos S.A. por aqui.", 1,1));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Faz cerca de 20 anos isso. Mas ouvi da Sra. Marques, a empregada, que esta é uma noite importante para a família e para a empresa.", 1,1));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Eles estão prestes a decidir algo importante e optaram por esta reunião para fazer isto.", 1,1));
		dialogoEduardo.Add(new DialogLine ("Jane", "Estou me sentindo terrivelmente pior: agora estou no meio de uma reunião de família... que furada Hastings!", 0,0));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Hahaha, como você me diverte Jane. Bem, Se está realmente incomodada e curiosa assim como eu estou, faça um favor para nós dois: ", 1,1));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "descubra qual é a real razão desta cerimônia e me informe assim que tiver certeza do que se trata, o que acha? ", 1,1));
		dialogoEduardo.Add(new DialogLine ("Eduardo Hastings", "Também servirá como maneira de socializar. ", 1,1));
		dialogoEduardo.Add(new DialogLine ("Jane", "Não é má ideia... é exatamente isto que eu vou fazer!", 0,0));

		PlayerState1.OnInitActions.Add(new Esperar(gm, 2));

		PlayerState1.OnInitActions.Add(mover0);

		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation(gm));
		PlayerState1.OnInitActions.Add(new Esperar(gm, 2));

		PlayerState1.OnInitActions.Add(mover1);
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation(gm));
		PlayerState1.OnInitActions.Add(dialog1);
		PlayerState1.OnInitActions.Add(new Esperar(gm, 2));

		PlayerState1.OnInitActions.Add(mover0);
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation(gm));
		PlayerState1.OnInitActions.Add(dialog1);
		PlayerState1.OnInitActions.Add(new Esperar(gm, 2));

		PlayerState1.OnInitActions.Add(mover1);
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation(gm));
		PlayerState1.OnInitActions.Add(dialog1);
		PlayerState1.OnInitActions.Add(new Esperar(gm, 2));

		PlayerState1.OnInitActions.Add(mover0);
		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation(gm));
		PlayerState1.OnInitActions.Add(dialog1);
		*/
		PlayerState1.OnInitActions.Add(new Esperar(gm, 2));

		PlayerState1.OnInitActions.Add(new PlayWaitingAnimation(gm, false));
		PlayerState1.OnInitActions.Add(dialog2);

		PlayerState1.OnInitActions.Add(new MoverPersonagem(gm, "Eduardo", "point1", false));
 		PlayerState1.OnInitActions.Add(new MoverPersonagem(gm, "Eduardo", "point2", true));
		PlayerState1.OnInitActions.Add(new MostrarDialogos(gm, dialogoEduardo));
		PlayerState1.OnInitActions.Add(new SalvarPosicaoGlobal(gm, "Eduardo"));
		PlayerState1.OnInitActions.Add(new TocarMusica(gm, 4,0));
		PlayerState1.OnInitActions.Add(new MudarEstado(gm, "Player", 0));


		// FIM ESTADO 1
		AddStateTo(PlayerState1);

	}
}