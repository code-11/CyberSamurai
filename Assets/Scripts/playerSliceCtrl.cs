using UnityEngine;
using System.Collections;

public class playerSliceCtrl : MonoBehaviour {

	public float m_strikeLength=1f;

	private playerMoveCtrl moveRef;
	private Rigidbody2D rb;
	private LineRenderer mineLaser;

	void Start () {
		mineLaser = gameObject.AddComponent<LineRenderer> ();
		mineLaser.material = new Material (Shader.Find ("Sprites/Default"));
		mineLaser.material.color = Color.red;	
		mineLaser.sortingOrder = 1;
		mineLaser.SetWidth (0.05F, 0.05F);
		mineLaser.SetVertexCount (2);

		rb = GetComponent<Rigidbody2D>();
		moveRef = GetComponent<playerMoveCtrl> ();
	}

	private void slice(){
		Vector2 forward = moveRef.getLastHeading ();
		Debug.Log (forward);
		RaycastHit2D [] hits = Physics2D.RaycastAll (transform.position, forward, m_strikeLength);
		Vector2 there = (((Vector2) transform.position) + (forward*m_strikeLength));
		//Debug.DrawLine (transform.position, there , Color.red,.5f);
		mineLaser.SetPosition (0, transform.position);
		mineLaser.SetPosition (1, there);

		foreach (var hit in hits) {
			if (hit.collider.gameObject.tag != "Player") {
				LifeCtrl hitLife = hit.collider.gameObject.GetComponent<LifeCtrl> ();
				if (hitLife != null) {
					hitLife.dcrHealth ();
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			slice ();
		}

	}
}
