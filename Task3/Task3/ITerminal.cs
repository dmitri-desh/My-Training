﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public interface ITerminal :IShouldClearEventHandlers
    {
        PhoneNumber Number { get; }
        /// <summary>
        /// fires when the terminal try to connect to station
        /// </summary>
        event EventHandler<Request> OutgoingConnection;

        /// <summary>
        /// fires when station try to connect to terminal
        /// </summary>
        event EventHandler<IncomingCallRequest> IncomingRequest;

        /// <summary>
        /// fires when terminal send respond to the station
        /// </summary>
        event EventHandler<Respond> IncomingRespond;

        /// <summary>
        /// fires when terminal is going to call mode
        /// </summary>
        event EventHandler Online;

        /// <summary>
        /// fires when the connection is interrupted
        /// </summary>
        event EventHandler Offline;

        void Call(PhoneNumber target);
        void IncomingRequestFrom(PhoneNumber source);
        void Drop();
        void Answer();
        void Plug();
        void Unplug();

        /// <summary>
        /// fires when user plug the device
        /// </summary>
        event EventHandler Plugging;

        /// <summary>
        /// fires when user unplug the device
        /// </summary>
        event EventHandler UnPlugging;

        void RegisterEventHandlersForPort(IPort port);
    }
}