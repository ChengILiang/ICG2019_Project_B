using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitivesGenerator : MonoBehaviour {

	[SerializeField] GameObject m_CubePrefab;
	[SerializeField] GameObject m_SpherePrefab;

	// Use this for initialization
	void Start () {

		GeneratePrimitives (m_CubePrefab, Random.Range (10, 15));
		GeneratePrimitives (m_SpherePrefab, Random.Range (10, 15));
	}

	[SerializeField] Vector2 m_Dimension = new Vector2 (20, 20);

	void GeneratePrimitives (GameObject primitive, int count) {

		for (int i = 0; i < count; i++) {
		
			var primitiveIns = GameObject.Instantiate (primitive);

			Color altColor = new Color (
				                 Random.Range (0, 1f),
				                 Random.Range (0, 1f),
				                 Random.Range (0, 1f)
			                 );
			primitiveIns.GetComponent<Renderer> ().material.color = altColor;

			primitiveIns.transform.localPosition = new Vector3 (
				Random.Range (-m_Dimension.x, m_Dimension.x),
				3f,
				Random.Range (-m_Dimension.y, m_Dimension.y)
			);
		}
	}
		
}
