using UnityEngine;
using System.Collections;
public class Profile
{
	private string nome;
	private string idade;
	private string sexo;
	private string descricao;

	public Profile(string nome,string idade,string sexo,string descricao)
	{
		this.nome = nome;
		this.idade = idade;
		this.sexo = sexo;
		this.descricao = descricao;
	}

	public string getInfo()
	{
		string info = nome + "\n" + idade + "\n" + sexo;
		return info;
	}

	public string Nome {
		get {
			return nome;
		}
	}

	public string Idade {
		get {
			return idade;
		}
	}

	public string Sexo {
		get {
			return sexo;
		}
	}

	public string Descricao {
		get {
			return descricao;
		}
	}
	
}