using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PortraitChange : MonoBehaviour
{
    [SerializeField] Image portrait;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] Sprite[] sprites = new Sprite[5];
    // Start is called before the first frame update
    void Start()
    {
        portrait.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        switch (textMeshProUGUI.text)
        {
            case "พนักงานบริษัท":
                portrait.sprite = sprites[0];
                break;
            case "ชายชราหัวรั้น":
                portrait.sprite = sprites[1];
                break;
            case "หนุ่มน้อยผู้กล้า":
                portrait.sprite = sprites[2];
                break;
            case "หนูน้อยไร้เดียงสา":
                portrait.sprite = sprites[3];
                break;
            case "เด็กสาวรักสันโดษ":
                portrait.sprite = sprites[4];
                break;
            default:
                break;
        }
    }
}
