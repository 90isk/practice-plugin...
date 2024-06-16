using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace ContainmentBroacastPlugin
{
    public class ContainmentBroadcast
    {
        private Config config;
        public ContainmentBroadcast(Config config)
        {
            this.config = config;
        }
        public void Broadcast(DiedEventArgs ev)
        {
            if (ev.Player.IsScp == true && ev.Player.Role != RoleTypeId.Scp0492)
            {                
                if (ev.Attacker.IsHuman == true)
                {
                    var a = ev.Player.Role.Name;
                    var b = ev.Attacker.CustomName;
                    string message = string.Format("{0}已被重新收容 , 收容者{1}", a, b);
                    Map.Broadcast((ushort)5f, message);
                }
                else
                {
                    var a = ev.Player.Role.Name;
                    string message = string.Format("{0}已被重新收容 , 它自杀了", a);
                    Map.Broadcast((ushort)5f, message);
                }
            }    
        }
    }
}
