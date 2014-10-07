using UnityEngine;
using System.Collections;

public class TextPlaceholder : MonoBehaviour {

	// Variaveis de dialogo
	ArrayList[] dialogmanager;// cada posicao corresponde a um personagem
	string[] dialogs;
	string[] dialogs1;
	int[] dtypes;
	int[] dtypes1;
	DialogEntry dialogentries1;
	DialogEntry dialogentries2;
	int[] imgfiles;// indice de qual das imagens do personagem aparece
	int[] imgfiles1;
	int[] imgindex;// indice que indica qual o personagem que esta falando
	int[] imgindex1;
	int[] imgpos;
	int[] imgpos1;

	int linelenght = 40;

	// Use this for initialization
	void Start () {
		// Codigo para dialogo teste
		init_mega_array (1);
		dialogs = new string[4];
		dtypes = new int[4];
		dialogs [0] = "Esse eh um dialogo de teste";
		dtypes [0] = 0;
		dialogs [1] = "Essa eh a segunda pagina do dialogo de teste hu3 hu3";
		dtypes [1] = 0;
		dialogs [2] = "Essa eh a terceira pagina do dialogo de teste. Tem muito texto aqui";
		dtypes [2] = 0;
		dialogs [3] = "Aqui eh um exemplo de escolha. Escolha um! <Mude_o_estado>1@Nao_mude_o_estado>0";
		dtypes [3] = 1;

		dialogs1 = new string[2];
		dtypes1 = new int[2];
		dialogs1 [0] = "Esse eh o dialogo no estado 1";
		dtypes1 [0] = 0;
		dialogs1 [1] = "Parece tosco isso nao eh?";
		dtypes1 [1] = 0;

		imgfiles = new int[4];
		imgfiles [0] = 1;
		imgfiles [1] = 0;
		imgfiles [2] = 1;
		imgfiles [3] = 0;

		imgfiles1 = new int[2];
		imgfiles1 [0] = 1;
		imgfiles1 [1] = 1;

		imgindex = new int[4];
		imgindex [0] = 0;
		imgindex [1] = 0;
		imgindex [2] = 1;
		imgindex [3] = 1;
				
		imgindex1 = new int[2];
		imgindex1 [0] = 0;
		imgindex1 [1] = 0;

		imgpos = new int[4];
		imgpos [0] = 1;
		imgpos [1] = 0;
		imgpos [2] = 1;
		imgpos [3] = 0;

		imgpos1 = new int[2];
		imgpos1 [0] = 1;
		imgpos1 [1] = 1;

		dialogentries1 = new DialogEntry (dialogs, dtypes, imgfiles, imgindex, imgpos);
		dialogentries2 = new DialogEntry (dialogs1, dtypes1, imgfiles1, imgindex1, imgpos1);;

		dialogs [0] = ResolveTextSize (dialogs [0], linelenght);
		dialogs [1] = ResolveTextSize (dialogs [1], linelenght);
		dialogs [2] = ResolveTextSize (dialogs [2], linelenght);
		dialogs [3] = ResolveTextSize (dialogs [3], linelenght);

		dialogs1 [0] = ResolveTextSize (dialogs1 [0], linelenght);
		dialogs1 [1] = ResolveTextSize (dialogs1 [1], linelenght);

		dialogmanager[0].Add (dialogentries1);
		dialogmanager [0].Add (dialogentries2);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void init_mega_array(int X)
	{
		dialogmanager = new ArrayList[X];
		for (int i = 0; i < dialogmanager.Length; i++)
		{
			dialogmanager[i] = new ArrayList();
		}
	}

	//retorna o numero de caixas de dialogo do personagem no estado especificado
	public int NumText(int personagem, int estado)
	{
		ArrayList adia = dialogmanager [personagem];
		DialogEntry dia = (DialogEntry)adia [estado];
		string[] pages = dia.dialogs;
		return pages.Length;
		//return dialogs.Length;
	}

	//retorna a caixa de dialogo especifica do personagem no estado especificado
	public string LoadText(int personagem, int estado, int page)
	{
		ArrayList adia = dialogmanager [personagem];
		DialogEntry dia = (DialogEntry)adia [estado];
		string[] pages = dia.dialogs;
		return pages[page];
		//return dialogs [page];
	}

	public int LoadType(int personagem, int estado, int page)
	{
		ArrayList adia = dialogmanager [personagem];
		DialogEntry dia = (DialogEntry)adia [estado];
		int[] pagetypes = dia.types;
		return pagetypes [page];
	}

	public string[] LoadChoices (int personagem, int estado, int page)
	{
		ArrayList adia = dialogmanager [personagem];
		DialogEntry dia = (DialogEntry)adia [estado];
		string[] pagechoices = new string[dia.choices[page].Count];
		for (int i = 0; i<pagechoices.Length; i++) 
		{
			pagechoices[i] = (string)dia.choices[page].ToArray()[i];
		}
		return pagechoices;
	}

	public int LoadChoiceState(int personagem, int estado, int page, int choiceindex)
	{
		ArrayList adia = dialogmanager [personagem];
		DialogEntry dia = (DialogEntry)adia [estado];
		int choice = (int)dia.choicestates [page].ToArray() [choiceindex];
		return choice;
	}

	public int LoadFaceSet (int personagem, int estado, int page)
	{
		ArrayList adia = dialogmanager [personagem];
		DialogEntry dia = (DialogEntry)adia [estado];
		int[] facesets = dia.imgfiles;
		return facesets [page];
	}
	public int LoadFaceIndex (int personagem, int estado, int page)
	{
		ArrayList adia = dialogmanager [personagem];
		DialogEntry dia = (DialogEntry)adia [estado];
		int[] faces = dia.imgindex;
		return faces [page];
	}
	public int LoadFacePos (int personagem, int estado, int page)
	{
		ArrayList adia = dialogmanager [personagem];
		DialogEntry dia = (DialogEntry)adia [estado];
		int[] facepos = dia.imgpos;
		return facepos [page];
	}

	//quebra o texto em linhas por numero de caracteres definido por linelenght
	string ResolveTextSize(string input, int lineLength)
	{
		string[] words = input.Split(' ');
		string result = "";
		string line = "";
		foreach(string s in words){
			char[] chars = s.ToCharArray();
			if (chars[0] != '<')
			{
				string temp = line + " " + s;
				if(temp.Length > lineLength){
					result += line + "\n";
					line = s;
				}
				else {
					line = temp;
				}
			}
		}
		result += line;
		return result.Substring(1,result.Length-1);
	}
}

public class DialogEntry
{
	public string[] dialogs;// dialogos - cada posicao eh uma pagina
	public int[] types;// tipos de dialogos
	public ArrayList[] choices;
	public ArrayList[] choicestates;
	public int[] imgfiles;
	public int[] imgindex;
	public int[] imgpos;

	public DialogEntry(string[] dialogs, int[] types, int[] imf, int[] imi, int[] imp)
	{
		this.dialogs = dialogs;
		this.types = types;
		this.imgfiles = imf;
		this.imgindex = imi;
		this.imgpos = imp;
		this.choices = new ArrayList[types.Length];
		this.choicestates = new ArrayList[types.Length];
		for (int i = 0; i < choices.Length; i++)
		{
			this.choices[i] = new ArrayList();
			this.choicestates[i] = new ArrayList();
			if (types[i] == 1)
			{
				string[] words = dialogs[i].Split('<');
				string[] worchoice = words[1].Split('@');
				foreach(string s in worchoice)
				{
					string[] statechoice = s.Split('>');
					string s2 = statechoice[0].Replace("_"," ");
					choices[i].Add(s2);
					int statec = int.Parse(statechoice[1]);
					choicestates[i].Add (statec);
				}
			}
		}
	}

}
