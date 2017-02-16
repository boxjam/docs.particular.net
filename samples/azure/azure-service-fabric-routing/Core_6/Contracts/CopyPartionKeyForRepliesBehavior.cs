﻿using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Pipeline;
using NServiceBus.Transport;

namespace Contracts
{
    class CopyPartionKeyForRepliesBehavior : IBehavior<IOutgoingReplyContext, IOutgoingReplyContext>
    {
        public Task Invoke(IOutgoingReplyContext context, Func<IOutgoingReplyContext, Task> next)
        {
            IncomingMessage message;
            string partitionKey;
            if (context.Extensions.TryGet(out message) &&
                message.Headers.TryGetValue(PartitionHeaders.OriginatorPartitionKey, out partitionKey))
            {
                context.Headers[PartitionHeaders.PartitionKey] = partitionKey;
            }

            return next(context);
        }
    }
}