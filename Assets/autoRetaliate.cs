using UnityEngine;
using System.Collections;

public class autoRetaliate : MonoBehaviour {

	public float m_retaliationDelay=1f;

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
			LifeCtrl playerLife = col.gameObject.GetComponent<LifeCtrl> ();
			if (playerLife != null) {
				playerLife.dcrHealth ();
				//StartCoroutine(Example());
			} else {
				Debug.Log ("Player has no life module!");
			}
		}
	}
	IEnumerator sliceDelay() {
		yield return new WaitForSeconds(m_retaliationDelay);

	}
	/*
	private void enemySlice(){
		Vector2 forward = moveRef.getLastHeading ();
		Debug.Log (forward);
		RaycastHit2D [] hits = Physics2D.RaycastAll (transform.position, forward, m_strikeLength);
		Vector2 there = (((Vector2) transform.position) + (forward*m_strikeLength));
		Debug.DrawLine (transform.position, there , Color.red,.5f);

		foreach (var hit in hits) {
			if (hit.collider.gameObject.tag != "Player") {
				LifeCtrl hitLife = hit.collider.gameObject.GetComponent<LifeCtrl> ();
				if (hitLife != null) {
					hitLife.dcrHealth ();
				}
			}
		}
	}
	*/
}
