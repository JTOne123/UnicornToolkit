﻿// Copyright (c) 2016 John Shu

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
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Unicorn.ServiceModel
{
    public class ServiceModelJsonConvert
    {
        public static T DeserializeObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString, DefaultJsonSerializerSettings.Setting);
        }

        public static T DeserializeObject<T>(JToken jsonToken)
        {
            if (jsonToken == null)
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(jsonToken.ToString(), DefaultJsonSerializerSettings.Setting);
        }

        public static object DeserializeObject(JToken jsonToken, Type objectType)
        {
            if (jsonToken == null)
            {
                if (objectType.GetTypeInfo().IsValueType)
                {
                    return Activator.CreateInstance(objectType);
                }

                return null;
            }

            return JsonConvert.DeserializeObject(jsonToken.ToString(), objectType, DefaultJsonSerializerSettings.Setting);
        }

        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value, DefaultJsonSerializerSettings.Setting);
        }
    }
}