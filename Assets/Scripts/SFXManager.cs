using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour {

  public AudioSource playerHurt;
  public AudioSource playerAttack;

  private static bool sfxmanExists;

	// Use this for initialization
	void Start () {
    if (!sfxmanExists)
    {
      sfxmanExists = true;
      DontDestroyOnLoad(transform.gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }
}
