using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Network
{
    class Packet
    {
        public uint PacketId;
        public uint SenderId;
        public byte[] Data;
    }
}
