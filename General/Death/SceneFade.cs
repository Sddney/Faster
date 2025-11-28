using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SceneFade : MonoBehaviour
{

    public GameObject black_screen;

    private Image image;

    public float alpha = 0f;

    public GameObject death_screen;

    public bool fade_out = false;

    public Death fail;

    private void Start()
    {
        image = black_screen.GetComponent<Image>();
    }

    private void Update()
    {

        if (fail.fail && !fade_out)
        {
            StartCoroutine(FadeOut());
            fade_out = true;
        }
        else if (fail.fail == false)
        {
            fade_out = false;
            alpha = 0f;
            image.color = new Color(0, 0, 0, alpha);
        }
    }
    
    private IEnumerator FadeOut()
    {
        while (alpha < 1)
        {
            alpha += 0.01f;
            image.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), alpha);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
