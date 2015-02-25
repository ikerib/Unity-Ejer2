using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject PrefBala;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			GameObject bala = (GameObject)GameObject.Instantiate(PrefBala); 
			Rigidbody balaFisicas = (Rigidbody) bala.GetComponent<Rigidbody>();
			balaFisicas.AddForce(new Vector3(0,130,-400));
		}
	}
}
