using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move_reaper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]private RectTransform move_background;
    [SerializeField] private RectTransform move;
    private float radius;

    //Ä³¸¯ÅÍ Á¶ÇÕ
    public Reaper reaper;//½ºÄÌ·¹Åæ

    private bool is_move = false;
    public Vector2 movePositon;

    private void Start()
    {
        if (reaper.gameObject.activeSelf == false)
        {
            reaper.now_hp.gameObject.SetActive(false);
            reaper.total_hp.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            reaper.now_hp.gameObject.SetActive(true);
            reaper.total_hp.gameObject.SetActive(true);
            gameObject.SetActive(true);
        }


        radius = move_background.rect.width * 0.5f;
    }

    private void Update()
    {
        if (is_move)
            reaper.transform.position += (Vector3)movePositon;

        if (move.anchoredPosition.x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            reaper.transform.localScale = scale * 4;
        }
        else if (move.anchoredPosition.x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= 1;
            reaper.transform.localScale = scale * 4;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)move_background.position;

        value = Vector2.ClampMagnitude(value, radius);
        move.localPosition = value;
        value = value.normalized;
        float distance = Vector2.Distance(move_background.position, move.position) / radius;
        movePositon = new Vector3(value.x * reaper.reaper_speed * Time.deltaTime * distance, value.y * reaper.reaper_speed * Time.deltaTime * distance, 0f);
        
        
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
