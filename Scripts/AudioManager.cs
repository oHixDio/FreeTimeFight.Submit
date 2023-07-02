using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    [SerializeField] AudioSource sourceBGM;
    [SerializeField] AudioSource sourceSE;
    [SerializeField] AudioSource sourceSESub;

    public AudioSource SourceBGM   { get => sourceBGM  ; }
    public AudioSource SourceSE    { get => sourceSE   ; }
    public AudioSource SourceSESub { get => sourceSESub; }

    [SerializeField] AudioClip mainBGM;
    [SerializeField] AudioClip bossBGM;
    [SerializeField] AudioClip completeBGM;
    [SerializeField] AudioClip systemClearSE;
    [SerializeField] AudioClip systemErrerSE;
    [SerializeField] AudioClip attackSE;
    [SerializeField] AudioClip criticalSE;
    [SerializeField] AudioClip enemyAttackSE;
    [SerializeField] AudioClip enemyCriticalSE;
    [SerializeField] AudioClip healSE;
    [SerializeField] AudioClip levelUpSE;
    [SerializeField] AudioClip statusUpSE;
    [SerializeField] AudioClip statusDownSE;
    [SerializeField] AudioClip buySE;
    [SerializeField] AudioClip shortingSE;

    public AudioClip MainBGM         { get => mainBGM        ; }
    public AudioClip BossBGM         { get => bossBGM        ; }
    public AudioClip CompleteBGM     { get => completeBGM    ; }
    public AudioClip SystemClearSE   { get => systemClearSE  ; }
    public AudioClip SystemErrerSE   { get => systemErrerSE  ; }
    public AudioClip AttackSE        { get => attackSE       ; }
    public AudioClip CriticalSE      { get => criticalSE     ; }
    public AudioClip EnemyAttackSE   { get => enemyAttackSE  ; }
    public AudioClip EnemyCriticalSE { get => enemyCriticalSE; }
    public AudioClip HealSE          { get => healSE         ; }
    public AudioClip LevelUpSE       { get => levelUpSE      ; }
    public AudioClip StatusUpSE      { get => statusUpSE     ; }
    public AudioClip StatusDownSE    { get => statusDownSE   ; }
    public AudioClip BuySE           { get => buySE          ; }
    public AudioClip ShortingSE      { get => shortingSE     ; }

    int defaultAmount = 3;

    void Start()
    {
        SetVolume();
    }

    private void SetVolume()
    {
        sourceBGM.volume = defaultAmount;
        sourceSE.volume = defaultAmount;
        sourceSESub.volume = defaultAmount;
    }

    public void ChangeVolume(AudioSource source, int val)
    {
        source.volume += val;
    }

    public void PlayBGM(AudioClip clip)
    {
        sourceBGM.Stop();
        sourceBGM.clip = clip;
        sourceBGM.Play();
    }

    public void StopBGM()
    {
        sourceBGM.Stop();
    }

    public void PlayOneShotSE(AudioClip clip)
    {
        sourceSE.PlayOneShot(clip);
    }

    public void PlayOneShotSESub(AudioClip clip)
    {
        sourceSESub.PlayOneShot(clip);
    }
}
