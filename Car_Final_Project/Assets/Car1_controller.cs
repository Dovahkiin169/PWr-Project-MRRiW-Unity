using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Car1_controller : MonoBehaviour {

	private Animation anim;
	public Score score;
	public Text scoreText;

	private Rigidbody rb;
    public float Speed = 90.0f;
    public float rotationSpeed = 45.0f;

	private float referenceYPosition;
	public VJPedal accelerator;
	public VJPedal brake;

	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animation> ();
		rb = GetComponent<Rigidbody> ();
		scoreText = GameObject.Find("Scoretext").GetComponent<Text>(); 
		
		referenceYPosition = transform.localPosition.y;
	}

	void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "racetrack")
		{
			rb.velocity = Vector3.zero;
		}
    }

	private float xInput = 0;
	private float yInput = 0;

	// Update is called once per frame
	void Update () {
		//getting player inpuit
		xInput = CrossPlatformInputManager.GetAxis ("Horizontal");
		yInput = accelerator.value - brake.value;

		if (Input.GetKeyUp (KeyCode.Escape)) {
                    Debug.Log ("onResume Received");
                    AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer"); 
                    AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject> ("currentActivity"); 
					jo.Call("shareText",scoreText.text);
                    jo.Call ("onBackPressed");
            }
	}

	void FixedUpdate()
	{
		//movement by force
		if(yInput != 0)
		{
			var movementForce = yInput * transform.forward * Speed * Time.deltaTime; 

			var forwardVelocity = Vector3.Dot(Vector3.Normalize(transform.forward), rb.velocity);

			if(forwardVelocity >= 0)
			{
				transform.Rotate(0, xInput * Time.deltaTime * rotationSpeed, 0);
			}
			else
			{
				transform.Rotate(0, -xInput * Time.deltaTime * rotationSpeed, 0);
			}
			rb.AddForce(movementForce);
		}

		//dampening sliding
		var currentRightNormal = Vector3.Normalize(transform.right);
		var lateralDampeningVector = Vector3.Dot(currentRightNormal, rb.velocity) * currentRightNormal;
		var lateralDampeningImpulse = rb.mass * -lateralDampeningVector;
		rb.AddForce(lateralDampeningImpulse * Time.deltaTime);

		// more dampening
		rb.AddTorque( 0.1f * rb.inertiaTensor.magnitude * -rb.angularVelocity );

		// removing unwanted rotations after any collisions
		var oldYRotation = transform.localEulerAngles.y;
		transform.localEulerAngles = new Vector3(0, oldYRotation, 0);

		//remove y changes after any collisions
		var actualXPosition = transform.localPosition.x;
		var actualZPosition = transform.localPosition.z;
		transform.localPosition = new Vector3(actualXPosition, referenceYPosition, actualZPosition);
	}	
}




