using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UniRx.Triggers;

public class UniRXDeneme : MonoBehaviour
{
    private void Awake()
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.UpdateAsObservable()
            .Where(s => Time.time < 3f)
            .Subscribe(x => Debug.Log("cube"), () => Debug.Log("destroy"));

    }
}
