using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSkin : MonoBehaviour
{
   public static SaveSkin instance { get; private set; }

   public int currentRaccon;

   private void Awake()
   {
    if (instance != null && instance != this)
     Destroy(gameObject);
    else instance = this;

    DontDestroyOnLoad(gameObject);
    Load();
   }

   public void Load()
   {
    if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
        PlayerDat_Storage data =(PlayerDat_Storage)binaryFormatter.Deserialize(file);

        currentRaccon = data.currentRaccon;
        file.Close();
    }
   }
   public void Save()
   {
    BinaryFormatter binaryFormatter= new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
    PlayerDat_Storage data = new PlayerDat_Storage();

    data.currentRaccon = currentRaccon;
    binaryFormatter.Serialize(file, data);
    file.Close();
   }
}
[Serializable]
class PlayerDat_Storage
{
    public int currentRaccon;
}
