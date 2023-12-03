using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KR_Interface
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = "Курсовой проект Ремизов А-05-20";
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = "НИУ МЭИ";
            this.textBoxDescription.Text = "БД должна поддерживать выполнение следующих функций:\r\n    • учет сведений об аспирантах   ВУЗа различных категорий (очные, заочные, соискатели, докторанты);\r\n    • формирование списка аспирантов по кафедрам и по научным руководителям;\r\n    • изменение данных об аспирантах  (научный руководитель, научное направление, \tперсональные данные, дипломы, награды);\r\n    • учет научных публикаций аспирантов (у одной публикации только один автор);\r\n    • учет научных публикаций научного руководителя аспиранта;\r\n    • учет работы научных советов.\r\n    •  составление отчетов о состоявшихся защитах (по различным категориям, научным направлениям, кафедрам, научным руководителям и т.п.)\r\nУточнения предметной области:\r\n•\tПо одному направлению может быть несколько научных советов, один научный совет может принимать защиты по нескольким направлениям\r\n•\tАспирант может обучаться только на одном направлении, на одном направлении может обучаться несколько аспирантов\r\n•\tУ одного аспиранта может быть только одна защита (успешная или неуспешная), одну защиту может выполнять только один аспирант.\r\n•\tУ публикации может быть только 1 автор.\r\n•\tОдин совет может принимать много защит, у одной защиты может быть только один совет.\r\n•\tУ аспиранта может быть только один научный руководитель, у научного руководителя может быть несколько аспирантов.\r\n•\tОдин преподаватель может преподавать на нескольких направлениях, на одном направлении могут преподавать несколько преподавателей\r\n";
            
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
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
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
