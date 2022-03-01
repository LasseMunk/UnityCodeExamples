using UnityEngine;
using NaughtyAttributes;

namespace LasseMunk_Logger
{
    
    public class SendLogs : MonoBehaviour
    {
        [SerializeField] private Logger _logger;

        [Button]
        void LogAMessage()
        {
            Log("this is my message");
        }
        
        private void Log(object message)
        {
            if(_logger != null)
                _logger.Log(message, this);
        }
    }
}
