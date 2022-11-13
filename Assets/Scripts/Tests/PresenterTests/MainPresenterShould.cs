using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MainPresenterShould
{
    
    [Test]
    public void CreateApomodoroAndAviewAndSendIt()
    {
        string pomodoroName = "Trabajar en lonja kata";
        IAddPomodoroView apomodoroView = Substitute.For<IAddPomodoroView>();
        MainPresenter mainPresenter = new MainPresenter(apomodoroView);
        mainPresenter.CreatePomodoro(pomodoroName);
        apomodoroView.Received().AddPomodoroPrefab(pomodoroName);
    }

    
}
