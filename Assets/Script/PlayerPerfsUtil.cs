using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class PlayerPerfsUtil
{
    public static void SaveList<T>(string key, List<T> value)
    {
        string serizlizedList = Serialize<List<T>>(value);
        PlayerPrefs.SetString(key, serizlizedList);
    }

    public static void SaveDict<Key, Value>(string key, Dictionary<Key, Value> value)
    {
        string serizlizedDict = Serialize<Dictionary<Key, Value>>(value);
        PlayerPrefs.SetString(key, serizlizedDict);
    }

    public static List<T> LoadList<T>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string serizlizedList = PlayerPrefs.GetString(key);
            return Deserialize<List<T>>(serizlizedList);
        }

        return new List<T>();
    }

    public static Dictionary<Key, Value> LoadDict<Key, Value>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string serizlizedDict = PlayerPrefs.GetString(key);
            return Deserialize<Dictionary<Key, Value>>(serizlizedDict);
        }

        return new Dictionary<Key, Value>();
    }

    private static string Serialize<T>(T obj)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, obj);
        return Convert.ToBase64String(memoryStream.GetBuffer());
    }

    private static T Deserialize<T>(string str)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(str));
        return (T)binaryFormatter.Deserialize(memoryStream);
    }
}
