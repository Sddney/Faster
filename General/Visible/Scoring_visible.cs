using UnityEngine;
using TMPro;

public class Scoring_visible : MonoBehaviour
{
    public TextMeshProUGUI EText;

    public Counter counter;
    void Start()
    {
        
    }

    
    void Update()
    {
        EText.text = "Score\n"+counter.count.ToString();
    }
}
