using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockUIComponent : MonoBehaviour
{
    UISprite SlicedSprite1;
    UISprite SlicedSprite2;
    UISprite SlicedSprite3;

    //     UISprite Table;
    UIScrollView ScrollView;
    UIPanel Panel;

    UIScrollBar ScrollBar;
    UISprite ScrollBarBackground;
    UISprite ScrollBarForeground;

    BoxCollider SlicedSprite1Box;
    UITable Table;
    UIInput editorNew;

    List<StockUIComponentRow> row = new List<StockUIComponentRow>();
    StockUIComponentRow title;
    UIToggle titleToggle;

    UIPopupList DepartmentList;
    UIPopupList PostTypeList;

    GameObject rowObject = null;

    int needRefresh = 0;

    public void resize()
    {
        SlicedSprite1.SetRect( 1 , 1 , GameSetting.width - 184 , GameSetting.height - 102 );
        SlicedSprite2.SetRect( 0 , 0 , GameSetting.width - 182 , GameSetting.height - 100 );
        SlicedSprite1.transform.localPosition = new Vector3( 0.0f , 0.0f , 0.0f );
        SlicedSprite2.transform.localPosition = new Vector3( 0.0f , 0.0f , 0.0f );
        SlicedSprite1Box.center = new Vector3( ( GameSetting.width - 184 ) * 0.5f , -( GameSetting.height - 102 ) * 0.5f );
        SlicedSprite1Box.size = new Vector3( GameSetting.width - 184 , GameSetting.height - 102 );
        SlicedSprite1Box.transform.localPosition = new Vector3( 0.0f , 0.0f , 0.0f );

        SlicedSprite3.SetRect( 0 , 0 , GameSetting.width - 232 , GameSetting.height - 170 );
        SlicedSprite3.transform.localPosition = new Vector3( 10.0f , -60.0f , 0.0f );

        ScrollBar.transform.localPosition = new Vector3( GameSetting.width - 232 + 17 , 0.0f , 0.0f );

        ScrollBarBackground.height = GameSetting.height - 170;
        ScrollBarForeground.height = GameSetting.height - 180;
        BoxCollider boxCollider = ScrollBarForeground.transform.GetComponent<BoxCollider>();
        boxCollider.size = new Vector3( boxCollider.size.x + 20 , boxCollider.size.y , boxCollider.size.z );

        //         Table.SetRect( 10 , 60 , GameSetting.width - 222 , GameSetting.height - 170 - 60 );
        //         Table.transform.localPosition = new Vector3( 10.0f , -60.0f , 0.0f );

        Panel.baseClipRegion = new Vector4( ( GameSetting.width - 232 ) * 0.5f , -( GameSetting.height - 170 - 70 ) * 0.5f ,
            ( GameSetting.width - 232 ) , ( GameSetting.height - 170 - 70 ) );

        transform.localPosition = new Vector3( 181.0f , -102.0f );

        if ( row != null )
        {
            for ( int i = 0 ; i < row.Count ; i++ )
                row[ i ].resize();
        }

        title.resize();
    }

    void Awake()
    {
        editorNew = transform.Find( "editorNew" ).GetComponent<UIInput>();

        DepartmentList = transform.Find( "DepartmentList" ).GetComponent<UIPopupList>();
        PostTypeList = transform.Find( "PostTypeList" ).GetComponent<UIPopupList>();

        SlicedSprite1 = transform.Find( "SlicedSprite1" ).GetComponent<UISprite>();
        SlicedSprite2 = transform.Find( "SlicedSprite2" ).GetComponent<UISprite>();
        SlicedSprite3 = transform.Find( "SlicedSprite3" ).GetComponent<UISprite>();
        SlicedSprite1Box = SlicedSprite1.transform.GetComponent<BoxCollider>();

        ScrollBar = SlicedSprite3.transform.Find( "ScrollBar" ).GetComponent<UIScrollBar>();
        ScrollView = SlicedSprite3.transform.Find( "ScrollView" ).GetComponent<UIScrollView>();

        ScrollBarBackground = ScrollBar.transform.Find( "Background" ).GetComponent<UISprite>();
        ScrollBarForeground = ScrollBar.transform.Find( "Foreground" ).GetComponent<UISprite>();

        Panel = ScrollView.transform.GetComponent<UIPanel>();
        //        Table = ScrollView.transform.Find( "Table" ).GetComponent<UISprite>();

        title = SlicedSprite3.transform.Find( "title" ).GetComponent<StockUIComponentRow>();
        titleToggle = title.transform.GetComponentInChildren<UIToggle>();

        Table = ScrollView.transform.Find( "Table" ).GetComponent<UITable>();
        //        Table.onReposition = onReposition;

        rowObject = Resources.Load<GameObject>( GameSetting.UIPath + "StockUIRow" );
    }

    void Start()
    {
        resize();
    }

    public void onCheck()
    {
        for ( int i = 0 ; i < row.Count ; i++ )
        {
            row[ i ].setCheck( titleToggle.value );
        }
    }

    public void updateData()
    {
        DepartmentList.Clear();
        for ( int i = 0 ; i < BookData.data.Count ; i++ )
        {
            string str = BookData.data[ i ].bID + "(" + BookData.data[ i ].bName + ")";
            DepartmentList.AddItem( str , BookData.data[ i ].bID );
            if ( i == 0 )
                DepartmentList.value = str;
        }

        PostTypeList.Clear();
        for ( int i = 0 ; i < StorageData.data.Count ; i++ )
        {
            string str = StorageData.data[ i ].sID + "(" + StorageData.data[ i ].sName + ")";
            PostTypeList.AddItem( str , StorageData.data[ i ].sID );
            if ( i == 0 )
                PostTypeList.value = str;
        }


        ScrollBar.value = 0.0f;

        needRefresh = 0;

        if ( StockData.data.Count == 0 )
        {
            return;
        }

        if ( row.Count != StockData.data.Count )
        {
            for ( int i = 0 ; i < row.Count ; i++ )
            {
                row[ i ].gameObject.transform.parent = null;
                Destroy( row[ i ].gameObject );
            }

            row.Clear();

            for ( int i = 0 ; i < StockData.data.Count ; i++ )
            {
                GameObject obj = Instantiate<GameObject>( rowObject , Table.transform );
                obj.name = "row" + i.ToString();
                StockUIComponentRow r = obj.GetComponent<StockUIComponentRow>();
                r.resize();

                row.Add( r );
            }
        }

        for ( int i = 0 ; i < StockData.data.Count ; i++ )
        {
            row[ i ].setData( StockData.data[ i ] );
        }

        Table.repositionNow = true;
    }

    public void onNewDB1( string d )
    {
    }

    public void onNewDB( string d )
    {
        if ( d.Contains( "FAILED" ) )
        {
            AlarmUIHandler.instance.alarmLocal( "insertError" );
            return;
        }
        else
        {
            StockData.loadData();
        }
    }

    public IEnumerator onChange()
    {
        yield return new WaitForSeconds( 0.5f );

        if ( ScrollBarBackground.GetComponent<BoxCollider>().enabled )
        {
            ScrollBar.value = 1.0f;
        }
    }

    public void onNew()
    {
        if ( needRefresh > 0 )
        {
            return;
        }

        if ( editorNew.value.Length == 0 )
        {
            return;
        }

        int num = int.Parse( editorNew.value );

        if ( num == 0 )
        {
            return;
        }

        string book = DepartmentList.value.Split( '(' )[ 0 ];
        string storage = PostTypeList.value.Split( '(' )[ 0 ];

        phpSQL.instance.php( "CALL .INSERT_STOCK('" + book + "', '" + storage + "' , '" + num + "' )" , onNewDB );

        editorNew.value = "";

        phpSQL.instance.php( "CALL .INSERT_SALE('" + book + "', '" + storage + "' , '" + num + "' , '" + "0" + "' , '" + "0" + "' , '" + "1" + "' )" , onNewDB1 );
    }

    public void onUpdate()
    {
        for ( int i = 0 ; i < row.Count ; i++ )
        {
            if ( row[ i ].check() )
            {
                phpSQL.instance.php( "CALL .UPDATE_STOCK( '" + row[ i ].id() + "' , " +
                    " '" + row[ i ].editor1.value.Split( '(' )[ 0 ] + "' , " +
                    " '" + row[ i ].editor2.value.Split( '(' )[ 0 ] + "' , " +
                    " " + row[ i ].editor[ 3 ].value + " , " +
                    " '" + row[ i ].editor[ 4 ].value + "' " +
                    " )" , onUpdateDB );
            }

        }
    }

    public void onUpdateDB( string d )
    {
        if ( d.Contains( "FAILED" ) )
        {
            AlarmUIHandler.instance.alarmLocal( "updateFailed" );
        }
        else
        {
            AlarmUIHandler.instance.alarmLocal( "updateSuccess" );
        }
    }

    public void onDeleteDB( string d )
    {
        needRefresh--;

        if ( d.Contains( "FAILED" ) )
        {
            AlarmUIHandler.instance.alarmLocal( "deleteError" );
        }
        else
        {
            if ( needRefresh == 0 )
                StockData.loadData();
        }
    }

    public void onDelete()
    {
        if ( needRefresh > 0 )
        {
            return;
        }

        needRefresh = 0;

        for ( int i = 0 ; i < row.Count ; i++ )
        {
            if ( row[ i ].check() )
            {
                phpSQL.instance.php( "CALL .DELETE_STOCK('" + row[ i ].id() + "' )" , onDeleteDB );
                needRefresh++;
            }
        }
    }

    public void onRefresh()
    {
        StockData.loadData();
    }


}

