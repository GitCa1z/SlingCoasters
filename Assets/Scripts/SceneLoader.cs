using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public void loadSequance(string loadedScene)
    {
        SceneManager.LoadScene(loadedScene);
    }
}
