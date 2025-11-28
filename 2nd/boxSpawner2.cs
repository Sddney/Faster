using UnityEngine;
using System.Collections.Generic;

public class boxSpawner2 : MonoBehaviour
{
    public Spawning_Boxes box_cp;

    public GameObject bigBox_pref;

    public GameObject box_pref;

    private Vector3 small_box_spawn_pos;

    private Vector3[] big_box_spawn_pos = new Vector3[2];

    public List<Rigidbody2D> spawnedBoxes = new List<Rigidbody2D>();

    public float speed = 10f;

    private int random;

    public bool box_destroyed_x = true;

    void Start()
    {
        small_box_spawn_pos = new Vector3(-12, -1, 0);

        big_box_spawn_pos[0] = new Vector3(-12, -4f, 0);

        big_box_spawn_pos[1] = new Vector3(-12, -1f, 0);

    }

    private void spawn_small_copy() 
    {
            GameObject smallBox = Instantiate(box_pref, small_box_spawn_pos, Quaternion.identity);
            Rigidbody2D rb = smallBox.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.left * speed;
            Destroy_big_boxes db = smallBox.GetComponent<Destroy_big_boxes>();
        if (db == null)
        {
            db = smallBox.AddComponent<Destroy_big_boxes>();
        }
        db.spawner2 = box_cp;

    }

    private void spawn_big_copy()
    {
           
            GameObject bigBox = Instantiate(bigBox_pref, big_box_spawn_pos[random], Quaternion.identity);
            Rigidbody2D rb = bigBox.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            spawnedBoxes.Add(rb);
            Destroy_big_boxes db = bigBox.GetComponent<Destroy_big_boxes>();
            if (db == null)
            {
            db = bigBox.AddComponent<Destroy_big_boxes>();
            }
            db.spawner2 = box_cp;

    }


    void Update()
    {
        foreach (Rigidbody2D rb in spawnedBoxes)
        {
            if (rb != null)
            {
                rb.linearVelocity = Vector2.left * speed;
            }
        }
        if (box_cp.small_box) 
        {
            spawn_small_copy();
            Debug.Log("New Spawned");
            box_cp.small_box = false;
        }

        if (box_cp.big_box)
        {
            random = Random.Range(0, 2);
            spawn_big_copy();
            box_cp.big_box = false;

        }
    }
}
