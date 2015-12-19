using UnityEngine;
using System.Collections;

public class playerMoveCtrl : MonoBehaviour {
	
	public float speed = 10.0F;
	private Vector2 m_lastHeading;
	private Rigidbody2D rb;

	public Vector2 getLastHeading(){
		return m_lastHeading;
	}

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update() {
			
			//rigidbody2D.velocity=Vector3.right* -4
			Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
			//moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			rb.velocity = moveDirection;

		if (rb.velocity.magnitude > .01) {
			m_lastHeading = rb.velocity.normalized;
		}
			//controller.Move(moveDirection * Time.deltaTime);
	}
	
}
