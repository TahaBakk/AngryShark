using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

	public Rigidbody2D Jugador;
	public Rigidbody2D lanzar;

	//public Rigidbody2D gancho;

	public float soltar = .15f;
	public float distanciaMaxArrastre = 4f;

	public GameObject proximoObjeto;

	private bool presionada = false;

	void Update ()
	{
		if (presionada)
		{
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if(Vector3.Distance(mousePosition,lanzar.position) > distanciaMaxArrastre)
			{
				Jugador.position = lanzar.position + (mousePosition - lanzar.position).normalized * distanciaMaxArrastre;
			}else
			{
				Jugador.position = mousePosition;
			}

		}
	}


	void OnMouseDown ()
	{
		presionada = true;
		Jugador.isKinematic = true;
	}

	void OnMouseUp ()
	{
		presionada = false;
		Jugador.isKinematic = false;

		StartCoroutine(Release());
	}

	IEnumerator Release ()
	{
		yield return new WaitForSeconds(soltar);

		GetComponent<SpringJoint2D>().enabled = false;
		this.enabled = false;

		yield return new WaitForSeconds(2f);

		if(proximoObjeto != null)
		{
			proximoObjeto.SetActive(true);
		} else
		{
			enemigo.vidas = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
