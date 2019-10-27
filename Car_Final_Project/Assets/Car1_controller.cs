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

	// Update is called once per frame
	void Update () {
		//getting player inpuit
		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float y = accelerator.value - brake.value;

		//movement by force
		if(y != 0)
		{
			var forwardForce = y * transform.forward * Speed * Time.deltaTime;

			transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
			rb.AddForce(forwardForce);
		}

		//dampening sliding
		var currentRightNormal = Vector3.Normalize(transform.right);
		var lateralDampeningVector = Vector3.Dot(currentRightNormal, rb.velocity) * currentRightNormal;
		var lateralDampeningImpulse = rb.mass * -lateralDampeningVector;
		rb.AddForce(lateralDampeningImpulse * Time.deltaTime);

		// more dampening
		rb.AddTorque( 0.1f * rb.inertiaTensor.magnitude * -rb.angularVelocity );

		//dampening when not moving
		var currentForwardNormal = Vector3.Normalize(transform.right);
		var forwardVelocity = Vector3.Dot(currentForwardNormal, rb.velocity) * currentForwardNormal;
		scoreText.text = "Vel : " + forwardVelocity;

		// removing unwanted rotations after any collisions
		var oldYRotation = transform.localEulerAngles.y;
		transform.localEulerAngles = new Vector3(0, oldYRotation, 0);

		//remove y changes after any collisions
		var actualXPosition = transform.localPosition.x;
		var actualZPosition = transform.localPosition.z;
		transform.localPosition = new Vector3(actualXPosition, referenceYPosition, actualZPosition);

		if (Input.GetKeyUp (KeyCode.Escape)) {
                    Debug.Log ("onResume Received");
                    AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer"); 
                    AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject> ("currentActivity"); 
					jo.Call("shareText",scoreText.text);
                    jo.Call ("onBackPressed");
            }
	}	
}




