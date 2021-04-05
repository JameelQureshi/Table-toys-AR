using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IntroController : MonoBehaviour
{
    public Animator girlAnimator;
    public Animator boyAnimator;

    public AudioClip[] audioClips;

    AudioSource audioSource;

    private int currentAudioIndex=0;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;

        girlAnimator.enabled = false;
        boyAnimator.enabled = false;

        //PlayIntroAudio();
    }


    public void PlayIntroAudio()
    {
        if (currentAudioIndex == 2)
        {
            girlAnimator.enabled = false;
            boyAnimator.enabled = true;
        }
        else
        {
            girlAnimator.enabled = true;
            boyAnimator.enabled = false;
        }

        if (currentAudioIndex< audioClips.Length)
        {
            audioSource.clip = audioClips[currentAudioIndex];
            audioSource.Play();
            StartCoroutine(WaitForNextAudio((int)audioSource.clip.length));
        }
        else
        {
            girlAnimator.enabled = false;
        }
    }

    IEnumerator WaitForNextAudio(int duration)
    {
        yield return new WaitForSeconds(duration);
        currentAudioIndex++;
        PlayIntroAudio();
    }

  
}
