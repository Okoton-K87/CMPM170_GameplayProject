using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURLScript : MonoBehaviour
{
    public string url; // URL to open

    public void OpenURL()
    {
        Application.OpenURL(url);
    }
}

