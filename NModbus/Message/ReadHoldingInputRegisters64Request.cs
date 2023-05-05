﻿using System.Diagnostics;
using System.IO;

namespace NModbus.Message
{
  internal class ReadHoldingInputRegisters64Request : ReadHoldingInputRegistersRequest
  {
    public ReadHoldingInputRegisters64Request()
    {
    }

    public ReadHoldingInputRegisters64Request(byte functionCode, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        : base(functionCode, slaveAddress, startAddress, numberOfPoints)
    {
      StartAddress = startAddress;
      NumberOfPoints = numberOfPoints;
    }

    public override void ValidateResponse(IModbusMessage response)
    {
      var typedResponse = response as ReadHoldingInputRegistersResponse;
      Debug.Assert(typedResponse != null, "Argument response should be of type ReadHoldingInputRegistersResponse.");
      var expectedByteCount = NumberOfPoints * 8;

      if (expectedByteCount != typedResponse.ByteCount)
      {
        string msg = $"Unexpected byte count. Expected {expectedByteCount}, received {typedResponse.ByteCount}.";
        throw new IOException(msg);
      }
    }
  }
}
