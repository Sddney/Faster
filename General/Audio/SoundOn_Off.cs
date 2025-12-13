using UnityEngine;
using UnityEngine.UI;

public class SoundOn_Off : MonoBehaviour
{

    public Sprite soundOn;
    public Sprite soundOff;

    private Image image;
    
    public void Start()
    {
        image = GetComponent<Image>();
    }
    public void OnOffSound()
    {
        if(image.sprite == soundOn)
        {
            image.sprite = soundOff;
        }
        else
        {
            image.sprite = soundOn;
        }
    }
}
