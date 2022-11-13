using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddPomodoroView : MonoBehaviour, IAddPomodoroView
{
    public Button createPomodoro;
    public GameObject pomodoroPanel;
    public GameObject existingPomodoros;
    private MainPresenter _mainPresenter;
    [SerializeField]
    private TMP_InputField newPomodoroName;
    
    void Start()
    {
        createPomodoro.onClick.AddListener(CreatePomodoro);
        _mainPresenter = new MainPresenter(this);
    }
    void CreatePomodoro()
    {
        if(!newPomodoroName.text.Trim().Equals(""))
            _mainPresenter.CreatePomodoro(newPomodoroName.text);
        newPomodoroName.text = "";
    }
    

    public void AddPomodoroPrefab(string pomodoroName)
    {
        GameObject newPomodoro = Instantiate(pomodoroPanel, existingPomodoros.transform);
        PomodoroMono pomodoroMono = newPomodoro.GetComponent<PomodoroMono>();
        pomodoroMono.CreatePomodoro(pomodoroName);

    }

}
