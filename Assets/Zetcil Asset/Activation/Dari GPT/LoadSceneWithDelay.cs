using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneWithDelay : MonoBehaviour
{
    [SerializeField] private string sceneName; // The name of the scene you want to load
    [SerializeField] private float delayTime; // The amount of time to wait before loading the scene

    private void Start()
    {
        StartCoroutine(LoadSceneAfterDelay(delayTime));
    }

    IEnumerator LoadSceneAfterDelay(float delayTime)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
