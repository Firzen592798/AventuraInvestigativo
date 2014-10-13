using UnityEngine;
using System.Collections;
public class MudarEstado : Acao{
	string personagem;
	GameController gm;
	int state;
	public MudarEstado(string personagem, int state){
		this.personagem = personagem;
		this.state = state;
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	public override bool Update(){
		gm.changeState(personagem, state);
		return true;
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
				
				if (c == '(') {
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
					if (top == '(' && s.Count > 0) {
						s.Pop();
					}
				}
				else if (c != ' ') {
					char top = '#';
					if (s.Count > 0) {
						top = (char)s.Pop();
					}
					while ((top != '(')&&(top != '#')) {
						if ((top == '!')||(c != '!')){
							break;
						}
						P.Add(top);
						if (s.Count > 0) {
							top = (char)s.Pop();
						}
						else {
							top = '#';
						}
					}
					s.Push(c);
				}
			}
		}
		
		string result = "";
		foreach(string st in P) {
			result = result + st + " ";
		}
		return result;
	}

}