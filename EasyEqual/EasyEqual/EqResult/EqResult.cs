﻿using System;
using System.Collections.Generic; 
namespace EasyEqual
{
    public class EqResult : IEqResult
    {
        private bool _response;
        private HashSet<Type> _differentFields; 

        public EqResult(bool returnValue)
        {
            _response = returnValue; 
        }

        public bool GetResponse()
        {
            return _response; 
        }

        public HashSet<Type> GetDifferences()
        {
            throw new NotImplementedException(); 
        }
    }
}
