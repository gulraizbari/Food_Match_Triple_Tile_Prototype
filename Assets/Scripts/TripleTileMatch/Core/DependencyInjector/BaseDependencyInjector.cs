using UnityEngine;

namespace TripleTileMatch.Core.DependencyInjector
{
    public class BaseDependencyInjector : MonoBehaviour
    {
        private void Awake()
        {
            InjectDependencies();
        }

        public virtual void InjectDependencies()
        {
            
        }
    }
}

