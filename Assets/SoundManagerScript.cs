using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip turretShootingSound, playerJumpSound, playerDieSound, snakeDieSound;

    private static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip>("jump");
        playerDieSound = Resources.Load<AudioClip>("death");
        turretShootingSound = Resources.Load<AudioClip>("turret");
        snakeDieSound = Resources.Load<AudioClip>("snakeDeath");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void PlaySound(String clip)
        {
            switch (clip)
            {
                case "jump":
                    audioSource.PlayOneShot(playerJumpSound);
                    break;
                case "gameOver":
                    audioSource.PlayOneShot(playerDieSound);
                    break;
                case "shooting":
                    audioSource.PlayOneShot(turretShootingSound);
                    break;
                case "snakeDeath":
                    audioSource.PlayOneShot(snakeDieSound);
                    break;
            }
        }
}
