using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticStation
{
    public interface IStation :IShouldClearEventHandlers
    {
        void RegisterEventHandlersForTerminal(ITerminal terminal);
        void RegisterEventHandlersForPort(IPort port);
    }
}