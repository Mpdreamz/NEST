﻿using System;

namespace Profiling.Indexing
{
    public class Message
    {
        public Guid Id { get; set; }

        public DateTime Timestamp { get; set; }
        public string Body { get; set; }
    }
}
