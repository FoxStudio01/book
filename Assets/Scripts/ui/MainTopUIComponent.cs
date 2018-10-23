using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTopUIComponent : MonoBehaviour
{
    UISprite SlicedSprite1;
    UISprite SlicedSprite2;

    BoxCollider SlicedSprite1Box;
    UIInput editorYear;

    public void resize()
    {
        SlicedSprite1.SetRect( 1 , 1 , GameSetting.width - 2 , 98 );
        SlicedSprite2.SetRect( 0 , 0 , GameSetting.width , 100 );
        SlicedSprite1.transform.localPosition = new Vector3( 0.0f , 0.0f , 0.0f );
        SlicedSprite2.transform.localPosition = new Vector3( 0.0f , 0.0f , 0.0f );
        SlicedSprite1Box.center = new Vector3( GameSetting.width * 0.5f , -98 * 0.5f );
        SlicedSprite1Box.size = new Vector3( Screen.width , 98 );
        SlicedSprite1Box.transform.localPosition = new Vector3( 0.0f , 0.0f , 0.0f );

        transform.localPosition = new Vector3( 0.0f , 0.0f );
    }

    void Start()
    {
        editorYear = transform.Find( "editorYear" ).GetComponent<UIInput>();

        SlicedSprite1 = transform.Find( "SlicedSprite1" ).GetComponent<UISprite>();
        SlicedSprite2 = transform.Find( "SlicedSprite2" ).GetComponent<UISprite>();
        SlicedSprite1Box = SlicedSprite1.transform.GetComponent<BoxCollider>();

        resize();
    }

    public void onLeft0()
    {
        SaleUIHandler.instance.Show();
        SaleUIHandler.instance.updateData();
    }

    public void onLeft1()
    {
        StockUIHandler.instance.Show();
        StockUIHandler.instance.updateData();
    }

    public void onPhp( string d )
    {

    }

    public void onLeft3()
    {
        if ( editorYear.value == null || editorYear.value.Length < 3 )
        {
            return;
        }

        WWW a = new WWW( phpSQL.instance.urlSale + editorYear.value );
        Application.OpenURL( a.url );
    }

    public void onLeft2()
    {
        if ( editorYear.value == null || editorYear.value.Length < 3 )
        {
            return;
        }

        WWW a = new WWW( phpSQL.instance.urlProfit + editorYear.value );
        Application.OpenURL( a.url );
    }




}
