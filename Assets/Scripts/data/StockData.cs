using System.Collections.Generic;
using UnityEngine;


public struct Stock
{
    public int stIndex;
    public string stBookID;
    public string stStorageID;
    public int stStorageNum;
    public string stNotes;
}

public class StockData
{
    public static List<Stock> data = new List<Stock>();

    public static void loadData()
    {
        phpSQL.instance.php( "SELECT * FROM .stock" , onLoad );
    }

    public static int getNum( string bid , string sid )
    {
        for ( int i = 0 ; i < data.Count ; i++ )
        {
            if ( bid == data[ i ].stBookID && 
                sid == data[ i ].stStorageID )
            {
                return data[ i ].stStorageNum;
            }
        }

        return 0;
    }


    public static void onLoad( string d )
    {
        data.Clear();

        string[] a = d.Split( '{' );

        for ( int i = 1 ; i < a.Length ; i++ )
        {
            string[] pa = a[ i ].Replace( "}" , "" ).Split( ',' );

            Stock p = new Stock();

            p.stIndex = int.Parse( pa[ 0 ] );
            p.stBookID = pa[ 1 ];
            p.stStorageID = pa[ 2 ];
            p.stStorageNum = int.Parse( pa[ 3 ] );
            p.stNotes = pa[ 4 ];
            
            data.Add( p );
        }

        StockUIHandler.instance.updateData();
    }

}

