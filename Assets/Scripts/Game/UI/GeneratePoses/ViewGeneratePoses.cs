using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Game.GeneratePoses;
using Pose = Game.GeneratePoses.Pose;

using Zenject;

namespace Game.UI.GeneratePoses
{
    public class ViewGeneratePoses : MonoBehaviour
    {
        [SerializeField] private Canvas _cubePosesCanvas;
        [SerializeField] private Image _randomPoseImageSlot;
        [SerializeField] private Text _textPoseName;

        IGeneratePose _generatePose;


        [Inject]
        private void Cunstruct(IGeneratePose generatePose)
        {
            _generatePose = generatePose;
        }


        private void Start()
        {
            _generatePose.OnGeneratePose += ResponseGeneratePose;
        }
        public void ShowCubePosesCanvas()
        {
            _cubePosesCanvas.enabled = true;
        }

        public void GeneratePose()
        {
            _generatePose.TryGenerateRandomPose();
        }


        private void ResponseGeneratePose(Pose pose)
        {
            SetSpriteToPoseImage(pose.SpriteView);
            SetPoseName(pose.PoseName);
        }

        private void SetSpriteToPoseImage(Sprite sprite)
        {
            _randomPoseImageSlot.sprite = sprite;
        }

        private void SetPoseName(string poseName)
        {
            _textPoseName.text = poseName;
        }


    }
}