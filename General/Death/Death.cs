using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class Death : MonoBehaviour
{
    public GameObject dead;

    public Spawning_Boxes box;
    public boxSpawner2 box2;

    public bool fail = false;

    public new switchCamera camera;

    public GameObject player1;

    public GameObject player2;

    public GameObject counter1;

    public GameObject counter2;

    public Life_count life;

    public AudioMixer mixer;
    public AudioClip deathSound;
    public AudioClip restartSound;


    private float preVolume;
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
            box2.speed = 0f;
            box.spawnInterval = 0f;
            fail = true;
            box.spawner = false;
            camera.camera_switching = false;
            counter1.SetActive(false);
            counter2.SetActive(false);
            mixer.GetFloat("MusicVolume", out preVolume);
            mixer.SetFloat("MusicVolume", -80f);
            AudioControl.instance.PlaySound(deathSound, transform, 1f);

        }
    }

    void Update()
    {
        deadScreen();
    }
    
    public void Restart()
    {
            Counter.count = 0;
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
            box.speed = 5f;
            box2.speed = 8f;
            box.spawnInterval = 2f;
            mixer.SetFloat("MusicVolume", preVolume);
            AudioControl.instance.PlaySound(restartSound, transform, 1f);
    }
}
