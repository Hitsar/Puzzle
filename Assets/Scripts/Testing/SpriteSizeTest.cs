using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSizeTest : MonoBehaviour
{
    [SerializeField] private Image _image;

    private void Start()
    {
        Debug.Log(_image.sprite.rect.width);
        Debug.Log(_image.sprite.rect.height);
    }
}
