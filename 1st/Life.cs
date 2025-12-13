using UnityEngine;

public class Life : MonoBehaviour
{
    private Collider2D col;

    public bool obstacle_faced = false;

    public bool hasCalled = false;
    
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box" || collision.gameObject.tag == "BigBox")
        {
            obstacle_faced = true;
        }
        if (collision.gameObject.tag == "BigBox" && !hasCalled)
        {
            hasCalled = true;
        }
    }
}
