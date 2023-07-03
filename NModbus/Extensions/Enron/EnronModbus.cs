﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NModbus.Data;
using NModbus.Message;

namespace NModbus.Extensions.Enron
{
    /// <summary>
    ///     Utility extensions for the Enron Modbus dialect.
    /// </summary>
    public static class EnronModbus
	{
		/// <summary>
		///    Reads contiguous block of input registers with 32 bit register size.
		/// </summary>
		/// <param name="master">The Modbus master.</param>
		/// <param name="slaveAddress">Address of device to read values from.</param>
		/// <param name="startAddress">Address to begin reading.</param>
		/// <param name="numberOfPoints">Number of holding registers to read.</param>
		/// <returns>Input registers status.</returns>
		public static uint[] ReadInputRegisters32(this IModbusMaster master, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
		{
			ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 62);

			var request = new ReadHoldingInputRegisters32Request(
				ModbusFunctionCodes.ReadInputRegisters,
				slaveAddress,
				startAddress,
				numberOfPoints);

			return PerformReadRegisters(master, request);
		}

        /// <summary>
        ///    Reads contiguous block of input registers with 64 bit register size.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <param name="bytesPerPoint">Number of bytes per point.</param>
        /// <returns>Input registers status.</returns>
        public static ulong[] ReadInputRegisters64(this IModbusMaster master, byte slaveAddress, ushort startAddress, 
            ushort numberOfPoints, ushort bytesPerPoint = 8)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 31);

            var request = new ReadHoldingInputRegisters64Request(
                ModbusFunctionCodes.ReadInputRegisters,
                slaveAddress,
                startAddress,
                numberOfPoints,
                bytesPerPoint);

            return PerformReadRegisters(master, request);
        }

        /// <summary>
        ///    Reads contiguous block of holding registers.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>Holding registers status.</returns>
        public static uint[] ReadHoldingRegisters32(this IModbusMaster master, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
		{
			ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 62);

			var request = new ReadHoldingInputRegisters32Request(
				ModbusFunctionCodes.ReadHoldingRegisters,
				slaveAddress,
				startAddress,
				numberOfPoints);

			return PerformReadRegisters(master, request);
		}

        /// <summary>
        ///    Reads contiguous block of holding registers.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <param name="bytesPerPoint">Number of bytes per point.</param>
        /// <returns>Holding registers status.</returns>
        public static ulong[] ReadHoldingRegisters64(this IModbusMaster master, byte slaveAddress, ushort startAddress, 
            ushort numberOfPoints, ushort bytesPerPoint)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 31);

            var request = new ReadHoldingInputRegisters64Request(
                ModbusFunctionCodes.ReadHoldingRegisters,
                slaveAddress,
                startAddress,
                numberOfPoints,
                bytesPerPoint);

            return PerformReadRegisters(master, request);
        }

        /// <summary>
        ///    Asynchronously reads contiguous block of input registers with 32 bit register size.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public static Task<uint[]> ReadInputRegisters32Async(this IModbusMaster master, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
		{
			ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 125);

			var request = new ReadHoldingInputRegisters32Request(
				ModbusFunctionCodes.ReadInputRegisters,
				slaveAddress,
				startAddress,
				numberOfPoints);

			return PerformReadRegistersAsync(master, request);
		}

        /// <summary>
        ///    Asynchronously reads contiguous block of input registers with 32 bit register size.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <param name="bytesPerPoint">Number of bytes per point.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public static Task<ulong[]> ReadInputRegisters64Async(this IModbusMaster master, byte slaveAddress, ushort startAddress, 
            ushort numberOfPoints, ushort bytesPerPoint)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 62);

            var request = new ReadHoldingInputRegisters64Request(
                ModbusFunctionCodes.ReadInputRegisters,
                slaveAddress,
                startAddress,
                numberOfPoints,
                bytesPerPoint);

            return PerformReadRegistersAsync(master, request);
        }

        /// <summary>
        ///    Asynchronously reads contiguous block of holding registers.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public static Task<uint[]> ReadHoldingRegisters32Async(this IModbusMaster master, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
		{
			ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 125);

			var request = new ReadHoldingInputRegisters32Request(
				ModbusFunctionCodes.ReadHoldingRegisters,
				slaveAddress,
				startAddress,
				numberOfPoints);

			return PerformReadRegistersAsync(master, request);
		}

        /// <summary>
        ///    Asynchronously reads contiguous block of holding registers.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <param name="bytesPerPoint">Number of bytes per point.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public static Task<ulong[]> ReadHoldingRegisters64Async(this IModbusMaster master, byte slaveAddress, ushort startAddress, 
            ushort numberOfPoints, ushort bytesPerPoint)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 62);

            var request = new ReadHoldingInputRegisters64Request(
                ModbusFunctionCodes.ReadHoldingRegisters,
                slaveAddress,
                startAddress,
                numberOfPoints,
                bytesPerPoint);

            return PerformReadRegistersAsync(master, request);
        }

        /// <summary>
        ///     Write a single 32 bit holding register.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        public static void WriteSingleRegister32(
			this IModbusMaster master,
			byte slaveAddress,
			ushort registerAddress,
			uint value)
		{
			if (master == null)
			{
				throw new ArgumentNullException(nameof(master));
			}

			master.WriteMultipleRegisters32(slaveAddress, registerAddress, new[] { value });
		}

        /// <summary>
        ///     Write a single 64 bit holding register.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        public static void WriteSingleRegister64(
            this IModbusMaster master,
            byte slaveAddress,
            ushort registerAddress,
            ulong value)
        {
            if (master == null)
            {
                throw new ArgumentNullException(nameof(master));
            }

            master.WriteMultipleRegisters64(slaveAddress, registerAddress, new [] { value });
        }

        /// <summary>
        ///     Write a block of contiguous 32 bit holding registers.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        public static void WriteMultipleRegisters32(
			this IModbusMaster master,
			byte slaveAddress,
			ushort startAddress,
			uint[] data)
		{
			if (master == null)
			{
				throw new ArgumentNullException(nameof(master));
			}

			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			if (data.Length == 0 || data.Length > 61)
			{
				throw new ArgumentException("The length of argument data must be between 1 and 61 inclusive.");
			}

			master.WriteMultipleRegisters32(slaveAddress, startAddress, Convert(data).ToArray());
		}

        /// <summary>
        ///     Write a block of contiguous 64 bit holding registers.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        public static void WriteMultipleRegisters64(
            this IModbusMaster master,
            byte slaveAddress,
            ushort startAddress,
            ulong[] data)
        {
            if (master == null)
            {
                throw new ArgumentNullException(nameof(master));
            }

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length == 0 || data.Length > 30)
            {
                throw new ArgumentException("The length of argument data must be between 1 and 30 inclusive.");
            }

            master.WriteMultipleRegisters64(slaveAddress, startAddress, Convert(data).ToArray());
        }

        private static Task<uint[]> PerformReadRegistersAsync(IModbusMaster master, ReadHoldingInputRegisters32Request request)
		{
			return Task.Factory.StartNew(() => PerformReadRegisters(master, request));
		}

        private static Task<ulong[]> PerformReadRegistersAsync(IModbusMaster master, ReadHoldingInputRegisters64Request request)
        {
            return Task.Factory.StartNew(() => PerformReadRegisters(master, request));
        }

        private static uint[] PerformReadRegisters(IModbusMaster master, ReadHoldingInputRegisters32Request request)
		{
			ReadHoldingInputRegistersResponse response = master.Transport.UnicastMessage<ReadHoldingInputRegistersResponse>(request);

			uint[] registers = new uint[request.NumberOfPoints];

			if (response.Data is IModbusMessageDataCollection data)
			{
				for (int i = 0; i < response.Data.ByteCount; i += 4)
				{
					registers[i / 4] = (uint)(data.NetworkBytes[i + 0] << 24 | data.NetworkBytes[i + 1] << 16 | data.NetworkBytes[i + 2] << 8 | data.NetworkBytes[i + 3]);
				}
			}

			return registers;
		}

        private static ulong[] PerformReadRegisters(IModbusMaster master, ReadHoldingInputRegisters64Request request)
        {
            ReadHoldingInputRegistersResponse response = master.Transport.UnicastMessage<ReadHoldingInputRegistersResponse>(request);

            ulong[] registers = new ulong[request.NumberOfPoints * request.BytesPerPoint / 8];

            if (response.Data is IModbusMessageDataCollection data)
            {
                for (int i = 0; i < response.Data.ByteCount; i += 8)
                {
                    registers[i / 8] = (ulong)(
                        (long)(data.NetworkBytes[i + 0] << 24 | data.NetworkBytes[i + 1] << 16 | data.NetworkBytes[i + 2] << 8 | data.NetworkBytes[i + 3] << 0) << 32 |
                        (long)(data.NetworkBytes[i + 4] << 24 | data.NetworkBytes[i + 5] << 16 | data.NetworkBytes[i + 6] << 8 | data.NetworkBytes[i + 7] << 0)
                    );
                }
            }

            return registers;
        }

        private static void ValidateNumberOfPoints(string argumentName, ushort numberOfPoints, ushort maxNumberOfPoints)
		{
			if (numberOfPoints < 1 || numberOfPoints > maxNumberOfPoints)
			{
				string msg = $"Argument {argumentName} must be between 1 and {maxNumberOfPoints} inclusive.";
				throw new ArgumentException(msg);
			}
		}

		/// <summary>
		///     Convert the 32 bit registers to two 16 bit values.
		/// </summary>
		private static IEnumerable<ushort> Convert(uint[] registers)
		{
			foreach (var register in registers)
			{
                byte[] bytes = BitConverter.GetBytes(register);
                                
                // low order value
                yield return BitConverter.ToUInt16(bytes, 2);

				// high order value
				yield return BitConverter.ToUInt16(bytes, 0);
			}
		}

        /// <summary>
        ///     Convert the 64 bit registers to two 16 bit values.
        /// </summary>
        private static IEnumerable<ushort> Convert(ulong[] registers)
        {
            foreach (var register in registers)
            {
                byte[] bytes = BitConverter.GetBytes(register);

                yield return BitConverter.ToUInt16(bytes, 6);
                yield return BitConverter.ToUInt16(bytes, 4);
                yield return BitConverter.ToUInt16(bytes, 2);
                yield return BitConverter.ToUInt16(bytes, 0);
            }
        }
    }
}
