using UnityEngine;
using System.Collections;

public class Esperar : Acao{

	float tempo_inicial;
	double wait_seconds;

	public Esperar(double segundos) {
		wait_seconds = segundos;
		tempo_inicial = -1;
	}

	public override bool Update() {
		if (tempo_inicial == -1) {
			tempo_inicial = Time.time;
		}

		if (Time.time - tempo_inicial < wait_seconds) {
			return false;
		}
		else {
			return true;
		}
	}
}