using DG.Tweening;
using UnityEngine;

namespace _Code.Traps
{
    public class RotateObject : MonoBehaviour
    {
        [SerializeField] private Transform transformToRotation;
        [SerializeField] private float duration = 5;
        [SerializeField] private float degree = -90;
        [SerializeField] private bool rotateOnStart = true;

        private Tween _currentTween;
        private float _currentDegree;
        private float _startDegree;

        private void Start()
        {
            _startDegree = transformToRotation.rotation.z;
            _currentDegree = degree;
            if (rotateOnStart)
            {
                RotateLoop();
            }
        }

        public void RotateLoop()
        {
            //Проверка на активность твина
            if (_currentTween is {active: true}) _currentTween.Kill();

            //Поворот по объекту по duration

            //var distance = Vector3.Distance(transformToRotation.position, newPositionObj.transform.position);
            //var duration = (distance / speed);
            _currentTween = transformToRotation.DORotate(new Vector3(0, 0, _currentDegree), duration).SetEase(Ease.OutSine);

            //Выставление следующего градуса
            if (_currentDegree == _startDegree)
            {
                _currentDegree = degree;
            }
            else
            {
                _currentDegree = _startDegree;
            }

            //Движение к следующей точке по завершению твина (луп)
            _currentTween.onComplete = (() => RotateLoop());
        }
        
        public void RotateOneTime()
        {
            //Проверка на активность твина
            if (_currentTween is {active: true}) _currentTween.Kill();

            //Поворот по объекту по скорости

            //var distance = Vector3.Distance(transformToRotation.position, newPositionObj.transform.position);
            //var duration = (distance / speed);
            _currentTween = transformToRotation.DORotate(new Vector3(0, 0, _currentDegree), duration).SetEase(Ease.OutSine);

            //Выставление следующего градуса
            if (_currentDegree == _startDegree)
            {
                _currentDegree = degree;
            }
            else
            {
                _currentDegree = _startDegree;
            }
        }
    }
}