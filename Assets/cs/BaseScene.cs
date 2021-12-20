using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class SceneContName
{
    public const string TitleScene = "TitleScene";
    public const string InGameScene = "InGameScene";
    public const string LoadingScene = "LoadingScene";
}

public class BaseScene : MonoBehaviour
{
    void Start()
    {
        Intialize();
    }

    void Update()
    {
        UpdateScene();
    }

    protected virtual void Intialize()
    {
        SystemManager.Instance.CurrentScene = this;
        Debug.Log(SystemManager.Instance.GetCurrentScene<BaseScene>().ToString());
    }

    protected virtual void UpdateScene()
    {

    }
}
