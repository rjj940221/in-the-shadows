using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageController : MonoBehaviour {
	protected Animator animator;
	protected CanvasGroup canvasGroup;

	protected AudioSource sfx;
	
	public bool active = true;
	abstract public void activate();
	virtual public void deactivate(){
		if (active)
		{
			active = false;
			animator.SetTrigger("deactive");
			blockInput();
			sfx.Play();
		}
	}
	public void blockInput(){
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}

	public void alowInput(){
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
	}

	public virtual void switchPage(){
 		if (active){
			deactivate();
		}else{
			activate();
		}
	}
	 void OnMouseDown(){
		switchPage();
	 }
}
