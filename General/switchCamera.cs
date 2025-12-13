using UnityEngine;

public class switchCamera : MonoBehaviour
{


    public GameObject cam1;

    public GameObject cam2;

    public GameObject player1;

    public GameObject player2;

    public Spawning_Boxes box_spawner;

    public bool camera_switching = true;

    public GameObject counter1;

    public GameObject counter2;

    public player2_movement player2_movement;

    public AudioClip switchingSound;


        void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        player1.SetActive(true);
        player2.SetActive(false);
        counter1.SetActive(true);
        counter2.SetActive(false);
    
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && camera_switching)
        {
            AudioControl.instance.PlaySound(switchingSound, transform, 0.2f);

            if (cam1.activeSelf)
            {
                counter1.SetActive(false);
                counter2.SetActive(true);
                cam2.SetActive(true);
                cam1.SetActive(false);
                Debug.Log("switch");
                player1.SetActive(false);
                player2.SetActive(true);
                player2_movement.isCrouching = false;
            }
            else if (cam2.activeSelf)
            {
                counter1.SetActive(true);
                counter2.SetActive(false);
                cam1.SetActive(true);
                cam2.SetActive(false);
                Debug.Log("switch!");
                player2.SetActive(false);
                player1.SetActive(true);

            }
                
        }
    }
}
