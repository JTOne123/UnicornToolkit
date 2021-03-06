﻿// Copyright (c) 2016 Louis Wu

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Unicorn.UI.Xaml
{
    public static class VisualStateProperty
    {
        public static readonly DependencyProperty CurrentStateProperty =
            DependencyProperty.RegisterAttached("CurrentState", typeof(string), typeof(VisualStateProperty), new PropertyMetadata(null, TransitionToState));

        public static string GetCurrentState(DependencyObject obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            return (string)obj.GetValue(CurrentStateProperty);
        }

        public static void SetCurrentState(DependencyObject obj, string value)
        {
            obj?.SetValue(CurrentStateProperty, value);
        }

        private static void TransitionToState(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Control c = sender as Control;
            if (c != null)
            {
                bool b = VisualStateManagerHelper.GoToState(c, (string)args.NewValue, false);
            }
#if DEBUG
            else
            {
                throw new ArgumentException("CurrentState is only supported on the Control type");
            }
#endif
        }
    }
}
