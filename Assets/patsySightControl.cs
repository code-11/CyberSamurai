using UnityEngine;
using System.Collections;

public class patsySightControl : MonoBehaviour {

	public ArrayList m_allPlayers;
	public float m_sightRange=2f;

	private GameObject m_closestPlayer;

	private GameObject findClosest(){
		float min = (((GameObject) m_allPlayers [0]).transform.position-transform.position).magnitude;
		GameObject minPlayer = null;//(GameObject)m_allPlayers [0];

		foreach(GameObject player in m_allPlayers){
			float possibleMin = (player.transform.position - transform.position).magnitude;
			if (possibleMin <= min && possibleMin<=m_sightRange) {
				min = possibleMin;
				minPlayer = player;
			}
		}
		return minPlayer;
	}

	public GameObject getClosest(){
		return m_closestPlayer;
	}

	void Start(){
		GameObject gi = GameObject.FindGameObjectWithTag ("gameInfo");
		gameInfo giInfo = gi.GetComponent<gameInfo> ();
		if (giInfo != null) {
			m_allPlayers = giInfo.getPlayerList ();
		} else {
			Debug.Log ("player list module is null");
		}
	}
	
	// Update is called once per frame
	void Update () {
		m_closestPlayer = findClosest ();
	}
}
