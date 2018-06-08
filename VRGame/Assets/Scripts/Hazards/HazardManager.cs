using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour 
{
	[System.Serializable]
	public class HazardSettings
	{
		public float timeStart;
		public HazardStep step;
	}

	public HazardSettings[] settings;
	public Spawner spawner;

	private HazardStep currentStep;
	private HazardSettings next;
	private int currentIndex;
	
	private float currentTime;

	private HazardStep CurrentStep
	{
		get { return currentStep; }
		set
		{
			if (value == null || value.Equals(currentStep)) {
				return;
			}

			if (currentStep != null) {
				currentStep.OnFinish();
			}
			
			currentStep = value;

			if (currentStep != null) {
				currentStep.OnStart();
			}
		}
	}

	private void Update()
	{
		currentTime += Time.deltaTime;

		if (next != null && next.timeStart <= currentTime) {
			CurrentStep = next.step;
			next = settings.Length > currentIndex + 1 ? settings[++currentIndex] : null;
		}

		if (CurrentStep != null) {
			CurrentStep.Update(spawner);
		}
	}

	private void Start()
	{
		if (settings.Length == 0) {
			enabled = false;
			return;
		}

		next = settings[0];
		spawner.Parent = transform;
	}
}
