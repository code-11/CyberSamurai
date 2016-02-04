using UnityEngine;
using System.Collections;

public class DeathCinema : MonoBehaviour {

	bool m_restartable=false;

	public void activateCinema(Vector3 deathPos){
		GameObject tempCamObj = new GameObject ();
		tempCamObj.transform.position = new Vector3(deathPos.x,deathPos.y,-1);
		tempCamObj.AddComponent<Camera> ();
		tempCamObj.GetComponent<Camera> ().orthographic = true;
		tempCamObj.GetComponent<Camera> ().orthographicSize = 4f;
		tempCamObj.GetComponent<Camera> ().depth = -1;
		tempCamObj.GetComponent<Camera> ().backgroundColor = new Color (59/255f,0,23/255f);
		Time.timeScale *= .5f;
		m_restartable = false;
		StartCoroutine (theCinema ());
	}
	IEnumerator theCinema() {
		yield return new WaitForSeconds(1f);
		m_restartable = true;
		Time.timeScale *= 2;
	}

	// Update is called once per frame
	void Update () {
		if (m_restartable && Input.anyKeyDown) {
			Application.LoadLevel("lvl1");
		}
	}
}
