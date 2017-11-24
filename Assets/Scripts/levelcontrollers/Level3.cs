using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : ObjectControll {

	[System.Serializable] public class Limit{
			public Quaternion rotation;
			public Vector3 move;

			public Limit(Quaternion rotation, Vector3 move)
			{
				this.rotation = rotation;
				this.move = move;
			}
	}
	[SerializeField] public Limit limit;
	[SerializeField] public Level3 other;
	public bool oriented = false;

	public bool isOriented(){
		Debug.Log(oriented);
		if (Quaternion.Angle(limit.rotation, transform.rotation) < 20){
			if (!oriented)
				sfx.Play();
			oriented = true;
			return  true;
		}else{
			oriented = false;
			return  false;
		}
	}

	void Start(){
		vertical = true;
		horozantal = true;
		move = true;
	}
	protected override bool inLimit(){
		//Debug.Log ("orientation: " + transform.rotation + " target " + limit.rotation);
		//Debug.Log("deg delta "  +Quaternion.Angle(transform.rotation, limit.rotation));
		
		float yoff = other.transform.position.y - transform.position.y;
		float zoff = other.transform.position.z - transform.position.z;
		//Debug.Log ("yoff:"+yoff+ " zoff " + zoff);
		if (isOriented() && other.isOriented()
		&& yoff > limit.move.y - 0.5
		&& yoff < limit.move.y + 0.5
		&& zoff > limit.move.z - 0.5
		&& zoff < limit.move.z + 0.5){
			return true;
		}
		return false;
	}
}
