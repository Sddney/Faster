using UnityEngine;
using System.Collections;

public class Destroy_big_boxes : MonoBehaviour
{
    public Spawning_Boxes spawner2;
    public float destroyX = -34f;
    
    private IEnumerator variableChange()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        spawner2.spawnedBoxes.Remove(rb);
        yield return new WaitForSeconds(0.2f);
    }

    void Update()
    {

        if(transform.position.x < destroyX)
        {
            StartCoroutine(variableChange());
            Destroy(gameObject);
        }

    }
}
