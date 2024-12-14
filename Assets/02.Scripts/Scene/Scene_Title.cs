using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Scene : MonoBehaviour
{
    public void LoadGameScene()
    {
        sceneEnum = SceneEnum.Game;
        ChangeScene(sceneEnum);
    }
}
