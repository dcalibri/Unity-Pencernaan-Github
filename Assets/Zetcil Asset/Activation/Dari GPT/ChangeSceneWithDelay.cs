using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithDelay : MonoBehaviour
{
    [SerializeField] private float delayTime = 2.0f; // The amount of time to wait before loading the target scene
    [SerializeField] private string targetSceneName; // The name of the target scene to load

    private void Start()
    {
        Invoke("LoadTargetScene", delayTime);
    }

    private void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
