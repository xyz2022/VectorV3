using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideWorld : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public Material blackSkybox;
    public GameObject throwableObject;

    private Material previousSkybox;

    public void ShowWorld(bool show)
    {
        if (!show)
        {
            previousSkybox = RenderSettings.skybox;
            RenderSettings.skybox = blackSkybox;

            throwableObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            RenderSettings.skybox = previousSkybox;
            throwableObject.GetComponent<Rigidbody>().isKinematic = false;
        }

        for (int i = 0; i < gameObjects.Count; i++)
            gameObjects[i].SetActive(show);
        //RenderSettings.skybox = Color.black;
        
    }
}
