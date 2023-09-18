using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;


    public static MusicManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MusicManager>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        Play();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.F12))
        {
            Mute();
        }
    }

    public void Mute()
    {
        GetComponent<AudioSource>().mute = !GetComponent<AudioSource>().mute;
    }

    public void Play()
    {
        GetComponent<AudioSource>().Play();
    }
}