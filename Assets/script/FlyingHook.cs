using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingHook : MonoBehaviour {

	const float ATTACH_DISTANCE = 2f;
	GameObject m_DetectedObject;
	Joint m_JointForObject = null;
	Color origin_Color = Color.white;
	[SerializeField] LineRenderer m_Cable;
	[SerializeField] GameObject model;
	[SerializeField] GameObject m_JointBody;

	void Update () {

		if (m_JointForObject == null) {
			DetectObjects ();
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
		
			AttachOrDetachObject ();
		}

		UpdataCable ();
	}

	void AttachOrDetachObject () {
	
		if (m_JointForObject == null) {
		
			if (m_DetectedObject != null) {

				var joint = m_JointBody.AddComponent <ConfigurableJoint> ();
				joint.xMotion = ConfigurableJointMotion.Limited;
				joint.yMotion = ConfigurableJointMotion.Limited;
				joint.zMotion = ConfigurableJointMotion.Limited;
				joint.angularXMotion = ConfigurableJointMotion.Free;
				joint.angularYMotion = ConfigurableJointMotion.Free;
				joint.angularZMotion = ConfigurableJointMotion.Free;

				var limit = joint.linearLimit;
				limit.limit = 1f;

				joint.linearLimit = limit;

				joint.autoConfigureConnectedAnchor = false;
				joint.connectedAnchor = new Vector3 (0f, 0.25f, 0f);
				joint.anchor = new Vector3 (0f, 0f, 0f);

				joint.connectedBody = m_DetectedObject.GetComponent<Rigidbody> ();

				m_JointForObject = joint;

				m_DetectedObject.GetComponent <MeshRenderer> ().material.color = Color.red;
			}

		} else {
			m_DetectedObject.GetComponent <MeshRenderer> ().material.color = origin_Color;
			m_DetectedObject = null;
			GameObject.Destroy (m_JointForObject);
			m_JointForObject = null;
		}
	}


	void DetectObjects () {
	
		Ray ray = new Ray (model.transform.position, Vector3.down);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, ATTACH_DISTANCE)) {
			
			if (m_DetectedObject == hit.collider.gameObject) {
				return;
			}

			RecoverDetectedObject ();

			MeshRenderer renderer = hit.collider.GetComponent <MeshRenderer> ();

			if (renderer != null && renderer.gameObject.tag != "Floor") {
				origin_Color = renderer.material.color;		
				renderer.material.color = Color.yellow;

				m_DetectedObject = hit.collider.gameObject;
			}
		} else {

			RecoverDetectedObject ();
		}
	}

	void RecoverDetectedObject () {

		if (m_DetectedObject != null) {

			m_DetectedObject.GetComponent <MeshRenderer> ().material.color = origin_Color;
			m_DetectedObject = null;
		}

	}

	void UpdataCable () {
	
		m_Cable.enabled = m_JointForObject != null;

		if (m_Cable.enabled) {
			
			m_Cable.SetPosition (0, m_JointForObject.transform.position);

			var connectedBodyTransform = m_JointForObject.connectedBody.transform;
			m_Cable.SetPosition (1, connectedBodyTransform.TransformPoint (m_JointForObject.connectedAnchor));
		}
	}
}
