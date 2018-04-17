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
    public List<AudioSource> shot;

    public List<AudioClip> hitSound;
    public List<AudioSource> hit;

    public List<AudioClip> walkSound;
    public AudioSource walk;

    public List<AudioClip> kiSound;
    public AudioSource ki;

    public List<AudioClip> spawnSound;
    public AudioSource spawn;

    public List<AudioClip> dashSound;
    public AudioSource dash;

    public List<AudioClip> clipSound;
    public List<AudioSource> clip;


    public AudioSource music_UI;
    public AudioSource music_game;

    public float speedVolumeChange = 20;

    public void ChangeMusic()
    {
        StartCoroutine(downSource(music_UI));

        StartCoroutine(upSource(music_game));
        music_game.loop = true;
    }

    IEnumerator downSource(AudioSource aS)
    {
        while (aS.volume > 0)
        {
            aS.volume -= speedVolumeChange * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        aS.Stop();
    }
    IEnumerator upSource(AudioSource aS)
    {
        music_game.Play();
        while (aS.volume < 1)
        {
            aS.volume += speedVolumeChange * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void PlayShot()
    {
        AudioSource source = shot[0];
        foreach (AudioSource aS in shot)
        {
            if (!aS.isPlaying)
                source = aS;
        }
        PlaySoundList(shotSound, source);
    }
    public void PlayHit()
    {
        AudioSource source = hit[0];
        foreach (AudioSource aS in hit)
        {
            if (!aS.isPlaying)
                source = aS;
        }
        PlaySoundList(hitSound, source);
    }

    public void PlayWalk()
    {
        if(!walk.isPlaying)
            PlaySoundList(walkSound, walk);
    }

    public void PlayKi()
    {
        PlaySoundList(kiSound, ki);
    }


    public void PlaySpawn()
    {
        PlaySoundList(spawnSound, spawn);
    }

    public void PlayDash()
    {
        if (!dash.isPlaying)
        PlaySoundList(dashSound, dash);
    }

    public void PlayClip()
    {
        AudioSource source = clip[0];
        foreach (AudioSource aS in clip)
        {
            if (!aS.isPlaying)
                source = aS;
        }
        PlaySoundList(clipSound, source);
    }



    public void PlaySoundList(List<AudioClip> listSource, AudioSource source)
    {
        int random = Random.Range(0, listSource.Count);
        source.clip = listSource[random];
        source.PlayOneShot(source.clip);
    }

}
