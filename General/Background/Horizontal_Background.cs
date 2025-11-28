using UnityEngine;
using UnityEngine.UI;

public class Horizontal_Background : MonoBehaviour
{
    public RawImage image1;
    public RawImage image2;

    public float speed1;
    public float speed2;

    public boxSpawner2 boxes;
    public float decreaser = 0.03f;

    void Update()
    {
        speed1 = boxes.speed;
        speed2 = boxes.speed;
        image1.uvRect = new Rect(image1.uvRect.position + new Vector2(speed1 * decreaser * Time.deltaTime, 0), image1.uvRect.size);
        image2.uvRect = new Rect(image2.uvRect.position + new Vector2(speed2 * decreaser * Time.deltaTime, 0), image2.uvRect.size);
    }
}
