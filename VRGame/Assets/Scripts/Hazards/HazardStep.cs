using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HazardStep : ScriptableObject 
{

	public virtual void OnStart()
	{
		Debug.Log($"Started {name}");
	}

	public abstract void Update(Spawner spawner);
	

	public virtual void OnFinish()
	{
		Debug.Log($"Finished {name}");
	}
}
