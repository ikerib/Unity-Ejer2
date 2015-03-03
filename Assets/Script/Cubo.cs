using UnityEngine;
using System.Collections;

public class Cubo : MonoBehaviour
{
	
		// Variables publicas para el acceso desde el diseñador
		public float velocidad;
		public float maxLeft;
		public float maxRight;
		public DebugMessages dLog;
		public int vidas;

		// Variables privadas del script
		Transform myTransform;
		int sentido;
		private bool gameOver; // Constrola si hay que finalizar el juego o no
	
		// Use this for initialization
		void Start ()
		{
		
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
				gameOver = false;


		}
	
		// Update is called once per frame
		void Update ()
		{
				// comprobamos si estamos dentro de los limites
				if (((myTransform.position.x <= maxLeft) && (sentido == -1)) 
		    ||
						((myTransform.position.x >= maxRight) && (sentido == 1))) {
						// Si entra es que en el siguiente frame pasaría de los limites
						// por lo que cambiamos de sentido
						sentido *= -1;
				}
		
				// realizamos el movimiento
				myTransform.Translate (Vector3.right * velocidad * sentido * Time.deltaTime);
		
		}

		// Función para restar vidas al personaje
		public void DisminuirVidas ()
		{
				vidas -= 1;
				if (vidas < 1) {
						// terminamos el juego
						audio.Play ();
						gameOver = true;
						Camera.main.audio.Stop ();						
				} 
		}

		
		void OnGUI ()
		{
				// Mostramos Vidas
				GUI.Label (new Rect (10, 10, 200, 100), vidas.ToString ());
				if (gameOver) {
						// Mostramos Game Over
						this.velocidad = 0f;
						GUI.Label (new Rect (380, 310, 320, 220), "<color=white><size=50>Game Over</size></color>");
				}
						
		}	
}