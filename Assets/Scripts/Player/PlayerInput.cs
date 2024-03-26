using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        private List<IInputs> _inputs;


        private void Update()
        {
            DefineMoveInput();
        }

        public void AddTiger(IInputs input)
        {
            if (_inputs == null)
                _inputs = new List<IInputs>();
            _inputs.Add(input);
        }

        private void DefineMoveInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PressTap();
            }
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                PressTap();
            }
        }

        private void PressTap()
        {
            foreach (var input in _inputs)
            {
                input.OnPlayerTap();
            }
        }
    }
}