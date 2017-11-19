using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour {

    static public LoadingBar instance { get; set; }

    public Text loadingText;
    public Slider sliderBar;


    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void StartLoading(string _loadingSceneName)
    {
        StartCoroutine(LoadNewScene(_loadingSceneName));
    }

    IEnumerator LoadNewScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            sliderBar.value = progress;
            loadingText.text = progress * 100f + "%";
            if(progress == 100)
            {

                GameObject.FindGameObjectWithTag("Spawn");
            }
            yield return null;
        }
    }
}
