using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class ButtonColorBase : MonoBehaviour
{
    public Color color;
    [Header("References")] 
        public Image uiImage;
        public Player player;
    private void OnValidate()
    {
        uiImage.GetComponent<Image>();
    }
    private void Start()
    {
        uiImage.color = color;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        player.ChangeColor(color);
    }
}
