using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOverride : MonoBehaviour
{

    [Header("Loading Type")]
    public LoadSceneMode LoadingType;

    [Header("Main Settings")]
    public string TargetScene;

    [Header("Loading Delay")]
    public bool usingDelay;
    public float Delay;

    [Header("Loading Screen")]
    public bool usingLoadingScreen;
    public string LoadingScene;

    public void LoadScene()
    {
        //Melakukan perpindahan antar scene. Catatan: Scene yang dipanggil sudah didaftarkan di Build Setting
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        if (usingLoadingScreen)
        {
            SceneManager.LoadSceneAsync(LoadingScene, LoadSceneMode.Additive);
        }
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(TargetScene, LoadingType);

        while (!asyncLoad.isDone)
        {
            PlayerPrefs.SetFloat("Loading", asyncLoad.progress);
            yield return null;
        }

        if (usingLoadingScreen)
        {
            SceneManager.UnloadSceneAsync(LoadingScene);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (usingDelay)
        {
            Invoke("LoadScene", Delay);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
