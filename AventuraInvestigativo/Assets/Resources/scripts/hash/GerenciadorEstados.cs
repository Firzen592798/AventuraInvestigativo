using UnityEngine;
using System.Collections;
public class GerenciadorEstados {

	private static GerenciadorEstados instance;

	Hashtable hash;
	bool[] eventos;
	public static GerenciadorEstados getInstance(){
		if (instance == null) {
			instance = new GerenciadorEstados();
		}
		return instance;
	}
	//evento 0 - pegar chave
	//evento 1 - pegar papel
	private GerenciadorEstados() {
		hash = new Hashtable();
		eventos = new bool[2];
		hash.Add ("Tapete", new states_CarpetObject());
		hash.Add ("Mesa", new states_TableObject());
		hash.Add ("Eduardo", new states_Eduardo());
		hash.Add ("Porta", new states_DoorObject());
		hash.Add ("Player", new states_Player());
	}

	public void alterarEstado(string personagem, int novoEstado, string condit){

		bool THE_ANSWER = true;

		if (condit != null) 
		{
			string condicao = to_suffix(condit);
			Debug.Log(condit+" -> "+condicao);
			string[] op = condicao.Split(' ');
			Stack s = new Stack();
			foreach (string operand in op)
			{
				bool value;
				char chara = operand.ToCharArray()[0];
				if ((chara == '&')||(chara == '|'))
				{
					bool b1 = (bool)s.Pop();
					bool b2 = (bool)s.Pop();
					if (chara == '&')
					{
						value = ((b1) && (b2));
					}
					else
					{
						value = ((b1) || (b2));
					}
					s.Push(value);
				}else if (chara == '!')
				{
					value = (bool)s.Pop();
					value = !value;
					s.Push(value);
				}else
				{
					int num = int.Parse(operand);
					value = eventos[num];
					s.Push(value);
				}
			}
			THE_ANSWER = (bool)s.Pop();

		}
		
		if (hash.ContainsKey(personagem)&&THE_ANSWER) {
			((DicionarioAcoes)hash[personagem]).setAState(novoEstado);
		}
	}

	public int getEstadoIndex(string personagem) {
		//Debug.Log ("Estado de " + personagem + " = " + (int)hash [personagem]);
		return ((DicionarioAcoes)hash[personagem]).getAState();
	}

	public state getEstado(string personagem) {
		int state_index = getEstadoIndex (personagem);
		return ((DicionarioAcoes)hash[personagem]).getStatePersonagem(state_index);
		//return dict.getStatePersonagem(personagem, (int)hash[personagem]);
	}

	public void setEventActive(int ev_num) {
		eventos[ev_num] = true;
		//Debug.Log ("Eventos:" + eventos [0] + eventos [1]);
	}

	public void setEventDeactive(int ev_num) {
		eventos[ev_num] = false;
		//Debug.Log ("Eventos:" + eventos [0] + eventos [1]);
	}

	public void setGlobalPosition(string personagem, Vector3 pos, int scene) {
		((DicionarioAcoes)hash[personagem]).setGloabalPosition(pos, scene);
	}

	public PositionGlobal getGlobalPosition(string personagem) {
		return ((DicionarioAcoes)hash[personagem]).getGlobalPosition();
	}

	string to_suffix(string infix) {
		Stack s = new Stack();
		s.Push('(');
		string noa = infix+")";
		
		char[] list_c = noa.ToCharArray();
		ArrayList P = new ArrayList();
		string symbol = "";
		for(int i = 0; i < list_c.Length; i++) {
			char c = list_c[i];
			if ((c != '|')&&(c != '&')&&(c != '!')&&(c != '(')&&(c != ')')&&(c != ' ')) {
				symbol = symbol+c.ToString();
			}
			else {
				if (symbol != "") {
					P.Add(symbol);
					symbol = "";
				}
				
				if ((c == '(')||(c == '!')) {
					s.Push(c);
				}
				else if (c == ')') {
					char top = '#';
					if (s.Count > 0) {
						top = (char)s.Pop();
					}
					while (top != '(' && top != '#') {
						P.Add(top.ToString());
						if (s.Count > 0) {
							top = (char)s.Pop();
						}
						else {
							top = '#';
						}
					}
				}
				else if (c != ' ') {
					char top = '#';
					if (s.Count > 0) {
						top = (char)s.Pop();
					}
					while ((top != '(')&&(top != '#')) {
						P.Add(top.ToString());
						if (top == '!'){
							break;
						}
						if (s.Count > 0) {
							top = (char)s.Pop();
						}
						else {
							top = '#';
						}
					}
					if (top == '(') {
						s.Push('(');
					}
					s.Push(c);
				}
			}
		}
		
		string result = "";
		for(int i = 0; i < P.Count; i++) {
			if (i < P.Count-1) {
				result = result + P[i] + " ";
			}
			else {
				result = result + P[i];
			}
		}
		return result;
	}
}