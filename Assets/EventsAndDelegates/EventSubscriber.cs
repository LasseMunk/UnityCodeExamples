// https://www.youtube.com/watch?v=3ZfwqWl-YI0&t=0s&ab_channel=CodeMonkey

using System;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{

  [SerializeField] private EventEmitter eventEmitter;

  void OnEnable()
  {
    eventEmitter.OnSpacebarPressed += LogOnSpacePressed;
    eventEmitter.OnAkeyPressed += LogOnAkeyPressed;
    eventEmitter.OnDkeyPressed += LogOnDkeyPressed;
  }

  private void OnDisable()
  {
    eventEmitter.OnSpacebarPressed -= LogOnSpacePressed;
    eventEmitter.OnAkeyPressed -= LogOnAkeyPressed;
    eventEmitter.OnDkeyPressed -= LogOnDkeyPressed;
  }

  private void LogOnAkeyPressed(int i, bool b)
  {
    Debug.Log($"first argument is an int {i} second is a bool {b}");
  }

  void LogOnSpacePressed()
  {
    Debug.Log("posted from subscriber on spacebar pressed, this only works once");
    // this unsubscribes from the event and therefore only works once
    eventEmitter.OnSpacebarPressed -= LogOnSpacePressed;
  }

  bool LogOnDkeyPressed(int i)
  {
    return i > 0;
  }
}
