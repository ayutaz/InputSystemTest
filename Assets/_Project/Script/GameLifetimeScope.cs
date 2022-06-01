using UnityEngine;
using UnityEngine.InputSystem.UI;
using VContainer;
using VContainer.Unity;

namespace _Project
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameView gameView;
        [SerializeField] private MenuView menuView;
        [SerializeField] private PlayerMessage playerMessage;
        [SerializeField] private PlayerMove playerMove;
        [SerializeField] private SelectObject selectObject;
        [SerializeField] private InputSystemUIInputModule inputModule;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(selectObject);
            builder.RegisterComponent(playerMessage);
            builder.RegisterComponent(inputModule);
            builder.RegisterComponent(menuView);
            builder.RegisterComponent(gameView);
            builder.RegisterComponent(playerMove);
            builder.RegisterEntryPoint<GameManager>();
        }
    }
}