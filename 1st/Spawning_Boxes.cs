using UnityEngine;
using System.Collections.Generic;

public class Spawning_Boxes : MonoBehaviour
{
    public float speed = 5f;
    public GameObject boxes;
    public GameObject bigBoxes;
    public float spawnInterval = 10f;

    private Vector3 screenBounds;
    private Vector3[] spawnPosition = new Vector3[3];

    public List<Rigidbody2D> spawnedBoxes = new List<Rigidbody2D>();
    
    public bool small_box = false;
    public bool big_box = false;
    public bool spawner = true;

    public bool box_destroyed_y = true;

    void Start()
    {
        // Set spawn positions
        spawnPosition[0] = new Vector3(-2, 7, 0);
        spawnPosition[1] = new Vector3(0, 7, 0);
        spawnPosition[2] = new Vector3(2, 7, 0);
    }

    void FixedUpdate()
    {
        speed = speed + 0.0005f;
        if (spawner)
        {
            foreach (Rigidbody2D rb in spawnedBoxes)
            {
                rb.linearVelocity = Vector2.down * speed;
            }
            if (box_destroyed_y)
            {
                int random = Random.Range(0, 2);
                if (random == 0)
                {
                    spawnBox();
                    small_box = true;
                }
                else
                {
                    spawnBigBox();
                    big_box = true;
                }
                box_destroyed_y = false;
            }
        }
    }


    private void Spawning(GameObject box_prefab, Vector3 position)
    {
        GameObject box = Instantiate(box_prefab, position, Quaternion.identity);
        Rigidbody2D rb = box.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        spawnedBoxes.Add(rb);
        Destroy_small_boxes db = box.GetComponent<Destroy_small_boxes>();
        if (db == null)
            db = box.AddComponent<Destroy_small_boxes>();
        db.spawner1 = this;
    }

    public void spawnBox()
    {
        small_box = true;
        int random = Random.Range(0, 3);
        int oneOrTwo = Random.Range(0, 3);

        if (oneOrTwo > 0)
        {
            // Spawn single box
            Spawning(boxes, spawnPosition[random]);

        }
        else
        {
            // Spawn two boxes
            Spawning(boxes, spawnPosition[random]);

            int next_box_index = Random.Range(0, 3);
            if (random != next_box_index)
            {
                Spawning(boxes, spawnPosition[next_box_index]);
            }
        }
    }

    private void spawnBigBox()
    {
        Spawning(bigBoxes, spawnPosition[1]);
    }

    public void SetSpeed(float newSpeed)
    {
        newSpeed = speed;
    }
}
