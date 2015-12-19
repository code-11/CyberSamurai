using UnityEngine;
using System.Collections;

public class LifeCtrl : MonoBehaviour {

	public int m_health=1;


	public void dcrHealth(){
		m_health-=1;
		healthCheck();
	}

	private void healthCheck(){
		if (m_health<=0){
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
