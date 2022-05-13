using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
//using TMPro.EditorUtilities;
using UnityEngine.UI;

public class DynamicJoystick : Joystick
{
    PointerEventData eventData;
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

    [SerializeField] private float moveThreshold = 1;
    Vector3 inicPos;
    protected override void Start()
    {
        MoveThreshold = moveThreshold;
        base.Start();
        background.gameObject.SetActive(true);
        inicPos = background.transform.position;
    }

    void Update() {
        if (background.transform.position.x >= Screen.width) {
            background.transform.position = new Vector3(Screen.width, background.transform.position.y, background.transform.position.z); 
        }
    }


    public override void OnPointerDown(PointerEventData eventData)
    {
        if (background.transform.position.x > Screen.width)
        {
            OnPointerUp(eventData);
        }
        else {
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log(background.anchoredPosition.x);
        base.OnPointerUp(eventData);
        background.transform.position = inicPos;
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > moveThreshold)
        {
            Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
            background.anchoredPosition += difference;
        }
        base.HandleInput(magnitude, normalised, radius, cam);
    }
}