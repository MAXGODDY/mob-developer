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
    [SerializeField]
    StartLobiControler StartLobiControler;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(PlayerController);
        builder.RegisterComponent(DeathUIController);
        builder.RegisterComponent(StartLobiControler);
    }
}
