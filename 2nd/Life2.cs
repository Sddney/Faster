using UnityEngine;

public class Life2 : MonoBehaviour
{

    public bool obstacle2_faced = false;

    private Collider2D col;

    void Start() 
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box2")
        {
            obstacle2_faced = true;
           
        }
    }
}
