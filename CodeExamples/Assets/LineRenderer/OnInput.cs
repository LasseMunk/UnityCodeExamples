using UnityEngine;
using System;

public class OnInput : MonoBehaviour
{
  public event Action OnInputDown;
  public event Action OnInputUp;

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      OnInputDown?.Invoke();
    }
    if (Input.GetMouseButtonUp(0))
    {
      OnInputUp?.Invoke();
    }
  }
}
