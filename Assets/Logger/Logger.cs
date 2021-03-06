using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace LasseMunk_Logger
{
    [AddComponentMenu("_LasseMunk/Services/Logging")]
    public class Logger : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private bool showLogs;
        [SerializeField] private string prefix;
        [SerializeField] private Color prefixColor;

        private string _hexColor;
        
        private void OnValidate()
        {
            _hexColor = "#" + ColorUtility.ToHtmlStringRGB(prefixColor);
        }


        public void Log(object message, Object sender)
        {
            if (!showLogs) return;
            
            Debug.Log($"<color={_hexColor}>{prefix}: {message}</color>", sender);
        }
    }

}