using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelect : MonoBehaviour
{
  [SerializeField] OnInput _onInput;

  public event Action<RaycastHit> OnRaycastObjectHit;

  Camera _mainCamera;
  RaycastHit _lastRaycastHit;
  bool _castRay;

  void Awake()
  {
    _mainCamera = Camera.main;
  }

  void OnEnable()
  {
    if (_onInput != null)
    {
      _onInput.OnInputDown += SetCastRayTrue;
      _onInput.OnInputUp += SetCastRayFalse;
    }
  }
  void OnDisable()
  {
    if (_onInput != null)
    {
      _onInput.OnInputDown -= SetCastRayTrue;
      _onInput.OnInputUp -= SetCastRayFalse;
    }
  }

  void Update()
  {
    if (_castRay)
    {
      Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray, out _lastRaycastHit, 50f))
      {
        OnRaycastObjectHit?.Invoke(_lastRaycastHit);
      }
    }
  }

  void SetCastRayTrue()
  {
    _castRay = true;
  }
  void SetCastRayFalse()
  {
    _castRay = false;
  }
}
