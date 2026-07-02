using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PosDevice
    {
        public int id { get; set; } // شناسه دستگاه
        public string DeviceName { get; set; } // نام دستگاه
        public string DeviceType { get; set; } // نوع دستگاه (مثلاً کارت‌خوان یا پرینتر)
        public string PortName { get; set; } // نام پورت یا آدرس IP
        public int BaudRate { get; set; } // نرخ انتقال (در صورت استفاده از پورت سریال)
        public bool IsDefault { get; set; } // آیا دستگاه پیش‌فرض است یا نه
        public string Status { get; set; } // وضعیت دستگاه (مثلاً متصل، قطع و ...)

    }
}
