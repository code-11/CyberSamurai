using UnityEngine;
using System.Collections;

public class shurikenLogic : MonoBehaviour {
	void OnCollisionEnter2D (Collision2D col)
	{
		LifeCtrl life = col.gameObject.GetComponent<LifeCtrl> ();
		if (life != null) {
			life.dcrHealth ();
			Destroy(gameObject);
		} else {
			//hit an object with no life
			Destroy(gameObject);
		}
	}
}
