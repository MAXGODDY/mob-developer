using MoreMountains.Feedbacks;
using UnityEngine;

public class GameFeedbackManager : MonoBehaviour
{
    [SerializeField] private MMF_Player coinTextFeedbacks;

    public void PlayCoinTextFeedbacks()
    {
        coinTextFeedbacks.PlayFeedbacks();
    }

}
