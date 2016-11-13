using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

  public int MaxHealth;
  public int CurrentHealth;

  private PlayerStats thePlayerStats;

  public int expToGive;

  public string enemyQuestName;
  private QuestManager theQM;

  // Use this for initialization
  void Start()
  {
    CurrentHealth = MaxHealth;

    thePlayerStats = FindObjectOfType<PlayerStats>();
    theQM = FindObjectOfType<QuestManager>();
  }

  // Update is called once per frame
  void Update()
  {
    if (CurrentHealth <= 0)
    {
      theQM.enemyKilled = enemyQuestName;

      Destroy(gameObject);//Destroys whatever game object this script is attacked to

      thePlayerStats.AddExperience(expToGive);
    }
  }

  public void HurtEnemy(int damageToGive)
  {
    CurrentHealth -= damageToGive;
  }

  public void SetMaxHealth()
  {
    CurrentHealth = MaxHealth;
  }
}
