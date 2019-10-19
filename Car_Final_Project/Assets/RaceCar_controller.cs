using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class RaceCar_controller : MonoBehaviour {

	private Animation anim;

	private Rigidbody rb;
    public float movementSpeedNewRaceCar = 20.0f;
    public float rotationSpeedNewRaceCar = 5.0f;
	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animation> ();
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float y = CrossPlatformInputManager.GetAxis ("Vertical");

		transform.Rotate(0, x * Time.deltaTime * rotationSpeedNewRaceCar, 0);
        transform.Translate(0, 0, -y * Time.deltaTime * movementSpeedNewRaceCar);

		var oldYRotation = transform.localEulerAngles.y;
		transform.localEulerAngles = new Vector3(0, oldYRotation, 0);

		var oldXPosition = transform.localPosition.x;
		var oldZPosition = transform.localPosition.z;
		transform.localPosition = new Vector3(oldXPosition, 0, oldZPosition);


		if (Input.GetKeyUp (KeyCode.Escape)) {
                    Debug.Log ("onResume Received");
                    AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer"); 
                    AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject> ("currentActivity"); 
                    jo.Call ("onBackPressed");
            }
	}	
}


