using Module20.Support;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

/* Model
 Модель использует используемые в приложении данные.
 Модели могут содержать логику, непосредственно связанную этими данными,
 например, логику валидации свойств модели.
 В то же время модель не должна содержать никакой логики, связанной с отображением
 данных и взаимодействием с визуальными элементами управления.

 Нередко модель реализует интерфейсы INotifyPropertyChanged или INotifyCollectionChanged,
 которые позволяют уведомлять систему об изменениях свойств модели.
 Благодаря этому облегчается привязка к представлению, хотя опять же прямое 
 взаимодействие между моделью и представлением отсутствует.

*/

namespace Module20.Models
{

    /// <summary>
    /// Information about a media file item such as its filename, duration, file extention, data format etc
    /// </summary>
    public class CMediaFile
    {
        public CMediaFile() { }

        /// <summary>
        /// The file name of this directory item
        /// </summary>
        public string FileName { get; set; } = "";
        public string File_ItemType { get; set; } = "WAV File";

        /// <summary>
        /// The absolute path to this item
        /// </summary>
        public string File_FullPath { get; set; }
        public long File_Size { get; set; }

        public TimeSpan Length { get; set; } = new TimeSpan(0);
        public TimeSpan CurrentPosition { get; set; } = new TimeSpan(0);

        public long Video_FrameWidth { get; set; }
        public long Video_FrameHeight { get; set; }
        public long Video_TotalBitRate { get; set; }
        public long Video_FrameRate { get; set; }

        public string Audio_BitRate { get; set; } = "384kbps";
        public long Audio_Channels { get; set; }
        public long Audio_SampleRate { get; set; }
        public string Audio_Frequency { get; set; } = "24khz";


        public bool IfExists()
        {
            return File.Exists(File_FullPath);
        }


        public void Clear()
        {
            FileName = null;
            File_ItemType = null;
            File_FullPath = null;
            File_Size = 0;
            Length = new TimeSpan(0);
            CurrentPosition = new TimeSpan(0);
            Video_FrameWidth = 0;
            Video_FrameHeight = 0;
            Video_TotalBitRate = 0;
            Video_FrameRate = 0;
            Audio_BitRate = null;
            Audio_Channels = 0;
            Audio_SampleRate = 0;
            Audio_Frequency = null;
        }
    }

}
