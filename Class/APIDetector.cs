using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBZ_DokkanBottle
{
    class APIDetector
    {
        public static class AppScreen
        {
            public class GetPos
            {
                public static Rectangle CursorX;
                public static Rectangle CursorY;
                public static Int32 AppLeftLoc;
                public static Int32 AppTopLoc;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct Rect
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("user32.dll")]
            private static extern int SetForegroundWindow(IntPtr hWnd);

            private const int SW_RESTORE = 9;

            [DllImport("user32.dll")]
            private static extern IntPtr ShowWindow(IntPtr hWnd, int nCmdShow);

            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
            
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


            public static Bitmap CaptureApplication(string procName)
            {
                Process proc;

                // Cater for cases when the process can't be located.
                try
                {
                    proc = Process.GetProcessesByName(procName)[0];
                }
                catch (IndexOutOfRangeException e)
                {
                    return null;
                }

                // You need to focus on the application
                SetForegroundWindow(proc.MainWindowHandle);
                ShowWindow(proc.MainWindowHandle, SW_RESTORE);

                // You need some amount of delay, but 1 second may be overkill
                Thread.Sleep(1000);

                Rect rect = new Rect();
                IntPtr error = GetWindowRect(proc.MainWindowHandle, ref rect);

                // sometimes it gives error.
                while (error == (IntPtr)0)
                {
                    error = GetWindowRect(proc.MainWindowHandle, ref rect);
                }
                int width = rect.right - rect.left;
                int height = rect.bottom - rect.top;
                GetPos.AppLeftLoc = rect.left;
                GetPos.AppTopLoc = rect.top;

                Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                Graphics.FromImage(bmp).CopyFromScreen(rect.left,
                                                       rect.top,
                                                       0,
                                                       0,
                                                       new Size(width, height),
                                                       CopyPixelOperation.SourceCopy);

                bmp.Save("temp.bmp", ImageFormat.Bmp);
                return bmp;
            }
        }

        public static Double Tolerance = 20 / 100.0;
        public static Rectangle autoSearchBitmap(Bitmap bitmap1, Bitmap bitmap2)
        {
            Rectangle location = Rectangle.Empty;
            location = searchBitmap(bitmap1, bitmap2, Tolerance);

            return location;
        }

        public static Rectangle searchBitmap(Bitmap smallBmp, Bitmap bigBmp, double tolerance)
        {
            BitmapData smallData =
              smallBmp.LockBits(new Rectangle(0, 0, smallBmp.Width, smallBmp.Height),
                       System.Drawing.Imaging.ImageLockMode.ReadOnly,
                       System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData bigData =
              bigBmp.LockBits(new Rectangle(0, 0, bigBmp.Width, bigBmp.Height),
                       System.Drawing.Imaging.ImageLockMode.ReadOnly,
                       System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int smallStride = smallData.Stride;
            int bigStride = bigData.Stride;

            int bigWidth = bigBmp.Width;
            int bigHeight = bigBmp.Height - smallBmp.Height + 1;
            int smallWidth = smallBmp.Width * 3;
            int smallHeight = smallBmp.Height;

            Rectangle location = Rectangle.Empty;
            int margin = Convert.ToInt32(255.0 * tolerance);

            unsafe
            {
                byte* pSmall = (byte*)(void*)smallData.Scan0;
                byte* pBig = (byte*)(void*)bigData.Scan0;

                int smallOffset = smallStride - smallBmp.Width * 3;
                int bigOffset = bigStride - bigBmp.Width * 3;

                bool matchFound = true;

                for (int y = 0; y < bigHeight; y++)
                {
                    for (int x = 0; x < bigWidth; x++)
                    {
                        byte* pBigBackup = pBig;
                        byte* pSmallBackup = pSmall;

                        //Look for the small picture.
                        for (int i = 0; i < smallHeight; i++)
                        {
                            int j = 0;
                            matchFound = true;
                            for (j = 0; j < smallWidth; j++)
                            {
                                //With tolerance: pSmall value should be between margins.
                                int inf = pBig[0] - margin;
                                int sup = pBig[0] + margin;
                                if (sup < pSmall[0] || inf > pSmall[0])
                                {
                                    matchFound = false;
                                    break;
                                }

                                pBig++;
                                pSmall++;
                            }

                            if (!matchFound) break;

                            //We restore the pointers.
                            pSmall = pSmallBackup;
                            pBig = pBigBackup;

                            //Next rows of the small and big pictures.
                            pSmall += smallStride * (1 + i);
                            pBig += bigStride * (1 + i);
                        }

                        //If match found, we return.
                        if (matchFound)
                        {
                            location.X = x;
                            location.Y = y;
                            location.Width = smallBmp.Width;
                            location.Height = smallBmp.Height;
                            break;
                        }
                        //If no match found, we restore the pointers and continue.
                        else
                        {
                            pBig = pBigBackup;
                            pSmall = pSmallBackup;
                            pBig += 3;
                        }
                    }

                    if (matchFound) break;

                    pBig += bigOffset;
                }
            }

            bigBmp.UnlockBits(bigData);
            smallBmp.UnlockBits(smallData);

            return location;
        }

        public static Boolean CheckEventPos(Bitmap Large, Bitmap Small)
        {
            Bitmap bitmap1 = Large;
            Bitmap bitmap2 = Small;

            if (bitmap1.Width > bitmap2.Width || bitmap1.Height > bitmap2.Height)
            {
                Bitmap aux = bitmap2;
                bitmap2 = bitmap1;
                bitmap1 = aux;
            }

            if (bitmap1.Height > bitmap2.Height)
            {
                MessageBox.Show("None of the Bitmaps can contain the other.", "Data error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            Rectangle location = Rectangle.Empty;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            location = APIDetector.autoSearchBitmap(bitmap1, bitmap2);
            stopWatch.Stop();

            if (location.Width != 0)
            {
                APIDetector.AppScreen.GetPos.CursorX.X = location.X;
                APIDetector.AppScreen.GetPos.CursorY.Y = location.Y;
                return true;
            }
            else
            {
                return false;
            }
            bitmap1.Dispose();
            bitmap2.Dispose();
        }
    }
}