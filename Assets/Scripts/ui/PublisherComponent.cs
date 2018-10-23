using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublisherComponent : MonoBehaviour
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

    List< PublisherComponentRow > row = new List< PublisherComponentRow >();
    PublisherComponentRow title;
    UIToggle titleToggle;

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
        BoxCollider boxCollider = ScrollBarForeground.transform.GetComponent< BoxCollider >();
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
        editorNew = transform.Find( "editorNew" ).GetComponent< UIInput >();

        SlicedSprite1 = transform.Find( "SlicedSprite1" ).GetComponent< UISprite >();
        SlicedSprite2 = transform.Find( "SlicedSprite2" ).GetComponent< UISprite >();
        SlicedSprite3 = transform.Find( "SlicedSprite3" ).GetComponent< UISprite >();
        SlicedSprite1Box = SlicedSprite1.transform.GetComponent< BoxCollider >();

        ScrollBar = SlicedSprite3.transform.Find( "ScrollBar" ).GetComponent< UIScrollBar >();
        ScrollView = SlicedSprite3.transform.Find( "ScrollView" ).GetComponent< UIScrollView >();

        ScrollBarBackground = ScrollBar.transform.Find( "Background" ).GetComponent< UISprite >();
        ScrollBarForeground = ScrollBar.transform.Find( "Foreground" ).GetComponent< UISprite >();
        
        Panel = ScrollView.transform.GetComponent< UIPanel >();
//        Table = ScrollView.transform.Find( "Table" ).GetComponent<UISprite>();

//        row[ 0 ] = ScrollView.transform.Find( "Table" ).transform.Find( "line0" ).GetComponent< PublisherComponentRow >();
//        row[ 1 ] = ScrollView.transform.Find( "Table" ).transform.Find( "line1" ).GetComponent< PublisherComponentRow >();

        title = SlicedSprite3.transform.Find( "title" ).GetComponent< PublisherComponentRow >();
        titleToggle = title.transform.GetComponentInChildren< UIToggle >();

        Table = ScrollView.transform.Find( "Table" ).GetComponent< UITable >();
//        Table.onReposition = onReposition;

        rowObject = Resources.Load< GameObject >( GameSetting.UIPath + "PublisherUIRow" );
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
        ScrollBar.value = 0.0f;

        needRefresh = 0;

        if ( PublisherData.data.Count == 0 )
        {
            return;
        }

        if ( row.Count != PublisherData.data.Count )
        {
            for ( int i = 0 ; i < row.Count ; i++ )
            {
                row[ i ].gameObject.transform.parent = null;
                Destroy( row[ i ].gameObject );
            }

            row.Clear();

            for ( int i = 0 ; i < PublisherData.data.Count ; i++ )
            {
                GameObject obj = Instantiate< GameObject >( rowObject , Table.transform );
                obj.name = "row" + i.ToString();
                PublisherComponentRow r = obj.GetComponent<PublisherComponentRow>();
                r.resize();

                row.Add( r );
            }
        }

        for ( int i = 0 ; i < PublisherData.data.Count ; i++ )
        {
            row[ i ].setData( PublisherData.data[ i ] );
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

            Publisher p = new Publisher();

            p.pID = pa[ 1 ];
            p.pName = pa[ 2 ];
            p.pPhone = pa[ 3 ];
            p.pAddress = pa[ 4 ];
            p.pNotes = pa[ 5 ];

            PublisherData.data.Add( p );

            GameObject obj = Instantiate<GameObject>( rowObject , Table.transform );
            obj.name = "row" + ( PublisherData.data.Count - 1 ).ToString();
            PublisherComponentRow r = obj.GetComponent<PublisherComponentRow>();
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

        if ( ScrollBarBackground.GetComponent< BoxCollider >().enabled )
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

        phpSQL.instance.php( "CALL .INSERT_PUBLISHER('" + editorNew.value +"', '"  + Localization.Get( "publisher" )  + "' )" , onNewDB );

        editorNew.value = "";
    }

    public void onUpdate()
    {
        for ( int i = 0 ; i < row.Count ; i++ )
        {
            if ( row[ i ].check() )
            {
                phpSQL.instance.php( "CALL .UPDATE_PUBLISHER( '" + row[ i ].id() + "' , " +
                    " '" + row[ i ].editor1.value + "' , " +
                    " '" + row[ i ].editor2.value + "' , " +
                    " '" + row[ i ].editor3.value + "' , " +
                    " '" + row[ i ].editor4.value + "' " +
                    " )" , onUpdateDB );
            }

        }
    }

    public void onUpdateDB( string d )
    {
        if ( d.Contains( "FAILED" ) )
        {

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
                PublisherData.loadData();
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
                phpSQL.instance.php( "CALL .DELETE_PUBLISHER('" + row[ i ].id() + "' )" , onDeleteDB );
                needRefresh++;
            }
        }
    }

    public void onRefresh()
    {
        PublisherData.loadData();
    }


}
