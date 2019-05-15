using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog_jump : MonoBehaviour {

	bool Move, align, Jump, isGround;
	Vector3 JumpTo = new Vector3 (0, 0, 0);
	private float desireRot;
	public float rotSpeed = 20;
	public float damping = 5;
	public float frogSpeed = 30;
	public float jumpForce = 0.5f;
	private int jumpNum = 2;

	public Vector3 jumping;

	Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		jumping = new Vector3 (0, 0.5f, 0);

		Move = true;
		align = false;
		Jump = true;
		//isGround = true;

		JumpTo = CreatePoint ();
	}

	void OnCollisionStay(){
	
		isGround = true;
	}
	
	// Update is called once per frame
	void Update () {



		if (Move == true) {

			if (align == false) {
				//rotate if frog not facing the point created

				//rotate until align to the right point
				slowlyRotation (JumpTo);

				Invoke ("isAlign", 3.0f);

			}

			if (align == true) {
				//start jumping after aligning to the point
				if (Jump == true) {
					
					transform.position += transform.forward * Time.deltaTime * frogSpeed;
					for (int i = 0; i <= jumpNum; i++) {
						if (isGround == true) {
							rb.AddForce (jumping * jumpForce, ForceMode.Impulse);
							}
					}
					isGround = false;
					Jump = false;
				}
				if (Jump == false) {
					Move = false;	
				}
			}
		
		} else if (Move == false) {

			JumpTo = CreatePoint ();
			Jump = true;
			Move = true;
			align = false;
		}

	}

	public Vector3 CreatePoint (){
		float x, z;
		x = Random.Range (-50f, 50f);
		z = Random.Range (-50f, 50);
		Vector3 pos = new Vector3 (x,0,z);
		Vector3 frogPos = gameObject.GetComponent<Transform> ().position;

		Vector3 frogDiretion = pos - frogPos;

		return frogDiretion;
	}

	void slowlyRotation (Vector3 rotationDirection){
		
		Quaternion rot = Quaternion.LookRotation (rotationDirection);

		transform.rotation = Quaternion.RotateTowards (transform.rotation, rot, 50 * Time.deltaTime);
	}

	void isAlign(){
		align = true;
	}


}