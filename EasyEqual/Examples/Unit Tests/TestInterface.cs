﻿using System;

namespace EasyEqual
{
    public interface ITestInterface<T>
    {
        void EqualValues();
        void UnequalValues();

        void EqualNullValues();
        void UnequalNullValues();

        void DeepEqual();
        void DeepUnequal();

        void EqualQuick();
        void EqualQuickDeep(); 

        Compare<T> compare { get; set;  }
    }
}
