using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataHandler : MonoBehaviour
{

    public float timer = 0f;
    public TMP_Text timer_text;
    public GameObject _mainText;
    public GameObject GameOverCanvas;

    public List<string> _data;
    public List<int> _movement_data;

    float time_provided = 10f;
    InputManager _inputManager;

    public TextHandler _textHandler;

    private TextMeshProUGUI _main_text;
    public int iterindex = 0;



    bool game_over = false;

    void Start()
    {

        GameOverCanvas.SetActive(false);

        timer = time_provided;

        _inputManager = this.GetComponent<InputManager>();
        
        _main_text = _mainText.GetComponent<TextMeshProUGUI>();

        //
        _data.Add("Kite");
        _movement_data.Add(1);
        _data.Add("Human");
        _movement_data.Add(-1);
        _data.Add("Plane");
        _movement_data.Add(1);
        _data.Add("Fish");
        _movement_data.Add(-1);

        _data.Add("Kite");
        _movement_data.Add(1);
        _data.Add("Human");
        _movement_data.Add(-1);
        _data.Add("Plane");
        _movement_data.Add(1);
        _data.Add("Fish");
        _movement_data.Add(-1);

        //
        _main_text.text = _data[iterindex];

    }


    void Update()
    {
        if (game_over)
            return;

        timer -= Time.deltaTime;

        // will provide x sec to user to answer
        if( timer <= 0f)
        {
            //reset timer
            timer = time_provided;
            ChangeText();

        }

        

        updateTimer(timer);
    }

    void ChangeText()
    {
        iterindex = iterindex + 1;
        Debug.Log("Change text called");
        // reset text
        if (iterindex < _data.Count)
        {
            _main_text.text = _data[iterindex];
        }
        _textHandler.resetText();

    }

    void updateTimer(float timer_val)
    {
        timer_text.text = Mathf.RoundToInt(timer_val).ToString();
    }

    public void UpKeyPress()
    {
        if (iterindex <= _data.Count &&_movement_data[iterindex] == 1)
        {

            Debug.Log("Up");
            timer = time_provided;
            ChangeText();

        }
        else
        {
            Debug.Log("Wrong up");
            OnGameOver();
        }
    }

    public void DownKeyPress()
    {
        if (iterindex <= _data.Count && _movement_data[iterindex] == -1)
        {

            Debug.Log("Down");
            timer = time_provided;
            ChangeText();
        }
        else
        {
            Debug.Log("Wrong down");
            OnGameOver();
        }
    }

    void OnGameOver()
    {
        game_over = true;
        GameOverCanvas.SetActive(true);

    }

    public void onRestartButtonClicked()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        game_over = false;
        iterindex = 0;
    }
}
