using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	Canvas[] canvas;
	[Header("Prefabs")]
	public GameObject selectedIndicatorPrefab;
	private List<GameObject> selectedObjects = new List<GameObject>();
	private List<GameObject> selectedIndicators = new List<GameObject>();

	void Start(){
		this.canvas = GameObject.FindObjectsOfType<Canvas> ();
	}

//SELECTED OBJECT LIST
	//select an object
	public void selectObject(GameObject obj){
		this.clearSelectedObjects();
		this.addSelectedObject(obj);
	}

	public void selectAnotherObject(GameObject obj){
		if(this.selectedObjects.Contains(obj)){
			this.deselectObject(obj);
		} else {
			this.addSelectedObject(obj);
		}
	}
	//add selected object
	public void addSelectedObject(GameObject obj){
		if(!obj){
			this.clearSelectedObjects();
			return;
		}
		
		this.selectedObjects.Add(obj);
		this.createSelectedIndicatorForObject(obj);
	}
	//remove a selected object
	public void deselectObject(GameObject obj){
		if(!obj){
			return;
		}
		int index = this.selectedObjects.IndexOf(obj);
		if(index >=0 && index < this.selectedObjects.Count && index < this.selectedIndicators.Count){
			this.removeIndicatorAtIndex(index);
			this.selectedObjects.RemoveAt(index);
		}
	}
	//clear all selected object
	public void clearSelectedObjects(){
		this.selectedObjects.Clear();
		this.clearAllIndicators();
	}

//SELECTED INDICATOR LIST	-private
	//create an indicator
	private void createSelectedIndicatorForObject(GameObject obj){
		GameObject selector = (Instantiate (selectedIndicatorPrefab));
		selector.transform.SetParent (this.canvas[0].transform, false);
		selector.GetComponent<UISelectedIndicator> ().setTarget (obj);
		this.selectedIndicators.Add (selector);
	}
	//remove an indicator
	private void removeIndicatorAtIndex(int index){
		Destroy(this.selectedIndicators[index]);
		this.selectedIndicators.RemoveAt(index);
	}
	//clear all indicator
	private void clearAllIndicators(){
		foreach (GameObject indicator in this.selectedIndicators){
			Destroy(indicator.gameObject);
		}
		this.selectedIndicators.Clear();
	}
}

