using UnityEngine;
using System.Collections;
public class Profile
{
	string nome;
	string idade;
	string sexo;
	string descricao;

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

	public string getDesc()
	{
		return descricao;
	}
	
}