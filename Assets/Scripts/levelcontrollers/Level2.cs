using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : ObjectControll {
	[SerializeField] public List<Quaternion> Limits;

	void Start(){
		vertical = true;
		horozantal = true;
	}
	protected override bool inLimit(){
		foreach (Quaternion lim in Limits)
		{
			//Debug.Log ("orientation: " + transform.rotation + " target " + lim);
			//Debug.Log("deg delta "  +Quaternion.Angle(transform.rotation, lim));
			if (Quaternion.Angle(lim, transform.rotation) < 8)
				return true;
			}
		return false;
	}
}
