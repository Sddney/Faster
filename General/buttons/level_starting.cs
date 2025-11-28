using UnityEngine;
using UnityEngine.SceneManagement;

public class level_starting : MonoBehaviour
{
    public void Level1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
