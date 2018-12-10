using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMotion_RootMotion : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("v",Input.GetAxis("Vertical"));
		anim.SetFloat("h",Input.GetAxis("Horizontal"));

		if (Input.GetButtonDown("Jump")) {
			anim.SetTrigger("jump");
		}
	}
}
