using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public enum InputType{
	inputPC,
	inputMobile
}

public class InputManager : MonoBehaviour {

	private GameManager gameManager;
	public LayerMask SelectableLayers;		//create the layers in the inspector and select the selectable layers here.
	public InputType inputType;

	void Start(){
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}

	void Update () {
		if (inputType == InputType.inputPC) {
			ComputerInputs ();
		} else if (inputType == InputType.inputMobile) {
		
		}
	}

	void ComputerInputs(){
		if(Input.GetKey(KeyCode.LeftShift)){
			if(Input.GetMouseButtonDown(0)){
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				this.gameManager.selectAnotherObject(this.getSelectableObjectFromInputRay(ray));
			} else if (Input.GetMouseButtonDown(1)){

			}
		} else {
			if(Input.GetMouseButtonDown(0)){
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				this.gameManager.selectObject(this.getSelectableObjectFromInputRay(ray));
			} else if (Input.GetMouseButtonDown(1)){

			}
		}
	}

	GameObject getSelectableObjectFromInputRay(Ray ray){
		GameObject result = null;

		RaycastHit hitInfo;
		if(Physics.Raycast (ray, out hitInfo, 100, this.SelectableLayers.value)){
			result = hitInfo.transform.root.gameObject;
		}

		return result;
	}
}
