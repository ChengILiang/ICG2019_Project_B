using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jib_motion : MonoBehaviour {

	bool rotate_right, rotate_left;
	float velocity = 0.5f;

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			rotate_left = true;
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			rotate_left = false;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			rotate_right = true;
		}

		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			rotate_right = false;
		}


		if (rotate_left) {
			gameObject.transform.Rotate (new Vector3 (0, -velocity, 0));
		}

		if (rotate_right) {
			gameObject.transform.Rotate (new Vector3 (0, velocity, 0));
		}

	}
}
