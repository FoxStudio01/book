using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaleUIComponent : MonoBehaviour
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
    UIInput editorNew1;
    UIInput editorNew2;

    UILabel NumLabel;

    List<SaleUIComponentRow> row = new List<SaleUIComponentRow>();
    SaleUIComponentRow title;
    UIToggle titleToggle;

    UIPopupList bookList;
    UIPopupList storageList;

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
        editorNew1 = transform.Find( "editorNew1" ).GetComponent<UIInput>();
        editorNew2 = transform.Find( "editorNew2" ).GetComponent<UIInput>();

        NumLabel = transform.Find( "Num" ).GetComponent<UILabel>();

        bookList = transform.Find( "bookList" ).GetComponent<UIPopupList>();
        storageList = transform.Find( "storageList" ).GetComponent<UIPopupList>();
 
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

        title = SlicedSprite3.transform.Find( "title" ).GetComponent<SaleUIComponentRow>();
        titleToggle = title.transform.GetComponentInChildren<UIToggle>();

        Table = ScrollView.transform.Find( "Table" ).GetComponent<UITable>();
        //        Table.onReposition = onReposition;

        rowObject = Resources.Load<GameObject>( GameSetting.UIPath + "SaleUIRow" );
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
        bookList.Clear();
        for ( int i = 0 ; i < BookData.data.Count ; i++ )
        {
            string str = BookData.data[ i ].bID + "(" + BookData.data[ i ].bName + ")";
            bookList.AddItem( str , BookData.data[ i ].bID );
            if ( i == 0 )
                bookList.value = str;
        }

        storageList.Clear();
        for ( int i = 0 ; i < StorageData.data.Count ; i++ )
        {
            string str = StorageData.data[ i ].sID + "(" + StorageData.data[ i ].sName + ")";
            storageList.AddItem( str , StorageData.data[ i ].sID );
            if ( i == 0 )
                storageList.value = str;
        }

        ScrollBar.value = 0.0f;

        needRefresh = 0;

        if ( SaleData.data.Count == 0 )
        {
            return;
        }

        if ( row.Count != SaleData.data.Count )
        {
            for ( int i = 0 ; i < row.Count ; i++ )
            {
                row[ i ].gameObject.transform.parent = null;
                Destroy( row[ i ].gameObject );
            }

            row.Clear();

            for ( int i = 0 ; i < SaleData.data.Count ; i++ )
            {
                GameObject obj = Instantiate<GameObject>( rowObject , Table.transform );
                obj.name = "row" + i.ToString();
                SaleUIComponentRow r = obj.GetComponent<SaleUIComponentRow>();
                r.resize();

                row.Add( r );
            }
        }

        for ( int i = 0 ; i < SaleData.data.Count ; i++ )
        {
            row[ i ].setData( SaleData.data[ i ] );
        }

        Table.repositionNow = true;
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
            //            AlarmUIHandler.instance.alarmLocal( "insertSuccess" );

            string[] pa = d.Replace( "}" , "" ).Replace( "{" , "" ).Split( ',' );

            Sale p = new Sale();

            p.saIndex = int.Parse( pa[ 0 ] );
            p.saBookID = pa[ 1 ];
            p.saTime = pa[ 2 ];
            p.saWholesaleNum = int.Parse( pa[ 3 ] );
            p.saRetailNum = int.Parse( pa[ 4 ] );
            p.saDiscount = double.Parse( pa[ 5 ] );
            p.saCost = double.Parse( pa[ 6 ] );
            p.saCount = double.Parse( pa[ 7 ] );
            p.saNotes = pa[ 8 ];

            SaleData.data.Add( p );

            GameObject obj = Instantiate<GameObject>( rowObject , Table.transform );
            obj.name = "row" + ( SaleData.data.Count - 1 ).ToString();
            SaleUIComponentRow r = obj.GetComponent<SaleUIComponentRow>();
            r.resize();
            row.Add( r );
            r.setData( p );

            Table.repositionNow = true;
            StartCoroutine( onChange() );
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

//         if ( editorNew.value.Length == 0 )
//         {
//             return;
//         }

        if ( editorNew1.value.Length == 0 && 
            editorNew2.value.Length == 0 )
        {
            return;
        }

        int new2 = editorNew1.value.Length > 0 ? int.Parse( editorNew1.value ) : 0;
        int new1 = editorNew2.value.Length > 0 ? int.Parse( editorNew2.value ) : 0;

        string book = bookList.value.Split( '(' )[ 0 ];
        string storage = storageList.value.Split( '(' )[ 0 ];

//        editorNew.value = "1";
        editorNew1.value = "0";
        editorNew2.value = "0";

        phpSQL.instance.php( "CALL .INSERT_SALE('" + book + "', '" + storage + "' , '" + "0" + "' , '" + new1 + "' , '" + new2 + "' , '" + 1 + "' )" , onNewDB );

        editorNew.value = "";
    }

    public void onChangeNum1()
    {
        if ( editorNew1.value.Length == 0 )
        {
            return;
        }

        string book = bookList.value.Split( '(' )[ 0 ];
        string storage = storageList.value.Split( '(' )[ 0 ];

        int num = StockData.getNum( book , storage );

        if ( int.Parse( editorNew1.value ) > num )
        {
            editorNew1.value = num.ToString();
        }
    }

    public void onChangeNum2()
    {
        if ( editorNew2.value.Length == 0 )
        {
            return;
        }

        string book = bookList.value.Split( '(' )[ 0 ];
        string storage = storageList.value.Split( '(' )[ 0 ];

        int num = StockData.getNum( book , storage );

        if ( int.Parse( editorNew2.value ) > num )
        {
            editorNew2.value = num.ToString();
        }
    }


    public void Update()
    {
        string book = bookList.value.Split( '(' )[ 0 ];
        string storage = storageList.value.Split( '(' )[ 0 ];

        NumLabel.text = Localization.Get( "num" ) + StockData.getNum( book , storage ).ToString();
    }

    public void onUpdate()
    {
        for ( int i = 0 ; i < row.Count ; i++ )
        {
            if ( row[ i ].check() )
            {
                phpSQL.instance.php( "CALL .UPDATE_SALE( '" + row[ i ].id() + "' , " +
                    " '" + row[ i ].editor[ 8 ].value + "' " +
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
                SaleData.loadData();
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
                phpSQL.instance.php( "CALL .DELETE_SALE('" + row[ i ].id() + "' )" , onDeleteDB );
                needRefresh++;
            }
        }
    }

    public void onRefresh()
    {
        SaleData.loadData();
    }


}


