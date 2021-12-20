using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    static SystemManager instance = null;
    public static SystemManager Instance
    {
        get
        {
            return instance;
        }
    }
    BaseScene currentScene;
    public BaseScene CurrentScene
    {
        set
        {
            currentScene = value;
        }
        get
        {
            return currentScene;
        }
    }

    public T GetCurrentScene<T>()
        where T : BaseScene
    {
        return currentScene as T;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        DontDestroyOnLoad(this);
    }
}
