using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class PomodoroMonoDeprecatedIntento
{
    public GameObject pomodoroPanel = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PomodoroPanel.prefab");
 
    [UnityTest]
    public IEnumerator DeprecatedIntento()
    {
        GameObject prefab = GameObject.Instantiate(pomodoroPanel);
        PomodoroMono mono = prefab.GetComponent<PomodoroMono>();
        mono.CreatePomodoro("Heraldo");
        mono.StartPomodoro();
        yield return new WaitForSeconds(5);
        mono.PausePomodoro();
        yield return new WaitForSeconds(1);
        Assert.AreEqual("Nombre: Heraldo, Tiempo restante: 19, Tiempo pausado: 1", mono.getPomodoroText());
        yield return null;
    }
}
