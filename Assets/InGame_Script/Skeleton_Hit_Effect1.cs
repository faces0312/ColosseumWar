using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Hit_Effect1 : MonoBehaviour
{
    public float dis_time;

    void Start()
    {
        if (gameObject.transform.localScale.x < 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y);
        }

        else if (gameObject.transform.localScale.x > 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y);
        }
    }
    void Update()
    {
        if (dis_time > 0.5f)
            Destroy(gameObject);
        dis_time += Time.deltaTime;
    }
}
