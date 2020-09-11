using System;
using System.IO.Ports;
using System.Threading;
using Modbus.Device;
using System.Linq;
using System.Collections.Generic;

namespace cm
{
    public class Reader
    {
        private Settings m_settings = new Settings();
        private List<Indicators> m_indicators = new List<Indicators>();
        private Indicators m_lastIndicators = new Indicators(0, 0, 0, 0, 0);
        private Mutex m_mutex = new Mutex();
        private Random m_rnd = new Random();

        private OnRead m_onRead;

        SerialPort m_port;
        IModbusSerialMaster m_master;

        public delegate void OnRead(bool redraw);

        public void ReConnect()
        {
            m_mutex.WaitOne();

            try
            {
                Disconnect();

                m_port = new SerialPort(m_settings.COM)
                {
                    BaudRate = m_settings.Baudrate,
                    DataBits = 7,
                    Parity = Parity.None,
                    StopBits = StopBits.Two,
                    ReadTimeout = 300,
                    WriteTimeout = 300
                };
                m_port.Open();

                m_master = ModbusSerialMaster.CreateAscii(m_port);
            }
            catch
            {
            };

            m_mutex.ReleaseMutex();
        }

        public void Disconnect()
        {
            try
            {
                m_master.Dispose();
                m_port.Close();
                m_port.Dispose();
            }
            catch
            {

            }
        }

        public Reader(Settings settings, OnRead onRead)
        {
            m_settings = settings;
            m_onRead = onRead;

            ReConnect();
        }

        public void Read()
        {
            byte slaveId = 1; //broadcast
            ushort numRegisters = 7;
            ushort startAddress = 2;
            ushort startAddress_Uab = 8 - 2; //???
            ushort startAddress_Ia = 4 - 2;
            ushort startAddress_Ib = 5 - 2;
            ushort startAddress_Uc = 2 - 2;
            ushort startAddress_Ic = 6 - 2;

            while (!m_shouldStop)
            {
                m_mutex.WaitOne();

                ushort[] registers;

                try
                {
                    registers = m_master.ReadHoldingRegisters(slaveId, startAddress, numRegisters);
                }
                catch(Exception e)
                {
                    m_mutex.ReleaseMutex();
                    Thread.Sleep(500);
                    ReConnect();
                    continue;
                }

                m_lastIndicators = new Indicators(
                    m_settings.Uab_mult * registers[startAddress_Uab]  /*  *  m_rnd.Next(1, 100)  */,
                    m_settings.Ia_mult * registers[startAddress_Ia]   /* *  m_rnd.Next(1, 100)  */,
                    m_settings.Uc_mult * registers[startAddress_Uc]   /* *  m_rnd.Next(1, 100) */,
                    m_settings.Ic_mult * registers[startAddress_Ic]   /* * m_rnd.Next(1, 100) */ ,
                    m_settings.Ib_mult * registers[startAddress_Ib]   /* * m_rnd.Next(1, 100) */);

                if (m_shouldStore)
                {
                    if (!Filter(m_lastIndicators))
                    {
                        m_indicators.Add(m_lastIndicators);
                    }

                    m_onRead(true);
                }
                else
                {
                    m_onRead(true);
                }

                m_mutex.ReleaseMutex();

                Thread.Sleep(10);
            }

            Disconnect();
        }

        public void RequestStop()
        {
            m_shouldStop = true;
        }

        public void RequestPause()
        {
            m_shouldStore = false;
        }

        public void RequestResume()
        {
            m_shouldStore = true;
        }

        public void RequestClear()
        {
            m_mutex.WaitOne();
            m_indicators.Clear();
            m_mutex.ReleaseMutex();

            m_onRead(true);
        }

        private bool Filter(Indicators indicators)
        {
            if (m_indicators.Count <= 0)
            {
                return false;
            }

            var Ia_min = m_indicators.Min(t => Math.Abs(t.m_Ia - indicators.m_Ia));
            var Uab_min = m_indicators.Min(t => Math.Abs(t.m_Uab - indicators.m_Uab));

            return (Ia_min < 0.001) && (Uab_min < 0.001);
        }

        public Indicators GetLastIndicators()
        {
            m_mutex.WaitOne();

            Indicators indicators = new Indicators(m_lastIndicators);

            m_mutex.ReleaseMutex();

            return indicators;
        }

        public List<Indicators> GetIndicators()
        {
            m_mutex.WaitOne();

            List<Indicators> indicators = new List<Indicators>();
            indicators.AddRange(m_indicators);

            m_mutex.ReleaseMutex();

            return indicators;
        }

        private volatile bool m_shouldStop = false;
        private volatile bool m_shouldStore = true;
    }
}
