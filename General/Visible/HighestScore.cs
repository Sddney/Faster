using UnityEngine;
using TMPro;

public class HighestScore : MonoBehaviour
{
    public TextMeshProUGUI EText;
    void Start()
    {
        EText.text = PlayerPrefs.GetInt("HighestScore", 0).ToString();
    }
    
}
