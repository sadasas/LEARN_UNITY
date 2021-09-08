using System.IO;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;


[Serializable]
public struct PlayerData
{
  public  ItemContainer itemContainer;

    public PlayerData( ItemContainer inventory)
    {
        this.itemContainer = inventory;
    }
}


public static class SaveLoad 
{
    //path
    public static string directory = "/SaveData/";
    public static string fileName = "MydssDDAsssDsata.json";

    //loc
    static  string  dir = Application.persistentDataPath + directory;
   // public static FileStream dataStream; 



    public static void SaveData(PlayerData pd)
    {

        #region Criptography encirpsi

        Aes iAes = Aes.Create();

        byte[] savedKey = iAes.Key;

        //save key
        string key = System.Convert.ToBase64String(savedKey);
        PlayerPrefs.SetString("key", key);

        FileStream dataStream = new FileStream(dir + fileName, FileMode.Create);

        byte[] inputIV = iAes.IV;
        dataStream.Write(inputIV, 0, inputIV.Length);

        CryptoStream iStream = new CryptoStream(dataStream, iAes.CreateEncryptor(iAes.Key, iAes.IV), CryptoStreamMode.Write);

        StreamWriter sWritter = new StreamWriter(iStream);

        string toJSON = JsonUtility.ToJson(pd);

        sWritter.Write(toJSON);

        sWritter.Close();

        iStream.Close();

        dataStream.Close();


        #endregion


        #region Binnary Formatter

        /*  try
          {
              BinaryFormatter formatter = new BinaryFormatter();
              dataStream = File.Create(dir+fileName);


              PlayerData _pd = new PlayerData();
              _pd.itemContainer = pd.itemContainer;


              string json = JsonUtility.ToJson(_pd);
              formatter.Serialize(dataStream, json);
          }

          catch
          {


          }

          finally
          {
              dataStream.Close();

          }*/

        #endregion


        #region JSON


        /*   try
           {
               if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
               string json = JsonUtility.ToJson(pd);
               File.WriteAllText(dir + fileName, json);
           }
           catch
           {

           }
           finally
           {

           }
   */
        #endregion


        #region cryptograpy Hash



        /*   string json = JsonUtility.ToJson(pd);

           UnicodeEncoding ue = new UnicodeEncoding();

           byte[] dataByte = ue.GetBytes(json);

           SHA256 sHash = SHA256.Create();

           byte[] hasValue = sHash.ComputeHash(dataByte);

           string _hasValue = Convert.ToBase64String(hasValue);

           PlayerPrefs.SetString("hasValue", _hasValue);

   FileStream dataStream = File.Create(dir+fileName);

       StreamWriter sWritter = new StreamWriter(dataStream);

            sWritter.Write(json);

       sWritter.Close();

   dataStream.Close();*/


        #endregion

    }

    public static PlayerData LoadData()
    {
       
        PlayerData pd = new PlayerData();
        if (File.Exists(dir +fileName))
        {

            #region JSON
            /*    try
                {
                    string json = File.ReadAllText(fullPath);
                    pd = JsonUtility.FromJson<PlayerData>(json);
                }
                catch
                {

                }*/
            #endregion


            #region Binnary Formatter

            /*   try
               {

                   BinaryFormatter formatter = new BinaryFormatter();
                   dataStream = File.Open(dir+fileName, FileMode.Open);
                   string json = (string)formatter.Deserialize(dataStream);
                   pd = JsonUtility.FromJson<PlayerData>(json);

               }
               catch
               {

               }

               finally
               {

                   dataStream.Close();

               }*/

            #endregion


            #region Cryptography encrypsi

            if (PlayerPrefs.HasKey("key"))
            {
                byte[] savedKey = Convert.FromBase64String(PlayerPrefs.GetString("key"));

                FileStream dataStream = new FileStream(dir + fileName, FileMode.Open);

                Aes oAes = Aes.Create();

                byte[] outputIV = new byte[oAes.IV.Length];

                dataStream.Read(outputIV, 0, outputIV.Length);

                CryptoStream oStream = new CryptoStream(dataStream, oAes.CreateDecryptor(savedKey, outputIV), CryptoStreamMode.Read);

                StreamReader reader = new StreamReader(oStream);

                string text = reader.ReadToEnd();

                pd = JsonUtility.FromJson<PlayerData>(text);
            }

            #endregion

            #region cryptography Hash

            /*  if(PlayerPrefs.HasKey("hasValue"))
              {

                  FileStream dataStream = File.Open(dir + fileName, FileMode.Open);

                      StreamReader sReader = new StreamReader(dataStream);

                              string text = sReader.ReadToEnd();

                              dataStream.Close();

                              UnicodeEncoding ue = new UnicodeEncoding();

                              byte[] dataByte = ue.GetBytes(text);

                              SHA256 sHas = SHA256.Create();

                              byte[] hasValue = sHas.ComputeHash(dataByte);

                              byte[] _hasValue = Convert.FromBase64String(PlayerPrefs.GetString("hasValue"));

                              int a = 0;

                              for (int i = 0; i < _hasValue.Length; i++)
                              {
                                  if (hasValue[i] == _hasValue[i]) a++;
                                  else Debug.Log("not match");
                              }

                              if (a >= _hasValue.Length)
                              {
                                  Debug.Log(" match");
                                  pd = JsonUtility.FromJson<PlayerData>(text);
                              }

              }*/

            #endregion




        }

        else
        {
            Debug.Log("no data");
        }

        return pd;

    }

    
}
