using UnityEngine;
using System.Collections;

public class VolumeManager : MonoBehaviour {

  public VolumeController[] vcObjects;

  public float MaxVolumeLevel = 1.0f;
  public float currentVolumeLevel;

	// Use this for initialization
	void Start () {
    vcObjects = FindObjectsOfType<VolumeController>();

    if(currentVolumeLevel > MaxVolumeLevel)
    {
      currentVolumeLevel = MaxVolumeLevel;
    }

    for (int i = 0; i < vcObjects.Length; i++)
    {
      vcObjects[i].SetAudioLevel(currentVolumeLevel);
    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
