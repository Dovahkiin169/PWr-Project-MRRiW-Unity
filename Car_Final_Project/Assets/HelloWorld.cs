using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System;

public class HelloWorld : MonoBehaviour {

    Text textObj;

	void Start () {

        int x = System.Convert.ToInt32(CaptiveReality.Jni.Util.StaticCall<string>("sayHello", "Invalid Response From JNI", "com.captivereality.texturehelper.HelloWorld"));
        if(x==1)
        {
            GameObject.Find ("PoliceCar").SetActive(false);
            GameObject.Find ("RaceCar").SetActive(false);
        }
        else if(x==2)
        {
            GameObject.Find ("SlowCar").SetActive(false);
            GameObject.Find ("PoliceCar").SetActive(false);
        }
        else if(x==3)
        {
            GameObject.Find ("SlowCar").SetActive(false);
            GameObject.Find ("RaceCar").SetActive(false);
        }

        // Make the call using JNI to the Java Class and write out the response (or write 'Invalid Response From JNI' if there was a problem).
       // textObj.text = CaptiveReality.Jni.Util.StaticCall<string>("sayHello", "Invalid Response From JNI", "com.captivereality.texturehelper.HelloWorld");
    }
	
}
