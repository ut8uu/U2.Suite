using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace U2.Logger.Data;

[PrimaryKey(nameof(Id))]
public sealed class LogEntry
{
    public Guid Id { get; set; }

    public DateTime DateTimeOn { get; set; }
    public DateTime DateTimeOff { get; set; }
}
