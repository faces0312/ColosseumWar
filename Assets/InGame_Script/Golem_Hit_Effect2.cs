using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Hit_Effect2 : MonoBehaviour
{
    public float dis_time;
    void Update()
    {
        if (dis_time > 0.5f)
            Destroy(gameObject);
        dis_time += Time.deltaTime;
    }
}
