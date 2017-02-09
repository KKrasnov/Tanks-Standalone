using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor.Bullet;
using TanksTest.Core.Actor.Tank;
using TanksTest.Core.Actor.Tank.Factory;
using TanksTest.Core.Camera;

using TanksTest.PlayerInput;

namespace TanksTest.Core.Player
{
    public class PlayerController : IPlayerController
    {
        private readonly BaseTankFactory _tankFactory;

        private readonly BaseCameraController _cameraController;

        private BaseTank _playerTank;

        public event Action<int, int> OnPlayerObjectHealthChangedEvent;

        public PlayerController(BaseTankFactory tankFactory, BaseCameraController cameraController)
        {
            if (tankFactory == null)
                throw new ArgumentNullException("tankFactory");

            _tankFactory = tankFactory;


            if (cameraController == null)
                throw new ArgumentNullException("cameraController");

            _cameraController = cameraController;
        }

        public void Init()
        {

        }

        public void StartGameProccess()
        {
            _playerTank = _tankFactory.CreateObject();
            _cameraController.ObservedActor = _playerTank;

            _playerTank.OnDamageTakenEvent += OnTankHealthPointsChangedHandler;
            _playerTank.OnHealTakenEvent += OnTankHealthPointsChangedHandler;

            InputService.Instance.OnFireClickEvent += OnFireClickHanldler;

            InputService.Instance.OnMousePositionChangedEvent += OnMousePositionChangedHanlder;

            InputService.Instance.OnMoveForwardClickEvent += OnMoveForwardClickHandler;
            InputService.Instance.OnMoveBackwardClickEvent += OnMoveBackwardClickHandler;

            InputService.Instance.OnTurnLeftClickEvent += OnTurnLeftClickHandler;
            InputService.Instance.OnTurnRightClickEvent += OnTurnRightClickHandler;

            InputService.Instance.OnPrevWeaponClickEvent += OnPrevWeaponClickHandler;
            InputService.Instance.OnNextWeaponClickEvent += OnNextWeaponClickHandler;
        }

        public void StopGameProccess()
        {
            if (_playerTank != null)
            {
                _playerTank.OnDamageTakenEvent -= OnTankHealthPointsChangedHandler;
                _playerTank.OnHealTakenEvent -= OnTankHealthPointsChangedHandler;
                _tankFactory.DestroyObject(_playerTank);
            }

            InputService.Instance.OnFireClickEvent -= OnFireClickHanldler;

            InputService.Instance.OnMousePositionChangedEvent -= OnMousePositionChangedHanlder;

            InputService.Instance.OnMoveForwardClickEvent -= OnMoveForwardClickHandler;
            InputService.Instance.OnMoveBackwardClickEvent -= OnMoveBackwardClickHandler;

            InputService.Instance.OnTurnLeftClickEvent -= OnTurnLeftClickHandler;
            InputService.Instance.OnTurnRightClickEvent -= OnTurnRightClickHandler;

            InputService.Instance.OnPrevWeaponClickEvent -= OnPrevWeaponClickHandler;
            InputService.Instance.OnNextWeaponClickEvent -= OnNextWeaponClickHandler;
        }

        private void OnTankHealthPointsChangedHandler(int amount)
        {
            if (OnPlayerObjectHealthChangedEvent != null)
                OnPlayerObjectHealthChangedEvent(_playerTank.CurrentHealthPoints, _playerTank.MaxHealthPoints);
        }

        private void OnFireClickHanldler()
        {
            _playerTank.Shoot();
        }

        private void OnMoveForwardClickHandler()
        {
            _playerTank.MoveTo(_playerTank.transform.forward);
        }

        private void OnMoveBackwardClickHandler()
        {
            _playerTank.MoveTo(-_playerTank.transform.forward);
        }

        private void OnTurnLeftClickHandler()
        {
            _playerTank.RotateTo(-_playerTank.transform.right);
        }

        private void OnTurnRightClickHandler()
        {
            _playerTank.RotateTo(_playerTank.transform.right);
        }

        private void OnPrevWeaponClickHandler()
        {
            _playerTank.ApplyPrevCannon();
        }

        private void OnNextWeaponClickHandler()
        {
            _playerTank.ApplyNextCannon();
        }

        private void OnMousePositionChangedHanlder(float x, float y)
        {
            var camera = UnityEngine.Camera.main;
            Vector3 worldPosition = camera.ScreenToWorldPoint(new Vector3(x, y, 10));
            _playerTank.RotateTurretTo(worldPosition);
        }
    }
}
