﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[System.Serializable]
	public class EnemyStats {
		public int Health = 100;
	}

	public EnemyStats enemyStats = new EnemyStats ();
	public int fallBoundary = -20;

	public void DamageEnemy (int damage) {
		enemyStats.Health -= damage;
		if (enemyStats.Health <= 0) {
			GameControl.KillEnemy (this);
		}
	}
}
