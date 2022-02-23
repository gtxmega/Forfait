using System;


namespace Game.GeneratePoses
{
    public interface IGeneratePose
    {
        event Action<Pose> OnGeneratePose;

        Pose GetCurrentPose();
        void TryGenerateRandomPose();

    }
}