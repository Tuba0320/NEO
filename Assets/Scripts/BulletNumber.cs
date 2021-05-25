using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletNumber : MonoBehaviour
{
    [SerializeField]
    GameObject muzzle;
    PlayerGeneralMuzzleController pgmc;
    Text text;

    void Start()
    {
        text = GetComponentInChildren<Text>();
        pgmc = muzzle.GetComponent<PlayerGeneralMuzzleController>();
    }

    void Update()
    {
        int num = pgmc.getNum();
        text.text = num.ToString();
    }
}
