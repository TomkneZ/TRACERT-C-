﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRACEROUT
{
    class ICMP
    {
        public byte Type;
        public byte Code;
        public UInt16 Checksum;
        public int MessageSize;
        public byte[] Message = new byte[1024];

        public ICMP()
        {
        }

        public ICMP(byte[] data, int size)
        {
            Type = data[20];
            Code = data[21];
            Checksum = BitConverter.ToUInt16(data, 22);
            MessageSize = size - 24;
            Buffer.BlockCopy(data, 24, Message, 0, MessageSize);
        }

        public byte[] getBytes()
        {
            byte[] data = new byte[MessageSize + 9];
            Buffer.BlockCopy(BitConverter.GetBytes(Type), 0, data, 0, 1);
            Buffer.BlockCopy(BitConverter.GetBytes(Code), 0, data, 1, 1);
            Buffer.BlockCopy(BitConverter.GetBytes(Checksum), 0, data, 2, 2);
            Buffer.BlockCopy(Message, 0, data, 4, MessageSize);
            return data;
        }

        public UInt16 getChecksum()
        {
            //The checksum is the 16 - bit ones's complement of the one's
            //complement sum of the ICMP message starting with the ICMP Type.
            //For computing the checksum, the checksum field should be zero.
            //If the total length is odd, the received data is padded with one
            //octet of zeros for computing the checksum.This checksum may be
            //replaced in the future.
            UInt32 chcksm = 0;
            byte[] data = getBytes();
            int packetsize = MessageSize + 8;    //76     
            int index = 0;
            while (index < packetsize)
            {
                chcksm += Convert.ToUInt32(BitConverter.ToUInt16(data, index));
                index += 2;
            }
            chcksm = (chcksm >> 16) + (chcksm & 0xffff);
            chcksm += (chcksm >> 16);
            return (UInt16)(~chcksm);
        }
    }

}
