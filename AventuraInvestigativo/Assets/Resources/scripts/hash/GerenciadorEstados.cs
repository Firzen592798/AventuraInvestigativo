using UnityEngine;
using System.Collections;
public class GerenciadorEstados {

	private static GerenciadorEstados instance;
	DicionarioAcoes dict;
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
		dict = new DicionarioAcoes();
		hash = new Hashtable();
		eventos = new bool[2];
		hash.Add ("Tapete", 0);
		hash.Add ("Papel", 0);
		hash.Add ("Eduardo", 0);
		hash.Add ("Porta", 0);
	}

	public void alterarEstado(string personagem, int novoEstado, string condicao){

		bool THE_ANSWER = true;

		if (condicao != null) 
		{
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
			hash[personagem] = novoEstado;
		}
	}

	public int getEstadoIndex(string personagem) {
		//Debug.Log ("Estado de " + personagem + " = " + (int)hash [personagem]);
		return (int)hash[personagem];
	}

	public state getEstado(string personagem) {
		return dict.getStatePersonagem(personagem, (int)hash[personagem]);
	}

	public void setEventActive(int ev_num)
	{
		eventos [ev_num] = true;
		Debug.Log ("Eventos:" + eventos [0] + eventos [1]);
	}
}