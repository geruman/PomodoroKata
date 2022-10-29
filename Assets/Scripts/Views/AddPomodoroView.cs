using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddPomodoroView : MonoBehaviour
{
    public Button createPomodoro;
    public GameObject pomodoroPanel;
    public GameObject existingPomodoros;
    // Start is called before the first frame update
    void Start()
    {
        createPomodoro.onClick.AddListener(CreatePomodoro);
    }
    void CreatePomodoro()
    {
        Instantiate(pomodoroPanel, existingPomodoros.transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
