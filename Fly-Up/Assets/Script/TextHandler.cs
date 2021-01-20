using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHandler : MonoBehaviour
{

    private RectTransform _mainText_Transform;

    InputManager _inputManager;

    private void Start()
    {
       _inputManager =  GameObject.Find("Manager").GetComponent<InputManager>();

        
        _mainText_Transform = this.GetComponent<RectTransform>();
        

        if (_inputManager == null)
            Debug.Log(" InputManager is null");
        if (_mainText_Transform == null)
            Debug.Log(" RectTransfrom -> Maintext is null");
    }

    private void Update()
    {
        if(_inputManager.shouldMove)
        {
            moveText(_inputManager.direction);
        }
    }

    void moveText(int direction)
    {
        _mainText_Transform.localPosition = Vector3.Lerp(_mainText_Transform.localPosition, new Vector3(0, Screen.height * direction, 0), 5 * Time.deltaTime);
        if (_mainText_Transform.localPosition.y >= Screen.height) _inputManager.shouldMove = false;
    }

    void resetText()
    {
        _mainText_Transform.localPosition = Vector3.zero;
    }

    void changeText(string text)
    {
        this.GetComponent<TextMeshProUGUI>().text = text;
    }
}
