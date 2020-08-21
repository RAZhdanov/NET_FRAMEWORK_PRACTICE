using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module20.Models
{
    public enum MediaCommand
    {
        EMediaCommand_DoPlay,
        EMediaCommand_DoPause,
        EMediaCommand_DoStop,
        EMediaCommand_SwitchOnRepeatMode
    }
    public enum MediaState
    {
        EMediaState_None,
        EMediaState_IsOpened,
        EMediaState_IsFailed,
        EMediaState_IsPlaying,
        EMediaState_IsPaused,
        EMediaState_IsStopped
    }
}
