using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Player : MonoBehaviour
{
  private int health = 5; // private member variable -> field
  public int Health { get => health; }
  public int Level { get; private set; }

  [Button]
  void SetLevelTo(int newLevel = 10)
  {
    // Level = newLevel;
    Debug.Log(Level);
  }
}
