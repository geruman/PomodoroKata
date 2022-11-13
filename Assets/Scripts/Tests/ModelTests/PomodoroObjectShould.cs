using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PomodoroObjectShould
{
    private PomodoroObject pomodoroObject;

    [SetUp]
    public void SetUp()
    {
        //GIVEN
        pomodoroObject = new PomodoroObject("My pomodoro");
    }
    // A Test behaves as an ordinary method
    [Test]
    public void HaveAName()
    {
        //THEN
        Assert.AreEqual("My pomodoro", pomodoroObject.Name);
    }
    [Test]
    public void Tick5Seconds()
    {
        //WHEN
        pomodoroObject.Start();
        pomodoroObject.Tick(5);
        //THEN
        Assert.AreEqual(20d,pomodoroObject.TimeLeft);


    }
    [Test]
    public void NotTick5Seconds()
    {
        //WHEN
        pomodoroObject.Tick(5);
        //THEN
        Assert.AreEqual(25d, pomodoroObject.TimeLeft);

    }
    [Test]
    public void Tick5SecondsAndPause3()
    {
        //WHEN
        pomodoroObject.Start();
        pomodoroObject.Tick(5);
        pomodoroObject.Pause();
        pomodoroObject.Tick(3);
        //THEN
        Assert.AreEqual(20d, pomodoroObject.TimeLeft);
        Assert.AreEqual(3d, pomodoroObject.PausedTime);

    }

}
