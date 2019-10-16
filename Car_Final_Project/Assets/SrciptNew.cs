using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptNew : MonoBehaviour {
	public Button JumpButton;

	void Start () {
		Button btn = JumpButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		transform.Translate(0, 0, -10 * Time.deltaTime * 10.0f);
	}
}