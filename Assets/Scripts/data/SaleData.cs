using System.Collections.Generic;
using UnityEngine;


public struct Sale
{
    public int saIndex;
    public string saBookID;
    public string saTime;
    public int saNum;
    public int saWholesaleNum;
    public int saRetailNum;
    public double saDiscount;
    public double saCost;
    public double saCount;
    public string saNotes;
}

public class SaleData
{
    public static List<Sale> data = new List<Sale>();

    public static void loadData()
    {
        phpSQL.instance.php( "SELECT * FROM .sale" , onLoad );
    }

    public static void onLoad( string d )
    {
        data.Clear();

        string[] a = d.Split( '{' );

        for ( int i = 1 ; i < a.Length ; i++ )
        {
            string[] pa = a[ i ].Replace( "}" , "" ).Split( ',' );

            Sale p = new Sale();

            p.saIndex = int.Parse( pa[ 0 ] );
            p.saBookID = pa[ 1 ];
            p.saTime = pa[ 2 ];
            p.saNum = int.Parse( pa[ 3 ] );
            p.saWholesaleNum = int.Parse( pa[ 4 ] );
            p.saRetailNum = int.Parse( pa[ 5 ] );
            p.saDiscount = double.Parse( pa[ 6 ] );
            p.saCost = double.Parse( pa[ 7 ] );
            p.saCount = double.Parse( pa[ 8 ] );
            p.saNotes = pa[ 9 ];

            data.Add( p );
        }

        SaleUIHandler.instance.updateData();
    }



}
