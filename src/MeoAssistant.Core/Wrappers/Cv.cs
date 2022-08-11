// <copyright file="Cv.cs" company="MaaAssistantArknights">
// MeoAsstGui - A part of the MeoAssistantArknights project
// Copyright (C) 2021 MistEO and Contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY
// </copyright>

namespace MeoAssistant.Core.Wrappers
{
    using System.Runtime.InteropServices;

    public static class Cv
    {
        public static bool ImWrite(string filename, Mat img)
        {
            return ImWrite(filename, img.Pointer);
        }

        public static void Rectangle(Mat img, Rect rec, Scalar color)
        {
            Rectangle(img.Pointer, rec.Pointer, color.Pointer);
        }

        public static void PutText(Mat img, string text, Point org, int fontFace, double fontScale, Scalar color)
        {
            PutText(img.Pointer, text, org.Pointer, fontFace, fontScale, color.Pointer);
        }

        public static void CvtColor(Mat src, Mat dst, int code)
        {
            CvtColor(src.Pointer, dst.Pointer, code);
        }

        public static void InRange(Mat src, Scalar lowerB, Scalar upperB, out Mat output)
        {
            output = Mat.New();
            InRange(src.Pointer, lowerB.Pointer, upperB.Pointer, output.Pointer);
        }

        [DllImport("MeoAssistant.Wrapper.dll", EntryPoint = "imwrite", CharSet = CharSet.Unicode)]
        private static extern bool ImWrite(string filename, IntPtr img);

        [DllImport("MeoAssistant.Wrapper.dll", EntryPoint = "rectangle")]
        private static extern void Rectangle(IntPtr img, IntPtr rec, IntPtr color);

        [DllImport("MeoAssistant.Wrapper.dll", EntryPoint = "putText", CharSet = CharSet.Unicode)]
        private static extern void PutText(IntPtr img, string text, IntPtr org, int fontFace, double fontScale, IntPtr color);

        [DllImport("MeoAssistant.Wrapper.dll", EntryPoint = "cvtColor")]
        private static extern void CvtColor(IntPtr src, IntPtr dst, int code);

        [DllImport("MeoAssistant.Wrapper.dll", EntryPoint = "inRange")]
        private static extern void InRange(IntPtr src, IntPtr lowerB, IntPtr upperB, IntPtr output);

        public class Mat : CppObject
        {
            public Mat(IntPtr pointer)
                : base(pointer)
            {
            }

            public static Mat New()
            {
                return new Mat(NewInternal());
            }

            [DllImport("MeoAssistant.Wrapper.dll", EntryPoint = "new_Mat")]
            private static extern IntPtr NewInternal();
        }

        public class Rect : CppObject
        {
            public Rect(IntPtr pointer)
                : base(pointer)
            {
            }
        }

        public class Scalar : CppObject
        {
            public Scalar(IntPtr pointer)
                : base(pointer)
            {
            }
        }

        public class Point : CppObject
        {
            public Point(IntPtr pointer)
                : base(pointer)
            {
            }
        }
    }
}
