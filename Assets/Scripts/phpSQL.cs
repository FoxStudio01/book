using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class phpSQL : SingletonMono< phpSQL >
{
    public string url = "http://book.foxgames.cn/sqlRequest1.php?sql=";
    public string urlSale = "http://book.foxgames.cn/sqlRequest1Sale.php?sql=";
    public string urlProfit = "http://book.foxgames.cn/sqlRequest1Profit.php?sql=";


    public delegate void phpCallback( string data );


    public void php( string sql , phpCallback cb )
    {
        StartCoroutine( phpwww( url , sql , cb ) );
    }
    public void phpSale( string sql , phpCallback cb )
    {
        StartCoroutine( phpwww( urlSale , sql , cb ) );
    }
    public void phpProfit( string sql , phpCallback cb )
    {
        StartCoroutine( phpwww( urlProfit , sql , cb ) );
    }


    IEnumerator phpwww( string u , string sql , phpCallback cb )
    {
        WWWForm form = new WWWForm();
        WWW www = new WWW( u +  sql , form );
        yield return www;

        if ( !string.IsNullOrEmpty( www.error ) )
        {
#if UNITY_EDITOR
            Debug.Log( www.error );
#endif
            cb( null );
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log( www.text );
#endif
            cb( www.text );
        }
    }

    


}