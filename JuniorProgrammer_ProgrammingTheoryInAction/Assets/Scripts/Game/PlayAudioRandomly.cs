using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioRandomly : MonoBehaviour
{
    [SerializeField] private AudioClip audioToRepeat;
    [SerializeField] private float minTimeToRepeat;
    [SerializeField] private float maxTimeToRepeat;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(RepeatSoundRandomly());
    }
    private IEnumerator RepeatSoundRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeToRepeat, maxTimeToRepeat));
            audioSource.PlayOneShot(audioToRepeat, 1f);
        }
    }
}
