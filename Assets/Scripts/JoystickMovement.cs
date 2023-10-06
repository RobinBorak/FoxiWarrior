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
    Vector2 mouse = Camera.main.ScreenToWorldPoint(getLeftTouchIndex());
    joystickBg.transform.position = mouse;
    joystick.transform.position = mouse;
    joystickTouchPos = mouse;
  }



  public void Drag(BaseEventData baseEventData)
  {
    Vector2 dragPos = Camera.main.ScreenToWorldPoint(getLeftTouchIndex());

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
  Vector3 getLeftTouchIndex()
  {
    int touchesLength = Input.touches.Length;
    if(touchesLength < 2){
      return Input.mousePosition;
    }
    int leftTouchIndex = -1;
    for (int i = 0; i < Input.touches.Length; i++)
    {
      if (Input.touches[i].position.x < Screen.width / 2)
      {
        leftTouchIndex = i;
      }
    }
    return Input.touches[leftTouchIndex].position;
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
