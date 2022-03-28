using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] Block blockPrefab;

   // public static List
    public static List<Block> blocks = new List<Block>();

    //strings according to what your saving
    const string autosave = "/block";
    const string autosave1 = "/block.count";

    void Awake()
    {
       // LoadBlock();
    }

    //Use if Android
    //void OnApplicationPause(bool pause)
    //{
    //    SaveFish();
    //}

    void OnApplicationQuit()
    {
        SaveBlock();
    }


    public void LoadButton()
    {
        //while (GameObject.FindGameObjectsWithTag("Breakable_1") != null) Destroy(GameObject.FindWithTag("Breakable_1"));
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Breakable_1");
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject.Destroy(enemies[i]);
        }
        LoadBlock();
    }
    void SaveBlock()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + autosave + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + autosave1 + SceneManager.GetActiveScene().buildIndex;

        FileStream countStream = new FileStream(countPath, FileMode.Create);

        formatter.Serialize(countStream, blocks.Count);
        countStream.Close();

        //Replace "lessThan" with a left angled bracket
        for (int i = 0; i < blocks.Count; i++)
        {
            FileStream stream = new FileStream(path + i, FileMode.Create);
            BlockData data = new BlockData(blocks[i]);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    void LoadBlock()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + autosave + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + autosave1 + SceneManager.GetActiveScene().buildIndex;
        int fishCount = 0;

        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);

            fishCount = (int)formatter.Deserialize(countStream);
            countStream.Close();
        }
        else
        {
            Debug.LogError("Path not found in " + countPath);
        }

        //Replace "lessThan" with an left angled bracket
        for (int i = 0; i < fishCount; i++)
        {
            if (File.Exists(path + i))
            {
                FileStream stream = new FileStream(path + i, FileMode.Open);
                BlockData data = formatter.Deserialize(stream) as BlockData;

                stream.Close();

                Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);

                Block blocks = Instantiate(blockPrefab, position, Quaternion.identity);


                blocks.name = data.name;
            }
            else
            {
                Debug.LogError("Path not found in " + (path + i));
            }
        }
    }
}