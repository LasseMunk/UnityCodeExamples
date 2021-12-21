using UnityEngine;
// https://forum.unity.com/threads/is-it-possible-to-disable-all-debug-logs-in-builds.361553/
public class DebugLoggerDisable : MonoBehaviour
{

  private void Awake()
  {
#if UNITY_EDITOR
    Debug.unityLogger.logEnabled = true;
#else
    Debug.unityLogger.logEnabled = false;
#endif
  }
}
