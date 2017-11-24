using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionController : PageController {

	public delegate void Reset();
    public static event Reset resetEvt;

	public static OptionController inctence = null;

	public void testMode(){
		LevelCompleatController.incetence.setTestMode(true);
		this.deactivate();
		//TestModeControler.inctence.activate();
		TestModeControler.inctence.alowInput();
	}
	public void playMode(){
		LevelCompleatController.incetence.setTestMode(false);
		this.deactivate();
		TestModeControler.inctence.deactivate();
		TestModeControler.inctence.blockInput();
		PlayModeControler.inctence.alowInput();
	}

    public override void activate()
    {
       if (!active)
		{
			animator.SetTrigger("active");
			TestModeControler.inctence.blockInput();
			active = true;
			sfx.Play();
		}
    }

    void Awake(){
	if (inctence == null){
		inctence = this;
		animator = gameObject.GetComponent<Animator>();
		canvasGroup = gameObject.GetComponentInChildren<CanvasGroup>();
		sfx = gameObject.GetComponent<AudioSource>();
	}else if (inctence != this)
		Destroy(this.gameObject);
	}

	public override void switchPage(){
 		if (!active){
			activate();
			alowInput();
			TestModeControler.inctence.activate();
			TestModeControler.inctence.blockInput();
		}
	}
	 public void resetProgres(){
		 PlayerPrefs.DeleteAll();
		 if (resetEvt != null)
		 	resetEvt();
	 }
}
