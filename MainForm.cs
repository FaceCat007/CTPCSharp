/*基于捂脸猫FaceCat框架 v1.0
上海卷卷猫信息技术有限公司
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FaceCat;
using System.IO;
using System.Threading;
namespace ctpstrategy
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : FCForm {
        /// <summary>
        ///  创建图形控件
        /// </summary>
        public MainForm() {
            InitializeComponent();
            m_xmlEx = new MainFrame();
            m_xml = m_xmlEx;
            m_xml.createNative();
            m_native = m_xml.getNative();
            m_native.setResourcePath(Application.StartupPath + "\\config\\ctpcs");
            m_native.setPaint(new GdiPlusPaintEx());
            m_host = new WinHostEx();
            m_host.setNative(m_native);
            m_native.setHost(m_host);
            m_host = m_native.getHost() as WinHostEx;
            m_host.setHWnd(Handle);
            m_native.setAllowScaleSize(true);
            m_native.setSize(new FCSize(ClientSize.Width, ClientSize.Height));
            String zoomFactor = MyColor.getZoomFactor();
            if (zoomFactor != "nil")
            {
                double scaleFactor = FCTran.strToDouble(zoomFactor);
                m_xmlEx.setScaleFactor(scaleFactor);
            }
            m_native.setScaleSize(new FCSize(ClientSize.Width, ClientSize.Height));
            m_xml.loadFile(Application.StartupPath + "\\config\\ctpcs\\MainFrame2.xml", null);
            m_xmlEx.resetScaleSize(m_native.getSize());
            Invalidate();
            //字符串+
            m_native.update();
            m_native.invalidate();
        }

        private MainFrame m_xmlEx;

        /// <summary>
        /// 获取或设置XML主框架
        /// </summary>
        public MainFrame XmlEx {
            get { return m_xmlEx; }
            set { m_xmlEx = value; }
        }

        /// <summary>
        /// 鼠标滚动方法
        /// </summary>
        /// <param name="e">参数</param>
        protected override void OnMouseWheel(MouseEventArgs e) {
            base.OnMouseWheel(e);
            if (m_host.isKeyPress(0x11)) {
                double scaleFactor = m_xmlEx.getScaleFactor();
                if (e.Delta > 0) {
                    if (scaleFactor > 0.2) {
                        scaleFactor -= 0.1;
                    }
                }
                else if (e.Delta < 0) {
                    if (scaleFactor < 10) {
                        scaleFactor += 0.1;
                    }
                }
                m_xmlEx.setScaleFactor(scaleFactor);
                m_xmlEx.resetScaleSize(getClientSize());
                Invalidate();
            }
        }

        /// <summary>
        /// 尺寸改变方法
        /// </summary>
        /// <param name="e">参数</param>
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            if (m_host != null) {
                if (m_xmlEx != null)
                {
                    m_xmlEx.resetScaleSize(getClientSize());
                }
                Invalidate();
            }
        }

        /// <summary>
        /// 消息监听
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m) {
            if (m_host != null) {
                if (m_host.onMessage(ref m) > 0) {
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}