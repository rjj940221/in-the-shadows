using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : ObjectControll {
	[SerializeField] public List<Quaternion> Limits;
	public bool oriented = false;
	public Level4 other;

	public bool isOriented(){
		foreach (Quaternion lim in Limits)
		{
			//Debug.Log("deg delta "  +Quaternion.Angle(lim, transform.rotation));
			if (Quaternion.Angle(lim, transform.rotation) < tolerance){
				if (!oriented)
					sfx.Play();
				oriented = true;
				return true;
			}
		}
		oriented = false;
		return false;
	}

	void Start(){
		vertical = true;
		horozantal = true;
		move  = false;
	}
	protected override bool inLimit(){
		//Debug.Log ("orientation: " + transform.rotation);
		if (isOriented() && other.isOriented())
			return true;
		else
			return false;
	}
}