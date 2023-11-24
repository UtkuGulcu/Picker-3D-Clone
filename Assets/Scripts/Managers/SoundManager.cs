using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    
    [Header("References")]
    [SerializeField] private SoundEffectsReferencesSO soundEffectsReferencesSO;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There are more than one Sound Managers!");
            Destroy(this);
        }
    }

    public void PlayCollectableCollisionSound(object sender, object data)
    {
        bool isFillAreaGround = (bool)data;
        
        float pickerCollisionVolume = 1f;
        float fillAreaCollisionVolume = 0.8f;
        
        
        float volume = isFillAreaGround ? fillAreaCollisionVolume : pickerCollisionVolume;
        
        PlaySound(soundEffectsReferencesSO.collectableCollision, volume);
    }

    public void PlayFillAreaSuccessSound()
    {
        PlaySound(soundEffectsReferencesSO.fillAreaSuccess);
    }

    public void PlayPickedPowerUpSound()
    {
        PlaySound(soundEffectsReferencesSO.pickedPowerUp);
    }

    private void PlaySound(AudioClip audioClip, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
    }
}
