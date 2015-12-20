using UnityEngine;
using System.Collections;

public class autoRetaliate : MonoBehaviour {

	public float m_retaliationDelay=1f;
	public float m_strikeLength=1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Vector2 hitLoc = col.contacts [0].point;
			Vector2 hitDir = hitLoc - (Vector2) transform.position;
			Debug.Log (hitDir);
			StartCoroutine (sliceDelay (hitDir));
			/*
			LifeCtrl playerLife = col.gameObject.GetComponent<LifeCtrl> ();
			if (playerLife != null) {
				playerLife.dcrHealth ();
				//StartCoroutine(Example());
			} else {
				Debug.Log ("Player has no life module!");
			}
			*/
		}
	}
	IEnumerator sliceDelay(Vector2 hitLoc) {
		yield return new WaitForSeconds(m_retaliationDelay);
		enemySlice (hitLoc);
	}

	private void enemySlice(Vector2 hitLoc){
		hitLoc.Normalize ();
		RaycastHit2D [] hits = Physics2D.RaycastAll (transform.position, hitLoc, m_strikeLength);
		Vector2 there = (((Vector2) transform.position) + (hitLoc*m_strikeLength));
		Debug.DrawLine (transform.position, there , Color.red,m_strikeLength);

		foreach (var hit in hits) {
			if (hit.collider.gameObject.tag == "Player") {
				LifeCtrl hitLife = hit.collider.gameObject.GetComponent<LifeCtrl> ();
				if (hitLife != null) {
					hitLife.dcrHealth ();
				}
			}
		}
	}

}
