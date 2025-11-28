using UnityEngine;
using System.Collections;

public class Life_count : MonoBehaviour
{
    public Life player1_obs_faced;

    public Life2 player2_obs_faced;

    public int life = 20;

    public bool damage_taken = false;

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        damage_taken = false;
    }
    void Update()
    {
        if (player1_obs_faced.obstacle_faced || player2_obs_faced.obstacle2_faced)
        {
            life -= 1;
            damage_taken = true;
            StartCoroutine(wait());
            player1_obs_faced.obstacle_faced = false;
            player2_obs_faced.obstacle2_faced = false;
        }
    
    }
}
