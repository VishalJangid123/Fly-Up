using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;


public enum Menu
{
    COUNTDOWN,
    IN_GAME,
    GAME_OVER
}

public class DataHandler : MonoBehaviour
{

    public float timer = 0f;
    public TMP_Text countdown_text;
    public TMP_Text timer_text;
    public GameObject _mainText;

    public List<string> _data;
    public List<int> _movement_data;

    float time_provided = 3f;
    InputManager _inputManager;

    public TextHandler _textHandler;

    private TextMeshProUGUI _main_text;
    public int iterindex = 0;


    public AudioClip click_sound;
    

    [HideInInspector]
    public bool game_over = false;
    public bool isCountdownDone = false;

    float countdown = 3f;

    List<PanelController> _panelController;

    void Start()
    {

        _panelController = FindObjectsOfType<PanelController>().ToList();
        
        foreach(var panel in _panelController)
        {
            panel.gameObject.SetActive(false);

        }

        PanelSwitch(Menu.COUNTDOWN);
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

        // set audioclip to click for countdown to audiosource
        GameManager.instance._audioSource.clip = click_sound;
        StartCoroutine(countDown(countdown));
    }

    IEnumerator countDown(float seconds)
    {
        while(seconds > -1)
        {
            if(seconds == 0) countdown_text.text = "Start";
            else countdown_text.text = seconds.ToString();
            
            GameManager.instance._audioSource.Play();
            countdown_text.gameObject.GetComponent<Lean.Transition.Extras.LeanAnimation>().BeginTransitions();
            yield return new WaitForSeconds(1.0f);
            seconds--;
        }
        isCountdownDone = true;
    }

    void Update()
    {
        if (game_over)
            return;

        if (isCountdownDone == false)
        {
            
        }
        else
        {
            PanelSwitch(Menu.IN_GAME);



            timer -= Time.deltaTime;

            // will provide x sec to user to answer
            if (timer <= 0f)
            {
                //check if user has given some answer or not


                //reset timer
                OnGameOver();
                //timer = time_provided;
                //ChangeText();

            }



            updateTimer(timer);
        }
    }

    void ChangeText()
    {
        iterindex = iterindex + 1;
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
        PanelSwitch(Menu.GAME_OVER);

    }

    public void onRestartButtonClicked()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        game_over = false;
        iterindex = 0;
        isCountdownDone = false;
        StartCoroutine(countDown(countdown));
    }


    public void onMainMenuButtonClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
        game_over = false;
        iterindex = 0;
    }



    void PanelSwitch(Menu menu)
    {
        foreach (var panel in _panelController)
        {
            if (panel._panel == menu)
            {
                panel.gameObject.SetActive(true);
            }
            else
            {
                panel.gameObject.SetActive(false);
            }
        }
    }

}
