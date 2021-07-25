using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float amplitude = 1f, length = 2f, speed = 1f, offset = 0f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Debug.Log("Instance already exists, gotta destry obj YOU KNOW");
            Destroy(this);
        }
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float _x)
    {
        return amplitude * Mathf.Sin(_x / length + offset);
    }
}
