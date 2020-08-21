using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Module20.Models
{
    public class MediaProvider : IMediaProvider<Grid>
    {
        public MediaElement MediaElement { get; private set; } = null;
        
        public MediaProvider(MediaElement _mediaElement)
        {
            MediaElement = _mediaElement;
        }

        public bool IsLoaded { get; set; } = false;

        public void LoadMediaFile(Grid view, string _path)
        {
            if(!ReferenceEquals(MediaElement, null) && !ReferenceEquals(_path, null))
            {
                MediaElement.Source = new Uri(_path);
                MediaElement.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                MediaElement.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                MediaElement.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
                view.Children.Add(MediaElement);
                
                IsLoaded = true;
            }
        }


        public bool IsVideo()
        {
            return MediaElement.HasVideo;
        }

        public bool IsAudio()
        {
            return !MediaElement.HasVideo && MediaElement.HasAudio;
        }

    }
}
