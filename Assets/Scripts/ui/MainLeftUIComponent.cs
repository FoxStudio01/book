using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLeftUIComponent : MonoBehaviour
{
    UISprite SlicedSprite1;
    UISprite SlicedSprite2;
    UISprite ScrollBar;

    BoxCollider SlicedSprite1Box;
    BoxCollider ScrollBarBox;

    UIPanel SubPanel;

    public void resize()
    {
        SlicedSprite1.SetRect( 1 , 101 , 178 , GameSetting.height - 102 );
        SlicedSprite2.SetRect( 0 , 100 , 180 , GameSetting.height - 100 );
        SlicedSprite1.transform.localPosition = new Vector3( 0.0f , 0.0f , 0.0f );
        SlicedSprite2.transform.localPosition = new Vector3( 0.0f , 0.0f , 0.0f );
        SlicedSprite1Box.center = new Vector3( 178 * 0.5f , -( GameSetting.height - 102 ) * 0.5f );
        SlicedSprite1Box.size = new Vector3( 178.0f , ( GameSetting.height - 102 ) );
        SlicedSprite1Box.transform.localPosition = new Vector3( 0.0f , 0.0f , 0.0f );

        ScrollBar.SetRect( 0 , 0 , 22 , GameSetting.height - 100 );
        ScrollBar.transform.localPosition = new Vector3( 0.0f , 0.0f , 0.0f );
        ScrollBarBox.center = new Vector3( 22 * 0.5f , -( GameSetting.height - 100 ) * 0.5f );
        ScrollBarBox.size = new Vector3( 22 , ( GameSetting.height - 100 ) );

        SubPanel.baseClipRegion = new Vector4( 178 * 0.5f , -( GameSetting.height - 102 ) * 0.5f ,
178 , GameSetting.height - 102 );
//        SubPanel.transform.localPosition = new Vector3( 0.0f , 0.0f , 0.0f );

        transform.localPosition = new Vector3( 0.0f , -102.0f );
    }

    void Awake()
    {
        SubPanel = transform.Find( "SubPanel" ).GetComponent<UIPanel>();

        SlicedSprite1 = transform.Find( "SlicedSprite1" ).GetComponent<UISprite>();
        SlicedSprite2 = transform.Find( "SlicedSprite2" ).GetComponent<UISprite>();
        SlicedSprite1Box = SlicedSprite1.transform.GetComponent<BoxCollider>();

        ScrollBar = transform.Find( "Scroll Bar" ).Find( "Background" ).GetComponent<UISprite>();
        ScrollBarBox = ScrollBar.transform.GetComponent<BoxCollider>();
    }

    public void onTouch1()
    {
        BookUIHandler.instance.Show();
        BookUIHandler.instance.updateData();
    }
    public void onTouch2()
    {
        StockUIHandler.instance.Show();
        StockUIHandler.instance.updateData();
    }
    public void onTouch3()
    {
        BookTypeUIHandler.instance.Show();
        BookTypeUIHandler.instance.updateData();
    }
    public void onTouch4()
    {
        StorageUIHandler.instance.Show();
        StorageUIHandler.instance.updateData();
    }
    public void onTouch5()
    {
        DepartmentUIHandler.instance.Show();
        DepartmentUIHandler.instance.updateData();
    }
    public void onTouch6()
    {
        WorkerUIHandler.instance.Show();
        WorkerUIHandler.instance.updateData();
    }
    public void onTouch7()
    {
        PostTypeUIHandler.instance.Show();
        PostTypeUIHandler.instance.updateData();
    }
    public void onTouch8()
    {
        PublisherUIHandler.instance.Show();
        PublisherUIHandler.instance.updateData();
    }

    void Start()
    {
        
        resize();
    }



}
