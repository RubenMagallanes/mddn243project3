	var playerV1: Transform; // assign a gameObject from inspector
	
	function OnTriggerEnter (other : Collider) {
		if(other.tag == "Player"){
			GameObject.Find("Door").transform.position == playerV1.position;
			GameObject.Find("Door").transform.rotation == playerV1.rotation;
			
			print(transform.position);	
		}
	}