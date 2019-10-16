using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class NitroController : MonoBehaviour
{
    // Start is called before the first frame update
	private Rigidbody rb;
    public float movementSpeed = 20.0f;
    public float rotationSpeed = 5.0f;
	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animation> ();
		rb = GetComponent<Rigidbody> ();
	}

    // Update is called once per frame
    void Update()
    {
        		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float y = CrossPlatformInputManager.GetAxis ("Vertical");
                transform.Translate(0, 0, -y * Time.deltaTime * movementSpeed);
    }
}
