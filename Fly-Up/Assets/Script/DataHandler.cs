using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataHandler : MonoBehaviour
{

    public float timer = 0f;
    public TMP_Text timer_text;
    public GameObject _mainText;

    public List<string> _data;
    public List<int> _movement_data;

    float time_provided = 3f;
    InputManager _inputManager;

    private TextMeshProUGUI _main_text;
    private int iterindex = 0;

    void Start()
    {
        timer = time_provided;

        _inputManager = this.GetComponent<InputManager>();
        _main_text = _mainText.GetComponent<TextMeshProUGUI>();

        _data.Add("Kite");
        _movement_data.Add(1);

        _data.Add("Human");
        _movement_data.Add(-1);
        _data.Add("Plane");
        _movement_data.Add(1);
        _data.Add("Fish");
        _movement_data.Add(-1);

        _main_text.text = _data[iterindex];

    }


    void Update()
    {
        timer -= Time.deltaTime;

        // will provide x sec to user to answer
        if( timer <= 0f)
        {
            //reset timer
            timer = time_provided;
            iterindex = iterindex + 1;
            // reset text
            if (iterindex < _data.Count)
            {
                _main_text.text = _data[iterindex];
            }


        }

        updateTimer(timer);
    }

    void updateTimer(float timer_val)
    {
        timer_text.text = Mathf.RoundToInt(timer_val).ToString();
    }
}
