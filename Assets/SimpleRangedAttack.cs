using UnityEngine;
using System.Collections;

public class SimpleRangedAttack : MonoBehaviour {
	private patsySightControl m_sight;
	private RaycastHit2D[] m_hits;
	private GameObject m_toShoot;
	private bool shot=false;
	public float m_shotSpeed;

	public void incrShot(){
		shot = false;
	}

	private bool shouldFire(){
		GameObject closePlayer = m_sight.getClosest ();
		if (closePlayer != null) {
			Physics2D.LinecastNonAlloc (transform.position, closePlayer.transform.position,m_hits);
			//Debug.Log ("hits "+m_hits [0].collider.gameObject.tag+" "+m_hits [1].collider.gameObject.tag);
			if (m_hits [1] != null) {
				return m_hits [1].collider.gameObject.tag == "Player";
			}
		} else {
			return false;
		}
	}

	private Vector2 wherePlace(Vector2 towardsPlayer){
		return (Vector2) transform.position+(towardsPlayer * (GetComponent<CircleCollider2D> ().radius + .25f));
	}

	public void fire(){
		GameObject closePlayer = m_sight.getClosest ();
		Vector2 towardsPlayer = closePlayer.transform.position - transform.position;
		towardsPlayer.Normalize ();
		Vector2 firingPos = wherePlace (towardsPlayer);
		m_toShoot = Resources.Load ("shuriken") as GameObject;
		GameObject shotObj=(GameObject) Instantiate(m_toShoot, firingPos, Quaternion.identity);
		shotObj.GetComponent<Rigidbody2D> ().velocity = towardsPlayer * m_shotSpeed;
		shot = true;
	}
		
	// Use this for initialization
	void Start () {
		m_sight = GetComponent<patsySightControl> ();
		m_hits = new RaycastHit2D[2];

	}
	
	// Update is called once per frame
	void Update () {
		if (shouldFire ()&&!shot) {
			fire ();
		} else {
			//Debug.Log ("In the way");
		}
	}
}
