using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorkerUIHandler : GameUIHandler< WorkerUIHandler >
{
    WorkerUIComponent component;

    void Awake()
    {
        mInstance = this;
    }

    public override void onRelease()
    {
        component = null;
    }
    public override void onInit()
    {
        component = uiObject.GetComponentInChildren< WorkerUIComponent >();
    }
    public override void onOpen()
    {
        updateData();
    }
    public override void onClose()
    {
    }

    public void updateData()
    {
        if ( !isShow )
        {
            return;
        }

        component.updateData();
    }

    public override void onResize()
    {
        if ( component == null )
            return;

        component.resize();
    }

}

