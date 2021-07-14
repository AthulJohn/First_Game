using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveAndLoad 
{
    public static void SaveData(ProgressData pd)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path=Application .persistentDataPath + "/progress.swen";
        FileStream stream = new FileStream(path,FileMode.Create);
        formatter.Serialize(stream,pd);
        stream.Close();
    }

   public static ProgressData LoadData()
    {
        string path=Application .persistentDataPath + "/progress.swen";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            ProgressData pd= formatter.Deserialize(stream) as ProgressData;
            stream.Close();
            return pd;
        }
       else
       return new ProgressData(1,true,true);
    }

}
