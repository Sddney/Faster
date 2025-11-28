using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destroy_small_boxes : MonoBehaviour
{
    public float destroyY = -6f;

    public Spawning_Boxes spawner1;
    

    private IEnumerator variableChange()
    {
        spawner1.box_destroyed_y = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        spawner1.spawnedBoxes.Remove(rb);
        yield return new WaitForSeconds(0.2f);
    }

    void Update()
    {

        if(transform.position.y < destroyY)
        {
            StartCoroutine(variableChange());
            Destroy(gameObject);
        }

    }
}
