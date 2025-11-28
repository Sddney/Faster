using UnityEngine;
using TMPro;

public class life_visible : MonoBehaviour
{
    public TextMeshProUGUI EText;

    public Life_count life_counter;
    void Start()
    {

    }


    void Update()
    {
        EText.text = "Life: " + life_counter.life.ToString();
    }
}
