using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellM : MonoBehaviour
{
    float speed = 1;

    void Update()
    {
        this.transform.Translate(0, (speed * Time.deltaTime) / 2.0f, speed * Time.deltaTime);
    }
}
