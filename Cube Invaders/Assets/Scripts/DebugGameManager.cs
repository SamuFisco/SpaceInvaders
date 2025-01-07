using UnityEngine;

public class DebugGameManager : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance != null)
        {
            Debug.Log($"GameManager encontrado. Score: {GameManager.Instance.Score}, ElapsedTime: {GameManager.Instance.ElapsedTime}");
        }
        else
        {
            Debug.LogError("GameManager no encontrado.");
        }
    }
}
