using UnityEngine;
using System.Collections;

public class flickering : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public Life_count life;

    private SpriteRenderer spriteRenderer1;
    private SpriteRenderer spriteRenderer2;

    public float alpha;
    private int flickerings = 3;

    void Start()
    {
        spriteRenderer1 = player1.GetComponent<SpriteRenderer>();
        spriteRenderer2 = player2.GetComponent<SpriteRenderer>();
    }
    
    private IEnumerator Flicker(SpriteRenderer Sprite)
    {
       for (int i = 0; i < flickerings; i++)
       {
            alpha = 0.1f;
            Sprite.color = new Color(1f, 1f, 1f, alpha);
            yield return new WaitForSeconds(0.1f);
            alpha = 1f;
            Sprite.color = new Color(1f, 1f, 1f, alpha);
            yield return new WaitForSeconds(0.1f);
       } 
    }


    void Update()
    {
        if (life.damage_taken)
        {
            if (player1.activeSelf)
            {
                StartCoroutine(Flicker(spriteRenderer1));
            }
            
            if (player2.activeSelf)
            {
                StartCoroutine(Flicker(spriteRenderer2));
            }
        }
    }
}
