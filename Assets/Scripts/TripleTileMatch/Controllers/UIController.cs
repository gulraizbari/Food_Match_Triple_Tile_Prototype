using TripleTileMatch.Interfaces;
using UnityEngine;

namespace TripleTileMatch.Controllers
{
    public class UIController : BaseMenuModule, IUIController
    {
        public IUIView UIViewHandler { get; set; }

        public override void Initialize()
        {
            base.Initialize();
            Debug.Log("UI Controller has been initialized!");
            UIViewHandler.InitializeView();
        }

    }
}
