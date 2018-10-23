using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageUIHandler : GameUIHandler< StorageUIHandler >
{
    StorageUIComponent component;

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
        component = uiObject.GetComponentInChildren<StorageUIComponent>();
    }
    public override void onOpen()
    {
    }
    public override void onClose()
    {
    }

    public override void onResize()
    {
        if ( component == null )
            return;

        component.resize();
    }

    public void updateData()
    {
        if ( !isShow )
        {
            return;
        }

        component.updateData();
    }

}

