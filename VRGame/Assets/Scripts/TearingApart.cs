using System.Collections;
using System.Collections.Generic;
using Framework.Events;
using UnityEngine;

public class TearingApart : MonoBehaviour, IHitListener
{
	public Collider[] colliders;

	public void OnHit(Collision other)
	{
		TearApart();
	}

	[ContextMenu("Tear apart")]
	private void TearApart()
	{
		TogglePhysics(true);
	}

	private void Start()
	{
		TogglePhysics(false);
	}

	private void TogglePhysics(bool isEnabled)
	{
		foreach (var collider in colliders) {
			collider.enabled = isEnabled;
			collider.GetComponent<Rigidbody>().useGravity = isEnabled;
		}
	}
}
