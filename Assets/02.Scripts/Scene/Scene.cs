using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class Scene : MonoBehaviour
{
    public enum SceneEnum
    {
        Title,
        Game
    }

    public static Scene sceneMgr;
    public SceneEnum sceneEnum = SceneEnum.Title;

    void Start()
    {
        if(sceneMgr == null)
        {
            sceneMgr = this;
        }
        else
        {
            Destroy(sceneMgr);
        }

        DontDestroyOnLoad(this);
    }

    public void ChangeScene(SceneEnum sceneEnum)
    {
        SceneManager.LoadScene((int)sceneEnum);
    }
}
