using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {

	 [SerializeField] protected GameObject model;
	 private GameObject spawn;
	
	void Awake(){
		spawn = GameObject.FindGameObjectWithTag("Spawn");
	}

	public void loadLevel(){
		try{
		GameObject [] tmp = GameObject.FindGameObjectsWithTag("ModelInPlay");
		foreach (GameObject obj in tmp)
			Destroy(obj.gameObject);
		}catch(UnityException e){
			Debug.Log("caught: " + e);
		}
		
		Instantiate(model, spawn.transform);
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Play");
	}
}
