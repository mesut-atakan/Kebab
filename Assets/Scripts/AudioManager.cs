using UnityEngine;



internal class AudioManager : MonoBehaviour
{
    public AudioClip[] music;
    public AudioSource musicSource;



    public void ChangeMussic()
    {
        if (this.musicSource.clip == music[0])
            this.musicSource.clip = music[1];
        else
            this.musicSource.clip = music[0];

        this.musicSource.Play();
    }
}