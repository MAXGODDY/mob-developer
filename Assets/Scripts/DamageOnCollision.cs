using Game;
using UnityEngine;
using VContainer;
using VContainer.Unity;


[RequireComponent(typeof(TreeMemory))]
public class DamageOnCollision : MonoBehaviour
{
    private DeathUIController _deathUIController;
    private StartLobiControler _startLobiControler;

    [Inject]
    public void Construct(DeathUIController deathUIController, StartLobiControler startLobiControler)
    {
        Debug.Log("[DI] Construct вызван");
        _deathUIController = deathUIController;
        _startLobiControler = startLobiControler;
    }

    private void Awake()
    {
        var container = LifetimeScope.Find<LifetimeScope>();
        var resolver = container.Container.Resolve<IObjectResolver>();
        resolver.Inject(this);
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(PlayerController.PlayerTag))
        {
            GetComponent<TreeMemory>()?.Remember();

            collision.collider.GetComponentInParent<PlayerController>()?.HandleDeath();
            _deathUIController.ShowDeathUI();
            _startLobiControler._mainCanvas.SetActive(false);
        }
    }
}
