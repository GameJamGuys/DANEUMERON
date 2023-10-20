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
        [SerializeField] private float duration = 5;

        private Tween _currentTween;
        private Transform _nextPoint;
        
        private void Start()
        {
            _nextPoint = firstPoint;
            MoveToNextPoint(_nextPoint);
        }

        private void MoveToNextPoint(Transform nextPoint)
        {
            //Проверка на активность твина
            if (_currentTween is {active: true}) DOTween.Kill(_currentTween);

            //Выставление следующей точки (к которой будем производить движение)
            if (_nextPoint == firstPoint)
            {
                _nextPoint = secondPoint;
            }
            else
            {
                _nextPoint = firstPoint;
            }
            
            //Движение к текущей точке и в завершении - движение к следующей
            _currentTween = transformToMove.DOMove(nextPoint.position, duration).SetEase(Ease.OutSine);
            _currentTween.onComplete = (() => MoveToNextPoint(_nextPoint));
        }
    }
}