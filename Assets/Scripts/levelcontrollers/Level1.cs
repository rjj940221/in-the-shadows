using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : ObjectControll {

	public Quaternion limit;
	protected override bool inLimit(){
			//Debug.Log ("orientation: " + transform.rotation + " target " + limit);
			//Debug.Log("deg delta "  +Quaternion.Angle(transform.rotation, limit));
		if (Quaternion.Angle(limit, transform.rotation) < 20)
		{
			horozantal = false;
			return true;
		}
		return false;
	}
}
