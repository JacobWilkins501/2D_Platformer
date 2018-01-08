﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask objectsToHit;
	public Transform bulletTrailPrefab;
	float timeToSpawnEffect = 0;
	public float effectSpawnRate = 10;

	float timeToFire = 0;
	Transform firePoint;
//	Transform Pistol;

	// Use this for initialization
	void Start () {
		firePoint = transform.Find ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("Fire Point not found");
		}

//		Pistol = transform.Find ("Pistol");
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shoot ();
			}
		} else if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
			timeToFire = Time.time + 1 / fireRate;
			Shoot ();
		}

		if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x < transform.position.x && transform.localScale.y == 1) {
			flipGun ();
		}
		if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x > transform.position.x && transform.localScale.y == -1) {
			flipGun ();
		}
	}

	void Shoot () {
		Vector2 mousePos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePointPos = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPos, mousePos - firePointPos, 100, objectsToHit);
		if (Time.time >= timeToSpawnEffect) {
			Effect ();
			timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
		}
		Debug.DrawLine (firePointPos, mousePos);
	}

	void Effect () {
		Instantiate (bulletTrailPrefab, firePoint.position, (firePoint.rotation));
	}

	void flipGun () {
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;
	}
}
