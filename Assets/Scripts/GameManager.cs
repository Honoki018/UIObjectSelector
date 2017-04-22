using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	Canvas[] canvas;

	public GameObject selectedIndicatorPrefab;
	public List<GameObject> selectedObjects;
	public List<GameObject> selectedIndicators;

	void Start(){
		this.canvas = GameObject.FindObjectsOfType<Canvas> ();
	}

	public void setSelectedObject(GameObject obj){
		clearSelectedObjects ();
		addSelectedObject (obj);
	}

	public void addSelectedObject(GameObject obj){
		this.selectedObjects.Add (obj);
		addIndicatorForObject (obj);
	}

	public void clearSelectedObjects(){
		this.selectedObjects.Clear ();
		clearIndicatorsFromObjects ();
	}

	void addIndicatorForObject (GameObject obj){
		GameObject selector = (Instantiate (selectedIndicatorPrefab));
		selector.transform.SetParent (this.canvas[0].transform, false);
		selector.GetComponent<UISelectedIndicator> ().setTarget (obj);
		this.selectedIndicators.Add (selector);
	}

	void clearIndicatorsFromObjects(){
		foreach (GameObject indicator in this.selectedIndicators) {
			Destroy (indicator.gameObject);
		}
		this.selectedIndicators.Clear ();
	}
}

