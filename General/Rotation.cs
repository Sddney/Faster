using UnityEngine;

public class Rotation : MonoBehaviour
{

    private float rotation_speed = 100f;
    
    void Start()
    {
        Transform transform = GetComponent<Transform>();
    }

    void Update()
    {
        transform.Rotate( 0, 0, rotation_speed * Time.deltaTime);
    }
}
