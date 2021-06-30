using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentController : MonoBehaviour
{
    [SerializeField]
    GameObject[] equipments;
    [SerializeField]
    Text nameText;
    [SerializeField]
    Text numberText;
    int num = 0;
    float scroll;

    void Start()
    {
        equipments[num].SetActive(true);
    }

    void FixedUpdate()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");
        nameText.text = equipments[num].name;
        numberText.text = num.ToString();
        if (scroll > 0)
        {
            if (num + 1 > equipments.Length - 1)
            {
                return;
            }
            equipments[num].SetActive(false);
            num++;
            equipments[num].SetActive(true);
        }
        else if(scroll < 0)
        {
            if (num - 1 < 0)
            {
                return;
            }
            equipments[num].SetActive(false);
            num--;
            equipments[num].SetActive(true);
        }
    }
}
