using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace SimpleSerial
{
    public partial class Form1 : Form
    {
        // Add this variable 
        SerialPort serialPort1 = new SerialPort();         
        public Form1()
        {
            InitializeComponent();
            button1.Text = "Lights On";
            int i = 0;
            string[] portNames = SerialPort.GetPortNames();
            while (i < portNames.Length)
            {
                comboBox1.Items.Add(portNames[i]);
                i++;
            }
          //  SerialPort serialPort1 = new SerialPort(); 
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            


            serialPort1.PortName = "COM6";
            serialPort1.BaudRate = 9600;

            serialPort1.Open();
            if (serialPort1.IsOpen)
            {
                buttonStart.Enabled = false;
                buttonStop.Enabled = true;
               
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
                
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) return;
            if (button1.Text == "Lights On")
            {
                serialPort1.Write("T");
                button1.Text = "Lights Off";
            }

            else
            {
                serialPort1.Write("F");
                button1.Text = "Lights On";
            }

        }

       
     
    }
      
    
}

        