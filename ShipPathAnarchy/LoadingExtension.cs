using FloatThroughCanals.Detours;
using FloatThroughCanals.Redirection;
using ICities;

namespace FloatThroughCanals
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnCreated(ILoading loading)
        {
            base.OnCreated(loading);
            Redirector<NetAIDetour>.Deploy();
            Redirector<ShipPathAIDetour>.Deploy();
        }

        public override void OnReleased()
        {
            base.OnReleased();
            Redirector<NetAIDetour>.Revert();
            Redirector<ShipPathAIDetour>.Revert();
        }
    }
}