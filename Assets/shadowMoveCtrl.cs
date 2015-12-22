using UnityEngine;
using System.Collections;

public class shadowMoveCtrl : MonoBehaviour {
	private patsySightControl m_sight;
	private Rigidbody2D m_rb;

	private int teleports = 3;


	// Use this for initialization
	void Start () {
		m_sight = GetComponent<patsySightControl> ();
		m_rb = GetComponent<Rigidbody2D>();

	}

	void teleportBehind(){
		GameObject closePlayer = m_sight.getClosest ();
		if (closePlayer != null) {
			Vector2 towardsPlayer = closePlayer.transform.position - transform.position;
			if (towardsPlayer.magnitude < 1) {
				Vector2 newPos = (Vector2)transform.position + towardsPlayer * 4;
				Debug.Log ("CurPos: " + transform.position + " newPos: " + newPos);
				Collider2D there = Physics2D.OverlapCircle (newPos, GetComponent<CircleCollider2D> ().radius);
				Debug.DrawLine (transform.position, (Vector2)transform.position+newPos , Color.red);
				if (there == null) {
					transform.position = newPos;
					teleports -= 1;
				} else {
					Debug.Log ("Can't teleport");
				}
			}
			//Debug.Log ("towards:"+towardsPlayer);
		}
	}

	// Update is called once per frame
	void Update () {
		if (teleports>0) {
			teleportBehind ();
		}
	}
}
