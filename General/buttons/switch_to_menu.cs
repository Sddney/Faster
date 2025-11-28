using UnityEngine;

public class switch_to_menu : MonoBehaviour
{
    public void switch_to_menu_scene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
