using System.ComponentModel;
using UnityEngine;
using Zenject;

public class BallInstaller : MonoInstaller
{
    [SerializeField] private BallView ballView;
    [SerializeField] private int _ballInitialHealth = 10;

    public override void InstallBindings()
    {
        Container.Bind<BallView>().FromInstance(ballView).AsSingle();
        Container.QueueForInject(ballView);
        var ballModel = new BallModel(_ballInitialHealth);
        Container.Bind<BallModel>().FromInstance(ballModel).AsSingle();
        BallPresenter ballPresenter = new BallPresenter(ballView, ballModel);
        Container.Bind<BallPresenter>().FromInstance(ballPresenter).AsSingle();
    }
}