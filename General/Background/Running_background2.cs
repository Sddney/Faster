using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Running_background2 : MonoBehaviour
{

    public GameObject sprite1;
    public GameObject sprite2;
    public GameObject sprite3;
    public float speed;
    private List<Rigidbody2D> rb_list = new List<Rigidbody2D>();


    public Spawning_Boxes boxes;
    public bool spawningNext = false;

    private List<GameObject> sprites = new List<GameObject>();

    Vector2 spawnPos = new Vector2(7f, 9.3f);

    private List<bool> hasSpawned = new List<bool>();

    private int sortOrderDecrease = 0;

    private int spriteCount;

    private void Start()
    {
        sprites.Add(sprite1);
        sprites.Add(sprite2);
        sprites.Add(sprite3);
        Appear(sprite1);
    }

    public void Appear(GameObject prefub)
    {
        GameObject city = Instantiate(prefub, spawnPos, Quaternion.identity);
        Rigidbody2D rb = city.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb_list.Add(rb);
        SpriteRenderer spriteRenderer = city.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder -= sortOrderDecrease;
        sortOrderDecrease += 3;
        hasSpawned.Add(false);

    }

    void Update()
    {
        speed = boxes.speed;
        for (int i = 0; i < rb_list.Count; i++)
        {
            Rigidbody2D rb = rb_list[i];
            rb.linearVelocity = new Vector2(0, -speed);
            if (!hasSpawned[i] && rb.transform.position.y < 7.3f)
            {
                hasSpawned[i] = true;
                spawningNext = true;
            }
            if (rb.transform.position.y < -10f)
            {
                Destroy(rb.gameObject);
                rb_list.RemoveAt(i);
                hasSpawned.RemoveAt(i);
                i--;
            }
        }
        
        
        if (spawningNext)
        {
            if (spriteCount > 2) spriteCount = 0;
            Appear(sprites[spriteCount]);
            spriteCount++;
            spawningNext = false;
        }

        
    }
}
