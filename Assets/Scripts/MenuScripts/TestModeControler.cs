using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestModeControler : PageController {

public static TestModeControler inctence = null;

    public override void activate()
    {
       if (!active)
		{
			animator.SetTrigger("active");
			active = true;
			sfx.Play();
		}
    }

	public override void switchPage(){
 		if (!active){
			activate();
			alowInput();
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
}
