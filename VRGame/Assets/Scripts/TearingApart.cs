using System.Collections;
using System.Collections.Generic;
using Framework.Events;
using UnityEngine;

public class TearingApart : MonoBehaviour, IHitListener
{
	public float force;
	public Rigidbody[] rbs;

	public Collider outerCollider;

	public void OnHit(Collision other)
	{
		TearApart();
	}

	[ContextMenu("Tear apart")]
	private void TearApart()
	{
		TogglePhysics(true);

		var centerPoint = new Vector3();
		foreach (var rb in rbs) {
			centerPoint += rb.position;
		}

		centerPoint /= rbs.Length;

		foreach (var rb in rbs) {
			rb.AddExplosionForce(force, centerPoint, 1f);
		}
	}

	private void Start()
	{
		foreach (var rb in rbs) {
			Physics.IgnoreCollision(outerCollider, rb.GetComponent<Collider>());
		}
		
		TogglePhysics(false);
	}

	private void TogglePhysics(bool isEnabled)
	{
		foreach (var rb in rbs) {
			rb.useGravity = isEnabled;
			rb.GetComponent<Collider>().enabled = isEnabled;
		}
	}
}
