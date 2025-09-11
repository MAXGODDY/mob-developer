using Game;
using VContainer;
using VContainer.Unity;
using UnityEngine;

public class MyLifetimeScope : LifetimeScope
{
    [SerializeField] private GameFeedbackManager _gameFeedbackManager;
    [SerializeField] private DeathUIController _damageOnCollision;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<GameFeedbackManager>();
        builder.RegisterComponentInHierarchy<DeathUIController>();
    }
}
