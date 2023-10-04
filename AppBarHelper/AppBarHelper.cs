using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AppBarHelper
{
    public class AppBarHelper
    {
        public AppBarHelper(IntPtr handle, Size size, Point location)
        {
            Handle = handle;
            Size = size;
            Location = location;

            CallbackMessageID = RegisterCallbackMessage();
            if (CallbackMessageID == 0)
                throw new Exception("RegisterCallbackMessage failed");
        }

        public KeyValuePair<Size, Point> ChangeFormPosition(AppBarEdges position, Size size, Point location)
        {
            // Change application edge
            Size = size;
            Location = location;
            m_PrevSize = Size;
            this.Edge = position;

            return new KeyValuePair<Size, Point>(Size, Location);
        }


        #region AppBarFunctions

        // saves the current edge
        private AppBarEdges m_Edge = AppBarEdges.Float;

        // are we in dock mode?
        private Boolean IsAppbarMode = false;

        // save the floating size and location
        private Size m_PrevSize;
        private Point m_PrevLocation;

        // saves the callback message id
        private UInt32 CallbackMessageID = 0;

        private IntPtr Handle;
        private Size Size;
        private Point Location;


        public enum AppBarEdges
        {
            Left = 0,
            Top = 1,
            Right = 2,
            Bottom = 3,
            Float = 4
        }

        public enum AppBarMessages
        {
            /// <summary>
            /// Registers a new appbar and specifies the message identifier
            /// that the system should use to send notification messages to 
            /// the appbar. 
            /// </summary>
            New = 0x00000000,
            /// <summary>
            /// Unregisters an appbar, removing the bar from the system's 
            /// internal list.
            /// </summary>
            Remove = 0x00000001,
            /// <summary>
            /// Requests a size and screen position for an appbar.
            /// </summary>
            QueryPos = 0x00000002,
            /// <summary>
            /// Sets the size and screen position of an appbar. 
            /// </summary>
            SetPos = 0x00000003,
            /// <summary>
            /// Retrieves the autohide and always-on-top states of the 
            /// Microsoft® Windows® taskbar. 
            /// </summary>
            GetState = 0x00000004,
            /// <summary>
            /// Retrieves the bounding rectangle of the Windows taskbar. 
            /// </summary>
            GetTaskBarPos = 0x00000005,
            /// <summary>
            /// Notifies the system that an appbar has been activated. 
            /// </summary>
            Activate = 0x00000006,
            /// <summary>
            /// Retrieves the handle to the autohide appbar associated with
            /// a particular edge of the screen. 
            /// </summary>
            GetAutoHideBar = 0x00000007,
            /// <summary>
            /// Registers or unregisters an autohide appbar for an edge of 
            /// the screen. 
            /// </summary>
            SetAutoHideBar = 0x00000008,
            /// <summary>
            /// Notifies the system when an appbar's position has changed. 
            /// </summary>
            WindowPosChanged = 0x00000009,
            /// <summary>
            /// Sets the state of the appbar's autohide and always-on-top 
            /// attributes.
            /// </summary>
            SetState = 0x0000000a
        }


        public AppBarEdges Edge
        {
            get
            {
                return m_Edge;
            }
            set
            {
                m_Edge = value;
                if (value == AppBarEdges.Float)
                    AppbarRemove();
                else
                    AppbarNew();

                if (IsAppbarMode)
                    SizeAppBar();

            }
        }

        private Boolean AppbarRemove()
        {
            // prepare data structure of message
            ShellApi.APPBARDATA msgData = new ShellApi.APPBARDATA();
            msgData.cbSize = (UInt32)Marshal.SizeOf(msgData);
            msgData.hWnd = Handle;

            // remove appbar
            UInt32 retVal = ShellApi.SHAppBarMessage((UInt32)AppBarMessages.Remove, ref msgData);

            IsAppbarMode = false;

            Size = m_PrevSize;
            Location = m_PrevLocation;

            return (retVal != 0) ? true : false;
        }

        private Boolean AppbarNew()
        {
            if (CallbackMessageID == 0)
                throw new Exception("CallbackMessageID is 0");

            if (IsAppbarMode)
                return true;

            m_PrevSize = Size;
            m_PrevLocation = Location;

            // prepare data structure of message
            ShellApi.APPBARDATA msgData = new ShellApi.APPBARDATA();
            msgData.cbSize = (UInt32)Marshal.SizeOf(msgData);
            msgData.hWnd = Handle;
            msgData.uCallbackMessage = CallbackMessageID;

            // install new appbar
            UInt32 retVal = ShellApi.SHAppBarMessage((UInt32)AppBarMessages.New, ref msgData);
            IsAppbarMode = (retVal != 0);

            SizeAppBar();

            return IsAppbarMode;
        }

        private void SizeAppBar()
        {
            ShellApi.RECT rt = new ShellApi.RECT();

            if ((m_Edge == AppBarEdges.Left) ||
                (m_Edge == AppBarEdges.Right))
            {
                rt.top = 0;
                rt.bottom = SystemInformation.PrimaryMonitorSize.Height;
                if (m_Edge == AppBarEdges.Left)
                {
                    rt.right = m_PrevSize.Width;
                }
                else
                {
                    rt.right = SystemInformation.PrimaryMonitorSize.Width;
                    rt.left = rt.right - m_PrevSize.Width;
                }
            }
            else
            {
                rt.left = 0;
                rt.right = SystemInformation.PrimaryMonitorSize.Width;
                if (m_Edge == AppBarEdges.Top)
                {
                    rt.bottom = m_PrevSize.Height;
                }
                else
                {
                    rt.bottom = SystemInformation.PrimaryMonitorSize.Height;
                    rt.top = rt.bottom - m_PrevSize.Height;
                }
            }

            AppbarQueryPos(ref rt);

            switch (m_Edge)
            {
                case AppBarEdges.Left:
                    rt.right = rt.left + m_PrevSize.Width;
                    break;
                case AppBarEdges.Right:
                    rt.left = rt.right - m_PrevSize.Width;
                    break;
                case AppBarEdges.Top:
                    rt.bottom = rt.top + m_PrevSize.Height;
                    break;
                case AppBarEdges.Bottom:
                    rt.top = rt.bottom - m_PrevSize.Height;
                    break;
            }

            AppbarSetPos(ref rt);

            Location = new Point(rt.left, rt.top);
            Size = new Size(rt.right - rt.left, rt.bottom - rt.top);
        }

        private void AppbarQueryPos(ref ShellApi.RECT appRect)
        {
            // prepare data structure of message
            ShellApi.APPBARDATA msgData = new ShellApi.APPBARDATA();
            msgData.cbSize = (UInt32)Marshal.SizeOf(msgData);
            msgData.hWnd = Handle;
            msgData.uEdge = (UInt32)m_Edge;
            msgData.rc = appRect;

            // query postion for the appbar
            ShellApi.SHAppBarMessage((UInt32)AppBarMessages.QueryPos, ref msgData);
            appRect = msgData.rc;
        }

        private void AppbarSetPos(ref ShellApi.RECT appRect)
        {
            // prepare data structure of message
            ShellApi.APPBARDATA msgData = new ShellApi.APPBARDATA();
            msgData.cbSize = (UInt32)Marshal.SizeOf(msgData);
            msgData.hWnd = Handle;
            msgData.uEdge = (UInt32)m_Edge;
            msgData.rc = appRect;

            // set postion for the appbar
            ShellApi.SHAppBarMessage((UInt32)AppBarMessages.SetPos, ref msgData);
            appRect = msgData.rc;
        }

        private UInt32 RegisterCallbackMessage()
        {
            String uniqueMessageString = Guid.NewGuid().ToString();
            return ShellApi.RegisterWindowMessage(uniqueMessageString);
        }
        #endregion


        public static Color GetAccentColor()
        {
            const String DWM_KEY = @"Software\Microsoft\Windows\DWM";
            using (RegistryKey dwmKey = Registry.CurrentUser.OpenSubKey(DWM_KEY, RegistryKeyPermissionCheck.ReadSubTree))
            {
                const String KEY_EX_MSG = "The \"HKCU\\" + DWM_KEY + "\" registry key does not exist.";
                if (dwmKey is null) throw new InvalidOperationException(KEY_EX_MSG);

                Object accentColorObj = dwmKey.GetValue("AccentColor");
                if (accentColorObj is Int32 accentColorDword)
                {
                    return ParseDWordColor(accentColorDword);
                }
                else
                {
                    const String VALUE_EX_MSG = "The \"HKCU\\" + DWM_KEY + "\\AccentColor\" registry key value could not be parsed as an ABGR color.";
                    throw new InvalidOperationException(VALUE_EX_MSG);
                }
            }

        }

        private static Color ParseDWordColor(Int32 color)
        {
            Byte
                a = (byte)((color >> 24) & 0xFF),
                b = (byte)((color >> 16) & 0xFF),
                g = (byte)((color >> 8) & 0xFF),
                r = (byte)((color >> 0) & 0xFF);


            return Color.FromArgb(a, r, g, b);
        }

        public static Color ChangeColorBrightness(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue));
        }
    }
}
