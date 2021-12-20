using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    protected override void UpdateScene()
    {
        base.UpdateScene();

        if (Input.GetKeyDown(KeyCode.Space))
            SceneController.Instance.AsyncLoadScene(SceneContName.InGameScene);
    }
}
