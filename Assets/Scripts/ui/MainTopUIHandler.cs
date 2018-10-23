using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTopUIHandler : GameUIHandler< MainTopUIHandler >
{
    MainTopUIComponent component;

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
        component = uiObject.GetComponentInChildren< MainTopUIComponent >();
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
}

