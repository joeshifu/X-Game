using UnityEngine;
using System.Collections;
using System;

public class SceneLoadManager
{
    public SceneBase m_currentScene = new SceneBase();

    private static SceneLoadManager m_instance;
    public static SceneLoadManager Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new SceneLoadManager();
            return m_instance;
        }
    }

	public UnityEngine.Object GetCurrentSceneCacheObj(string cacheName)
	{
		return this.m_currentScene.GetCacheObj(cacheName);
	}

    public void ChangeScene(eScene scene)
    {
        SceneBase change = null;
        switch (scene)
        {
            case eScene.None:
                break;
            case eScene.MainTown:
                change = new MainScene();
                break;
            case eScene.Battle:
               
                break;
            default:
                break;
        }

        if(change != null)
            SceneSwitch(change);
    }

    private void SceneSwitch(SceneBase currScene)
    {
        this.m_currentScene.Destroy();
        this.m_currentScene = currScene;
        currScene.Init();
    }

}
