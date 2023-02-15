using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhysicsText : MonoBehaviour
{
    //public TextMeshPro heightAboveOrigin;
    
    private void Start()
    {
        
    }

    public static void TextSet(TextMeshPro tmpro, string text)
    {
        tmpro.text = text;
    }
    public static void TextPosition(TextMeshPro tmpro, Vector3 position)
    {
        tmpro.transform.position = position;
    }
    public static void TextRotate(TextMeshPro tmpro, Quaternion rotation)
    {
        tmpro.transform.rotation = rotation;//Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }
    public static void TextShow(TextMeshPro tmpro, bool show)
    {
        tmpro.transform.gameObject.SetActive(show);
    }
    public static void TextFontSize(TextMeshPro tmpro, int fontSize)
    {
        tmpro.fontSize = fontSize;
    }

}
