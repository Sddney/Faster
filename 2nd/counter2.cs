using UnityEngine;

public class counter2 : MonoBehaviour
{
    private Collider2D coll;

    public bool point = false;
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box2")
        {
            point = true;
        }
    }
}
