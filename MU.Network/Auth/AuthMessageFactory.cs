﻿using MU.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using WebZen.Network;

namespace MU.Network.Auth
{
    public interface IAuthMessage
    { }

    public class AuthMessageFactory : MessageFactory<CSOpCode, IAuthMessage>
    {
        public AuthMessageFactory(ServerSeason Season)
        {
            Register<CIDAndPassS12>(CSOpCode.Login);
            Register<SLoginResult>(CSOpCode.Login);
            switch (Season)
            {
                default:
                    ChangeType<CIDAndPass>(CSOpCode.Login, typeof(CIDAndPassS12));
                    break;
                case ServerSeason.Season17Kor:
                    ChangeOPCode<CIDAndPassS12>(CSOpCode.LoginS17Kor);
                    //ChangeOPCode<SLoginResult>(CSOpCode.LoginS17Kor);
                    break;
                case ServerSeason.Season16Kor:
                case ServerSeason.Season12Eng:
                    Register<SResets>(CSOpCode.Resets);
                    break;
                case ServerSeason.Season9Eng:
                    //Register<CIDAndPassS12>(CSOpCode.Login);
                    Register<SResets>(CSOpCode.Resets);
                    Register<SResetCharList>(CSOpCode.ResetList);
                    break;
            }

            Register<CServerList>(CSOpCode.ChannelList);
            Register<SServerList>(CSOpCode.ChannelList);
            Register<SEnableCreation>(CSOpCode.EnableCreate);
            Register<CCharacterList>(CSOpCode.CharacterList);
            Register<CCharacterCreate>(CSOpCode.CharacterCreate);
            Register<CCharacterDelete>(CSOpCode.CharacterDelete);
            Register<CCharacterMapJoin>(CSOpCode.JoinMap);
            Register<CCharacterMapJoin2>(CSOpCode.JoinMap2);
            Register<CServerMove>(CSOpCode.ServerMoveAuth);

            // S2C
            Register<SJoinResult>(CSOpCode.JoinResult);
            Register<SJoinResultS16Kor>(CSOpCode.JoinResult);
            VersionSelector.Register<SJoinResult>(ServerSeason.Season6Kor, CSOpCode.JoinResult);
            VersionSelector.Register<SJoinResultS16Kor>(ServerSeason.Season16Kor, CSOpCode.JoinResult);

            VersionSelector.Register<SCharacterList>(ServerSeason.Season6Kor, CSOpCode.CharacterList);
            VersionSelector.Register<SCharacterListS9>(ServerSeason.Season9Eng, CSOpCode.CharacterList);
            VersionSelector.Register<SCharacterListS12>(ServerSeason.Season12Eng, CSOpCode.CharacterList);
            VersionSelector.Register<SCharacterListS16Kor>(ServerSeason.Season16Kor, CSOpCode.CharacterList);

            Register<SCharacterList>(CSOpCode.CharacterList);
            Register<SCharacterListS9>(CSOpCode.CharacterList);
            Register<SCharacterListS12>(CSOpCode.CharacterList);
            Register<SCharacterListS16Kor>(CSOpCode.CharacterList);
            Register<SCharacterCreate>(CSOpCode.CharacterCreate);
            Register<SCharacterDelete>(CSOpCode.CharacterDelete);
            Register<SCharacterMapJoin>(CSOpCode.JoinMap);
            Register<SCharacterMapJoin2>(CSOpCode.JoinMap2);
            Register<SCharacterMapJoin2S12Eng>(CSOpCode.JoinMap2);
            Register<SCharacterMapJoin2S16Kor>(CSOpCode.JoinMap2);
            VersionSelector.Register<SCharacterMapJoin2>(ServerSeason.Season6Kor, CSOpCode.JoinMap2);
            VersionSelector.Register<SCharacterMapJoin2S12Eng>(ServerSeason.Season12Eng, CSOpCode.JoinMap2);
            VersionSelector.Register<SCharacterMapJoin2S16Kor>(ServerSeason.Season16Kor, CSOpCode.JoinMap2);
            Register<SServerMove>(CSOpCode.ServerMove);
        }
    }
}
