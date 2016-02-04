using UnityEngine;
using System.Collections;

public class patsyMoveControl : MonoBehaviour {

	public float m_speed;

	private patsySightControl m_sight;
	private Rigidbody2D m_rb;


	// Use this for initialization
	void Start () {
		m_sight = GetComponent<patsySightControl> ();
		m_rb = GetComponent<Rigidbody2D>();

	}

	void moveTowards(){
		GameObject closePlayer = m_sight.getClosest ();
		if (closePlayer != null) {
			Vector2 towardsPlayer = closePlayer.transform.position - transform.position;
			towardsPlayer.Normalize ();			
			towardsPlayer=towardsPlayer * m_speed;
			m_rb.velocity = towardsPlayer;
			//Debug.Log ("towards:"+towardsPlayer);
		}
	}

	// Update is called once per frame
	void Update () {
		moveTowards ();
	}
}
