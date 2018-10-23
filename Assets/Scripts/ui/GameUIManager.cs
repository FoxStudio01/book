using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameUIManager : SingletonMonoManager< GameUIManager >
{
	public Dictionary< string , GameUIHandlerInterface > uiDic = new Dictionary< string , GameUIHandlerInterface >();

	public Transform anchorBottom;
	public Transform anchorBottomLeft;
	public Transform anchorBottomRight;
	public Transform anchorCenter;
	public Transform anchorLeft;
	public Transform anchorRight;
	public Transform anchorTop;
	public Transform anchorTopLeft;
	public Transform anchorTopRight;

	public UIRoot root;

    public Transform rootTransform;

    public int lastScreenWidth = 0;
    public int lastScreenHeight = 0;

    public override void initSingletonMono()
    {
        GameSetting.instance.init();

        init();

        loginUIHandler.instance.Show();
//        Debug.Log( Localization.Get( "Flag" ) );
    }

    void Start()
    {
        lastScreenWidth = Screen.width;
    }

    void Update()
    {
        float s = (float)root.activeHeight / Screen.height;

        GameSetting.height = Mathf.CeilToInt( Screen.height * s );
        GameSetting.width = Mathf.CeilToInt( Screen.width * s );

        if ( lastScreenWidth != Screen.width ||
            lastScreenHeight != Screen.height )
        {
            // resize

            lastScreenWidth = Screen.width;
            lastScreenHeight = Screen.height;

            GameSetting.height = Mathf.CeilToInt( Screen.height * s );
            GameSetting.width = Mathf.CeilToInt( Screen.width * s );

            foreach ( KeyValuePair<string , GameUIHandlerInterface> a in uiDic )
            {
                a.Value.Resize();
            }
        }
    }

    public void init()
	{
        rootTransform = GameObject.Find( "UI Root" ).transform;

		root = GameObject.FindObjectOfType<UIRoot>();
		float s = (float)root.activeHeight / Screen.height;

        lastScreenWidth = Screen.width;
        lastScreenHeight = Screen.height;

        GameSetting.height = Mathf.CeilToInt( Screen.height * s );
        GameSetting.width = Mathf.CeilToInt( Screen.width * s );

        Debug.Log( GameSetting.width + " " + GameSetting.height );

        Transform pf = transform;
		anchorBottom = pf.Find("Bottom");
		anchorBottomLeft = pf.Find("Bottom Left");
		anchorBottomRight = pf.Find("Bottom Right");
		anchorCenter = pf.Find("Center");
		anchorLeft = pf.Find("Left");
		anchorRight = pf.Find("Right");
		anchorTop = pf.Find("Top");
		anchorTopLeft = pf.Find("Top Left");
		anchorTopRight = pf.Find("Top Right");


        instanceUI< loginUIHandler >( anchorCenter , "LoginUI" , true , true );
        instanceUI< MainTopUIHandler >( anchorTopLeft , "MainTopUI" , true , true );
        instanceUI< MainLeftUIHandler >( anchorTopLeft , "MainLeftUI" , true , true );
        instanceUI< BookUIHandler >( anchorTopLeft , "BookUI" , true , false );

        instanceUI< PublisherUIHandler >( anchorTopLeft , "PublisherUI" , true , false );
        instanceUI< PostTypeUIHandler >( anchorTopLeft , "PostTypeUI" , true , false );
        instanceUI< WorkerUIHandler >( anchorTopLeft , "WorkerUI" , true , false );
        instanceUI< DepartmentUIHandler >( anchorTopLeft , "DepartmentUI" , true , false );
        instanceUI< BookTypeUIHandler >( anchorTopLeft , "BookTypeUI" , true , false );
        instanceUI< StorageUIHandler >( anchorTopLeft , "StorageUI" , true , false );
        instanceUI< BookUIHandler >( anchorTopLeft , "BookUI" , true , false );
        instanceUI< StockUIHandler >( anchorTopLeft , "StockUI" , true , false );
        instanceUI< SaleUIHandler >( anchorTopLeft , "SaleUI" , true , false );
        
        instanceUI< AlarmUIHandler >( anchorCenter , "AlarmUI" , false , false );


        AlarmUIHandler.instance.Show();
        AlarmUIHandler.instance.UnShow();
    }

    public void instanceUI<T>( Transform anchor , string uiName , bool single , bool allways ) where T : GameUIHandler< T >
    {
        rootTransform.gameObject.AddComponent<T>();
		GameUIHandler< T >.instance.uiName = uiName;
		GameUIHandler< T >.instance.anchor = anchor;
		
		GameUIHandler< T >.instance.single = single;
		GameUIHandler< T >.instance.allways = allways;
	}


	public void releaseUnusedHandler()
	{
		foreach ( KeyValuePair< string , GameUIHandlerInterface > a in uiDic )
		{ 
			a.Value.ReleaseUnused();
		}

		Resources.UnloadUnusedAssets();
	}
	
	public void setHandler( string name , GameUIHandlerInterface handler )
	{
		uiDic[ name ] = handler;
	}
	
	public GameObject createUI( string name )
	{
		string s = GameSetting.UIPath;
		s += name;
		
		GameObject cloneObject = (GameObject)Resources.Load (s);

		return (GameObject) Instantiate( cloneObject );
	}

	public GameObject getCloneUI( string name )
	{
		string s = GameSetting.UIPath;
		s += name;
		
		GameObject cloneObject = (GameObject)Resources.Load (s);

		return cloneObject;
	}

	public void checkSingel( string name )
	{
		foreach ( KeyValuePair< string , GameUIHandlerInterface > a in uiDic )
		{
			GameUIHandlerInterface uihander = (GameUIHandlerInterface)a.Value;

			if ( a.Key != name && !uihander.isAllways() )
			{
				uihander.UnShow();
			}
		}
	}


}
