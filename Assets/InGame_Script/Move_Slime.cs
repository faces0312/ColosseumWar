using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move_Slime : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform move_background;
    public RectTransform move;

    private float radius;

    //캐릭터 조합
    public Slime_In slime;

    private bool is_move = false;
    private Vector3 movePositon;

    private void Start()
    {
        if (slime.gameObject.activeSelf == false)
        {
            slime.now_hp.gameObject.SetActive(false);
            slime.total_hp.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            slime.now_hp.gameObject.SetActive(true);
            slime.total_hp.gameObject.SetActive(true);
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
            slime.transform.localScale = scale * 5;
        }
        else if (move.anchoredPosition.x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= 1;
            slime.transform.localScale = scale * 5;
        }


        if (is_move)
            slime.transform.position += movePositon;

        if (is_move)
            slime.anim.SetBool("Is_Walk", true);
        else
            slime.anim.SetBool("Is_Walk", false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)move_background.position;

        value = Vector2.ClampMagnitude(value, radius);
        move.localPosition = value;
        float distance = Vector2.Distance(move_background.position, move.position) / radius;
        value = value.normalized;
        movePositon = new Vector3(value.x * slime.slime_speed * Time.deltaTime * distance, value.y * slime.slime_speed * Time.deltaTime * distance, 0f);
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
