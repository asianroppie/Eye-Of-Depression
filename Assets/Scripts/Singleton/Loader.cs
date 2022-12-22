using System.IO;
using UnityEngine;

public class Loader 
{
    public static T Load<T>(string filepath) 
    {
        return JsonUtility.FromJson<T>(filepath);
    }
}
