using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    //this is a singleton
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    // if the ONLY SINGLE instance of this does not exist, make it.
    // otherwise don't make a new one
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }   
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;
        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }


}
