using System.IO;
using UnityEngine;

public static class GameSaver
{
    private static string FilePath => Path.Combine(Application.persistentDataPath, "playerdata.json");

    public static void Save(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(FilePath, json);
        Debug.Log($"[GameSaver] Saved to: {FilePath}");
    }

    public static PlayerData Load()
    {
        if (!File.Exists(FilePath))
        {
            Debug.LogWarning("[GameSaver] No save file found.");
            return new PlayerData(0);
        }

        string json = File.ReadAllText(FilePath);
        return JsonUtility.FromJson<PlayerData>(json);
    }

    public static void DeleteSave()
    {
        if (File.Exists(FilePath))
            File.Delete(FilePath);
    }
}
