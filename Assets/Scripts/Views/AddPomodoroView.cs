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
    // Start is called before the first frame update
    void Start()
    {
        createPomodoro.onClick.AddListener(CreatePomodoro);
        _mainPresenter = new MainPresenter(this);
    }
    void CreatePomodoro()
    {
        if(!newPomodoroName.text.Trim().Equals(""))
            _mainPresenter.CreatePomodoro(newPomodoroName.text);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPomodoroPrefab(string pomodoroName)
    {
        GameObject newPomodoro = Instantiate(pomodoroPanel, existingPomodoros.transform);
        PomodoroMono pomodoroMono = newPomodoro.GetComponent<PomodoroMono>();
        pomodoroMono.SetName(pomodoroName);
        
    }
}
