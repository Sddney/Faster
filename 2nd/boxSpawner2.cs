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

    public float speed = 8f;

    private int random;

    public bool box_destroyed_x = true;

    private bool top_box_spawned = false;

    public GameObject S_key;
    public GameObject player;

    void Start()
    {
        small_box_spawn_pos = new Vector3(-12, -1, 0);

        big_box_spawn_pos[0] = new Vector3(-12, -4f, 0);

        big_box_spawn_pos[1] = new Vector3(-12, -1f, 0);

    }

    private void spawn_small_copy() 
    {
            GameObject smallBox = Instantiate(box_pref, big_box_spawn_pos[0], Quaternion.identity);
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

    private IEnumerator<WaitForSeconds> S_show()
    {
        S_key.SetActive(true);
        yield return new WaitForSeconds(7f);
        S_key.SetActive(false);
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


    void FixedUpdate()
    {
        speed = speed + 0.0005f;
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
            if (random == 1 && !top_box_spawned)
            {
                StartCoroutine(S_show());
                top_box_spawned = true;
            }
            box_cp.big_box = false;

        }
    }
}
