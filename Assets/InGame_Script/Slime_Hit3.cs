using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Hit3 : MonoBehaviour
{
    public Move_Slime move_Slime;
    public float attack_angle;
    // Start is called before the first frame update
    void Start()
    {

        move_Slime = GameObject.Find("Canvas").transform.Find("MoveBack_slime").GetComponent<Move_Slime>();
        Invoke("Destory_Hit", 0.5f);

        attack_angle = Mathf.Atan2(move_Slime.move.transform.localPosition.y - 0, move_Slime.move.transform.localPosition.x - 0) * Mathf.Rad2Deg;

        if (attack_angle > 0)
            gameObject.transform.eulerAngles = new Vector3(0, 0, attack_angle - 180);
        else if (attack_angle < 0)
            gameObject.transform.eulerAngles = new Vector3(0, 0, attack_angle + 180);

    }

    // Update is called once per frame
    void Update()
    {
        if (attack_angle == 0)
        {
            gameObject.transform.Translate(new Vector3(1, -0.4f, 0) * Time.deltaTime * 25f, Space.World);

        }
        else
            gameObject.transform.Translate(new Vector3(-1, -0.4f, 0) * Time.deltaTime * 25f);
    }
    public void Destory_Hit()
    {
        Destroy(gameObject);
    }
}
