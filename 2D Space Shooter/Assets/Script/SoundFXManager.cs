using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        
        //Assign the audioClip
        audioSource.clip = audioClip;

        //Assign Volume
        audioSource.volume = volume;
        
        //Play Sound
        audioSource.Play();
        
        // get length of the audio clp
        float clipLength = audioSource.clip.length;
        
        // Destroy audio clip when done
        Destroy(audioSource.gameObject,clipLength);
    }
}
