using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainScene : SceneBase
{
    public MainScene():base()
    {
       
    }

    //可以直接call lua里面去

    public override void LoadCfgBeforeLoaderInit()
    {
        base.LoadCfgBeforeLoaderInit();

        this.m_needLoadQueue.Enqueue("uiprefab/notice");
        this.m_needLoadQueue.Enqueue("uiprefab/topbar");
        this.m_needLoadQueue.Enqueue("uiprefab/uibattle");
        this.m_needLoadQueue.Enqueue("uiprefab/uimain");
        this.m_needLoadQueue.Enqueue("uiprefab/uiroot");
        this.m_needLoadQueue.Enqueue("uiprefab/uiskill");
    }

    public override void Init()
    {
        base.Init();
    }

    public override void SceneLoaded()
    {
        base.SceneLoaded();
    }
    public override void Destroy()
    {
        base.Destroy();
    }
}
