using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 3f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float normalSpeed = 10f;
    int EffectTime = 2000;
    bool OnEffectTime = false;
    [SerializeField] ParticleSystem HighEffect;
    [SerializeField] ParticleSystem LowEffect;
    [SerializeField] AudioClip HighSpeedSFX;
    [SerializeField] AudioClip LowSpeedSFX;

    SurfaceEffector2D surfaceEffector2D;

    Rigidbody2D rd2d;

    bool enableControll = true;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enableControll)
        {
            RotatePlayer();
            BoostSpeed();
        }
    }

    public void DisableControl()
    {
        enableControll = false;
    }

    void BoostSpeed()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rd2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rd2d.AddTorque(-torqueAmount);
        }
        if (OnEffectTime)
        {
            EffectTime--;
        }
        if (EffectTime < 0)
        {
            OnEffectTime = false;
            torqueAmount = 3f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HighCloud")
        {
            EffectTime = 2000;
            OnEffectTime = true;
            HighEffect.Play();
            LowEffect.Stop();
            torqueAmount = 10f;
            GetComponent<AudioSource>().PlayOneShot(HighSpeedSFX);
        }

        if (other.tag == "PoisonCloud")
        {
            EffectTime = 2000;
            OnEffectTime = true;
            LowEffect.Play();
            HighEffect.Stop();
            torqueAmount = 0.5f;
            GetComponent<AudioSource>().PlayOneShot(LowSpeedSFX);
        }
    }
}
