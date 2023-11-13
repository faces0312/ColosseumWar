using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Move_Golem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform move_background;
    public RectTransform move;

    private float radius;

    //Ä³¸¯ÅÍ Á¶ÇÕ
    public Golem golem;//°ñ·½

    private bool is_move = false;
    private Vector3 movePositon;

    private void Start()
    {
        if (golem.gameObject.activeSelf == false)
        {
            golem.now_hp.gameObject.SetActive(false);
            golem.total_hp.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            golem.now_hp.gameObject.SetActive(true);
            golem.total_hp.gameObject.SetActive(true);
            gameObject.SetActive(true);
        }


        radius = move_background.rect.width * 0.5f;
    }

    private void Update()
    {
        if (move.anchoredPosition.x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            golem.transform.localScale = scale * 5;
        }
        else if (move.anchoredPosition.x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= 1;
            golem.transform.localScale = scale * 5;
        }


        if (is_move)
            golem.transform.position += movePositon;

        if (is_move)
            golem.anim.SetBool("Is_Walk", true);
        else
            golem.anim.SetBool("Is_Walk", false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)move_background.position;

        value = Vector2.ClampMagnitude(value, radius);
        move.localPosition = value;
        float distance = Vector2.Distance(move_background.position, move.position) / radius;
        value = value.normalized;
        movePositon = new Vector3(value.x * golem.golem_speed * Time.deltaTime * distance, value.y * golem.golem_speed * Time.deltaTime * distance, 0f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        is_move = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        is_move = false;
        move.localPosition = Vector3.zero;
        movePositon = Vector3.zero;
    }
}
