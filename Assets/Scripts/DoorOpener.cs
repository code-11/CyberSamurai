using UnityEngine;
using System.Collections;

public class DoorOpener : UrDeathHistorian {
	public ArrayList m_theDoors;
	// Use this for initialization
	void Start () {
	
	}
	void Update(){
		checkDeath ();
	}
	public override void doThing ()
	{
		foreach (GameObject door in m_theDoors) {
			Destroy (door);
		}
	}
}
