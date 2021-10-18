using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
  public event Action<float> OnBPMChanged;

  [SerializeField] float _beatsPrMinute = 120.0f;
  float _beatsPrSecond;

  void Start()
  {
    _beatsPrSecond = CalculateBeatsPrSecond(_beatsPrMinute);
    OnBPMChanged?.Invoke(_beatsPrSecond);
  }

  void OnValidate()
  {
    _beatsPrSecond = CalculateBeatsPrSecond(_beatsPrMinute);
    OnBPMChanged?.Invoke(_beatsPrSecond);
  }

  float CalculateBeatsPrSecond(float beatsPrMinute) { return (beatsPrMinute / 60); }
}
