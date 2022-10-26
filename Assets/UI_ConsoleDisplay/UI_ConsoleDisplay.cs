using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=Pi4SHO0IEQY

public class UI_ConsoleDisplay : MonoBehaviour
{
    private Dictionary<string, string> debugLogs = new Dictionary<string, string>();

    [SerializeField] private TMPro.TextMeshProUGUI consoleText;
    
    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }
    
    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logString, string stacktrace, LogType type)
    {
        // the logged string
        // stacktrace
        // type of log received. E.g. a log, error, exception etc.

        if (type == LogType.Log)
        {
            string[] splitString = logString.Split(char.Parse(":")); // split the logstring using : as separator
            string debugKey = splitString[0]; // first part of that split is the key
            string debugValue = splitString.Length > 1 ? splitString[1] : "";  // second part of string as value. Set it to empty string if second part is missing

            if (debugLogs.ContainsKey(debugKey))
                debugLogs[debugKey] = debugValue;
            else
                debugLogs.Add(debugKey, debugValue);
        }

        string displayText = "";
        foreach (KeyValuePair<string, string> log in debugLogs)
        {
            if (log.Value == "")
                displayText += log.Key + "\n"; // linebreak if value is empty string
            else
                displayText += log.Key + ": " + log.Value + "\n";
        }

        consoleText.text = displayText;
    }
}
