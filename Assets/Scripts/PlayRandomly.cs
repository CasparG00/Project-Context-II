using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomly : MonoBehaviour
{
    [SerializeField] private Vector2 randomPlayDelay = new Vector2(10, 20);
    private AudioSource audioSource;

    private float randomTime;
    private float currentTime;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        randomTime = Random.Range(randomPlayDelay.x, randomPlayDelay.y);
    }
    
    private void Update()
    {
        if (currentTime > randomTime)
        {
            randomTime = Random.Range(randomPlayDelay.x, randomPlayDelay.y);
            currentTime = 0;
            audioSource.Stop();
            audioSource.Play();
        }

        currentTime += Time.deltaTime;
    }
}
