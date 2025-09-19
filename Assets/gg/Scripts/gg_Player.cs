using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gg_Player : MonoBehaviour
{
    public Vector3 OriPosition;

    public int NowUnitNum;
    public gg_Unit[] Units;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        NowUnitNum = 2;
        SetUnit(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SetUnit(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetUnit(false);
        }
    }

    public void SetUnit(bool next)
    {
        Units[NowUnitNum].Played = false;
        if (next)
        {
            if (++NowUnitNum > 2)
            {
                NowUnitNum = 0;
            }
        }
        else
        {
            if (--NowUnitNum < 0)
            {
                NowUnitNum = 2;
            }
        }
        
        transform.parent = Units[NowUnitNum].transform;
        transform.localPosition = OriPosition;
        transform.localRotation = Quaternion.identity;
        Units[NowUnitNum].Played = true;
    }
}
