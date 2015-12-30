using UnityEngine;
using System.Collections;

public class gameInfo : MonoBehaviour {

	private ArrayList m_playerList;

	public ArrayList getPlayerList(){
		return m_playerList;
	}

	void Awake(){
		m_playerList=new ArrayList(GameObject.FindGameObjectsWithTag("Player"));
		Debug.Log (m_playerList.Count);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
