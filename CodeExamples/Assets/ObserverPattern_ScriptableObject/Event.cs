using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Game Event", order = 51)]
public class Event : ScriptableObject
{
  List<EventListener> eventListeners = new List<EventListener>();

  public void Register(EventListener eventListener)
  {
    eventListeners.Add(eventListener);
  }

  public void Unregister(EventListener eventListener)
  {
    eventListeners.Remove(eventListener);
  }

  public void Triggered(GameObject go)
  {
    for (int i = 0; i < eventListeners.Count; i++)
    {
      eventListeners[i].OnEventTrigger(go);
    }
  }
}
