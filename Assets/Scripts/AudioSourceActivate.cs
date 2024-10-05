using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceActivate : MonoBehaviour
{
    public List<AudioClip> sound = new List<AudioClip>();
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Subscribe to events
        FlappyBird.died += OnDied;
        FlappyBird.fly += OnFly;
        TubesSpawn.sound += OnCollect;
    }

    void OnDestroy()
    {
        // Unsubscribe from events
        FlappyBird.died -= OnDied;
        FlappyBird.fly -= OnFly;
        TubesSpawn.sound -= OnCollect;
    }

    void OnFly()
    {
        PlaySound(sound[0]); // Play 'Fly' sound
    }

    void OnCollect()
    {
        PlaySound(sound[1]); // Play 'Collect' sound
    }
    void OnDied()
    {
        PlaySound(sound[2]); // Play 'Lose' sound
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
