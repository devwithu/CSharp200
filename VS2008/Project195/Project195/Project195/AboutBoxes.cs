using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace Project195
{
    partial class AboutBoxes : Form
    {
        public AboutBoxes()
        {
            InitializeComponent();

            //  어셈블리 정보에서 제품 정보를 표시하기 위해 AboutBox를 초기화합니다.
            //  다음 방법 중 하나를 사용하여 응용 프로그램의 어셈블리 정보 설정을 변경합니다.
            //  - [프로젝트]->[속성]->[응용 프로그램]->[어셈블리 정보]
            //  - AssemblyInfo.cs
            this.Text = String.Format("{0} 정보", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("버전 {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region 어셈블리 특성 접근자

        public string AssemblyTitle
        {
            get
            {
                // 이 어셈블리에 있는 모든 Title 특성을 가져옵니다.
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // 하나 이상의 Title 특성이 있는 경우
                if (attributes.Length > 0)
                {
                    // 첫 번째 항목을 선택합니다.
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // 빈 문자열이 아닌 경우 항목을 반환합니다.
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // Title 특성이 없거나 Title 특성이 빈 문자열인 경우 .exe 이름을 반환합니다.
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // 이 어셈블리에 있는 모든 Description 특성을 가져옵니다.
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // Description 특성이 없는 경우 빈 문자열을 반환합니다.
                if (attributes.Length == 0)
                    return "";
                // Description 특성이 있는 경우 해당 값을 반환합니다.
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                // 이 어셈블리에 있는 모든 Product 특성을 가져옵니다.
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // Product 특성이 없으면 빈 문자열을 반환합니다.
                if (attributes.Length == 0)
                    return "";
                // Product 특성이 있으면 해당 값을 반환합니다.
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // 이 어셈블리에 있는 모든 Copyright 특성을 가져옵니다.
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // Copyright 특성이 없으면 빈 문자열을 반환합니다.
                if (attributes.Length == 0)
                    return "";
                // Copyright 특성이 있으면 해당 값을 반환합니다.
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                // 이 어셈블리에 있는 모든 Company 특성을 가져옵니다.
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // Company 특성이 없으면 빈 문자열을 반환합니다.
                if (attributes.Length == 0)
                    return "";
                // Company 특성이 있으면 해당 값을 반환합니다.
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
