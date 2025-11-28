using UnityEngine;
using UnityEngine.UI;

public class vertical_backgrond : MonoBehaviour
{

    public RawImage image;

    public float speed;

    public Spawning_Boxes boxes;

    public float decreaser = 0.03f;

    void Update()
    {
        speed = boxes.speed;
        image.uvRect = new Rect(image.uvRect.position + new Vector2(0, speed * Time.deltaTime * decreaser), image.uvRect.size);
    }

}
