using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PomodoroMono : MonoBehaviour
{
    [SerializeField] private TMP_Text pomodoroNameText;
    [SerializeField] private TMP_Text pomodoroCancelledText;
    [SerializeField] private TMP_Text pomodoroFinishedText;
    [SerializeField] private TMP_Text continueButtonText;
    PomodoroObject pomodoroObject = null;
    public void CreatePomodoro(string name)
    {
        if (pomodoroObject == null)
            pomodoroObject = new PomodoroObject(name);
    }
    public void StartPomodoro()
    {
        pomodoroObject.Start();
    }
    public void PausePomodoro()
    {
        pomodoroObject.Pause();
        continueButtonText.text = "Reanudar";

    }
    public void CancelPomodoro()
    {
        pomodoroObject.CancelPomodoro();
        pomodoroCancelledText.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        pomodoroCancelledText.gameObject.SetActive(false);
        pomodoroFinishedText.gameObject.SetActive(false);
    }
    public string getPomodoroText()
    {
        return "Nombre: "+pomodoroObject.Name+", Tiempo restante: "+((int)pomodoroObject.TimeLeft)+", Tiempo pausado: "+((int)pomodoroObject.PausedTime);
    }

    // Update is called once per frame
    void Update()
    {
        pomodoroObject.Tick(Time.deltaTime);
        if (pomodoroObject.Finished)
        {
            ShowFinished();
        }
        pomodoroNameText.text = getPomodoroText();
    }

    private void ShowFinished()
    {
        pomodoroFinishedText.gameObject.SetActive(true);
    }
}
