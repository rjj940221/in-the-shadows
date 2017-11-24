using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleatController : MonoBehaviour {

	private Animator animator;
	public bool testMode = true;
	public static LevelCompleatController incetence = null;

	public delegate void LevelCompleat();
    public static event LevelCompleat compleat;

	//public bool testMode = true;
	
	void Awake(){
		if (incetence == null)		{
			animator = GetComponent<Animator>();
			incetence = this;
		}else if (incetence != this){
			Destroy(this.gameObject);
		}
		
	}
	public void saveLevel(string level, int state){
		if (!testMode)
		{
			PlayerPrefs.SetInt(level, state);
			PlayerPrefs.Save();
		}
	}
	public void unlockLevel(string level){
		if(!testMode && PlayerPrefs.GetInt(level) < 1){
			saveLevel(level, 1);
		}
	}
	public void open(){
		animator.SetBool("Compleat", true);
	}

	public void close(){
		if(compleat != null)
                compleat();
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetBool("Play", false);
		animator.SetBool("Compleat", false);
	}

	public void exit(){
		PlayerPrefs.Save();
		Application.Quit();
	}

	public void setTestMode(bool testMode){
		this.testMode = testMode;
	}
}
