using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    [SerializeField] private AudioClip SFX_EnemySpellCast;
    [SerializeField] private AudioClip[] SFX_Punches;
    [SerializeField] private AudioClip[] SFX_Swishes;
    
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

    //if skeleton lands punch on player.
    public void play_Punch(){
        AudioSource audioSource = Instantiate(SFX_Object, new Vector3(0f,0f,0f), Quaternion.identity);
        audioSource.transform.parent = SFXManager;

        System.Random random = new System.Random();
        int randomNum = random.Next(0,6);

        audioSource.clip = SFX_Punches[randomNum];
        audioSource.volume = .1f;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
    //if skeleton misses punch on player.
    public void play_Swing(){
        AudioSource audioSource = Instantiate(SFX_Object, new Vector3(0f,0f,0f), Quaternion.identity);
        audioSource.transform.parent = SFXManager;

        System.Random random = new System.Random();
        int randomNum = random.Next(0,6);

        audioSource.clip = SFX_Swishes[randomNum];
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
   public void play_EnemySpellCast(){
        AudioSource audioSource = Instantiate(SFX_Object, new Vector3(0f,0f,0f), Quaternion.identity);
        audioSource.transform.parent = SFXManager;

        audioSource.clip = SFX_EnemySpellCast;
        audioSource.volume = .5f;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
