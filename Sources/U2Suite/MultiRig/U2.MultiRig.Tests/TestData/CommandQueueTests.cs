/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

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
