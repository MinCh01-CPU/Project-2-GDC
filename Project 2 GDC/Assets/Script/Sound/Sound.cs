using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public static Sound instance {get; private set; }

    [SerializeField] private int poolLength = 10;
    [SerializeField] private AudioSource soundFXObject;

    private Queue<AudioSource> sfxPool = new Queue<AudioSource>();
    public AudioClip jump, slash, getHit, dive, land;

    public AudioSource walking;
    public AudioSource backgroundSound;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(backgroundSound);
            InitializePool();

        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
  
        backgroundSound.loop = true;
       
    }

    public void PlayClip(AudioClip audioClip, Vector3 position, float volume = 1)
    {
        AudioSource audioSource = GetAvailableSource();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.transform.position = position;
        audioSource.gameObject.SetActive(true);
        audioSource.Play();
        DisableAfter(audioSource, audioSource.clip.length);
    }

    public void StartWalking(Vector3 position, float volume = 1)
    {
        walking.volume = volume;
        walking.transform.position = position;
        walking.gameObject.SetActive(true);
        walking.Play();
    }
    public void StopWalking()
    {
        walking.gameObject.SetActive(false);
        walking.Stop();
    }

    void InitializePool()
    {
        for (int i = 0; i < poolLength; i++)
        {
            AudioSource audioSource = Instantiate(soundFXObject, transform);
            audioSource.gameObject.SetActive(false);
            sfxPool.Enqueue(audioSource);
        }
    }

    AudioSource GetAvailableSource()
    {
        if (sfxPool.Count > 0)
        {
            return sfxPool.Dequeue();
        }
        else
        {
            AudioSource audioSource = Instantiate(soundFXObject, transform);
            return audioSource;
        }
    }

    IEnumerator DisableAfter(AudioSource audioSource, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Stop();
        audioSource.gameObject.SetActive(false);
        sfxPool.Enqueue(audioSource);
    }
    
}
