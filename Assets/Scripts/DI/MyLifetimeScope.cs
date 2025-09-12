using Game;
using VContainer;
using VContainer.Unity;
using UnityEngine;

public class MyLifetimeScope : LifetimeScope
{
    [SerializeField]
    PlayerController PlayerController;
    [SerializeField]
    DeathUIController DeathUIController;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(PlayerController);
        builder.RegisterComponent(DeathUIController);
    }
}
