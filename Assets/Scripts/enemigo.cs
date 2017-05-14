using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemigo : MonoBehaviour {

	public GameObject efectoEnemigo;

	public float health = 4f;

	public static int vidas = 0;
	public GameObject proximo;


 	void Start() {
		vidas++;
    }

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		if (colInfo.relativeVelocity.magnitude > health)
		{
			muere();
		}
	}

	void muere ()
	{
		Instantiate(efectoEnemigo, transform.position, Quaternion.identity);
		vidas--;
		if(vidas<=0)
		{//Controlar el fin de partida
			Debug.Log("Gola partida finalizada");
			SceneManager.LoadScene("MenuLevel");
		}
		Destroy(gameObject);

	}
}
