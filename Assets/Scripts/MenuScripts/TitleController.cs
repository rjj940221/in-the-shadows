using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : PageController {

static TitleController inctence = null;

    public override void activate()
    {
		if (!active)
		{
			if (!OptionController.inctence.active){
				OptionController.inctence.activate();
			}
			if (!TestModeControler.inctence.active){
				TestModeControler.inctence.activate();
			}
			OptionController.inctence.blockInput();
			TestModeControler.inctence.blockInput();
			animator.SetTrigger("active");
			active = true;
			sfx.Play();
		}
    }
	public override void deactivate(){
		base.deactivate();
		OptionController.inctence.alowInput();
		blockInput();
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
