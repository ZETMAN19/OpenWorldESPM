using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisSound : MonoBehaviour {
    public AudioSource audios;
    public AudioClip[] clips;
	

    private void OnCollisionEnter(Collision collision)
    {
        audios.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}
