using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour 
    {
        [SerializeField] private PlayerAnimation playerAnimation;
        [SerializeField] private Joystick joystick;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float angularSpeed;
        private float _speed;
        public float Speed { get { return _speed; } }

        private const float FaceAngleTolerance = 30f;
        

        
        private void Update()
        {
            MoveInput();
            HandleAnimations();
        }
        void HandleAnimations() {
            if (_speed > 0f) {
                playerAnimation.Run(true);
            }
            else {
                playerAnimation.Run(false);
            }
        }

        void MoveInput() {
            var direction=joystick.Direction;
            var norMagnitude = direction.magnitude;
            float targetSpeed;
            if (Mathf.Approximately(direction.magnitude, 0))
            {
                targetSpeed = 0;
            }
            else
            {
                var targetForward = new Vector3(direction.x, 0, direction.y);
                var targetRot = Quaternion.LookRotation(targetForward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    targetRot, angularSpeed * Time.deltaTime);

                if (Quaternion.Angle(transform.rotation, targetRot) > FaceAngleTolerance)
                {
                    targetSpeed = 0;
                }
                else
                {
                    targetSpeed = norMagnitude * maxSpeed;
                }
            }

            _speed = Mathf.MoveTowards(_speed, targetSpeed, acceleration * Time.deltaTime);
            _controller.Move(transform.forward * (_speed * Time.deltaTime) + Physics.gravity * Time.deltaTime);
        }
    }
}