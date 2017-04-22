using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType{
	mouse,
	touch
}

public class InputManager : MonoBehaviour {

	public InputType inputType;
	public GameManager gameManager;

	void Start(){
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}

	void Update () {
		if (inputType == InputType.mouse) {
			SelectObjectByMouse ();
		} else if (inputType == InputType.touch) {
		
		}
	}

	void SelectObjectByMouse(){
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;

			if (Physics.Raycast (ray, out hitInfo)) {
				/*it is adviced to create a base object for a model
				where the actual model would be in.
				this will provide a more managable object for you.*/
				//this gets the gameobject where the collider is
				GameObject hitObject = hitInfo.transform.root.gameObject;
				SelectObject (hitObject);
			} else {
				ClearSelectedObject ();
			}
		}
	}

	void SelectObject (GameObject obj){

		for (int i = 0; i < gameManager.selectedObjects.Count; i++) {
			if (obj == gameManager.selectedObjects[i]) {
				return;
			}
			ClearSelectedObject ();
		}

		gameManager.setSelectedObject(obj);
	}

	void ClearSelectedObject(){
		if (gameManager.selectedObjects.Count > 0) {
			gameManager.clearSelectedObjects();
		}
	}
}
