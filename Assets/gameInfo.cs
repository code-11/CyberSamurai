using UnityEngine;
using System.Collections;

public class gameInfo : MonoBehaviour {

	private ArrayList m_playerList;

	public ArrayList getPlayerList(){
		return m_playerList;
	}

	// Use this for initialization
	void Start () {
		m_playerList=new ArrayList(GameObject.FindGameObjectsWithTag("Player"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
