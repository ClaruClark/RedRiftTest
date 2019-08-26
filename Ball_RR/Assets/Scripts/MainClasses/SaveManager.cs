using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : Singleton<SaveManager>
{
    private Score score;

    public void Save(int ballHits)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/color.planet";
        FileStream stream = new FileStream(path, FileMode.Create);
        score = new Score();

        score.ballHits = ballHits;

        formatter.Serialize(stream, score);
        stream.Close();
    }

    public Score Load()
    {
        string path = Application.persistentDataPath + "/color.planet";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            score = formatter.Deserialize(stream) as Score;
            stream.Close();

            return score;
        }
        else
        {
            return null;
        }
    }
}
