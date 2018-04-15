using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundHandler : MonoBehaviour {

    public static soundHandler Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this);

        foreach(AudioListener aD in FindObjectsOfType<AudioListener>())
        {
            print(aD.name);
        }


    }

    public List<AudioClip> shotSound;
    public AudioSource shot;

    public List<AudioClip> hitPlayerSound;
    public AudioSource hitPlayer;

    public List<AudioClip> hitZombieSound;
    public AudioSource hitZombie;

    public List<AudioClip> deathSound;
    public AudioSource death;

    public List<AudioClip> switchSound;
    public AudioSource switchs;

    public List<AudioClip> emptySound;
    public List<AudioSource> empty;

    public List<AudioClip> zmoanSound;

    public AudioClip getZMoan()
    {
        int rnd = Random.Range(0, zmoanSound.Count);
        return zmoanSound[rnd];
    }
    public void PlayDeath()
    {
        PlaySOundList(deathSound, death);
    }
    public void PlaySwitch()
    {
        PlaySOundList(switchSound, switchs);
    }

    public void PlayShot()
    {
        PlaySOundList(shotSound, shot);
    }

    public void PlaySOundList(List<AudioClip> listSource, AudioSource source)
    {
        int random = Random.Range(0, listSource.Count);
        source.clip = listSource[random];
        source.PlayOneShot(source.clip);
    }


    public void PlayHitPlayer()
    {
        PlaySOundList(hitPlayerSound, hitPlayer);
    }


    public void PlayHitZombie()
    {
        PlaySOundList(hitZombieSound, hitZombie);
    }
    public void PlayEmpty()
    {

        int random = Random.Range(0, empty.Count);
        if(!empty[random].isPlaying)
            PlaySOundList(emptySound, empty[random]);
    }


}
