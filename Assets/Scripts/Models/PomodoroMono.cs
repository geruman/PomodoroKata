using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PomodoroMono : MonoBehaviour
{
    [SerializeField] private TMP_Text pomodoroNameText;
    [SerializeField] private TMP_Text pomodoroCancelledText;
    [SerializeField] private TMP_Text pomodoroFinishedText;
    private string _name;
    private double _timeleft = 25d;
    private double _timepaused = 0d;
    private bool _running = false;
    private bool _paused = false;
    private bool _cancelled = false;
    private bool _finished = false;
    public void SetName(string name)
    {
        _name = name;
    }
    public void StartPomodoro()
    {
        if (!_cancelled&&!_finished)
        {
            _running = true;
            _paused = false;
        }
    }
    public void PausePomodoro()
    {
        if (!_cancelled&& !_finished)
            _paused = true;
    }
    public void CancelPomodoro()
    {
        if (!_cancelled && !_finished)
        {
            _cancelled = true;
            _running = false;
            _paused = false;
            pomodoroCancelledText.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pomodoroCancelledText.gameObject.SetActive(false);
        pomodoroFinishedText.gameObject.SetActive(false);
    }
    public string getPomodoroText()
    {
        return "Nombre: "+_name+", Tiempo restante: "+((int)_timeleft)+", Tiempo pausado: "+((int)_timepaused);
    }

    // Update is called once per frame
    void Update()
    {
        if (_running&&!_paused)
        {
            _timeleft = _timeleft - Time.deltaTime;
            if (_timeleft<=0)
            {
                _running = false;
                _finished = true;
                ShowFinished();
            }

        }
        else if (_paused)
        {
            _timepaused = _timepaused + Time.deltaTime;
        }
        pomodoroNameText.text = getPomodoroText();
    }

    private void ShowFinished()
    {
        pomodoroFinishedText.gameObject.SetActive(true);
    }
}
