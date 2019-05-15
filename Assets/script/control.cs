using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour {

	bool down, grab, up;

	int dist = 0;

	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.UpArrow) && dist <= 15) {
			up = true;
		}

		if (Input.GetKeyUp (KeyCode.UpArrow) || dist >= 15) {
			up = false;
		}

		if (Input.GetKeyDown (KeyCode.DownArrow) && dist >= -140) {
			down = true;
		}

		if (Input.GetKeyUp (KeyCode.DownArrow) || dist <= -140) {
			down = false;
		}
			
		if (up) {
			gameObject.transform.Translate (0, 0, 0.2f);
			dist += 1;
		}

		if (down) {
			gameObject.transform.Translate (0, 0, -0.2f);
			dist -= 1;
		}
			
	}
}
