using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Controller_Cop : MonoBehaviour {

	private Animation anim;

	private Rigidbody rb;
    public float SpeedCop = 10.0f;
    public float rotationSpeedCop = 150.0f;

	private float referenceYPosition;
	
	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animation> ();
		rb = GetComponent<Rigidbody> ();

		referenceYPosition = transform.localPosition.y;
	}

	// Update is called once per frame
	void Update () {

		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float y = CrossPlatformInputManager.GetAxis ("Vertical");

		transform.Rotate(0, x * Time.deltaTime * rotationSpeedCop, 0);
        transform.Translate(0, 0, y * Time.deltaTime * SpeedCop);

		var oldYRotation = transform.localEulerAngles.y;
		transform.localEulerAngles = new Vector3(0, oldYRotation, 0);

		var actualXPosition = transform.localPosition.x;
		var actualZPosition = transform.localPosition.z;
		transform.localPosition = new Vector3(actualXPosition, referenceYPosition, actualZPosition);

		if (Input.GetKeyUp (KeyCode.Escape)) {
                    Debug.Log ("onResume Received");
                    AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer"); 
                    AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject> ("currentActivity"); 
                    jo.Call ("onBackPressed");
            }
	}	
}






