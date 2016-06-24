using UnityEngine;
using System.Collections;

public class BombCtrl : MonoBehaviour {
	public float m_timeToExplode;
	private Sprite m_explosionSprite;
	// Use this for initialization
	void Start () {
		StartCoroutine (countdown ());		
	}
	private IEnumerator countdown(){
		yield return new WaitForSeconds(m_timeToExplode-.3f);
		graphicalExplosion ();
		yield return new WaitForSeconds(.3f);
		explode ();
	}
	private void graphicalExplosion(){
		SpriteRenderer theSprite=gameObject.GetComponent<SpriteRenderer> ();
		Sprite explosionSprite= Resources.Load<UnityEngine.Sprite>("Sprites/explosion");
		theSprite.color = new Color (1, 1, 1);
		//Debug.Log (explosionSprite);
		theSprite.sprite = explosionSprite;
	}
		
	private void explode(){
		Collider2D[] hits;
		hits = Physics2D.OverlapCircleAll (transform.position, 1.5f);
		foreach (Collider2D hit in hits) {
			LifeCtrl lifeForce = hit.gameObject.GetComponent<LifeCtrl> ();
			if (lifeForce != null) {
				lifeForce.dcrHealth ();
			}
		}
		Destroy (gameObject);
	}
}
