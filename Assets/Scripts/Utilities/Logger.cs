using UnityEngine;

public class Logger : MonoBehaviour
{
    public static void LogInfo(string message)
    {
        Log(message, "info");
    }

    public static void LogWarning(string message)
    {
        Log(message, "warning");
    }

    public static void LogError(string message)
    {
        Log(message, "error");
    }

    private static void Log(string message, string tag)
    {
        Debug.Log($"[{tag}]: {message}");
    }
}