using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    static SceneController instance;
    public static SceneController Instance
    {
        get
        {
            return instance;
        }
    }
    public float Progress { get; set; }
    public string nextSceneName { get; set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Cant have two instance of singletone");
            DestroyImmediate(this);

            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void AsyncLoadScene(string _nextSceneName)
    {
        nextSceneName = _nextSceneName;
        SceneManager.LoadScene(SceneContName.LoadingScene);
    }
    
    IEnumerator AsyncLoadSceneCoroutine()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            Progress = asyncOperation.progress;

            if (Progress >= 0.9f)
            {
                Debug.Log("AsyncLoadScene is complete!  " + nextSceneName + "  Press Space to NextScene");
                if (Input.GetKeyDown(KeyCode.Space))
                    asyncOperation.allowSceneActivation = true;
            }            yield return null;
        }
    }

    public void CallScene()
    {
        StartCoroutine("AsyncLoadSceneCoroutine");
    }
}
