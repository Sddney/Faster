using UnityEngine;
using TMPro;

public class Scoring_visible : MonoBehaviour
{
    public TextMeshProUGUI EText;
    void Start()
    {
        
    }

    
    void Update()
    {
        EText.text = "Score\n"+ Counter.count.ToString();
    }
}
