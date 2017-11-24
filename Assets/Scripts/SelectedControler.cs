using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedControler : MonoBehaviour {
public ObjectControll [] models;
public int idx = 0;

void Awake()
{
	foreach (ObjectControll tmp in models)
		tmp.active = false;
	models[0].active = true;
}
	void FixedUpdate () {
		float d = Input.GetAxis("Mouse ScrollWheel");
		if (d > 0f)
		{
			models[idx].active = false;
			Debug.Log("Befor scrol " + idx);
			idx = (idx + 1 < models.Length) ? idx + 1 : 0;
			Debug.Log("After scrol " + idx);
			models[idx].active = true;
		}else if (d < 0f){
			models[idx].active = false;
			Debug.Log("Befor scrol " + idx);
			idx = (idx - 1 > 0) ? idx - 1 : models.Length - 1;
			Debug.Log("After scrol " + idx);
			models[idx].active = true;
		}
	}
}
