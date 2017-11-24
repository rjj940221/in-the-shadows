using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

	private Animator animator;
	private bool state = false;
	
	public static PauseController incetence = null;
	
	void Awake(){
		if (incetence == null)		{
			animator = GetComponent<Animator>();
			incetence = this;
		}else if (incetence != this){
			Destroy(this.gameObject);
		}
		
	}

	 void Update(){
		 if (Input.GetKeyDown(KeyCode.Escape)){
			state = !state;
			animator.SetBool("Compleat", state);
		 }
	 }
	public void open(){
		animator.SetBool("Compleat", true);
	}

	public void close(){
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetBool("Play", false);
		animator.SetBool("Compleat", false);
	}

	public void exit(){
		PlayerPrefs.Save();
		Application.Quit();
	}
}
