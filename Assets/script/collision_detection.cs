using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_detection : MonoBehaviour {

	private Color altColor ;
	private Renderer rend;

	void setColor(){
		altColor.g = 0f;
		altColor.r = 0.1f;
		altColor.b = 0f;
		altColor.a = 0.1f;
	}

	void Start(){

		setColor ();

		rend = GetComponent<Renderer> ();
		rend.material.color = altColor;
	}



	void OnCollisionEnter(Collision other){
		altColor.g += Random.Range (-0.3f, 0.3f);
		altColor.r += Random.Range (-0.3f, 0.3f);
		altColor.b += Random.Range (-0.3f, 0.3f);
		altColor.a += Random.Range (-0.3f, 0.3f);

		altColor = UnityEngine.Random.ColorHSV ();


		Color lightColor = new Color (
			                   Random.Range (0f, 1f),
			                   Random.Range (0f, 1f),
			                   Random.Range (0f, 1f)
		                   );

		ParticleSystem.MainModule settings = GetComponent<ParticleSystem> ().main;
		settings.startColor = lightColor;

	}

}
