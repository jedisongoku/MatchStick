using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataStore : MonoBehaviour
{

    public static string saveFilePath = "/ms04.dat";

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + saveFilePath);

        PlayerData data = new PlayerData();
        data.score = Player.score;
        data.highScores = Player.highScores;

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
            Player.highScores = data.highScores;


        }
        else
        {
            Player.score = 0;
            Player.highScores.Add(1, new List<int>());
            Player.highScores[1].Add(0);
            Player.highScores[1].Add(0);
            Player.highScores[1].Add(0);
            Player.highScores.Add(2, new List<int>());
            Player.highScores[2].Add(0);
            Player.highScores[2].Add(0);
            Player.highScores[2].Add(0);
            Player.highScores.Add(3, new List<int>());
            Player.highScores[3].Add(0);
            Player.highScores[3].Add(0);
            Player.highScores[3].Add(0);

        }
    }
}

[Serializable]
class PlayerData
{
    public int score;
    public Dictionary<int, List<int>> highScores = new Dictionary<int, List<int>>();
}
