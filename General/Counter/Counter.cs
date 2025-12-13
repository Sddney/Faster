using UnityEngine;

public class Counter : MonoBehaviour
{

    public static int count = 0;

    public counter1 counter1;

    public counter2 counter2;

    public Life_count life;

    void Start()
    {
        count = 0;

    }
    

    void Update()
    {
        if (counter1.point || counter2.point)
        {
            
            count += 1;
            counter1.point = false;
            counter2.point = false;
            
            if (count > PlayerPrefs.GetInt("HighestScore", 0))
            {
                PlayerPrefs.SetInt("HighestScore", count);
            }

            if (life.damage_taken)
            {
                count -= 1;
                life.damage_taken = false;
            }
        }
    }
}
