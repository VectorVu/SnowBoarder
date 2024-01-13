using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] ParticleSystem FinishEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FinishEffect.Play();
            Invoke("LoadNewScene", delayTime);
        }
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene(1);
    }
}
