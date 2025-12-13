using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MouseOnButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Sprite MainImage;
    public Sprite ButtonImage;

    private Image image;

    public AudioClip onButtonSound;

    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = MainImage;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = ButtonImage;
        AudioControl.instance.PlaySound(onButtonSound, transform, 1f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = MainImage;
    }

}
