using UnityEngine;
using UnityEngine.UI;

public enum gb_PlantType
{
    None,
    Potato,
    Carrot,
    Tomato,
    Garic,
    Onion
}

[System.Serializable]
public class gb_Plant
{
    public gb_PlantType type;
    public float maxGlow;
    public float Glow;
}

public class gb_Tile : MonoBehaviour
{
    public float water = 50;

    public gb_Plant[] plants;

    public Transform buyUI;

    public gb_Tile[] onTile;

    public Text priceText;

    public Slider WaterSlider;

    public bool buyed;

    public bool animal;

    public bool binilhouse;
    public bool autoget;
    public bool animalget;

    void Start()
    {

    }

    void Update()
    {
        if (!buyed)
        {
            if (gb_GameManager.Instance.Price == 0)
            {
                priceText.text = "¹«·á";
            }
            else priceText.text = gb_GameManager.Instance.Price.ToString("#,##0");
        }
        else
        {


            WaterSlider.value = water;
        }
    }

    public void Buy()
    {
        if (gb_GameManager.Instance.Player.Money >= gb_GameManager.Instance.Price)
        {
            buyed = true;
            buyUI.gameObject.SetActive(false);
            if (gb_GameManager.Instance.Price == 0)
            {
                gb_GameManager.Instance.Price = 20000;
                foreach (gb_Tile gt in gb_GameManager.Instance.tiles)
                {
                    if (gt != this)
                    {
                        gt.gameObject.SetActive(false);
                    }
                }
            }
            else gb_GameManager.Instance.Price *= 1.5f;

            foreach (gb_Tile gt in onTile)
            {
                if (!gt.gameObject.activeSelf)
                {
                    gt.gameObject.SetActive(true);
                }
            }
        }
    }

    public void setplant(int vagetype, int tilenum)
    {
        switch (vagetype)
        {
            case 0:
                plants[tilenum].type = gb_PlantType.Potato;
                plants[tilenum].maxGlow = 70;
                break;
            case 1:
                plants[tilenum].type = gb_PlantType.Carrot;
                plants[tilenum].maxGlow = 80;
                break;
            case 2:
                plants[tilenum].type = gb_PlantType.Tomato;
                plants[tilenum].maxGlow = 180;
                break;
            case 3:
                plants[tilenum].type = gb_PlantType.Garic;
                plants[tilenum].maxGlow = 100;
                break;
            case 4:
                plants[tilenum].type = gb_PlantType.Onion;
                plants[tilenum].maxGlow = 60;
                break;
        }
    }
}
