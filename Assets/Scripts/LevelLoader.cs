
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public ShowTutorial showTutorial;
    void Start()
    {
        showTutorial.gameObject.SetActive(false);
    }
    public void LoadLevel(int Level)
    {
        SceneManager.LoadScene(Level);
    }
    public void ShowTutorial()
    {
        showTutorial.gameObject.SetActive(true);
    }
}
