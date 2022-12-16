/*基于捂脸猫FaceCat框架 v1.0
上海卷卷猫信息技术有限公司
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ctpstrategy
{
    public class CTPDLL {
        /// <summary>
        /// 卖平：多单平仓
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int askClose(int ctpID, int requestID, String code, String exchangeID, double price, int qty, char timeCondition, String orderRef);
        /// <summary>
        /// 卖平今仓：平今天的开仓的空单
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int askCloseToday(int ctpID, int requestID, String code, String exchangeID, double price, int qty, char timeCondition, String orderRef);
        /// <summary>
        /// 卖开：空单开仓
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int askOpen(int ctpID, int requestID, String code, String exchangeID, double price, int qty, char timeCondition, String orderRef);
        /// <summary>
        /// 买平：空单平仓
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bidClose(int ctpID, int requestID, String code, String exchangeID, double price, int qty, char timeCondition, String orderRef);
        /// <summary>
        ///  买平今仓：平今天的开仓的空单
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bidCloseToday(int ctpID, int requestID, String code, String exchangeID, double price, int qty, char timeCondition, String orderRef);
        /// <summary>
        /// 买开：多单开仓
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bidOpen(int ctpID, int requestID, String code, String exchangeID, double price, int qty, char timeCondition, String orderRef);
        /// <summary>
        /// 撤单
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cancelOrder(int ctpID, int requestID, String exchangeID, String orderSysID, String orderRef);
        /// <summary>
        ///  和交易所建立连接
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int create();
        /// <summary>
        /// 生成ctp请求编号
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int generateReqID(int ctpID);
        /// <summary>
        /// 是否有新的数据
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int hasNewDatas(int ctpID);
        /// <summary>
        /// 获取资金账户信息
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getAccountData(int ctpID, IntPtr data);
        public static int getAccountData(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getAccountData(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 获取经纪公司ID
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getBrokerID(int ctpID, IntPtr data);
        public static int getBrokerID(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getBrokerID(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 获取手续费率
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getCommissionRate(int ctpID, String code, IntPtr data);
        public static int getCommissionRate(int ctpID, String code, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getCommissionRate(ctpID, code, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 获取深度市场行情
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getDepthMarketData(int ctpID, IntPtr data);
        public static int getDepthMarketData(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getDepthMarketData(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 获取合约数据
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getInstrumentsData(int ctpID, IntPtr data);
        public static int getInstrumentsData(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getInstrumentsData(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 获取投资者ID
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getInvestorID(int ctpID, IntPtr data);
        public static int getInvestorID(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getInvestorID(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 获取保证金率
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getMarginRate(int ctpID, String code, IntPtr data);
        public static int getMarginRate(int ctpID, String code, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getMarginRate(ctpID, code, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 获取投资者持仓数据
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getPositionData(int ctpID, IntPtr data);
        public static int getPositionData(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getPositionData(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        ///  获取投资者持仓明细数据
        /// </summary>
        /// <param name="ctpID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getPositionDetailData(int ctpID, IntPtr data);
        public static int getPositionDetailData(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getPositionDetailData(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 获取最新的委托回报（上一条）
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getOrderInfo(int ctpID, IntPtr data);
        public static int getOrderInfo(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getOrderInfo(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 获取所有的最新委托回报（今天的所有委托）
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getOrderInfos(int ctpID, IntPtr data);
        public static int getOrderInfos(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getOrderInfos(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }

        /// <summary>
        /// 获取sessionID
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getSessionID(int ctpID);

        /// <summary>
        /// 获取结算单信息
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getSettlementInfo(int ctpID, IntPtr data);
        public static int getSettlementInfo(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getSettlementInfo(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }

        /// <summary>
        /// 获取最新成交记录（上一条） 
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getTradeRecord(int ctpID, IntPtr data);
        public static int getTradeRecord(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getTradeRecord(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 获取最新交易记录（今天的所有交易）
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getTradeRecords(int ctpID, IntPtr data);
        public static int getTradeRecords(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getTradeRecords(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 获取交易日期
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getTradingDate(int ctpID, IntPtr data);
        public static int getTradingDate(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getTradingDate(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 获取交易时间
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getTradingTime(int ctpID, IntPtr data);
        public static int getTradingTime(int ctpID, StringBuilder data) {
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(1024 * 1024);
            int state = getTradingTime(ctpID, bufferIntPtr);
            String sbResult = Marshal.PtrToStringAnsi(bufferIntPtr);
            data.Append(sbResult);
            Marshal.FreeHGlobal(bufferIntPtr);
            return state;
        }
        /// <summary>
        /// 当天是否已经结算
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isClearanced(int ctpID);
        /// <summary>
        /// 是否是结算时间
        /// </summary>
        /// <param name="ctpID"></param>
        /// <returns></returns>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isClearanceTime(int ctpID);
        /// <summary>
        /// 数据是否准备好
        /// </summary>
        /// <param name="ctpID"></param>
        /// <returns></returns>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isDataOk(int ctpID);
        /// <summary>
        /// 行情数据服务器是否已经登录
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isMdLogined(int ctpID);
        /// <summary>
        /// 交易是否已经登录
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isTdLogined(int ctpID);
        /// <summary>
        /// 是否是交易时间
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isTradingTime(int ctpID);
        /// <summary>
        /// 是否是精确交易时间(去掉集合竞价时间和休息时间)
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isTradingTimeExact(int ctpID, String code);
        /// <summary>
        /// 请求手续费率
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int reqCommissionRate(int ctpID, String code, int requestID);
        /// <summary>
        /// 请求确认结算信息
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int reqQrySettlementInfoConfirm(int ctpID, int requestID);
        /// <summary>
        /// 查询结算信息
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int reqQrySettlementInfo(int ctpID, int requestID, String tradingDay);
        /// <summary>
        /// 请求保证金率
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int reqMarginRate(int ctpID, String code, int requestID);
        /// <summary>
        /// 启动创建的连接(在create后执行)
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int start(int ctpID, int requestID, String appID, String authCode, String mdServer, String tdServer, String brokerID, String investorID, String password);
        /// <summary>
        /// 订阅多个合约的行情数据
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int subMarketDatas(int ctpID, int requestID, String codes);
        /// <summary>
        /// 取消订阅多个合约的行情数据
        /// </summary>
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int unSubMarketDatas(int ctpID, int requestID, String codes);
    }
}
