using System.Collections.Generic;
using UnityEngine;


public struct Book
{
    public string bID;
    public string bPublisherID;
    public string bType;

    public string bName;
    public string bFormat;

    public double bCost;
    public double bRetail;
    public double bWholesale;
    public string bNotes;
}

public class BookData
{
    public static List<Book> data = new List<Book>();

    public static void loadData( string str )
    {
        if ( str != null && str.Length > 0 )
        {
            phpSQL.instance.php( "SELECT * FROM .books WHERE bID like'|" + str + "|' OR bPublisherID like '|" + str 
                + "|' OR bType like '|" + str + "|' OR bName like '|" + str + "|' OR bFormat like '|" + str + "|'" , onLoad );
        }
        else
            phpSQL.instance.php( "SELECT * FROM .books" , onLoad );
    }

    public static string getName( string id )
    {
        for ( int i = 0 ; i < data.Count ; i++ )
        {
            if ( data[ i ].bID == id )
            {
                return data[ i ].bName;
            }
        }

        return "";
    }

    public static void onLoad( string d )
    {
        data.Clear();

        string[] a = d.Split( '{' );

        for ( int i = 1 ; i < a.Length ; i++ )
        {
            string[] pa = a[ i ].Replace( "}" , "" ).Split( ',' );

            Book p = new Book();

            p.bID = pa[ 1 ];
            p.bPublisherID = pa[ 2 ];
            p.bType = pa[ 3 ];
            p.bName = pa[ 4 ];
            p.bFormat = pa[ 5 ];

            p.bCost = double.Parse( pa[ 6 ] );
            p.bRetail = double.Parse( pa[ 7 ] );
            p.bWholesale = double.Parse( pa[ 8 ] );

            p.bNotes = pa[ 9 ];

            data.Add( p );
        }

        BookUIHandler.instance.updateData();
        StockUIHandler.instance.updateData();
        SaleUIHandler.instance.updateData();
    }

}

