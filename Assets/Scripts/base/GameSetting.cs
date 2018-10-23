using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


public class GameSetting : SingletonNew< GameSetting > 
{
    public static int width = 1280;
    public static int height = 800;

    public static int version = 1000001;


    public static bool IsWWW = false;

    public static string UIPath = "UI/";
    public static string AudioPath = "Audio/";

    public static string StreamingAssetsPath;
    public static string PersistentDataPath;



    public string getVersion()
	{
		int mainVer = version / 1000000;
		int mVer = ( version / 1000 ) % 1000;
		int sourceVer = version % 1000;

		return "V " + mainVer + "." + string.Format( "{0:D2}", mVer ) + "." + string.Format( "{0:D3}", sourceVer ) ;
	}


	public void save()
	{
//		PlayerPrefs.SetInt( "quality" , quality );


		PlayerPrefs.Save();
	}

	public void load()
	{
//		enableMusic = PlayerPrefs.GetInt( "enableMusic" , 1 ) > 0 ? true : false;

		Localization.language = "Chinese";
	}

	public void init()
	{
		initGameSetting();

		load();
	}

	bool inited = false;




	void initGameSetting()
	{
		if ( !inited )
		{
#if UNITY_EDITOR
			StreamingAssetsPath = Application.dataPath + "/StreamingAssets/";
#elif UNITY_IPHONE
			StreamingAssetsPath = Application.dataPath + "/Raw/";
#elif UNITY_ANDROID
			StreamingAssetsPath = "jar:file://" + Application.dataPath + "!/assets/";
#elif UNITY_WEBPLAYER
			StreamingAssetsPath = Application.dataPath + "/StreamingAssets/";			
#else
			StreamingAssetsPath = Application.streamingAssetsPath + "/";
			//StreamingAssetsPath = Application.dataPath + "/StreamingAssets/";
#endif

//#if UNITY_EDITOR
			Debug.Log( "Screen: " + Screen.width + " " + Screen.height );
			Debug.Log( "memory: setting " + System.GC.GetTotalMemory(true) );
//#endif

   			PersistentDataPath = Application.persistentDataPath;

			Debug.Log( Application.persistentDataPath + " " + PersistentDataPath );
			Debug.Log( Application.streamingAssetsPath );

			inited = true;

			IsWWW = Application.platform == RuntimePlatform.Android ||
				Application.platform == RuntimePlatform.WebGLPlayer ||
			Application.platform == RuntimePlatform.WSAPlayerARM ||
			Application.platform == RuntimePlatform.WSAPlayerX64 ||
			Application.platform == RuntimePlatform.WSAPlayerX86 ;
            
			Localization.language = "Chinese";
		}
	}

	public delegate void loadCallback( byte[] bytes , bool err );
	public void loadRes( string path , loadCallback cb )
	{
		if ( IsWWW )
		{
			if ( GameUIManager.instance) 
			{
				GameUIManager.instance.StartCoroutine( wwwLoad( path , cb ) );
			}
		}
		else
		{
			try
			{
				#if UNITY_WEBPLAYER
				FileStream stream = File.Open( path , FileMode.Open );
				#else
				FileStream stream = File.Open( path , FileMode.Open , FileAccess.Read );
				#endif

				if ( stream == null )
				{
					cb( null , true );
					return;
				}
				
				byte[] bytes = new byte[ stream.Length ];
				stream.Read( bytes , 0 ,(int)stream.Length );
				stream.Close();
				stream.Dispose();

				cb( bytes , false );

				//System.GC.Collect();
			}
			catch ( Exception ex ) 
			{
				Debug.LogWarning( ex.Message + " " + path + " load error." );
			}
		}
	}

	public void loadResF( string path , loadCallback cb )
	{
		try
		{
			#if UNITY_WEBPLAYER || UNITY_WEBGL

			
			#else
			FileStream stream = File.Open( path , FileMode.Open , FileAccess.Read );

			if ( stream == null )
			{
				cb( null , true );
				return;
			}

			byte[] bytes = new byte[ stream.Length ];
			stream.Read( bytes , 0 ,(int)stream.Length );
			stream.Close();
			stream.Dispose();

			cb( bytes , false );

			#endif

			//System.GC.Collect();
		}
		catch ( Exception ex ) 
		{
			Debug.LogWarning( ex.Message + " " + path + " load error." );
		}
	}


	IEnumerator wwwLoad( string url , loadCallback cb )
	{
		if ( Application.platform == RuntimePlatform.WindowsEditor || 
		    Application.platform == RuntimePlatform.WindowsPlayer || 
			Application.platform == RuntimePlatform.OSXPlayer ||
			Application.platform == RuntimePlatform.OSXEditor ||
			Application.platform == RuntimePlatform.IPhonePlayer )
			url = "file://" + url;

		WWW www = new WWW( url );
		yield return www;

		if ( www.isDone )
		{
			if ( www.error != null ) 
			{
				cb( null , true );
//				Debug.LogWarning( url + " load error." );
			}
			else
			{
				cb( www.bytes , false );
				www.Dispose();
			}
		}
		else
		{
			cb( null , true );
//			Debug.LogWarning( url + " load error." );
		}
	}
	

	public delegate void loadWWWCallback( WWW www , int i , bool err );
	public void loadWWW( string path , int i , loadWWWCallback cb )
	{
		if ( GameUIManager.instance )  
		{
            GameUIManager.instance.StartCoroutine( wwwLoadW( path , i , cb ) );
		}
	}
	
	IEnumerator wwwLoadW( string url , int i , loadWWWCallback cb )
	{
		WWW www = new WWW( url );
		yield return www;
		
		if ( www.isDone )
		{
			if ( www.error != null ) 
			{
	
			}
			else
			{
				cb( www , i , false );
				www.Dispose();
			}
		}
		else
		{
			cb( null , i , true );
		}
	}

}

