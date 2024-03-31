using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private MainUI mainUI;

    public override void InstallBindings()
    {
        Container.Bind<WordService>().AsSingle();
        Container.BindInterfacesTo<AppStarter>().AsSingle();
        Container.Bind<GameRoundService>().AsSingle();
        Container.Bind<PlayerStatsInfo>().AsSingle();
        Container.Bind<StateMachine>().AsSingle();
        Container.Bind<ResultService>().AsSingle();
        Container.Bind<RoundControllerService>().AsSingle();
        Container.Bind<MainUI>().FromInstance(mainUI).AsSingle();
    }
}
