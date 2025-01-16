using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace UGame.Banks.Repository
{
    public partial class S_channelPO
    {
        #region tinyfx
        public static implicit operator S_channelEO(S_channelPO value)
        {
            if (value==null) return null;
            return new S_channelEO
            {
		        ChannelID = value.ChannelID,
		        OperatorID = value.OperatorID,
		        CName = value.CName,
		        CType = value.CType,
		        BranchKey = value.BranchKey,
		        FBPixelId = value.FBPixelId,
		        FBAccessToken = value.FBAccessToken,
		        KwaiConfig = value.KwaiConfig,
		        GAKey = value.GAKey,
		        TrackConfigs = value.TrackConfigs,
		        IsStats = value.IsStats,
		        Note = value.Note,
		        Status = value.Status,
		        RecDate = value.RecDate,
            };
        }
        public static implicit operator S_channelPO(S_channelEO value)
        {
            if (value==null) return null;
            return new S_channelPO
            {
		        ChannelID = value.ChannelID,
		        OperatorID = value.OperatorID,
		        CName = value.CName,
		        CType = value.CType,
		        BranchKey = value.BranchKey,
		        FBPixelId = value.FBPixelId,
		        FBAccessToken = value.FBAccessToken,
		        KwaiConfig = value.KwaiConfig,
		        GAKey = value.GAKey,
		        TrackConfigs = value.TrackConfigs,
		        IsStats = value.IsStats,
		        Note = value.Note,
		        Status = value.Status,
		        RecDate = value.RecDate,
            };
        }
        #endregion
    }
}