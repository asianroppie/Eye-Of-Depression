using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public sealed class Saver
{
    public static void WriteFileBinary(string filepath, object obj) 
    {
        Debug.Assert(obj.GetType().IsSerializable);

        var dirpath = Path.GetDirectoryName(filepath);

        if (!File.Exists(dirpath))
        {
            Debug.LogError($"Write path directory {dirpath} doesn't exists");

            return;
        }

        BinaryFormatter binForm = new BinaryFormatter();
        FileStream file = File.Create(filepath);
        
        binForm.Serialize(file, obj);
        file.Close();
        
        Debug.Log($"Object written to ${filepath}");
    }

    public static void WriteFileJson(string filepath, object obj)
    {
        Debug.Assert(obj.GetType().IsSerializable);

        var dirpath = Path.GetDirectoryName(filepath);

        if (!File.Exists(dirpath))
        {
            Debug.LogError($"Write path directory {dirpath} doesn't exists");

            return;
        }

        var jsonstring = JsonUtility.ToJson(obj);
        File.WriteAllText(filepath, jsonstring);
    }
}
