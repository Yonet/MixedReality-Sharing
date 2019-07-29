﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.MixedReality.Sharing.Network;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.MixedReality.Sharing.Matchmaking
{
    /// <summary>
    /// Handle to a joined matchmaking room.
    ///
    /// A room is a container for a Mixed Reality shared session, that can be created, advertised and/or joined through a
    /// matchmaking service. A participant joining/leaving a room will also join/leave the corresponding session.
    ///
    /// A process can use this interface to interact with a joined room and to access the corresponding session state.
    /// Instances of this interface are obtained when joining/creating a matchmaking room
    /// through an <see cref="IMatchmakingService"/> or <see cref="IMatchmakingExtendedService"/>. See <see cref="IRoomInfo"/> for the
    /// interface that wraps non-joined rooms.
    ///
    /// The lifetime of a room and the corresponding session is implementation-dependent.
    /// </summary>
    public interface IRoom
    {
        string Id { get; }

        /// <summary>
        /// Current owner of this room. The owner is initially the participant who created the room.
        /// The implementation can choose a new owner if e.g. the current owner is disconnected.
        /// </summary>
        IParticipant Owner { get; }

        /// <summary>
        /// Participants currently in the room.
        /// </summary>
        IEnumerable<IParticipant> Participants { get; }

        IReadOnlyDictionary<string, object> Attributes { get; }

        Task<TSessionType> JoinAsync<TSessionType>(CancellationToken cancellationToken) 
            where TSessionType : class, ISession<TSessionType>;
    }
}