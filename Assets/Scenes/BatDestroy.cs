﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BatDestroy : MonoBehaviour {

	public Material capMaterial;
	public AudioSource source;

	void OnCollisionEnter(Collision collision) {
		GameObject victim = collision.collider.gameObject;

		GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

		if (!pieces[1].GetComponent<Rigidbody>())
		{
			pieces[1].AddComponent<Rigidbody>();
			MeshCollider temp = pieces[1].AddComponent<MeshCollider>();
			temp.convex = true; 
			source.Play();
		}

	}
}
