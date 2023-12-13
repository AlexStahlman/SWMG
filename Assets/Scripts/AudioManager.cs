using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Header("Parent Object")]
    [SerializeField] private Transform SFXManager;

    [Header("Audio Objects")]
    [SerializeField] private AudioSource SFX_Object;
    [SerializeField] private AudioSource OST_Object;

    [Header("Sound Clips")]
    [SerializeField] private AudioClip OST_Soundtrack;
    [SerializeField] private AudioClip SFX_FireCast;
    
    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    private void Start(){
        PlaySoundtrack();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //function to play sounds.
    public void PlaySound(AudioClip audio, Transform spawnArea, float volume){

        AudioSource audioSource = Instantiate(SFX_Object, spawnArea.position, Quaternion.identity);

        audioSource.clip = audio;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }
    public void play_FireCast(){
        AudioSource audioSource = Instantiate(SFX_Object, new Vector3(0f,0f,0f), Quaternion.identity);
        audioSource.transform.parent = SFXManager;

        audioSource.clip = SFX_FireCast;
        audioSource.volume = .5f;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
   
   public void PlaySoundtrack(){
    AudioSource audioSource = Instantiate(OST_Object, new Vector3(0f,0f,0f), Quaternion.identity);
    audioSource.transform.parent = SFXManager;

    audioSource.clip = OST_Soundtrack;
    audioSource.loop = true;
    audioSource.volume = .1f;
    audioSource.Play();
   }
}
