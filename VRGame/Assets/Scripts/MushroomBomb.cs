using System.Collections;
using System.Collections.Generic;
using Framework.Events;
using UnityEngine;

public class MushroomBomb : MonoBehaviour
{
	public string collisionTag;
	public GameEvent playerLooseEvent;

	public FixedJoint joint;

	private Rigidbody jointRb;

	private void OnCollisionEnter(Collision other)
	{
		if (!other.gameObject.CompareTag(collisionTag)) {
			return;
		}


		jointRb.useGravity = true;
		joint.connectedBody.useGravity = true;
		jointRb.GetComponent<Rigidbody>().AddForce(Vector3.forward * joint.breakForce);
		
		playerLooseEvent.Raise();
	}

	private void Awake()
	{
		jointRb = joint.GetComponent<Rigidbody>();
	}
}
