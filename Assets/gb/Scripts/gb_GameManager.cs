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

    public GameObject[] seeds;

    public int[] seedcounts;

    public Transform Rain;
    public Transform Cyclone;
    public Transform Ice;

    public int glowvalue;
    private void Awake()
    {
        Instance = this;
        today = (Weather)Random.Range(0, 5);
        tomorrow = (Weather)Random.Range(0, 5);
        Rain.gameObject.SetActive(false);
        Ice.gameObject.SetActive(false);
        Cyclone.gameObject.SetActive(false);
        switch (today)
        {
            case Weather.Sun:
                RenderSettings.fogDensity = 0.01f;
                break;
            case Weather.Cloud:
                RenderSettings.fogDensity = 0.025f;
                break;
            case Weather.Cyclone:
                Rain.gameObject.SetActive(true);
                RenderSettings.fogDensity = 0.05f;
                Cyclone.gameObject.SetActive(true);
                break;
            case Weather.Rain:
                Rain.gameObject.SetActive(true);
                RenderSettings.fogDensity = 0.05f;
                break;
            case Weather.Ice:
                Ice.gameObject.SetActive(true);
                RenderSettings.fogDensity = 0.05f;
                break;
        }
    }

    public float glowtime;

    private void Update()
    {
        glowtime += Time.deltaTime;
        time += Time.deltaTime*12;
        if(time >= 1440)
        {
            today = tomorrow;
            Rain.gameObject.SetActive(false);
            Ice.gameObject.SetActive(false);
            Cyclone.gameObject.SetActive(false);
            switch (today)
            {
                case Weather.Sun:
                    RenderSettings.fogDensity = 0.01f;
                    break;
                case Weather.Cloud:
                    RenderSettings.fogDensity = 0.025f;
                    break;
                case Weather.Cyclone:
                    Rain.gameObject.SetActive(true);
                    RenderSettings.fogDensity = 0.05f;
                    Cyclone.gameObject.SetActive(true);
                    break;
                case Weather.Rain:
                    Rain.gameObject.SetActive(true);
                    RenderSettings.fogDensity = 0.05f;
                    break;
                case Weather.Ice:
                    Ice.gameObject.SetActive(true);
                    RenderSettings.fogDensity = 0.05f;
                    break;
            }
            tomorrow = (Weather)Random.Range(0, 5);
            time = 0;
        }
        Timer.text = (Mathf.Floor(time/60)).ToString("#,#00") + " : " + (time % 60).ToString("#,#00");
        Sun.transform.rotation = Quaternion.Euler((time/1440f)*360+270, -90, 0);

        if(glowtime >= 1)
        {
            glowtime = 0;
            foreach(gb_Tile t in tiles)
            {
                t.Glow(glowvalue);
            }
        }
    }
}
