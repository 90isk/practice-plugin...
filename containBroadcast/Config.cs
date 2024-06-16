using Exiled.API.Features;
using Exiled.API.Interfaces;
using System;
using System.ComponentModel;


namespace ContainmentBroacastPlugin
{
    public sealed class Config : IConfig
    {
        [Description("是否启用插件")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
    }
    public class ContainPlugin : Plugin<Config>      
    {
        public override string Author => "123";
        public override string Name => "123";
        public override Version Version => new Version(1, 1, 0);
        private ContainmentBroadcast eh { get; set; }
        public override void OnEnabled()
        {
            base.OnEnabled();
            eh = new ContainmentBroadcast(Config);
            Exiled.Events.Handlers.Player.Died += eh.Broadcast;
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Player.Died -= eh.Broadcast;
            eh = null;
        }
    }
}
