using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaleUIHandler : GameUIHandler< SaleUIHandler >
{
    SaleUIComponent component;

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
        component = uiObject.GetComponentInChildren<SaleUIComponent>();
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

