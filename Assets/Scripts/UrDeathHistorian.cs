using UnityEngine;
using System.Collections;

public abstract class UrDeathHistorian : MonoBehaviour
{
	public ArrayList m_objList;
	public void checkDeath(){
		if (m_objList.Count > 0) {
			doThing ();
		}
	}
	public abstract void doThing();
}


