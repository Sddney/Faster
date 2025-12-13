using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public static AudioControl instance;

    [SerializeField] private AudioSource SoundObject;
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySound(AudioClip clip, Transform spawnPosition, float volume)
    {
        AudioSource audioSource = Instantiate(SoundObject, spawnPosition.position, Quaternion.identity);
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
