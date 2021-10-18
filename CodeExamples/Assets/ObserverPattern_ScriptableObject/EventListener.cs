using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> { }

public class EventListener : MonoBehaviour
{
  public Event gameEvent;
  public UnityGameObjectEvent responseEvent = new UnityGameObjectEvent();

  void OnEnable()
  {
    gameEvent.Register(this);
  }

  void OnDisable()
  {
    gameEvent.Unregister(this);
  }

  public void OnEventTrigger(GameObject go)
  {
    responseEvent.Invoke(go);
  }
}
