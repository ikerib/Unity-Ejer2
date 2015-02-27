using UnityEngine;
using System.Collections;

public class Cubo : MonoBehaviour {
	
	// Variables publicas para el acceso desde el diseñador
	public float velocidad;
	public float maxLeft;
	public float maxRight;
	public DebugMessages dLog;
	public int vidas;
	public GUIText gameOverText;
	private bool gameOver;
	// Variables privadas del script
	Transform myTransform;
	int sentido;
	
	
	// Use this for initialization
	void Start () {
		
		// Variables iniciales. Si estan a nulo, establecemos valores por defecto
		myTransform = this.transform;
		if (velocidad == 0)
			velocidad = 1;
		if (maxLeft == 0)
			maxLeft = -6f;
		if (maxRight == 0)
			maxRight = 6f;
		if (vidas == 0)
			vidas = 3;
		sentido = 1;


	}
	
	// Update is called once per frame
	void Update () {
		// comprobamos si estamos dentro de los limites
		if (((myTransform.position.x <= maxLeft) && (sentido == -1)) 
		    ||
		    (( myTransform.position.x >= maxRight) && (sentido == 1)))
		{
			// Si entra es que en el siguiente frame pasaría de los limites
			// por lo que cambiamos de sentido
			sentido *= -1;
			
			// si es positivo vamos hacía la derecha
			if ( sentido > 0 ) {
				// Escribimos en la Consola la dirección usando el Script DebugMessages.cs
				dLog.WriteToLog("Derecha");
			} else {
				// Escribimos en la Consola la dirección usando el Script DebugMessages.cs
				dLog.WriteToLog("Izquierda");
			}
		}
		
		// realizamos el movimiento
		myTransform.Translate (Vector3.right * velocidad * sentido * Time.deltaTime);
		
	}

	public void DisminuirVidas() {
		vidas -= 1;
		if ( vidas < 1 ){
			GameOver();
			Debug.Log ("Fin");
		} 
	}
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}