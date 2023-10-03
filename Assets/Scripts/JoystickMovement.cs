using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMovement : MonoBehaviour
{

  public GameObject joystick;
  public GameObject joystickBg;
  public Vector2 joystickVector;
  private Vector2 joystickTouchPos;
  private Vector2 joystickOriginalPos;
  private float joystickRadius;


  // Start is called before the first frame update
  void Start()
  {
    joystickOriginalPos = joystickBg.transform.position;
    joystickRadius = joystickBg.GetComponent<RectTransform>().sizeDelta.y / 4;
  }

  public void PointerDown()
  {
    Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mouse.z = 0;
    joystickBg.transform.position = mouse;
    joystick.transform.position = mouse;
    joystickTouchPos = mouse;
  }

  public void Drag(BaseEventData baseEventData)
  {
    PointerEventData pointerEventData = baseEventData as PointerEventData;
    Vector2 dragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    joystickVector = (dragPos - joystickTouchPos).normalized;

    float joystickDistance = Vector2.Distance(dragPos, joystickTouchPos);

    if (joystickDistance < joystickRadius)
    {
      joystick.transform.position = joystickTouchPos + joystickVector * joystickDistance;
    }
    else
    {
      joystick.transform.position = joystickTouchPos + joystickVector * joystickRadius;
    }
  }

  public void PointerUp()
  {
    joystickVector = Vector2.zero;
    joystickBg.transform.position = joystickOriginalPos;
    joystick.transform.position = joystickOriginalPos;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
