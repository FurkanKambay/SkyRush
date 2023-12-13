using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Actuators;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Aircraft
{
    public class AircraftPlayer : AircraftAgent
    {
        [Header("Input Bindings")]
        public InputAction pitchInput;
        public InputAction yawInput;
        public InputAction boostInput;
        public InputAction pauseInput;


        /// <summary>
        ///  Calls base Initialize and initializes input
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            pitchInput.Enable();
            yawInput.Enable();
            boostInput.Enable();
            pauseInput.Enable();
        }
        /// <summary>
        ///  Reads player inputs from actionsOut
        /// </summary>
        /// <param name="actionsOut"> An array of floats for OnActionReceived to use </param>
        public override void Heuristic(in ActionBuffers actionsOut)
        {
            // Pitch : 1 == up, 0 == none, -1 == down
            int pitchValue = Mathf.RoundToInt(pitchInput.ReadValue<float>());

            // Yaw : 1 == turn right, 0 == none, -1 == turn left
            int yawnValue = Mathf.RoundToInt(yawInput.ReadValue<float>());

            // Boost : 1 == boost, 0 == no boost
            int boostValue = Mathf.RoundToInt(boostInput.ReadValue<float>());

            // Convert -1 (down) to discrete value 2
            if (pitchValue == -1f) pitchValue = 2;

            // convert -1 (turn left) to discrete value 2
            if (yawnValue == -1f) yawnValue = 2;

            var discreteActionsOut = actionsOut.DiscreteActions;

            // Additional logging for debugging
            if (discreteActionsOut.Length >= 3)
            {
                discreteActionsOut[0] = pitchValue;
                discreteActionsOut[1] = yawnValue;
                discreteActionsOut[2] = boostValue;
            }
            else
            {
                Debug.LogError("Not enough elements in continuousActionsOut array!");
            }
        }

        /// <summary>
        ///  Cleans up the inputs when destroyed
        /// </summary>
        private void OnDestroy()
        {
            pitchInput.Disable();
            yawInput.Disable();
            boostInput.Disable();
            pauseInput.Disable();
        }
    }
}
