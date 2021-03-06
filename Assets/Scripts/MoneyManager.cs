﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

  public Text moneyText;
  public int currentGold;

	// Use this for initialization
	void Start () {
    if (PlayerPrefs.HasKey("CurrentMoney"))
    {
      currentGold = PlayerPrefs.GetInt("CurrentMoney");

    } else {
      currentGold = 0;
      PlayerPrefs.SetInt("CurrentMoney", 0);
    }

    moneyText.text = "Gold: " + currentGold;
	}
	
	// Update is called once per frame
	void Update () {
	  
	}

  public void AddMoney(int goldToAdd)
  {
    currentGold += goldToAdd;
    PlayerPrefs.SetInt("CurrentMoney", currentGold); 
    moneyText.text = "Gold: " + currentGold;
  }
}
