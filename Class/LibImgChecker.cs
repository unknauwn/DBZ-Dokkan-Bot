﻿using System;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DBZ_DokkanBottle
{
    public static class ScreenNox
    {
        public class GetPos
        {
            public static Int32 CursorX;
            public static Int32 CursorY;
            public static Int32 NoxLeft;
            public static Int32 NoxTop;
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
            GetPos.NoxLeft = rect.left;
            GetPos.NoxTop = rect.top;

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics.FromImage(bmp).CopyFromScreen(rect.left,
                                                   rect.top,
                                                   0,
                                                   0,
                                                   new Size(width, height),
                                                   CopyPixelOperation.SourceCopy);
            //bmp.Save("temp.png", ImageFormat.Png);
            return bmp;
        }
    }


    class LockedFastImage
    {
        private Bitmap image;
        private byte[] rgbValues;
        private System.Drawing.Imaging.BitmapData bmpData;

        private IntPtr ptr;
        private int bytes;

        public LockedFastImage(Bitmap image)
        {
            this.image = image;
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            bmpData = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            ptr = bmpData.Scan0;
            bytes = Math.Abs(bmpData.Stride) * image.Height;
            rgbValues = new byte[bytes];
            if (bmpData.Stride < 0)
            {
                int lines, pos, BytesPerLine = Math.Abs(bmpData.Stride);
                for (lines = pos = 0; lines < image.Height; lines++, pos += BytesPerLine)
                {
                    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, pos, BytesPerLine);
                    ptr = (IntPtr)(ptr.ToInt64() + bmpData.Stride);
                }
            }
            else
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
        }

        /// <summary>
        /// Returns or sets a pixel of the image. 
        /// </summary>
        /// <param name="x">x parameter of the pixel</param>
        /// <param name="y">y parameter of the pixel</param>
        public Color this[int x, int y]
        {
            get
            {
                int index = (x + (y * image.Width)) * 4;
                return Color.FromArgb(rgbValues[index + 3], rgbValues[index + 2], rgbValues[index + 1], rgbValues[index]);
            }

            set
            {
                int index = (x + (y * image.Width)) * 4;
                rgbValues[index] = value.B;
                rgbValues[index + 1] = value.G;
                rgbValues[index + 2] = value.R;
                rgbValues[index + 3] = value.A;
            }
        }

        /// <summary>
        /// Width of the image. 
        /// </summary>
        public int Width
        {
            get
            {
                return image.Width;
            }
        }

        /// <summary>
        /// Height of the image. 
        /// </summary>
        public int Height
        {
            get
            {
                return image.Height;
            }
        }

        /// <summary>
        /// Returns the modified Bitmap. 
        /// </summary>
        public Bitmap asBitmap()
        {
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            return image;
        }
    }

    class ImageChecker
    {

        private LockedFastImage big_image;
        private LockedFastImage small_image;
        /// <summary>
        /// The time needed for last operation.
        /// </summary>
        public TimeSpan time_needed = new TimeSpan();

        /// <summary>
        /// Error return value.
        /// </summary>
        static public Point CHECKFAILED = new Point(-1, -1);

        /// <summary>
        /// Constructor of the ImageChecker
        /// </summary>
        /// <param name="big_image">The image containing the small image.</param>
        /// <param name="small_image">The image located in the big image.</param>
        public ImageChecker(Bitmap big_image, Bitmap small_image)
        {
            this.big_image = new LockedFastImage(big_image);
            this.small_image = new LockedFastImage(small_image);
        }

        /// <summary>
        /// Returns the location of the small image in the big image. Returns CHECKFAILED if not found.
        /// </summary>
        /// <param name="x_speedUp">speeding up at x achsis.</param>
        /// <param name="y_speedUp">speeding up at y achsis.</param>
        /// <param name="begin_percent_x">Reduces the search rect. 0 - 100</param>
        /// <param name="end_percent_x">Reduces the search rect. 0 - 100</param>
        /// <param name="begin_percent_x">Reduces the search rect. 0 - 100</param>
        /// <param name="end_percent_y">Reduces the search rect. 0 - 100</param>
        public Point bigContainsSmall(int x_speedUp = 1, int y_speedUp = 1, int begin_percent_x = 0, int end_percent_x = 100, int begin_percent_y = 0, int end_percent_y = 100)
        {
            /*
             * SPEEDUP PARAMETER
             * It might be enough to check each second or third pixel in the small picture.
             * However... In most cases it would be enough to check 4 pixels of the small image for diablo porposes.
             * */

            /*
             * BEGIN, END PARAMETER
             * In most cases we know where the image is located, for this we have the begin and end paramenters.
             * */

            DateTime begin = DateTime.Now;

            if (x_speedUp < 1) x_speedUp = 1;
            if (y_speedUp < 1) y_speedUp = 1;
            if (begin_percent_x < 0 || begin_percent_x > 100) begin_percent_x = 0;
            if (begin_percent_y < 0 || begin_percent_y > 100) begin_percent_y = 0;
            if (end_percent_x < 0 || end_percent_x > 100) end_percent_x = 100;
            if (end_percent_y < 0 || end_percent_y > 100) end_percent_y = 100;

            int x_start = (int)((double)big_image.Width * ((double)begin_percent_x / 100.0));
            int x_end = (int)((double)big_image.Width * ((double)end_percent_x / 100.0));
            int y_start = (int)((double)big_image.Height * ((double)begin_percent_y / 100.0));
            int y_end = (int)((double)big_image.Height * ((double)end_percent_y / 100.0));

            /*
             * We cant speed up the big picture, because then we have to check pixels in the small picture equal to the speeded up size 
             * for each pixel in the big picture.
             * Would give no speed improvement.
             * */

            //+ 1 because first pixel is in picture. - small because image have to be fully in the other image
            for (int x = x_start; x < x_end - small_image.Width + 1; x++)
                for (int y = y_start; y < y_end - small_image.Height + 1; y++)
                {
                    //now we check if all pixels matches
                    for (int sx = 0; sx < small_image.Width; sx += x_speedUp)
                        for (int sy = 0; sy < small_image.Height; sy += y_speedUp)
                        {
                            if (small_image[sx, sy] != big_image[x + sx, y + sy])
                                goto CheckFailed;
                        }

                    //check ok
                    time_needed = DateTime.Now - begin;
                    ScreenNox.GetPos.CursorX = x;
                    ScreenNox.GetPos.CursorY = y;
                    return new Point(x, y);

                CheckFailed:;
                }

            time_needed = DateTime.Now - begin;
            return CHECKFAILED;
        }
        public Boolean CheckImg(int x_speedUp = 1, int y_speedUp = 1, int begin_percent_x = 0, int end_percent_x = 100, int begin_percent_y = 0, int end_percent_y = 100)
        {
            /*
             * SPEEDUP PARAMETER
             * It might be enough to check each second or third pixel in the small picture.
             * However... In most cases it would be enough to check 4 pixels of the small image for diablo porposes.
             * */

            /*
             * BEGIN, END PARAMETER
             * In most cases we know where the image is located, for this we have the begin and end paramenters.
             * */

            DateTime begin = DateTime.Now;

            if (x_speedUp < 1) x_speedUp = 1;
            if (y_speedUp < 1) y_speedUp = 1;
            if (begin_percent_x < 0 || begin_percent_x > 100) begin_percent_x = 0;
            if (begin_percent_y < 0 || begin_percent_y > 100) begin_percent_y = 0;
            if (end_percent_x < 0 || end_percent_x > 100) end_percent_x = 100;
            if (end_percent_y < 0 || end_percent_y > 100) end_percent_y = 100;

            int x_start = (int)((double)big_image.Width * ((double)begin_percent_x / 100.0));
            int x_end = (int)((double)big_image.Width * ((double)end_percent_x / 100.0));
            int y_start = (int)((double)big_image.Height * ((double)begin_percent_y / 100.0));
            int y_end = (int)((double)big_image.Height * ((double)end_percent_y / 100.0));

            /*
             * We cant speed up the big picture, because then we have to check pixels in the small picture equal to the speeded up size 
             * for each pixel in the big picture.
             * Would give no speed improvement.
             * */

            //+ 1 because first pixel is in picture. - small because image have to be fully in the other image
            for (int x = x_start; x < x_end - small_image.Width + 1; x++)
                for (int y = y_start; y < y_end - small_image.Height + 1; y++)
                {
                    //now we check if all pixels matches
                    for (int sx = 0; sx < small_image.Width; sx += x_speedUp)
                        for (int sy = 0; sy < small_image.Height; sy += y_speedUp)
                        {
                            if (small_image[sx, sy] != big_image[x + sx, y + sy])
                                goto CheckFailed;
                        }
                    //check ok
                    time_needed = DateTime.Now - begin;
                    ScreenNox.GetPos.CursorX = x;
                    ScreenNox.GetPos.CursorY = y;
                    return true;

                CheckFailed:;
                }

            time_needed = DateTime.Now - begin;
            return false;
        }
    }
}