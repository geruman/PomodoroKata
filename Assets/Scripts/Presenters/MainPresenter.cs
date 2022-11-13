using System;

public class MainPresenter
{
    private IAddPomodoroView _pomodoroView;

    public MainPresenter(IAddPomodoroView apomodoroView)
    {
        _pomodoroView=apomodoroView;

    }

    public void CreatePomodoro(string pomodoroName)
    {
        _pomodoroView.AddPomodoroPrefab(pomodoroName);
    }
}