using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

	public Cubo myCubo;

	// Use this for initialization
	void Start () {
		Vector3 CameraPosition;
		CameraPosition = Camera.main.gameObject.transform.position;

		this.transform.position = CameraPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Cubo") {
			Destroy(gameObject);  
			myCubo.DisminuirVidas();
			Debug.Log ("Choque!");
		}
		Destroy(gameObject);  
	}
}
