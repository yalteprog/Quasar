using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource back_music;
    public AudioSource common_but_click;

    void Start()
    {
        
    }

    public void turnBackMusicOff()
    {
        back_music.Stop();
    }
    public void turnBackMusicOn()
    {
        back_music.Play();
    }
    public void turnEffectsOff()
    {
        common_but_click.mute = true ;
    }
    public void turnEffectsOn()
    {
        common_but_click.mute=false;
    }


}
