using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Weather
{
    Sun,
    Cloud,
    Rain,
    Cyclone,
    Ice,
}
public class gb_GameManager : MonoBehaviour
{
    public static gb_GameManager Instance;
    public gb_Player Player;

    public gb_Tile[] tiles;
    public float Price=0;

    public float time;

    public Text Timer;

    public Weather today;
    public Weather tomorrow;

    public Light Sun;
    private void Awake()
    {
        Instance = this;
        today = (Weather)Random.Range(0, 5);
        tomorrow = (Weather)Random.Range(0, 5);
        switch (today)
        {
            case Weather.Sun:
                RenderSettings.fogDensity = 0.01f;
                break;
            case Weather.Cloud:
                RenderSettings.fogDensity = 0.025f;
                break;
            case Weather.Rain:
                RenderSettings.fogDensity = 0.05f;
                break;
            case Weather.Cyclone:
                break;
            case Weather.Ice:
                break;
        }
    }
    private void Update()
    {
        time += Time.deltaTime*12;
        if(time >= 1440)
        {
            today = tomorrow;
            switch (today)
            {
                case Weather.Sun:
                    RenderSettings.fogDensity = 0.01f;
                    break;
                case Weather.Cloud:
                    RenderSettings.fogDensity = 0.025f;
                    break;
                case Weather.Rain:
                    RenderSettings.fogDensity = 0.05f;
                    break;
                case Weather.Cyclone:
                    break;
                case Weather.Ice:
                    break;
            }
            tomorrow = (Weather)Random.Range(0, 5);
            time = 0;
        }
        Timer.text = (Mathf.Floor(time/60)).ToString("#,#00") + " : " + (time % 60).ToString("#,#00");
        Sun.transform.rotation = Quaternion.Euler((time/1440f)*360+270, 0, 0);
    }
}
