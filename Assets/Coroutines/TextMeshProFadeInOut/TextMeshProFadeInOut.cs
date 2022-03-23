using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace TextMeshProFadeInOut
{
public class TextMeshProFadeInOut : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textToFadeInOut;

    [SerializeField] private float fadeTimeOn = 1f;
    [SerializeField] private float fadeTimeOff = 1f;
    [SerializeField] private float valueOn = 0;
    [SerializeField] private float valueOff = -1;
    
    private Coroutine _coTextToFadeInOut;

    [Button] private void TextOn() => _coTextToFadeInOut = CoTextOn(_coTextToFadeInOut, textToFadeInOut);
    [Button] private void TextOff() => _coTextToFadeInOut = CoTextOff(_coTextToFadeInOut, textToFadeInOut);

    private Coroutine CoTextOn(Coroutine routine, TextMeshProUGUI txt)
    {
        if (routine != null) StopCoroutine(routine);
        return StartCoroutine(SetTMPDilate(txt, valueOff, valueOn, fadeTimeOn));
    } 
    
    private Coroutine CoTextOff(Coroutine routine, TextMeshProUGUI txt)
    {
        if (routine != null) StopCoroutine(routine);
        return StartCoroutine(SetTMPDilate(txt, valueOn, valueOff, fadeTimeOff));
    }
    
    private static IEnumerator SetTMPDilate(TextMeshProUGUI text, float currentValue, float targetValue, float timeToReachTargetInSeconds)
    {
        var progress = 0f;
       
        if (timeToReachTargetInSeconds <= 0f)
        {
            timeToReachTargetInSeconds = 0.01f;
        } 

        while (progress < 1f)
        {
           var dilate = Mathf.Lerp(currentValue, targetValue, progress);
         
            text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, dilate);
            progress += (Time.deltaTime / timeToReachTargetInSeconds);

            yield return null;
        }
    }
    
  
}
}
