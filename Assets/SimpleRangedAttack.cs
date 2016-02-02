using UnityEngine;
using System.Collections;

public class SimpleRangedAttack : MonoBehaviour {
	private patsySightControl m_sight;
	private RaycastHit2D[] m_hits;
	private GameObject m_toShoot;
	private bool m_shouldShoot=true;
	public float m_shotSpeed;
	public float m_shotDelay;

	IEnumerator fireDelay() {
		m_shouldShoot = false;
		yield return new WaitForSeconds(m_shotDelay);
		fire ();
		m_shouldShoot = true;
	}

	private bool shouldFire(){
		GameObject closePlayer = m_sight.getClosest ();
		if (closePlayer != null) {
			//Debug.Log ("Found player");
			int mask= ~(1 << 8);//only raycast on all but layer 8
			Physics2D.LinecastNonAlloc (transform.position, closePlayer.transform.position,m_hits,mask);
			//Debug.Log ("hits "+m_hits [0].collider.gameObject.tag+" "+m_hits [1].collider.gameObject.tag);
			if (m_hits [1] != null) {
				Debug.Log ("Aiming at " + m_hits [1].collider.gameObject.name+ "and shouldShoot is: "+m_shouldShoot);
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
		//Debug.Log ("Fired");
		GameObject closePlayer = m_sight.getClosest ();
		if (closePlayer != null) {
			Vector2 towardsPlayer = closePlayer.transform.position - transform.position;
			towardsPlayer.Normalize ();
			Vector2 firingPos = wherePlace (towardsPlayer);
			m_toShoot = Resources.Load ("shuriken") as GameObject;
			GameObject shotObj = (GameObject)Instantiate (m_toShoot, firingPos, Quaternion.identity);
			shotObj.GetComponent<Rigidbody2D> ().velocity = towardsPlayer * m_shotSpeed;
		} else {
			Debug.Log("closePlayer is null");
		}
	}
		
	// Use this for initialization
	void Start () {
		m_sight = GetComponent<patsySightControl> ();
		m_hits = new RaycastHit2D[2];

	}
	
	// Update is called once per frame
	void Update () {
		if (shouldFire () && m_shouldShoot) {
			StartCoroutine(fireDelay ());
		} else {
			//Debug.Log ("In the way");
		}
	}
}
