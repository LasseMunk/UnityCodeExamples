// https://www.youtube.com/watch?v=CE9VOZivb3I
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

namespace LasseMunk_SceneManager
{
    public class SceneLoader : MonoBehaviour
    {

        [SerializeField] private Animator transition;
        [SerializeField] private float transitionTime = 1f;

        enum SceneNames
        {
            A,
            B,
            C
        }
        
        IEnumerator ILoadScene(SceneNames sceneName)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene((int)sceneName);
        }

        IEnumerator ILoadSceneAsync(SceneNames sceneName)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
            
            AsyncOperation operation = SceneManager.LoadSceneAsync((int) sceneName);
            
            while (!operation.isDone)
            {
                Debug.Log(operation.progress);
                yield return null; // wait until next frame
            }

            transition.SetTrigger("End");
        }
        
        [Button] void LoadSceneA() => StartCoroutine(ILoadScene(SceneNames.A));
        
        [Button] void LoadSceneB() => StartCoroutine(ILoadScene(SceneNames.B));
        
        [Button] void LoadSceneC() => StartCoroutine(ILoadScene(SceneNames.A));

        [Button] void LoadSceneAAsync() => StartCoroutine(ILoadSceneAsync(SceneNames.A));
    
        [Button] void LoadSceneBAsync() => StartCoroutine(ILoadSceneAsync(SceneNames.B));
        
        [Button] void LoadSceneCAsync() => StartCoroutine(ILoadSceneAsync(SceneNames.C));
    
    }
}
