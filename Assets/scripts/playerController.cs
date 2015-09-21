using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float speed;
	private Rigidbody pl;
	// Use this for initialization
	void Start () {
		pl = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		float moveSideways = Input.GetAxis("Horizontal");

		Vector3 dir = new Vector3 (moveSideways, 0.0f, 0.0f);

		pl.AddForce (dir * speed);
	}

	void OnCollisionEnter(Collision other){
		//check for level end / door etc
		if (other.transform.tag == "goal") {
			GameManager.completeLevel();
		}
	}
}
