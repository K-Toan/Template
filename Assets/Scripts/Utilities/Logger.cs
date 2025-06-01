using UnityEngine;

public class Logger : MonoBehaviour
{
    public static void LogInfo(string message)
    {
#if DEBUG
        Log(message, "info");
#endif
    }

    public static void LogWarning(string message)
    {
#if DEBUG
        Log(message, "warning");
#endif
    }

    public static void LogError(string message)
    {
#if DEBUG
        Log(message, "error");
#endif
    }

    private static void Log(string message, string tag)
    {
#if DEBUG
        Debug.Log($"[{tag}]: {message}");
#endif
    }
}