﻿using BlubLib.Serialization;
using MuEmu.Network.Serializers;
using System;
using System.Collections.Generic;
using System.Text;
using WebZen.Serialization;
using WebZen.Util;

namespace MuEmu.Network.Auth
{
    [WZContract]
    public class CIDAndPass : IAuthMessage
    {
        [WZMember(0, 10)]
        public byte[] btAccount { get; set; }

        [WZMember(1, 10)]
        public byte[] btPassword { get; set; }

        [WZMember(2)]
        public uint TickCount { get; set; }

        [WZMember(3)]
        public ushort Padding { get; set; }

        [WZMember(4, 5)]
        public byte[] btClientVersion { get; set; }

        [WZMember(5, 16)]
        public byte[] btClientSerial { get; set; }

        public string Account => btAccount.MakeString();
        public string Password => btPassword.MakeString();
        public string ClientVersion => btClientVersion.MakeString();
        public string ClientSerial => btClientSerial.MakeString();
    }

    [WZContract]
    public class CIDAndPassS12 : IAuthMessage
    {
        [WZMember(0, 10)]
        public byte[] btAccount { get; set; }

        [WZMember(1, 20)]
        public byte[] btPassword { get; set; }

        /*[WZMember(2, 100)]
        public byte[] btHWID { get; set; }*/

        [WZMember(3)]
        public uint TickCount { get; set; }

        /*[WZMember(3)]
        public ushort Padding { get; set; }*/

        [WZMember(4, 5)]
        public byte[] btClientVersion { get; set; }

        [WZMember(5, 16)]
        public byte[] btClientSerial { get; set; }

        /*[WZMember(6)]
        public byte ServerSeason { get; set; }*/

        public string Account => btAccount.MakeString();
        public string Password => btPassword.MakeString();
        public string ClientVersion => btClientVersion.MakeString();
        public string ClientSerial => btClientSerial.MakeString();
        //public string HardwareID => btHWID.MakeString();
    }

    [WZContract]
    public class CCharacterList : IAuthMessage
    { }

    [WZContract]
    public class CCharacterCreate : IAuthMessage
    {
        [WZMember(0, 10)]
        public byte[] btName { get; set; }

        [WZMember(1)]
        public HeroClass Class { get; set; }

        public string Name => btName.MakeString();
    }

    [WZContract]
    public class CCharacterDelete : IAuthMessage
    {
        [WZMember(0, 10)]
        public byte[] btName { get; set; }
        public string Name => btName.MakeString();

        [WZMember(0, 10)]
        public byte[] JoominNumber { get; set; }
    }

    [WZContract]
    public class CCharacterMapJoin : IAuthMessage
    {
        [WZMember(0,10)]
        public byte[] btName { get; set; }

        public string Name => btName.MakeString();
    }

    [WZContract]
    public class CCharacterMapJoin2 : IAuthMessage
    {
        [WZMember(0, 10)]
        public byte[] Name { get; set; }
    }

    [WZContract]
    public class CServerMove : IAuthMessage
    {
        [WZMember(0, 12)] public byte[] btAccount { get; set; }
        [WZMember(1, 12)] public byte[] Character { get; set; }
        [WZMember(2)] public uint AuthCode1 { get; set; }
        [WZMember(3)] public uint AuthCode2 { get; set; }
        [WZMember(4)] public uint AuthCode3 { get; set; }
        [WZMember(5)] public uint AuthCode4 { get; set; }
        [WZMember(6)] public uint TickCount { get; set; }
        [WZMember(7, 5)] public byte[] btClientVersion { get; set; }
        [WZMember(8, 16)] public byte[] btClientSerial { get; set; }

        public string ClientVersion => btClientVersion.MakeString();
        public string ClientSerial => btClientSerial.MakeString();
        public string Account => btAccount.MakeString();
    }
}
