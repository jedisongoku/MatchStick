using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataStore : MonoBehaviour
{

    public static string saveFilePath = "/sm01.dat";

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + saveFilePath);

        PlayerData data = new PlayerData();
        data.score = Player.score;
        data.highScore += Player.highScore;

        bf.Serialize(file, data);
        file.Close();

    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + saveFilePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + saveFilePath, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            Player.score = data.score;
            Player.highScore = data.highScore;


        }
        else
        {
            Player.score = 0;
            Player.highScore = 0;

        }
    }
}

[Serializable]
class PlayerData
{
    public int score;
    public int highScore;
}
