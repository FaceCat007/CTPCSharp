/*基于捂脸猫FaceCat框架 v1.0
上海卷卷猫信息技术有限公司
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FaceCat;
using System.Text;

namespace ctpstrategy
{
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PreViewForm preViewForm = new PreViewForm();
            preViewForm.loadFile("", false, new FCSize(1000, 800));
            preViewForm.Text = "facecat_ctpcs";
            MainForm mainForm = new MainForm();
            preViewForm.addForm2(mainForm);
            preViewForm.m_xml.findView("divWindow").setPadding(new FCPadding(2));
            preViewForm.m_xml.getNative().update();
            preViewForm.m_xml.getNative().invalidate();
            Application.Run(preViewForm);
        }
    }

    public class AppHost
    {
        /// <summary>
        /// 启动程序
        /// </summary>
        public static PreViewForm run(string cmd)
        {
            PreViewForm preViewForm = FaceCatAPI.createPreViewForm();
            preViewForm.setIsMerge(true);
            preViewForm.loadFile("", false, new FCSize(1000, 800));
            preViewForm.Text = "CTPfacecat_ctpcs";
            preViewForm.setUrl("https://www.jjmfc.com/app_ctpcs.html");
            preViewForm.setIconViewName("app_CTPCS");
            MainForm mainForm = new MainForm();
            preViewForm.addForm(mainForm);
            preViewForm.m_xml.findView("divWindow").setPadding(new FCPadding(2));
            preViewForm.Show();
            return preViewForm;
        }
    }
}