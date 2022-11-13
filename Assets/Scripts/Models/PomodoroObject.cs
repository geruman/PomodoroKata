using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroObject
{
    public PomodoroObject(string name)
    {
        Name = name;
    }
    public string Name { get;private  set; }
    public double TimeLeft { get; private set; } = 25d;
    public double PausedTime { get; private set; } = 0d;
    public bool Running { get; private set; } = false;
    public bool Paused { get; private set; } = false;
    public bool Cancelled { get; private set; } = false;
    public bool Finished { get; private set; } = false;

    public void Pause()
    {
        if (IsPomodoroEnabled())
            Paused = true;
    }

    public void Start()
    {
        if (IsPomodoroEnabled())
        {
            Running= true;
            Paused = false;
        }
    }

    public void CancelPomodoro()
    {
        if (IsPomodoroEnabled())
        {
            Cancelled = true;
            Running = false;
            Paused = false;
        }
    }

    public void Tick(float deltaTime)
    {
        if (IsPomodoroEnabled()&&Running&&!Paused)
        {
            TimeLeft = TimeLeft - deltaTime;
            if (TimeLeft<=0)
            {
                Running = false;
                Finished = true;

            }

        }else if (Paused)
        {
            PausedTime = PausedTime+ deltaTime;
        }
    }

    private bool IsPomodoroEnabled()
    {
        return (!Cancelled&& !Finished);
    }
}

