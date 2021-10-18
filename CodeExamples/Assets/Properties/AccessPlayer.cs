using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class AccessPlayer : MonoBehaviour
{
  [SerializeField] Player myPlayer;

  private void Start()
  {
    Debug.Log($"level in accessplayer {myPlayer.Level}");
    Debug.Log($"Health in accessplayer {myPlayer.Health}");
  }


  [Button("SetNewHealth")]
  void SetPlayerHealth(int newHealth = 10)
  {
    // myPlayer.Health = newHealth;
    Debug.Log($"set Health in accessplayer {myPlayer.Health}");
  }
}
