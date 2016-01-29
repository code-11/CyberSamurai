using UnityEngine;
using System.Collections;

public class LifeCtrl : MonoBehaviour {

	public int m_health=1;
	private DeathCinema m_afterlife;
	public bool m_triggersAfterlife;
	public bool m_gensBody;

	public void dcrHealth(){
		m_health-=1;
		healthCheck();
	}
	public void instaKill(){
		m_health = 0;
		healthCheck();
	}

	public void genBody(){
		GameObject body = Resources.Load ("body") as GameObject;
		GameObject bodyObj=(GameObject) Instantiate(body, transform.position+new Vector3(0,0,1), Quaternion.identity);
	}

	private void healthCheck(){
		if (m_health<=0){
			if (m_triggersAfterlife) {
				Debug.Log ("Activiating Cinema");
				gameObject.transform.GetChild(0).GetComponent<Camera> ().enabled = false;
				m_afterlife.activateCinema (gameObject.transform.position);
			}
			if (m_gensBody) {
				genBody ();
			}
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		m_afterlife=GameObject.FindGameObjectWithTag ("gameInfo").GetComponent<DeathCinema> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
