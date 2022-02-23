using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Events;

using Random = System.Random;

namespace Game.GeneratePoses
{
    public class GeneratePose : MonoBehaviour, IGeneratePose
    {
        [Header("Unity events")]
        public UnityEvent EventGeneratePose = new UnityEvent();

        public event Action<Pose> OnGeneratePose;


        [Header("Poses list")]
        [SerializeField] private Pose[] _poses;


        private Pose _currentPose;

        private Random _randomizer;
        private Coroutine _generateRandomPoseCoroutine;

        public void TryGenerateRandomPose()
        {
            var countPoses = _poses.Length;

            if (countPoses == 0) return;

            if (_randomizer == null)
                _randomizer = new Random();

            if(_generateRandomPoseCoroutine == null)
                _generateRandomPoseCoroutine = StartCoroutine(GenerateRandomPose(countPoses));
        }

        private IEnumerator GenerateRandomPose(int countPoses)
        {
            int randomIndex = 0;

            do
            {
                randomIndex = _randomizer.Next(0, countPoses);
                yield return null;

            } while (_currentPose != null && _currentPose.Equals(_poses[randomIndex]));

            _currentPose = _poses[randomIndex];

            OnGeneratePose?.Invoke(_currentPose);
            EventGeneratePose?.Invoke();

            _generateRandomPoseCoroutine = null;
        }

        public Pose GetCurrentPose()
        {
            return _currentPose;
        }


        private void ClearEventsListeners()
        {
            OnGeneratePose = null;
            EventGeneratePose.RemoveAllListeners();
        }

        private void OnDestroy()
        {
            ClearEventsListeners();
        }
    }
}