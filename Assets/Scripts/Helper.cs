using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Helper : MonoBehaviour {
    public static IEnumerator StartAction(UnityAction action, float timeDelay) {
        yield return new WaitForSeconds(timeDelay);
        action();
    }
    public static IEnumerator StartActionRealtimes(UnityAction action, float timeDelay)
    {
        yield return new WaitForSecondsRealtime(timeDelay);
        action();
    }

    public static IEnumerator StartAction(UnityAction action, System.Func<bool> condition) {
        yield return new WaitUntil(condition);
        action();
    }
}