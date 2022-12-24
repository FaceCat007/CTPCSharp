/*基于捂脸猫FaceCat框架 v1.0
上海卷卷猫信息技术有限公司
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ctpstrategy
{
    /// <summary>
    /// CTP交易API
    /// </summary>
    public class CTPDLL {
        /*
	    卖平：多单平仓
	    ctpID 唯一ID
	    requestID 请求ID
	    code 代码
	    exchangeID 交易所ID
	    price 价格
	    qty 数量
	    timeCondition 有效期 
	    orderRef 附加信息 
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int askClose(int ctpID, int requestID, String code, String exchangeID, double price, int qty, char timeCondition, String orderRef);
        /*
	    卖平今仓：平今天的开仓的空单
	    ctpID 唯一ID
	    requestID 请求ID
	    code 代码
	    exchangeID 交易所ID
	    price 价格
	    qty 数量
	    timeCondition 有效期
	    orderRef 附加信息
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int askCloseToday(int ctpID, int requestID, String code, String exchangeID, double price, int qty, char timeCondition, String orderRef);
        /*
	    卖开：空单开仓
	    ctpID 唯一ID
	    requestID 请求ID
	    code 代码
	    exchangeID 交易所ID
	    price 价格
	    qty 数量
	    timeCondition 有效期
	    orderRef 附加信息
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int askOpen(int ctpID, int requestID, String code, String exchangeID, double price, int qty, char timeCondition, String orderRef);
        /*
	    买平：空单平仓
	    ctpID 唯一ID
	    requestID 请求ID
	    code 代码
	    exchangeID 交易所ID
	    price 价格
	    qty 数量
	    timeCondition 有效期
	    orderRef 附加信息
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bidClose(int ctpID, int requestID, String code, String exchangeID, double price, int qty, char timeCondition, String orderRef);
        /*
	    买平今仓：平今天的开仓的空单
	    ctpID 唯一ID
	    requestID 请求ID
	    code 代码
	    exchangeID 交易所ID
	    price 价格
	    qty 数量
	    timeCondition 有效期
	    orderRef 附加信息
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bidCloseToday(int ctpID, int requestID, String code, String exchangeID, double price, int qty, char timeCondition, String orderRef);
        /*
	    买开：多单开仓
	    ctpID 唯一ID
	    requestID 请求ID
	    code 代码
	    exchangeID 交易所ID
	    price 价格
	    qty 数量
	    timeCondition 有效期
	    orderRef 附加信息
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bidOpen(int ctpID, int requestID, String code, String exchangeID, double price, int qty, char timeCondition, String orderRef);
        /*
	    撤单
	    ctpID 唯一ID
	    requestID 请求ID
	    exchangeID 交易所ID
	    orderSysID 委托编号
	    orderRef 附加信息
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cancelOrder(int ctpID, int requestID, String exchangeID, String orderSysID, String orderRef);
        /*
	    创建交易
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int create();
        /*
	    生成ctp请求编号
	    ctpID 唯一ID
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int generateReqID(int ctpID);
        /*
	    是否有最新数据
	    ctpID 唯一ID
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int hasNewDatas(int ctpID);
        /*
	    获取资金账户信息
	    ctpID 唯一ID
	    data 返回数据
	    */
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
        /*
	    获取经纪公司ID
	    ctpID 唯一ID
	    data 返回数据
	    */
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
        /*
	    获取手续费率
	    ctpID 唯一ID
	    code 代码
	    data 返回数据
	    */
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
        /*
	    获取深度市场行情
	    ctpID 唯一ID
	    data 返回数据
	    */
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
        /*
	    获取合约数据
	    ctpID 唯一ID
	    data 返回数据
	    */
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
        /*
	    获取投资者ID
	    ctpID 唯一ID
	    data 返回数据
	    */
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
        /*
	    获取保证金率
	    ctpID 唯一ID
	    code 代码
	    data 返回数据
	    */
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
        /*
	    获取投资者持仓数据
	    ctpID 唯一ID
	    data 返回数据
	    */
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
        /*
	    获取投资者持仓明细数据
	    ctpID 唯一ID
	    data 返回数据
	    */
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
        /*
	    获取最新的委托回报（上一条)
	    ctpID 唯一ID
	    data 返回数据
	    */
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
        /*
	    获取所有的最新委托回报（今天的所有委托）
	    ctpID 唯一ID
	    data 返回数据
	    */
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

        /*
	    获取sessionID
	    ctpID 唯一ID
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getSessionID(int ctpID);

        /*
	    获取结算单信息
	    ctpID 唯一ID
	    data 返回数据
	    */
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

        /*
	    获取最新成交记录（上一条）
	    ctpID 唯一ID
	    data 返回数据
	    */
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
        /*
	    获取最新交易记录（今天的所有交易）
	    ctpID 唯一ID
	    data 返回数据
	    */
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
        /* 
	    获取交易日期
	    ctpID 唯一ID
	    data 返回数据
	    */
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
        /*
	    获取交易时间
	    ctpID 唯一ID
	    data 返回数据
	    */
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
        /*
	    当天是否已经结算
	    ctpID 唯一ID
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isClearanced(int ctpID);
        /*
	    是否是结算时间
	    ctpID 唯一ID
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isClearanceTime(int ctpID);
        /*
	    数据是否ok
	    ctpID 唯一ID
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isDataOk(int ctpID);
        /*
	    行情数据服务器是否已经登录
	    ctpID 唯一ID
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isMdLogined(int ctpID);
        /*
	    交易是否已经登录
	    ctpID 唯一ID
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isTdLogined(int ctpID);
        /*
	    是否是交易时间
	    ctpID 唯一ID
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isTradingTime(int ctpID);
        /*
	    是否是精确交易时间(去掉集合竞价时间和休息时间)
	    ctpID 唯一ID
	    code 代码
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int isTradingTimeExact(int ctpID, String code);
        /*
	    请求手续费率
	    ctpID 唯一ID
	    code 代码
	    requestID 请求ID
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int reqCommissionRate(int ctpID, String code, int requestID);
        /*
	    请求确认结算信息
	    ctpID 唯一ID
	    requestID 请求ID
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int reqQrySettlementInfoConfirm(int ctpID, int requestID);
        /*
	    请求结算信息
	    ctpID 唯一ID
	    requestID 请求ID
	    tradingDate 交易日
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int reqQrySettlementInfo(int ctpID, int requestID, String tradingDay);
        /*
	    请求保证金率
	    ctpID 唯一ID
	    code 代码
	    requestID 请求ID
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int reqMarginRate(int ctpID, String code, int requestID);
        /*
	    启动创建的连接(在create后执行)
	    ctpID 唯一ID
	    requestID 请求ID
	    appID APPID
	    authCode 用户ID
	    mdServer 行情地址
	    tdServer 交易地址
	    brokerID 机构号
	    investorID 投资者账号
	    password 密码
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int start(int ctpID, int requestID, String appID, String authCode, String mdServer, String tdServer, String brokerID, String investorID, String password);
        /*
	    订阅多个合约的行情数据
	    ctpID 唯一ID
	    requestID 请求ID
	    codes 代码列表
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int subMarketDatas(int ctpID, int requestID, String codes);
        /*
	    取消订阅多个合约的行情数据
	    ctpID 唯一ID
	    requestID 请求ID
	    codes 代码列表
	    */
        [DllImport("iCTP.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int unSubMarketDatas(int ctpID, int requestID, String codes);
    }
}
