﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GameStarter : MonoBehaviour, ITrackableEventHandler {
	TrackableBehaviour mTrackableBehaviour;

	public List<GameObject> startWhenFound;

	public bool kittenPresent;

	// Use this for initialization
	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
			mTrackableBehaviour.RegisterTrackableEventHandler(this);

		Time.timeScale = 0.001f;
		foreach (var item in startWhenFound) {
			item.SetActive(false);
		}
	}

	public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		if (newStatus == TrackableBehaviour.Status.TRACKED) {
			kittenPresent = true;
			Debug.Log("kitten acquired!");

			Time.timeScale = 1f;
			foreach (var item in startWhenFound) {
				item.SetActive(true);
			}
		} else if (newStatus == TrackableBehaviour.Status.NOT_FOUND) {
			kittenPresent = false;
			Time.timeScale = 0.001f;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
