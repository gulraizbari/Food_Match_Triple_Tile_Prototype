
using TripleTileMatch.Core;

namespace TripleTileMatch.Interfaces
{
    public interface IGameFlowController
    {
        public void LoadModules();
        
        public void InitializeModule(BaseMenuModule module);
    }
}
