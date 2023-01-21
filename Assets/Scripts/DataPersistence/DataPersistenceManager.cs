using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private FileDataHandler dataHandler;
    public static DataPersistenceManager DPMinstance;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private void Awake()
    {
        if (DPMinstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DPMinstance = this;
        }
        DontDestroyOnLoad(gameObject);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }
    public void NewGame()
    {
        dataHandler.Delete();
        this.gameData = new GameData();
        Singleton.runtime.sympathyScore = this.gameData.sympathyScore;
        Singleton.runtime.day = this.gameData.day;
    }
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if(this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }
        if(this.gameData == null)
        {
            Debug.Log("No Data. Start a new game first before loading.");
            return;
        }
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }
    public void SaveGame()
    {
        if(this.gameData == null)
        {
            Debug.Log("No data. Start a new game first before saving.");
            return;
        }
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
    public bool HasGameData()
    {
        return gameData != null;
    }
}
