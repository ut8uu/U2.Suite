using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace U2.MultiRig.Tests.TestData
{
    public class CommandQueueTests
    {
        [Fact]
        public void AddCommand()
        {
            var initCommand = new QueueItem {Kind = CommandKind.Init};
            var writeCommand = new QueueItem {Kind = CommandKind.Write};
            var statusCommand = new QueueItem {Kind = CommandKind.Status};

            var queue = new CommandQueue();
            Assert.Empty(queue);
            Assert.Null(queue.CurrentCmd);

            queue.AddBeforeStatusCommands(initCommand);
            Assert.Single(queue);
            Assert.False(queue.HasStatusCommands);
            Assert.NotNull(queue.CurrentCmd);

            queue.AddBeforeStatusCommands(statusCommand);
            Assert.Equal(1, queue.IndexOf(statusCommand));
            Assert.True(queue.HasStatusCommands);

            queue.AddBeforeStatusCommands(writeCommand);
            Assert.Equal(1, queue.IndexOf(writeCommand));
            Assert.Equal(2, queue.IndexOf(statusCommand));
        }
    }
}
