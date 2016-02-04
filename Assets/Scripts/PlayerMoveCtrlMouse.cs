using UnityEngine;
using System.Collections;

public class PlayerMoveCtrlMouse : UrPlayerCtrl {
	public float speed = 10.0F;
	private Vector2 m_lastHeading;
	private Rigidbody2D rb;

	public override Vector2 getLastHeading(){
		return m_lastHeading;
	}

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() {

		//rigidbody2D.velocity=Vector3.right* -4

		Vector3 mousePos=((GetComponentInChildren<Camera>()).ScreenPointToRay(Input.mousePosition)).origin;
		Vector3 towards = (mousePos-transform.position).normalized;
		towards *= speed;
		rb.velocity = towards;
		if (rb.velocity.magnitude > .01) {
			m_lastHeading = rb.velocity.normalized;
		}

		//Debug.DrawLine (transform.position,mousePos,Color.green);
	}
}
