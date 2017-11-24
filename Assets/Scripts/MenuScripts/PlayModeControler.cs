using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayModeControler : PageController {

	public static PlayModeControler inctence = null;

    public override void activate()
    {
       if (!active)
		{
			animator.SetTrigger("active");
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
	 void OnMouseDown(){
		if (!active)
		{
			activate();
			alowInput();
		}
	 }
}
