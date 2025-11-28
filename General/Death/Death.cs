using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject dead;

    public Spawning_Boxes box;

    public bool fail = false;

    public new switchCamera camera;

    public GameObject player1;

    public GameObject player2;

    public Counter counter;

    public GameObject counter1;

    public GameObject counter2;

    public Life_count life;

     private void Start()
    {
        dead.SetActive(false);
    }

    public void deadScreen()
    {
        if (life.life <= 0 && fail == false)
        {
            dead.SetActive(true);
            box.speed = 0f;
            box.spawnInterval = 0f;
            fail = true;
            box.spawner = false;
            camera.camera_switching = false;
            counter1.SetActive(false);
            counter2.SetActive(false);
        }
    }

    void Update()
    {
        deadScreen();
    }
    
    public void Restart()
    {
         counter.count = 0;
            counter1.SetActive(true);
            counter2.SetActive(false);
            camera.camera_switching = true;
            camera.cam1.SetActive(true);
            camera.cam2.SetActive(false);
            player1.SetActive(true);
            player2.SetActive(false);
            box.spawner = true;
            dead.SetActive(false);
            life.life = 5;
            fail = false;
            box.speed = 4f;
            box.spawnInterval = 2f;
    }
}
