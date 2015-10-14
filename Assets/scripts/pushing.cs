using UnityEngine;
using System.Collections;

public class pushing : MonoBehaviour {

	float pushPower = 2.0f;
	public void OnControllerColliderHit (ControllerColliderHit hit){
		Rigidbody body = hit.collider.attachedRigidbody;

		if (body == null || body.isKinematic) {
			return;
		}
		if (hit.moveDirection.y < -0.3) {
			return;
		}

		Vector3 pushDir = new Vector3 (hit.moveDirection.x,0,0);
	
		body.velocity = pushDir * pushPower;
	}

}
