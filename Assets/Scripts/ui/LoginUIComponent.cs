using UnityEngine;

public class LoginUIComponent : MonoBehaviour
{
    


//     void onWechatLogin( string data )
//     {
// 
//     }

    void onLogin( string data )
    {
        if ( data == null )
        {
            return;
        }

        data = data.Replace( "{" , "" );
        data = data.Replace( "}" , "" );

        string[] a = data.Split( ',' );

        UserData.uid = int.Parse( a[ 0 ] );
        UserData.uCode = a[ 1 ];
        UserData.uLimit = int.Parse( a[ 2 ] );
        UserData.uPhone = a[ 3 ];
        UserData.uAddress = a[ 4 ];

        PostTypeData.loadData();
        BookTypeData.loadData();

        StorageData.loadData();
        PublisherData.loadData();
        DepartmentData.loadData();
        WorkerData.loadData();
        BookData.loadData( "BT1" );
        StockData.loadData();
        SaleData.loadData();

        loginUIHandler.instance.UnShow();

        MainTopUIHandler.instance.Show();
        MainLeftUIHandler.instance.Show();
        //        BookUIHandler.instance.Show();

        //       PublisherUIHandler.instance.Show();

        SaleUIHandler.instance.Show();
//        StockUIHandler.instance.Show();
//        BookUIHandler.instance.Show();
//        StorageUIHandler.instance.Show();
//        WorkerUIHandler.instance.Show();
//        BookTypeUIHandler.instance.Show();
//        DepartmentUIHandler.instance.Show();
//       PostTypeUIHandler.instance.Show();
    }

    public void onOptionsTouch()
    {

    }

    public void onWechatTouch()
    {

    }

    public void onTestTouch()
    {
        phpSQL.instance.php( "CALL .SELECT_USER( '92DQRS3PH0KFFKWC' )" , onLogin );
    }


}



