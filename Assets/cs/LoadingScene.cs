using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : BaseScene
{
    [SerializeField]
    Text loadingText;
    [SerializeField]
    Slider progressBar;

    const string LoadingText = "Loading...";
    const float TextPrintInterval = 0.2f;
    float lastTextPrintTime;
    int index = 0;

    bool isCalled = false;

    protected override void Intialize()
    {
        base.Intialize();

        lastTextPrintTime = Time.time;
    }

    protected override void UpdateScene()
    {
        base.UpdateScene();

        if(!isCalled)
            GotoNextScene();

        UpdateLoadingProgressBar();
        UpdateLoadingStr();
    }

    void UpdateLoadingStr()
    {
        if(progressBar.value >= 0.9f)
        {
            loadingText.text = "Press Space to NextScene";
            return;
        }

        if (Time.time - lastTextPrintTime >= TextPrintInterval)
        {
            loadingText.text = LoadingText.Substring(0, index + 1);

            if (index == LoadingText.Length - 1)
                index = 0;
            else
                index++;

            lastTextPrintTime = Time.time;
        }
    }
    void UpdateLoadingProgressBar()
    {
        progressBar.value = SceneController.Instance.Progress;
    }

    void GotoNextScene()
    {
        SceneController.Instance.CallScene();

        isCalled = true;
    }
}
