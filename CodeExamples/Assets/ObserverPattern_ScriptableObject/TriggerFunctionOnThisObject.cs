using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFunctionOnThisObject : MonoBehaviour
{
  public void LogText(GameObject go)
  {
    float x = go.transform.position.x;
    float y = go.transform.position.y;
    float z = go.transform.position.z;

    Debug.Log($"a gameobject {go.name} was spawned at position X: {x}, Y: {y}, Z: {z} ");
  }
}
