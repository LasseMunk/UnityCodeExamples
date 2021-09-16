// https://www.youtube.com/watch?v=3ZfwqWl-YI0&t=0s&ab_channel=CodeMonkey

using System;
using UnityEngine;

public class EventEmitter : MonoBehaviour
{

  // actions is a delegate with return type void
  public event Action OnSpacebarPressed;
  public event Action<int, bool> OnAkeyPressed;
  //   Func is a delegate which has a specified return type
  public event Func<int, bool> OnDkeyPressed;


  void Update()
  {
    // ? checks if there is a subscribers to the event, meaning the event is not null
    // Invoke invokes the event and therefore triggers the subscribers
    if (Input.GetKeyDown(KeyCode.Space)) OnSpacebarPressed?.Invoke();
    if (Input.GetKeyDown(KeyCode.A)) OnAkeyPressed?.Invoke(666, true);
    if (Input.GetKeyDown(KeyCode.D)) Debug.Log(OnDkeyPressed?.Invoke(10));
  }
}
