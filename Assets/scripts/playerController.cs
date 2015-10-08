using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	//public float speed;

	public bool movementMode = false;//either choosing actions, or moving. start off choosing actions 

	public ArrayList actionList;//holds all commands
	public Queue actionQueue;  // user's ordered versionis transferred to this


	private Action currentAction;
	private int actionFrameCountCurrent;
	private int actionFrameCountFinal;
	private bool done = true; // true when ready to grab next action

	public int movementSpeed = 1;
	
	// Use this for initialization
	void Start () {
		movementMode = false;
		actionList = new ArrayList();
		actionQueue = new Queue ();

		fillActionList ();
		//localCommand = actionList.Dequeue()

	}
	
	// Update is called once per frame
	void Update () {
		//only moves player of in action mode
		//if (movementMode) {
			//checkGetAction();
			//switch(currentAction.action){
			//case "right":
			//	transform.position.x += movementSpeed;

			//}
		//}
	}
	public void parseCommands(){

	}

	//checks to see if old actions done, if so
	void checkGetAction(){

	}
	void FixedUpdate(){

	}

	void OnCollisionEnter(Collision other){
		//check for level end / door etc
		if (other.transform.tag == "goal") {
			//GameManager.completeLevel(); done in trigger 
		}
	}
	void OnTriggerEnter(Collider other){
		//check for level end
		if (other.transform.tag == "goal") {
			//GameManager.completeLevel ();
		}
	}

	void fillActionList(){
		//pre: not much really
		while (!GameManager.listReady) {
			//wait till it is
		}
		//condition: the action list in gameManager is ready
		foreach (Action element in GameManager.actions) {
			actionList.Add(element);
		}
		//post: actionList now populated with level's specific actions
	}

	void transferToQueue(){
		//pre: actionList is populated in the right order
		foreach (Action element in actionList){
			actionQueue.Enqueue(element);
		}
		//post: actionQueue contains actions in right ofder
	} 

	public class Action{
		public string action; // can be walk, jump, etc
		public int frameCount; // number of frames to do this action, may not need for all actions

		public Action(string kind){
			this.action = kind;
		}

		//should probably make other 
	}
}


/* (csharp):

     
    using UnityEngine;
    using System.Collections;
     
     
    public class PlayerTester : MonoBehaviour
    {
        // movement config
        public float gravity = -15f;
        public float runSpeed = 8f;
        public float groundDamping = 20f; // how fast do we change direction? higher means faster
        public float inAirDamping = 5f;
        // public float jumpWaitTime = 2.0;
     
        [HideInInspector]
        public float rawMovementDirection = 1;
        //[HideInInspector]
        public float normalizedHorizontalSpeed = 0;
     
        CharacterController2D _controller;
        Animator _animator;
        public RaycastHit2D lastControllerColliderHit;
     
        [HideInInspector]
        public Vector3 velocity;
     
     
        void Awake()
        {
            _animator = GetComponent<Animator>();
            _controller = GetComponent<CharacterController2D>();
            _controller.onControllerCollidedEvent += onControllerCollider;
        }
     
       
        void onControllerCollider( RaycastHit2D hit )
        {
            // bail out on plain old ground hits
            if( hit.normal.y == 1f )
             return;
     
            // logs any collider hits
            //Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
        }
     
     
        void Update()
        {
            // grab our current velocity to use as a base for all calculations
            velocity = _controller.velocity;
     
            if( _controller.isGrounded )
                velocity.y = 0;
     
            if( Input.GetKey( KeyCode.RightArrow ) )
            {
                normalizedHorizontalSpeed = 1;
                if( transform.localScale.x < 0f )
                    transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
     
                if( _controller.isGrounded )
                    _animator.Play( Animator.StringToHash( "Run" ) );
            }
            else if( Input.GetKey( KeyCode.LeftArrow ) )
            {
                normalizedHorizontalSpeed = -1;
                if( transform.localScale.x > 0f )
                    transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
     
                if( _controller.isGrounded )
                    _animator.Play( Animator.StringToHash( "Run" ) );
            }
            else
            {
                normalizedHorizontalSpeed = 0;
     
                if( _controller.isGrounded )
                    _animator.Play( Animator.StringToHash( "Idle" ) );
            }
     
     
            if( Input.GetKeyDown( KeyCode.UpArrow ) )
            {
            //to avoid DOUBLE JUMP
                if( _controller.isGrounded ) {
                var targetJumpHeight = 2f;
                velocity.y = Mathf.Sqrt( 2f * targetJumpHeight * -gravity );  
                _animator.Play( Animator.StringToHash( "Jump" ) ); 
                }
            }
     
     
            // apply horizontal speed smoothing it
            var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
            velocity.x = Mathf.Lerp( velocity.x, normalizedHorizontalSpeed * rawMovementDirection * runSpeed, Time.deltaTime * smoothedMovementFactor );
           
            // apply gravity before moving
            velocity.y += gravity * Time.deltaTime;
     
            _controller.move( velocity * Time.deltaTime );
        }
     
    }*/