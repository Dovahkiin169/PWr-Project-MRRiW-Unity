using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Script : MonoBehaviour {
	public Button JumpButton;

	void Start () {
		Button btn = JumpButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
	}
}