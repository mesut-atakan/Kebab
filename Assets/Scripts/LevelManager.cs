using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


internal class LevelManager : MonoBehaviour
{
    private const float timeSpeed = 0.001f;
    private static float maxTimeSpeed = 5.0f;
    public static int CurrentLevelIndex {
        get => SceneManager.GetActiveScene().buildIndex;
    }
    public static string CurrentLevelName {
        get => SceneManager.GetActiveScene().name;
    }











    public static void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }






    public static void TimeSpeed()
    {
        Time.timeScale += timeSpeed * Time.deltaTime;
    }
}