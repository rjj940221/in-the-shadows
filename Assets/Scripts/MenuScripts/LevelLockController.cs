using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLockController : MonoBehaviour {
	public string level;
	public Sprite check;
	public Sprite unCheck;

	public bool alwaysOpen = false;
	private Button btn_load;
	public Image img_check;

	void Awake(){
		btn_load = gameObject.GetComponentInChildren<Button>();
		setState();
		LevelCompleatController.compleat += setState;
		OptionController.resetEvt += setState;
	}

	protected void setState(){
		img_check.sprite = unCheck; 
		if ((PlayerPrefs.HasKey(level) && PlayerPrefs.GetInt(level)> 0) || alwaysOpen){
			btn_load.interactable = true;
			if (PlayerPrefs.GetInt(level) == 2)
				img_check.sprite = check;
		}else{
			btn_load.interactable = false;
		}
	}

    void OnDestroy()
    {
        LevelCompleatController.compleat -= setState;
		OptionController.resetEvt -= setState;
    }
}
