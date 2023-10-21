using System;
using DG.Tweening;
using UnityEngine;

namespace _Code.Traps
{
    public class MovingBetweenTwoPoints : MonoBehaviour
    {
        [SerializeField] private Transform transformToMove;
        [SerializeField] private Transform firstPoint;
        [SerializeField] private Transform secondPoint;
        [SerializeField] private float speed = 5;
        [SerializeField] private bool moveOnStart = true;

        private Tween _currentTween;
        private Transform _currentPoint;

        private void Start()
        {
            _currentPoint = firstPoint;
            if (moveOnStart)
            {
                MoveToNextPointLoop();
            }
        }

        public void MoveToNextPointLoop()
        {
            //Проверка на активность твина
            if (_currentTween is {active: true}) _currentTween.Kill();

            //Движение к текущей точке по скорости
            var distance = Vector3.Distance(transformToMove.position, _currentPoint.position);
            var duration = (distance / speed);
            _currentTween = transformToMove.DOMove(_currentPoint.position, duration).SetEase(Ease.OutSine);

            //Выставление следующей точки (к которой будем производить движение)
            if (_currentPoint == firstPoint)
            {
                _currentPoint = secondPoint;
            }
            else
            {
                _currentPoint = firstPoint;
            }

            //Движение к следующей точке по завершению твина (луп)
            _currentTween.onComplete = (() => MoveToNextPointLoop());
        }

        public void MoveToNextPointOneTime()
        {
            //Проверка на активность твина
            if (_currentTween is {active: true}) _currentTween.Kill();

            //Движение к текущей точке по скорости
            var distance = Vector3.Distance(transformToMove.position, _currentPoint.position);
            var duration = (distance / speed);
            _currentTween = transformToMove.DOMove(_currentPoint.position, duration).SetEase(Ease.OutSine);

            //Выставление следующей точки (к которой будем производить движение)
            if (_currentPoint == firstPoint)
            {
                _currentPoint = secondPoint;
            }
            else
            {
                _currentPoint = firstPoint;
            }
        }

        public void RotateOneTimeWithoutLoop(bool state)
        {
            //Проверка на активность твина
            if (_currentTween is {active: true}) _currentTween.Kill();

            //Выбор текущего состояния
            if (state)
            {
                _currentPoint = firstPoint;
            }
            else
            {
                _currentPoint = secondPoint;
            }

            //Движение к текущей точке по скорости
            var distance = Vector3.Distance(transformToMove.position, _currentPoint.position);
            var duration = (distance / speed);
            _currentTween = transformToMove.DOMove(_currentPoint.position, duration).SetEase(Ease.OutSine);
        }

        public void StopTween()
        {
            if (_currentTween is {active: true}) _currentTween.Kill();
        }
    }
}