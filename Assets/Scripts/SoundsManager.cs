using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Android.Gradle;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField]
    List<SoundElement> soundClips;
    [SerializeField]
    AudioSource BgMusicSource;
    [SerializeField]
    AudioSource SoundClipSource;

    private static SoundsManager instance;
    public static SoundsManager Instance { get { return instance; } }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public void Start()
    {
        PlayBackGroundMusic();
    }

    public void PlayClip(Sounds type, SoundPlayingType playType)
    {
        SoundElement element = soundClips.Where(s => s.Type == type).FirstOrDefault();
        if(element != null)
        {
            if(playType == SoundPlayingType.OneShot)
            {
                if(!SoundClipSource.isPlaying) SoundClipSource.PlayOneShot(element.AudioClip);
            }
            //if(element.Type == Sounds.BGMusic)
            //{
            //    BgMusicSource.clip = element.AudioClip;
            //    BgMusicSource.Play();
            //}
            //else
            //{
            //    SoundClipSource.PlayOneShot(element.AudioClip);
            //}
        }
    }

    private void PlayBackGroundMusic()
    {
        SoundElement element = soundClips.Where(s => s.Type == Sounds.BGMusic).FirstOrDefault();
        BgMusicSource.clip = element.AudioClip;
        BgMusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class SoundElement
{
    public Sounds Type;
    public AudioClip AudioClip;
}

public enum Sounds
{
    BGMusic,
    OnClick,
    Death,
    PlayerMove,
    Jump,
}

public enum SoundPlayingType
{
    OneShot,
    Loop
}