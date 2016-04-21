using System;

namespace RealtyInvest.Common.Log
{
    public interface ILoger
    {
        void Log(Exception exception);
    }
}