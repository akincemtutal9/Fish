using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SlowMotion : MonoBehaviour
{
   private float slowMotion = 0.1f;
   private float normalTime = 1.0f;
   private bool doSlowMotion = false;

   [SerializeField] private GameObject player;
   [SerializeField] private Text TextUI;
   private DragLine dragLine;

   private void Start()
   {
      dragLine = GetComponent<DragLine>();
   }

   private void Update()
   {
      if (dragLine.inputForce.magnitude > 0)
      {
         if (doSlowMotion)
         {
            Time.timeScale = normalTime;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            TextUI.text = Time.timeScale.ToString("0");
            doSlowMotion = false;
         }
      }
      else
      {
         if (!doSlowMotion)
         {
            Time.timeScale = slowMotion;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            TextUI.text = Time.timeScale.ToString("0");
            doSlowMotion = true;
         }
      }
   }
}
