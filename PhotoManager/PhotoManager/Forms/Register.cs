﻿using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PhotoManager
{
    public partial class Register : Form, IRegisterView
    {
        #region Fields
        private static Register registerInstance;
        private bool nameCorrect = false;
        private bool surnameCorrect = false;
        private bool emailCorrect = false;
        private bool loginCorrect = false;
        private bool passwordCorrect = false;
        #endregion Fields;

        #region Events
        public event Action<User> CreateAccountEvent;
        #endregion Events

        #region Constructors
        private Register()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        #endregion Constructors

        #region Validation
        private bool IsEmpty(string tb)
        {
            if (tb.Trim() == string.Empty)
                return true;
            else
                return false;
        }
        private bool HasSpecialSIgns(string tb)
        {
            Regex regNumbers = new Regex("[@#$%^&*()]"); 
            if (regNumbers.IsMatch(tb) || tb.Contains(" "))
            {
                return true;
            }
            return false;
        }
        private bool HasNumbers(string tb)
        {
            Regex regNumbers = new Regex("[0-9]"); 
            if (regNumbers.IsMatch(tb) || tb.Contains(" "))
            {
                return true;
            }
            return false;
        }

        private void NameValidation(object sender, EventArgs e)
        {
            if (IsEmpty(tbName.Text) || HasNumbers(tbName.Text) || HasSpecialSIgns(tbName.Text))
            {
                lNameValidation.ForeColor = Color.Red;
                nameCorrect = false;
                return;
            }
            else
            {
                lNameValidation.ForeColor = Color.Green;
            }
            nameCorrect = true;
        }

        private void SurnameValidation(object sender, EventArgs e)
        {
            if (IsEmpty(tbSurname.Text) || HasNumbers(tbSurname.Text) || HasSpecialSIgns(tbSurname.Text))
            {
                lSurnameValidation.ForeColor = Color.Red;
                surnameCorrect = false;
                return;
            }
            else
            {
                lSurnameValidation.ForeColor = Color.Green;
            }

            surnameCorrect = true;
        }

        private void EmailValidation(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");

            if (IsEmpty(tbEmail.Text) || !reg.IsMatch(tbEmail.Text))
            {
                lEmailWalidation.ForeColor = Color.Red;
                emailCorrect = false;
                return;
            }
            else
            {
                lEmailWalidation.ForeColor = Color.Green;
            }

            emailCorrect = true;
        }

        private void LoginValidation(object sender, EventArgs e)
        {
            if (IsEmpty(tbLogin.Text) || HasSpecialSIgns(tbLogin.Text))
            {
                lLoginValidation.ForeColor = Color.Red;
                loginCorrect = false;
                return;
            }
            else
            {
                lLoginValidation.ForeColor = Color.Green;
            }

            loginCorrect = true;
        }

        private void PasswordValidation(object sender, EventArgs e)
        {
            if (IsEmpty(tbPassword.Text))
            {
                lPasswordValidation.ForeColor = Color.Red;
                passwordCorrect = false;
                return;
            }
            else
            {
                lPasswordValidation.ForeColor = Color.Green;
            }

            
            passwordCorrect = true;
        }

        #endregion Validation

        #region Methods
        public static Register RegisterInstance
        {
            get
            {
                if (registerInstance == null)
                    registerInstance = new Register();
                return registerInstance;
            }
        }
        public void ShowMessage(bool success, string message)
        {
            MessageBox.Show(message, success ? "Message" : "Error", MessageBoxButtons.OK);
        }
        private void bCreateAccount_Click(object sender, EventArgs e)
		{
            if (nameCorrect && surnameCorrect && emailCorrect && loginCorrect && passwordCorrect)
            {
                try
                {
                    CreateAccountEvent(new User(null, tbName.Text, tbSurname.Text, tbLogin.Text, tbPassword.Text, tbEmail.Text));

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
            else
            {
                if(String.IsNullOrEmpty(tbName.Text.Trim()))
                    lNameValidation.ForeColor = Color.Red;
                if (String.IsNullOrEmpty(tbSurname.Text.Trim()))
                    lSurnameValidation.ForeColor = Color.Red;
                if (String.IsNullOrEmpty(tbEmail.Text.Trim()))
                    lEmailWalidation.ForeColor = Color.Red;
                if (String.IsNullOrEmpty(tbLogin.Text.Trim()))
                    lLoginValidation.ForeColor = Color.Red;
                if (String.IsNullOrEmpty(tbPassword.Text.Trim()))
                    lPasswordValidation.ForeColor = Color.Red;

                ShowMessage(false, "You must correctly innput all data. Check your input with red dots.");
            }

            
        }

        public void ClearTextBoxes()
        {
            tbName.Text = string.Empty;
            tbSurname.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbLogin.Text = string.Empty;
            tbPassword.Text = string.Empty;
        }
        #endregion Methods


    }
}
