using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Car1_controller : MonoBehaviour {

	private Animation anim;

	private Rigidbody rb;
    public float Speed = 5.0f;
    public float rotationSpeed = 45.0f;
	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animation> ();
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float y = CrossPlatformInputManager.GetAxis ("Vertical");
	

		//transform.position += new Vector3(0,0,y/10);
		//transform.position += new Vector3(x/10,0,0);

		//Vector3 movement = new Vector3 (x, 0.0f, y);

		//enter trumps speed here!!!
		//rb.velocity = movement * 4f;

		transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * Speed);
		//rb.AddForce(new Vector3(x, 0.0f, y) * speed);

		/*if (x != 0 && y != 0) {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, Mathf.Atan2 (x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
		}*/

		if (Input.GetKeyUp (KeyCode.Escape)) {
                    Debug.Log ("onResume Received");
                    AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer"); 
                    AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject> ("currentActivity"); 
                    jo.Call ("onBackPressed");
            }

		//if (Input.GetKeyDown(KeyCode.Escape)){
	//		Application.Quit(); 
	//	}  
	}	
}




