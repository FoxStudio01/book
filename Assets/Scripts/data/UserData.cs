using UnityEngine;


public enum UserLimit
{
    USER = 2,
    BOOKS = 4,

    PUBLIISHER = 32,
    STOREAGE = 64,
    DEPARTMENT = 128,
    WORKER = 256,
    LIBRARY = 512,
    SALE = 1024,


}

public class UserData
{
    public static int uid;
    public static int uLimit;
    public static string uCode;
    public static string uPhone;
    public static string uAddress;
}
