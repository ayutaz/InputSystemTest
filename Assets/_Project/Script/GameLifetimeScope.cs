using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameView gameView;
        [SerializeField] private PlayerMove playerMove;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(gameView);
            builder.RegisterComponent(playerMove);
            builder.RegisterEntryPoint<GameManager>();
        }
    }
}